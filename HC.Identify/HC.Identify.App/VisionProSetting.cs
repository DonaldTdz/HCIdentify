using HC.Identify.Application.Identify;
using HC.Identify.Application.VisionPro;
using HC.Identify.Dto.Identify;
using HC.Identify.Dto.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HC.Identify.App.Main;
using static HC.Identify.Core.Identify.IdentifyEnum;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.FGGigE;
using Cognex.VisionPro.Exceptions;
using System.Text.RegularExpressions;

namespace HC.Identify.App
{
    public partial class VisionProSetting : FormMainChildren
    {
        bool isCameraOnline;       //是否连接相机
        string currentrDirectory;//当前根文件夹
        #region 康耐视

        ICogAcqFifo icogAcqFifo;  //获取数据
        ICogImage icogColorImage; //图像控件
        CogToolBlock cogToolBlock = new CogToolBlock();       //图像连接工具
        CogToolBlock cogToolBlockCopy = new CogToolBlock();
        CogImageFileTool cogImageFile = new CogImageFileTool(); //图像处理工具
        private VisionProAppService visionProAppService;
        //FileSystemInfo[] fileInfos;
        //int imgIndex;
        //ArrayList cogResultArray = new ArrayList();
        //int totalImgCount = 0;
        #endregion

        #region 数据存储处理

        List<CsvSpecification> csvSpecList = new List<CsvSpecification>();      //已注册产品数据

        #endregion

        //定义全局主窗口 刷新状态
        public Main MainForm;
        private CameraSettingAppService cameraSettingAppService;
        private CameraSettingShowDto cameraSettingShowDto;
        private SystemConfigAppService systemConfigAppService;
        public VisionProSetting()
        {
            InitializeComponent();
            cameraSettingAppService = new CameraSettingAppService();
            GetCameraSetting();
            //cameraSettingShowDto = new CameraSettingShowDto();
            InitImage();
            
        }

        public VisionProSetting(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            cameraSettingAppService = new CameraSettingAppService();
            GetCameraSetting();
            //cameraSettingShowDto = new CameraSettingShowDto();
            InitImage();
            systemConfigAppService = new SystemConfigAppService();
            GetSystemConfig();
        }
        Dictionary<ConfigEnum, SystemConfigDto> SystemConfig { get; set; }
        private void GetSystemConfig()
        {
            SystemConfig = systemConfigAppService.GetAllConfig().ToDictionary(k => k.Code, v => v);
        }
        /// <summary>
        /// 初始化图片模板集
        /// </summary>
        private void InitImage()
        {
            imgIndex = 0;
            var imgPath = txtImgPath.Text;
            if (!string.IsNullOrEmpty(imgPath))
            {
                var imgDir = new DirectoryInfo(imgPath);
                totalImgCount = imgDir.GetFiles().Length;
                fileInfos = imgDir.GetFileSystemInfos();
            }
            else
            {
                return; //如果为空就返回
            }
            if (fileInfos.Length == 0)
            {
                return;
            }
            if (fileInfos[imgIndex].Extension == ".bmp" || fileInfos[imgIndex].Extension == ".BMP" || fileInfos[imgIndex].Extension == ".jpg" ||
              fileInfos[imgIndex].Extension == ".JPG" || fileInfos[imgIndex].Extension == ".tif" || fileInfos[imgIndex].Extension == ".TIF")
            {
                cogImageFile.Operator.Open(fileInfos[imgIndex].FullName, CogImageFileModeConstants.Read);
                cogImageFile.Run();
                icogColorImage = cogImageFile.OutputImage;
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit();
            }
        }
        private void VisionProSetting_Load(object sender, EventArgs e)
        {
            //连接相机
            CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
            if (mFrameGrabbers.Count == 0)
            {
                isCameraOnline = false;
                btnLiveDisplay.Enabled = false; //禁用连续取像
                chkCamTrigOn.Enabled = false;   //禁用相机外部启用模式

                MessageBox.Show("无相机连接，运行离线模式");
            }
            else//相机模式运行
            {
                isCameraOnline = true;
                //获取第一个相机图片
                icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                // icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Bayer Color)", CogAcqFifoPixelFormatConstants.Format3Plane, 0, true);//Format3Plane
                //添加获取完成处理事件
                icogAcqFifo.Complete += new CogCompleteEventHandler(CompleteAcquire);
                int numReadyVal;   //读取值
                int numPendingVal; //等待值
                int iNum = icogAcqFifo.StartAcquire(); //开始获取
                //获取图片
                icogColorImage = icogAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
                //显示图片
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit(false);
                //icogAcqFifo.OwnedExposureParams.Exposure = 1;
                icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);

            }
            //ConnectionCamera();
            currentrDirectory = Directory.GetCurrentDirectory();
            cogToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(currentrDirectory + "\\TB_Set.Vpp");
            var csvDataPath = currentrDirectory + "\\Data\\Data.csv";
            if (!File.Exists(csvDataPath))
            {
                MessageBox.Show("数据文件不存在或路径错误！");
                return;
            }
            VisionProDataAppService.Instance.CsvDataPath = csvDataPath;
            csvSpecList = VisionProDataAppService.Instance.GetCsvSpecificationList();
            BindRegisteredSpec();
            visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay,double.Parse( SystemConfig[ConfigEnum.相机曝光度].Value));

        }

        private void VisionProSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (icogAcqFifo != null)
            {
                icogAcqFifo.Flush();
                icogAcqFifo.FrameGrabber.Disconnect(false);
            }
        }

        #region 连接相机

        private void ConnectionCamera()
        {
            CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
            if (mFrameGrabbers.Count == 0)
            {
                isCameraOnline = false;
                btnLiveDisplay.Enabled = false; //禁用连续取像
                chkCamTrigOn.Enabled = false;   //禁用相机外部启用模式

                MessageBox.Show("无相机连接，运行离线模式");
            }
            else//相机模式运行
            {
                isCameraOnline = true;
                //获取第一个相机图片
                icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                // icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Bayer Color)", CogAcqFifoPixelFormatConstants.Format3Plane, 0, true);//Format3Plane
                //添加获取完成处理事件
                icogAcqFifo.Complete += new CogCompleteEventHandler(CompleteAcquire);
                int numReadyVal;   //读取值
                int numPendingVal; //等待值
                int iNum = icogAcqFifo.StartAcquire(); //开始获取
                //获取图片
                icogColorImage = icogAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
                //显示图片
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit(false);
            }
        }

        private void CompleteAcquire(Object sender, CogCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(CompleteAcquire), new object[] { sender, e });
                return;
            }
            int numReadyVal;   //读取值
            int numPendingVal; //等待值
            bool busyVal;
            CogAcqInfo info = new CogAcqInfo();
            try
            {
                icogAcqFifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);
                if (numReadyVal > 0)
                {
                    icogColorImage = icogAcqFifo.CompleteAcquireEx(info);
                    cogRecordDisplay.Image = icogColorImage;
                    cogRecordDisplay.Fit(false);
                }
            }
            catch (CogException ce)
            {
                MessageBox.Show("The following error has occured\n" + ce.Message);
            }
            //自动存图
            if (chkAutoSaveImage.Checked)
            {
                AutoSaveImage();
            }

            //匹配计算
            RunCalculation();
        }

        #endregion

        #region 绑定已注册产品

        private void BindRegisteredSpec()
        {
            comboSpecBox.DataSource = csvSpecList.Select(c => c.Specification).Distinct().ToList();
        }

        #endregion

        #region 自动存图

        private void AutoSaveImage()
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\AutoSaveImage\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".BMP";
            cogImageFile.Operator.Open(path, CogImageFileModeConstants.Write);
            cogImageFile.InputImage = icogColorImage;
            cogImageFile.Run();
        }

        #endregion

        #region 匹配计算


        FileSystemInfo[] fileInfos;
        int imgIndex;
        ArrayList cogResultArray = new ArrayList();

        #region 原代码，目前改为调用VisionProAppService的公用方法
        private ArrayList ToolBlockRun()
        {
            cogToolBlock.Inputs["InputImage"].Value = icogColorImage;
            cogToolBlock.Inputs["iRow"].Value = 4;
            cogToolBlock.Inputs["iCol"].Value = 12;
            cogToolBlock.Inputs["bForceLeft"].Value = false;    //左边线错误
            cogToolBlock.Inputs["bForceRight"].Value = false;   //右边线错误
            cogToolBlock.Inputs["bShowGraphic"].Value = false;  //显示图形
            cogToolBlock.Run();

            ICogRecords SubRecords = cogToolBlock.CreateLastRunRecord().SubRecords;
            //cogRecordDisplay.Record = SubRecords["CogIPOneImageTool1.OutputImage"];
            //cogRecordDisplay.Record = SubRecords["CogImageConvertTool1.OutputImage"];//启用新算法解开注释第一次
            cogRecordDisplay.Record = SubRecords["CogFixtureTool3.OutputImage"];//启用新算法解开注释第二次
            cogRecordDisplay.Fit(true);
            cogResultArray = (ArrayList)cogToolBlock.Outputs["SubRectValues"].Value;
            if (cogResultArray.Count == 0)
            {
                //MessageBox.Show("ToolBlock结果为空！");
                cogRecordDisplay.Image = icogColorImage;
                return null;
            }
            if (!isCameraOnline)
            {
                txtCurrentImgFileName.Text = fileInfos[imgIndex].Name.Substring(0, (fileInfos[imgIndex].Name.Length - 4));  //当前图像文件名
                txtCurrentSpec.Text = fileInfos[imgIndex].Name.Substring(0, (fileInfos[imgIndex].Name.Length - 4));         //当前产品规格型号
            }
            return cogResultArray;
        }

        private string Calculation(ArrayList cogResultArray)
        {
            int totalType = csvSpecList.Count();
            //相关矩阵计算
            double[] dMatchScore = new double[totalType];   //50种型号的匹配分数
            //  int iPointsNum = this.Inputs.iRow * this.Inputs.iCol;
            double dMaxScore = -9999;
            string maxSpec = string.Empty;
            int i = 0;
            foreach (var item in csvSpecList)
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
                    dSumXY += (double)cogResultArray[k] * readVal;
                    dSumX += (double)cogResultArray[k];
                    dSumY += readVal;
                    dSumXBy2 += (double)cogResultArray[k] * (double)cogResultArray[k];
                    dSumYBy2 += readVal * readVal;
                    k++;
                }
                dMatchScore[i] = (iPointsNum * dSumXY - dSumX * dSumY) / (Math.Sqrt(iPointsNum * dSumXBy2 - dSumX * dSumX) * Math.Sqrt(iPointsNum * dSumYBy2 - dSumY * dSumY));
                // MessageBox.Show(dMatchScore[l].ToString()+"   "+ReadType[l]);
                if (dMatchScore[i] > dMaxScore)
                {
                    dMaxScore = dMatchScore[i];
                    maxSpec = item.Specification;
                }
                i++;
            }

            txtMatchSpec.Text = maxSpec;
            mMaxScore = dMaxScore;
            //配置结果值
            if (dMaxScore > 0.81)
            {
                lblResultDesc.Text = "OK";  //匹配成功
                lblResultDesc.ForeColor = Color.Green;
            }
            else
            {
                lblResultDesc.Text = "NG"; //匹配成功
                lblResultDesc.ForeColor = Color.Red;
            }
            return maxSpec;
        }
        #endregion

        double mMaxScore;

        private void RunCalculation()
        {
            DateTime befortime = DateTime.Now;//计算耗时
            //运行
            //var cogResultArray = ToolBlockRun();
            //计算
            //var spec = Calculation(cogResultArray);
            visionProAppService._icogColorImage = icogColorImage;
            if (icogColorImage != null)
            {
                double dMaxScore;
                var spec = visionProAppService.GetMatchSpecification(out cogResultArray, out dMaxScore);//获取匹配结果
                if (spec != null)
                {
                    txtMatchSpec.Text = spec.Specification;
                    mMaxScore = spec.dMaxScore;
                    lblResultDesc.Text = "OK";  //匹配成功
                    lblResultDesc.ForeColor = Color.Green;
                    if (chkAutoSaveData.Checked)
                    {
                        SaveData(spec.Specification);
                    }
                }
                else
                {
                    txtMatchSpec.Text = "";
                    lblResultDesc.Text = "NG"; //匹配成功
                    lblResultDesc.ForeColor = Color.Red;
                }
                txtPiPei.Text = dMaxScore.ToString();
                SetCurrentInageInfo();
                //计算用时
                DateTime aftertime = DateTime.Now;
                txtUseTime.Text = aftertime.Subtract(befortime).Milliseconds.ToString();//毫秒
            }
            else
            {
                MessageBox.Show("请选择图片！！！");
            }
           

        }

        #endregion

        #region 保存结果

        private void SaveData(string spec)
        {
            string logPath = System.Windows.Forms.Application.StartupPath + "\\ResultLog";
            VisionProDataAppService.Instance.SaveResultLog(logPath, spec, mMaxScore);
        }

        #endregion

        #region 工具设置

        bool isShowTool = false;

        private void btnToolSetting_Click(object sender, EventArgs e)
        {
            if (!isShowTool)
            {
                //关闭相机外部模式
                if (chkCamTrigOn.Checked)
                {

                    CreamOff();
                    chkCamTrigOn.Checked = false;//相机外部模式
                }
                //关闭连续取像
                if (cogRecordDisplay.LiveDisplayRunning)
                {
                    icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
                    cogRecordDisplay.StopLiveDisplay();
                    btnLiveDisplay.Text = "连续取像";
                }

                //开启工具设置
                isShowTool = true;
                btnToolSetting.Text = "关闭设置";
                cogToolBlockEditV2.Visible = true;
                if (isCameraOnline)
                {
                    int numReadyVal, numPendingVal;
                    int iNum = icogAcqFifo.StartAcquire();
                    icogColorImage = icogAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
                }
                cogToolBlock.Inputs["InputImage"].Value = icogColorImage;
                cogToolBlockCopy = (CogToolBlock)CogSerializer.DeepCopyObject(cogToolBlock);
                cogToolBlockEditV2.Subject = cogToolBlock;
            }
            else
            {
                DialogResult dialog = MessageBox.Show("保存修改吗？", "提示", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    CogSerializer.SaveObjectToFile(cogToolBlock, currentrDirectory + "\\TB_Set.Vpp");
                    cogToolBlockCopy = (CogToolBlock)CogSerializer.DeepCopyObject(cogToolBlock); ;
                }
                else
                {
                    cogToolBlock = (CogToolBlock)CogSerializer.DeepCopyObject(cogToolBlockCopy); ;
                }
                isShowTool = false;
                btnToolSetting.Text = "工具设置";
                cogToolBlockEditV2.Visible = false;
                cogToolBlockEditV2.Subject = null;
            }
        }

        #endregion

        #region 连续取像

        private void btnLiveDisplay_Click(object sender, EventArgs e)
        {
            if (cogRecordDisplay.LiveDisplayRunning)
            {
                icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);//相机曝光度
                cogRecordDisplay.StopLiveDisplay();
                btnLiveDisplay.Text = "连续取像";
            }
            else
            {
                //相机外部模式关闭
                icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
                cogRecordDisplay.StaticGraphics.Clear();
                cogRecordDisplay.Record = null;
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit(false);

                icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Manual;
                icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
                chkCamTrigOn.Checked = false;//相机外部模式
                cogRecordDisplay.StartLiveDisplay(icogAcqFifo);
                btnLiveDisplay.Text = "停止取像";
            }
        }

        #endregion

        #region 选择图片位置

        int totalImgCount = 0;

        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            var imgPath = string.Empty;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                imgPath = folder.SelectedPath;
                txtImgPath.Text = imgPath;
            }
            if (!string.IsNullOrEmpty(imgPath))
            {
                //读取第一张图
                imgIndex = 0;
                var imgDir = new DirectoryInfo(imgPath);
                totalImgCount = imgDir.GetFiles().Length;
                fileInfos = imgDir.GetFileSystemInfos();
                if (fileInfos[imgIndex].Extension == ".bmp" || fileInfos[imgIndex].Extension == ".BMP" || fileInfos[imgIndex].Extension == ".jpg" ||
                   fileInfos[imgIndex].Extension == ".JPG" || fileInfos[imgIndex].Extension == ".tif" || fileInfos[imgIndex].Extension == ".TIF")
                {
                    cogImageFile.Operator.Open(fileInfos[imgIndex].FullName, CogImageFileModeConstants.Read);
                    cogImageFile.Run();
                    icogColorImage = cogImageFile.OutputImage;
                    cogRecordDisplay.Image = icogColorImage;
                    cogRecordDisplay.Fit();
                }
                //ToolBlockRun();修改
                //visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay);
                visionProAppService._icogColorImage = icogColorImage;
                visionProAppService.GetToolBlockValues();
                SetCurrentInageInfo();

            }
        }

        #endregion

        #region 保存存储的图片

        private void btnSaveImgFileName_Click(object sender, EventArgs e)
        {
            if (icogColorImage == null)
            {
                MessageBox.Show("没有可供存储的图像！");
                return;
            }
            string strSaveImgPath = System.Windows.Forms.Application.StartupPath + "\\SaveImage\\" + txtImgFileName.Text + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".bmp";
            cogImageFile.Operator.Open(strSaveImgPath, CogImageFileModeConstants.Write);
            cogImageFile.InputImage = icogColorImage;
            cogImageFile.Run();
        }

        #endregion

        #region 重新运行

        private void btnReRun_Click(object sender, EventArgs e)
        {
            visionProAppService._icogColorImage = icogColorImage;
            if (icogColorImage != null)
            {
                visionProAppService.GetToolBlockValues();
                SetCurrentInageInfo();
            }
            else
            {
                MessageBox.Show("请选择图片！！！");
            }
           
        }

        #endregion

        #region 注册当前产品

        private void btnRegisterSpec_Click(object sender, EventArgs e)
        {
            //同时加入Read Value
            var spec = txtCurrentSpec.Text;
            if (spec == "")
            {
                MessageBox.Show("请先输入型号再保存数据");
                return;
            }
            if(!Regex.IsMatch(spec, @"^\d*$"))
            {
                MessageBox.Show("请先正确的型号再保存数据");
                return;
            }

            string strRowWrite = spec + ",";
            double[] newValues = new double[cogResultArray.Count];
            for (int i = 0; i < cogResultArray.Count; i++)
            {
                strRowWrite += string.Format("{0:###.###}", cogResultArray[i]) + ",";
                newValues[i] = (double)cogResultArray[i];
            }
            csvSpecList.Add(new CsvSpecification() { Specification = spec, Values = newValues });    //添加到已注册产品型号
            VisionProDataAppService.Instance.SaveToCsvRegistered(strRowWrite);  //保存到CSV文件
            BindRegisteredSpec();                               //重新绑定已注册产品
        }

        #endregion

        #region 运行或下一张

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (isCameraOnline)
            {
                int numReadyVal, numPendingVal;
                int iNum = icogAcqFifo.StartAcquire();
                icogColorImage = icogAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
            }
            else
            {
                if (chkBack.Checked)
                {
                    imgIndex--;
                    if (imgIndex < 0)
                    {
                        imgIndex = 0;
                    }
                }
                else
                {
                    imgIndex++;
                }
                if (imgIndex >= totalImgCount)
                {
                    imgIndex = 0;
                }
                if (fileInfos[imgIndex].Extension == ".bmp" || fileInfos[imgIndex].Extension == ".BMP" || fileInfos[imgIndex].Extension == ".jpg" ||
                  fileInfos[imgIndex].Extension == ".JPG" || fileInfos[imgIndex].Extension == ".tif" || fileInfos[imgIndex].Extension == ".TIF")
                {
                    cogImageFile.Operator.Open(fileInfos[imgIndex].FullName, CogImageFileModeConstants.Read);
                    cogImageFile.Run();
                    icogColorImage = cogImageFile.OutputImage;
                }
            }
            //ToolBlockRun(); //修改

            //visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay);
            visionProAppService._icogColorImage = icogColorImage;
            visionProAppService.GetToolBlockValues();
            SetCurrentInageInfo();


        }

        #endregion

        #region 匹配型号重新运行

        private void btnReMatchRun_Click(object sender, EventArgs e)
        {
            //更新模板数据（data）重新运行时可匹配新注册数据
            var csvDataPath = currentrDirectory + "\\Data\\Data.csv";
            if (!File.Exists(csvDataPath))
            {
                MessageBox.Show("数据文件不存在或路径错误！");
                return;
            }
            VisionProDataAppService.Instance.CsvDataPath = csvDataPath;
            csvSpecList = VisionProDataAppService.Instance.GetCsvSpecificationList();
            visionProAppService._csvSpecList = csvSpecList;

            //更新下拉框的数据;
            BindRegisteredSpec();
            RunCalculation();
        }

        #endregion

        #region 单次运行

        private void btnMatchRun_Click(object sender, EventArgs e)
        {
            if (isCameraOnline)
            {
                if (icogAcqFifo != null)
                {
                    int numReadyVal, numPendingVal;
                    int iNum = icogAcqFifo.StartAcquire();
                    icogColorImage = icogAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
                }
            }
            else
            {
                if (chkBack.Checked)
                {
                    imgIndex--;
                    if (imgIndex < 0)
                    {
                        imgIndex = 0;
                    }
                }
                else
                {
                    imgIndex++;
                }

                if (imgIndex >= totalImgCount)
                {
                    imgIndex = 0;
                }
                if (fileInfos[imgIndex].Extension == ".bmp" || fileInfos[imgIndex].Extension == ".BMP" || fileInfos[imgIndex].Extension == ".jpg" ||
                  fileInfos[imgIndex].Extension == ".JPG" || fileInfos[imgIndex].Extension == ".tif" || fileInfos[imgIndex].Extension == ".TIF")
                {
                    cogImageFile.Operator.Open(fileInfos[imgIndex].FullName, CogImageFileModeConstants.Read);
                    cogImageFile.Run();
                    icogColorImage = cogImageFile.OutputImage;
                }
                //visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay);
                //visionProAppService._icogColorImage = icogColorImage;

            }

            RunCalculation();
        }

        #endregion

        #region 仿真更改

        private void chkSimulation_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkSimulation.Checked)
            {
                isCameraOnline = false;
            }
            else
            {
                isCameraOnline = true;
            }
        }

        #endregion

        #region 相机外部模式

        private void chkCamTrigOn_CheckedChanged(object sender, EventArgs e)
        {
            bool bTrig = chkCamTrigOn.Checked;
            if (bTrig)
            {
                //关闭连续取像
                if (cogRecordDisplay.LiveDisplayRunning)
                {
                    icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
                    cogRecordDisplay.StopLiveDisplay();
                    btnLiveDisplay.Text = "连续取像";
                }
               
                CreamOn();
            }
            else
            {
                CreamOff();
            }
        }


        #endregion

        #region  恢复默认设置
        /// <summary>
        /// 恢复默认设置
        /// </summary>
        private void btn_Recover_Click(object sender, EventArgs e)
        {
            txtImgPath.Text = cameraSettingShowDto.PicPath;
            chkCamTrigOn.Checked = cameraSettingShowDto.CameraMode;
            chkSimulation.Checked = cameraSettingShowDto.Simulation;
            chkAutoSaveData.Checked = cameraSettingShowDto.SaveData;
            chkShowPic.Checked = cameraSettingShowDto.ShowPic;
            chkAutoSaveImage.Checked = cameraSettingShowDto.AutoSave;
        }
        public void GetCameraSetting()
        {
            var list = cameraSettingAppService.GetCameraSetting();
            cameraSettingShowDto = new CameraSettingShowDto();
            var pathDto = new CameraSettingCreateDto();
            foreach (var item in list)
            {
                if (item.Code == CameraEnum.图片位置)
                {
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        if (!Directory.Exists(item.Value))
                        {
                            item.Value = string.Empty;
                            cameraSettingAppService.UpdateSingleSetting(item);
                        }
                        else
                        {
                            cameraSettingShowDto.PicPath = item.Value;
                            txtImgPath.Text = item.Value;
                        }
                    }
                }
                if (item.Code == CameraEnum.相机外部模式)
                {
                    cameraSettingShowDto.CameraMode = bool.Parse(item.Value);
                    chkCamTrigOn.Checked = bool.Parse(item.Value);
                }
                if (item.Code == CameraEnum.仿真)
                {
                    cameraSettingShowDto.Simulation = bool.Parse(item.Value);
                    chkSimulation.Checked = bool.Parse(item.Value);
                }
                if (item.Code == CameraEnum.保存数据)
                {
                    cameraSettingShowDto.SaveData = bool.Parse(item.Value);
                    chkAutoSaveData.Checked = bool.Parse(item.Value);
                }
                if (item.Code == CameraEnum.显示图形)
                {
                    cameraSettingShowDto.ShowPic = bool.Parse(item.Value);
                    chkShowPic.Checked = bool.Parse(item.Value);

                }
                if (item.Code == CameraEnum.自动存图)
                {
                    cameraSettingShowDto.AutoSave = bool.Parse(item.Value);
                    chkAutoSaveImage.Checked = bool.Parse(item.Value);
                }
            }

        }
        #endregion

        #region 保存当前设置
        /// <summary>
        /// 保存当前设置
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            var list = new List<CameraSettingCreateDto>();

            var pathPic = new CameraSettingCreateDto();
            pathPic.Code = CameraEnum.图片位置;
            pathPic.Descs = CameraEnum.图片位置.ToString();
            pathPic.Value = txtImgPath.Text;
            list.Add(pathPic);

            var cameraMode = new CameraSettingCreateDto();
            cameraMode.Code = CameraEnum.相机外部模式;
            cameraMode.Descs = CameraEnum.相机外部模式.ToString();
            cameraMode.Value = chkCamTrigOn.Checked.ToString();
            list.Add(cameraMode);

            var simulation = new CameraSettingCreateDto();
            simulation.Code = CameraEnum.仿真;
            simulation.Descs = CameraEnum.仿真.ToString();
            simulation.Value = chkSimulation.Checked.ToString();
            list.Add(simulation);

            var saveData = new CameraSettingCreateDto();
            saveData.Code = CameraEnum.保存数据;
            saveData.Descs = CameraEnum.保存数据.ToString();
            saveData.Value = chkAutoSaveData.Checked.ToString();
            list.Add(saveData);

            var showPic = new CameraSettingCreateDto();
            showPic.Code = CameraEnum.显示图形;
            showPic.Descs = CameraEnum.显示图形.ToString();
            showPic.Value = chkShowPic.Checked.ToString();
            list.Add(showPic);

            var autoSave = new CameraSettingCreateDto();
            autoSave.Code = CameraEnum.自动存图;
            autoSave.Descs = CameraEnum.自动存图.ToString();
            autoSave.Value = chkAutoSaveImage.Checked.ToString();
            list.Add(autoSave);
            var result = cameraSettingAppService.SaveCameraSetting(list);
            if (result)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
        #endregion

        private void SetCurrentInageInfo()
        {
            if (!isCameraOnline)
            {
                txtCurrentImgFileName.Text = fileInfos[imgIndex].Name.Substring(0, (fileInfos[imgIndex].Name.Length - 4));  //当前图像文件名
                txtCurrentSpec.Text = fileInfos[imgIndex].Name.Substring(0, (fileInfos[imgIndex].Name.Length - 4));         //当前产品规格型号
            }
        }

        /// <summary>
        /// 窗体切换到另外的窗体时
        /// </summary>
        private void VisionProSetting_Leave(object sender, EventArgs e)
        {
            //关闭相机外部模式
            if (chkCamTrigOn.Checked)
            {
                //icogAcqFifo.OwnedTriggerParams.TriggerEnabled = false;
                //icogAcqFifo.OwnedExposureParams.Exposure = 1;
                //icogAcqFifo.Flush();
                //icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Manual;
                //icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
                CreamOff();
                chkCamTrigOn.Checked = false;//相机外部模式
            }
        }

        public void CreamOn()
        {
            icogAcqFifo.OwnedTriggerParams.TriggerEnabled = false;
            icogAcqFifo.Flush();
            icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;
            icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
            icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
        }
        public void CreamOff()
        {
            icogAcqFifo.OwnedTriggerParams.TriggerEnabled = false;
            icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
            icogAcqFifo.Flush();
            icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Manual;
            icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
        }
    }
}
