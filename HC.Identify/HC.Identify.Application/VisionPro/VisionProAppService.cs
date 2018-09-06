using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application.Helpers;
using HC.Identify.Dto.VisionPro;
using System.IO;
using System.Windows.Forms;

namespace HC.Identify.Application.VisionPro
{
    public class VisionProAppService : IdentifyAppServiceBase, IVisionProAppService
    {
        CogToolBlock _cogToolBlock;
        public ICogImage _icogColorImage;
        CogRecordDisplay _cogRecordDisplay;
        string _appPath;
        public List<CsvSpecification> _csvSpecList = new List<CsvSpecification>();
        CogImageFileTool _cogImageFile = new CogImageFileTool(); //图像处理工具

        public VisionProAppService(CogToolBlock cogToolBlock, ICogImage icogColorImage, CogRecordDisplay cogRecordDisplay)
        {
            _cogToolBlock = cogToolBlock;
            _icogColorImage = icogColorImage;
            _cogRecordDisplay = cogRecordDisplay;
            _appPath = System.Windows.Forms.Application.StartupPath;
            var csvDataPath = _appPath + "\\Data\\Data.csv";
            if (!File.Exists(csvDataPath))
            {
                MessageBox.Show("数据文件不存在或路径错误！");
                return;
            }
            VisionProDataAppService.Instance.CsvDataPath = csvDataPath;
            _csvSpecList = VisionProDataAppService.Instance.GetCsvSpecificationList();
        }

        public CogFrameGrabbers GetFrames()
        {
            CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
            return mFrameGrabbers;
        }

        public CsvSpecification GetMatchSpecification(out ArrayList cogResultArray)
        {
            var tbvals = GetToolBlockValues();
            cogResultArray = tbvals;
            if (tbvals == null)
            {
                return null;
            }
            if (tbvals.Count == 0)
            {
                CommHelper.WriteLog(_appPath, "GetMatchSpecification->GetToolBlockValues", "没有读取到值");
                return null;
            }
            try
            {
                int totalType = _csvSpecList.Count();//模板数据
                                                     //相关矩阵计算
                double[] dMatchScore = new double[totalType];   //50种型号的匹配分数
                                                                //  int iPointsNum = this.Inputs.iRow * this.Inputs.iCol;
                double dMaxScore = -9999;
                CsvSpecification maxSpec = new CsvSpecification();
                int i = 0;
                foreach (var item in _csvSpecList)
                {
                    double dSumXY = 0;
                    double dSumX = 0;
                    double dSumY = 0;
                    double dSumXBy2 = 0;
                    double dSumYBy2 = 0;
                    int iPointsNum = item.Values.Length;
                    int k = 0;
                    foreach (var readVal in item.Values)
                    {
                        dSumXY += (double)tbvals[k] * readVal;
                        dSumX += (double)tbvals[k];
                        dSumY += readVal;
                        dSumXBy2 += (double)tbvals[k] * (double)tbvals[k];
                        dSumYBy2 += readVal * readVal;
                        k++;
                    }
                    dMatchScore[i] = (iPointsNum * dSumXY - dSumX * dSumY) / (Math.Sqrt(iPointsNum * dSumXBy2 - dSumX * dSumX) * Math.Sqrt(iPointsNum * dSumYBy2 - dSumY * dSumY));
                    // MessageBox.Show(dMatchScore[l].ToString()+"   "+ReadType[l]);
                    if (dMatchScore[i] > dMaxScore)
                    {
                        dMaxScore = dMatchScore[i];
                        maxSpec = item;
                    }
                    i++;
                }
                if (true)//记录日志结果
                {
                    VisionProDataAppService.Instance.SaveResultLog(_appPath + "\\ResultLog", maxSpec.Specification, dMaxScore);
                }
                //配置结果值
                if (dMaxScore > 0.81)
                {
                    return maxSpec;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }
           
        }

        public ArrayList GetToolBlockValues()
        {
            _cogToolBlock.Inputs["InputImage"].Value = _icogColorImage;
            _cogToolBlock.Inputs["iRow"].Value = 4;
            _cogToolBlock.Inputs["iCol"].Value = 12;
            _cogToolBlock.Inputs["bForceLeft"].Value = false;    //左边线错误
            _cogToolBlock.Inputs["bForceRight"].Value = false;   //右边线错误
            _cogToolBlock.Inputs["bShowGraphic"].Value = false;  //显示图形
            _cogToolBlock.Run();

            ICogRecords subRecords = _cogToolBlock.CreateLastRunRecord().SubRecords;
            //_cogRecordDisplay.Record = subRecords["CogIPOneImageTool1.OutputImage"];//旧算法
            _cogRecordDisplay.Record = subRecords["CogImageConvertTool1.OutputImage"];//启用新算法解开注释
            _cogRecordDisplay.Fit(true);
            //return (ArrayList)_cogToolBlock.Outputs["SubRectValues"].Value;
            var cogResultArray = (ArrayList)_cogToolBlock.Outputs["SubRectValues"].Value;
            if (cogResultArray.Count == 0)
            {
                //MessageBox.Show("ToolBlock结果为空！");
                _cogRecordDisplay.Image = _icogColorImage;
                return null;
            }
            return cogResultArray;
        }

        public void SaveImage()
        {
            string path = _appPath + "\\SaveImage\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
             path = path + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".BMP";
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}
            _cogImageFile.Operator.Open(path, CogImageFileModeConstants.Write);
            _cogImageFile.InputImage = _icogColorImage;
            _cogImageFile.Run();
        }
    }
}
