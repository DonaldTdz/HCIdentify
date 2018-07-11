﻿using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application.VisionPro;
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

        #endregion

        #region 数据存储处理

        VisionProAppService vpCsvDataService;          //csv data 数据处理服务
        Dictionary<string, double[]> csvSpecList;      //已注册产品数据

        #endregion

        //定义全局主窗口 刷新状态
        public Main MainForm;

        public VisionProSetting()
        {
            InitializeComponent();
        }

        public VisionProSetting(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private void VisionProSetting_Load(object sender, EventArgs e)
        {
            //连接相机
            ConnectionCamera();
            currentrDirectory = Directory.GetCurrentDirectory();
            cogToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(currentrDirectory + "\\TB_Set.Vpp");
            var csvDataPath = currentrDirectory + "\\Data\\Data.csv";
            if (!File.Exists(csvDataPath))
            {
                MessageBox.Show("数据文件不存在或路径错误！");
                return;
            }
            vpCsvDataService = new VisionProAppService(csvDataPath);
            csvSpecList = vpCsvDataService.GetCsvSpecificationList();
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
                chkCamTrigOnv.Enabled = false;   //禁用相机外部启用模式

                MessageBox.Show("无相机连接，运行离线模式");
            }
            else//相机模式运行
            {
                isCameraOnline = true;
                //获取第一个相机图片
                icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                // mAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Bayer Color)", CogAcqFifoPixelFormatConstants.Format3Plane, 0, true);//Format3Plane
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
            comboSpecBox.DataSource = csvSpecList.Keys;
        }

        #endregion

        #region 自动存图

        private void AutoSaveImage()
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\AutoSaveImage\\" + DateTime.Now.ToString("yyyyMMdd_HHmmssfff") + ".BMP";
            cogImageFile.Operator.Open(path, CogImageFileModeConstants.Write);
            cogImageFile.InputImage = icogColorImage;
            cogImageFile.Run();
        }

        #endregion

        #region 匹配计算


        FileSystemInfo[] fileInfos;
        int imgIndex;

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
            cogRecordDisplay.Record = SubRecords["CogIPOneImageTool1.OutputImage"];
            cogRecordDisplay.Fit(true);
            ArrayList cogResultArray = (ArrayList)cogToolBlock.Outputs["SubRectValues"].Value;
            if (cogResultArray.Count == 0)
            {
                MessageBox.Show("ToolBlock结果为空！");
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
            string maxKey = string.Empty;
            int i = 0;
            foreach (var key in csvSpecList.Keys)
            {
                double dSumXY = 0;
                double dSumX = 0;
                double dSumY = 0;
                double dSumXBy2 = 0;
                double dSumYBy2 = 0;
                int iPointsNum = csvSpecList[key].Length;
                int k = 0;
                foreach (var readVal in csvSpecList[key])
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
                    maxKey = key;
                }
                i++;
            }

            txtMatchSpec.Text = maxKey;
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
            return maxKey;
        }

        double mMaxScore;

        private void RunCalculation()
        {
            DateTime befortime = DateTime.Now;//计算耗时
            //运行
            var cogResultArray = ToolBlockRun();
            //计算
            var spec = Calculation(cogResultArray);
            //计算用时
            DateTime aftertime = DateTime.Now;
            txtUseTime.Text = aftertime.Subtract(befortime).Milliseconds.ToString();//毫秒
            if (chkAutoSaveData.Checked)
            {
                SaveData(spec);
            }
        }

        #endregion

        #region 保存结果

        private void SaveData(string spec)
        {
            string logPath = System.Windows.Forms.Application.StartupPath + "\\ResultLog" + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            vpCsvDataService.SaveResultLog(logPath, spec, mMaxScore);
        }

        #endregion

        #region 工具设置

        bool isShowTool = false;

        private void btnToolSetting_Click(object sender, EventArgs e)
        {
            if (!isShowTool)
            {
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
                icogAcqFifo.OwnedExposureParams.Exposure = 0.5;
                cogRecordDisplay.StopLiveDisplay();
                btnLiveDisplay.Text = "连续取像";
            }
            else
            {
                icogAcqFifo.OwnedExposureParams.Exposure = 0.5;
                cogRecordDisplay.StaticGraphics.Clear();
                cogRecordDisplay.Record = null;
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit(false);

                icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Manual;
                icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
                chkCamTrigOnv.Checked = false;//相机外部模式
                cogRecordDisplay.StartLiveDisplay(icogAcqFifo);
                btnLiveDisplay.Text = "停止取像";
            }
        }

        #endregion

        #region 选择图片位置

        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            var imgPath = string.Empty;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                imgPath = folder.SelectedPath;
                txtImgPath.Text = imgPath;
            }
            //读取第一张图
            imgIndex = 0;
            var imgDir = new DirectoryInfo(imgPath);
            var totalImgCount = imgDir.GetFiles().Length;
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

            ToolBlockRun();
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

    }
}
