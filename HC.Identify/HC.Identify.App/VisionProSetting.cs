using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC.Identify.App
{
    public partial class VisionProSetting : FormMainChildren
    {
        bool cameraOnline;     //是否连接相机
        ICogAcqFifo mAcqFifo;  //获取数据
        ICogImage mColorImage; //图片控件
        //定义全局主窗口 刷新状态
        public Main MainForm;
        public VisionProSetting()
        {
            InitializeComponent();
        }

        public VisionProSetting(Main mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
        }

        private void VisionProSetting_Load(object sender, EventArgs e)
        {
            //连接相机
            ConnectionCamera();

        }

        #region 连接相机

        private void ConnectionCamera()
        {
            CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
            if (mFrameGrabbers.Count == 0)
            {
                cameraOnline = false;
                btnLiveDisplay.Enabled = false; //禁用连续取像
                chkCamTrigOn.Enabled = false;   //禁用相机外部启用模式

                MessageBox.Show("无相机连接，运行离线模式");
            }
            else//相机模式运行
            {
                cameraOnline = true;
                //获取第一个相机图片
                mAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                // mAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Bayer Color)", CogAcqFifoPixelFormatConstants.Format3Plane, 0, true);//Format3Plane
                //添加获取完成处理事件
                //mAcqFifo.Complete += new CogCompleteEventHandler(CompleteAcquire);
                int numReadyVal;   //读取值
                int numPendingVal; //等待值
                int iNum = mAcqFifo.StartAcquire(); //开始获取
                //获取图片
                mColorImage = mAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
                //显示图片
                cogRecordDisplay.Image = mColorImage;
                cogRecordDisplay.Fit(false);
            }
        }

        #endregion
    }
}
