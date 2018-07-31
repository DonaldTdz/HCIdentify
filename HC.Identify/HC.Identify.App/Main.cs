using HC.Identify.Application;
using HC.Identify.Application.Identify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC.Identify.App
{
    public partial class Main : Form
    {
        public MainChildrenCollection MainChildList = new MainChildrenCollection();
        UserAppService userAppServer;
        public FrameStatusEnum FrameStatus { get; set; }
        public RunStatusEnum RunStatus { get; set; }
        //COMServer cOMServer;//串口通信测试
        //SocketServer socketServer;
        //SocketClient socketClient;
        public Main()
        {
            InitializeComponent();
            userAppServer = new UserAppService();
            InitControles();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();

            // //串口测试
            // cOMServer = new COMServer("COM4", 9600, 8, StopBits.One, Parity.Even);
            // cOMServer.Open();
            // var txtSendStr = "串口通信成功了吗？";
            // var sendByte = Encoding.UTF8.GetBytes(txtSendStr);
            // cOMServer.Send(sendByte);
            //var result= cOMServer.Recive();
            // MessageBox.Show(result);
            //服务端
            //socketServer = new SocketServer();
            //socketServer.Open();
            //客户端
            //socketClient = new SocketClient("192.168.0.128", 89);
            //socketClient.Open();
            //socketClient.Send("socketClient");
        }

        //初始化控件
        public void InitControles()
        {
            this.ShowForm("Workbench", new Workbench(this));
        }

        public void InitData()
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 视觉配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm("VisionProSetting", new VisionProSetting(this));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ShowForm("Workbench", new Workbench(this));
        }

        private void ShowForm(string formName, FormMainChildren form)
        {
            if (this.MainChildList.ExistsForm(formName))
            {
                this.MainChildList[formName].WindowState = FormWindowState.Maximized;
                this.MainChildList[formName].Show();
                form.Dispose();
            }
            else
            {
                form.MdiParent = this;
                form.WindowState = FormWindowState.Maximized;
                form.ParentMainForm = this;
                this.MainChildList[formName] = form;
                form.Show();
            }
        }

        public void SetFrameStatus(FrameStatusEnum frameStatus)
        {
            this.FrameStatus = frameStatus;
            switch (frameStatus)
            {
                case FrameStatusEnum.None:
                    {
                        this.toolFrameStatus.Text = "相机未连接";
                        this.toolFrameStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\red.ico");
                    }
                    break;
                case FrameStatusEnum.Connected:
                    {
                        this.toolFrameStatus.Text = "相机已连接";
                        this.toolFrameStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\green.ico");
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 批次调整
        /// </summary>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.ShowForm("BatchAdjustment", new BatchAdjustment(this));
        }
        public void SetRunStatus(RunStatusEnum runStatusEnum)
        {
            this.RunStatus = runStatusEnum;
            switch (runStatusEnum)
            {
                case RunStatusEnum.None:
                    {
                        this.toolRunStatusVal.Text = "未开始";
                        this.toolRunStatusVal.ForeColor = Color.Gray;
                        this.toolRunStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\icon_status-dot.png");
                    }
                    break;
                case RunStatusEnum.Running:
                    {
                        this.toolRunStatusVal.Text = "运行中";
                        this.toolRunStatusVal.ForeColor = Color.Green;
                        this.toolRunStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\green.ico");
                    }
                    break;
                case RunStatusEnum.Suspend:
                    {
                        this.toolRunStatusVal.Text = "停止";
                        this.toolRunStatusVal.ForeColor = Color.Red;
                        this.toolRunStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\red.ico");
                    }
                    break;
                default:
                    break;
            }

        }

        public enum FrameStatusEnum
        {
            None = 0, //未连接
            Connected = 1 //已连接
        }

        public enum RunStatusEnum
        {
            None = 0, //未开始
            Running = 1, //运行中
            Suspend = 2, //暂停
        }

        public class FormMainChildren : Form
        {
            public string FormName { get; set; }
            public Main ParentMainForm { get; set; }
            public virtual void RefreshData() { }
        }

        public class MainChildrenCollection : List<FormMainChildren>
        {
            public FormMainChildren this[string formName]
            {
                get
                {
                    return this.Where(t => t.FormName == formName).FirstOrDefault();
                }
                set
                {
                    if (!ExistsForm(formName))
                    {
                        value.FormName = formName;
                        this.Add(value);
                    }
                }
            }

            public bool ExistsForm(string formName)
            {
                if (this[formName] == null)
                {
                    return false;
                }

                if (this[formName].IsDisposed)
                {
                    this.Remove(this[formName]);
                    return false;
                }
                return true;
            }

        }
    }
}
