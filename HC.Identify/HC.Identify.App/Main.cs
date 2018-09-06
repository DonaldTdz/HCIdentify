using HC.Identify.Application;
using HC.Identify.Application.Identify;
using HC.Identify.Core.Identify;
using HC.Identify.Dto.Identify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
        public FrameStatusEnum ZRStatus { get; set; }
        public FrameStatusEnum ScannerStatus { get; set; }
        //COMServer cOMServer;//串口通信测试
        //SocketServer socketServer;
        //SocketClient socketClient;
        public UserDto loginUser=new UserDto();
        public Main(UserDto user)
        {
            InitializeComponent();
            userAppServer = new UserAppService();
            InitControles();
            loginUser = user;
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
            IsManager();
        }

        public void IsManager()
        {
            if (loginUser.Role != RoleEnum.系统管理员)
            {
                系统管理ToolStripMenuItem.Visible = false;
                //系统用户ToolStripMenuItem.Visible = false;
            }
            toolUserName.Text = loginUser.Account;
            toolUserName.ForeColor = Color.SkyBlue;
        }

        //初始化控件
        public void InitControles()
        {
            //this.ShowForm("Workbench");
            this.ShowForm("WorkbenchNew");

        }

        public void InitData()
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 视觉配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm("VisionProSetting");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.ShowForm("Workbench");
            this.ShowForm("WorkbenchNew");
        }

        private void ShowForm(string formName)
        {
            if (this.MainChildList.ExistsForm(formName))
            {
                this.MainChildList[formName].WindowState = FormWindowState.Maximized;
                this.MainChildList[formName].Show();
            }
            else
            {
                var form = new FormMainChildren();
                switch (formName)
                {
                    case "Workbench":
                        {
                            form = new Workbench(this);
                        }; break;
                    case "VisionProSetting":
                        {
                            form = new VisionProSetting(this);
                        }; break;
                    case "BatchAdjustment":
                        {
                            form = new BatchAdjustment(this);
                        }; break;
                    case "SystemConfig":
                        {
                            form = new SystemConfig(this);
                        }; break;
                    case "UserInfo":
                        {
                            form = new UserInfo(this);
                        }; break;
                    case "AboutSystem":
                        {
                            form = new AboutSystem(this);
                        }; break;
                    case "WorkbenchNew":
                        {
                            form = new WorkbenchNew(this);
                        }; break;
                    default:
                        break;
                }
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
                case FrameStatusEnum.NoConnected:
                    {
                        this.toolFrameStatusVal.Text = "未连接";
                        this.toolFrameStatusVal.ForeColor = Color.Red;
                        this.toolFrameStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\red.ico");
                    }
                    break;
                case FrameStatusEnum.Connected:
                    {
                        this.toolFrameStatusVal.Text = "已连接";
                        this.toolFrameStatusVal.ForeColor = Color.Green;
                        this.toolFrameStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\green.ico");
                    }
                    break;
                case FrameStatusEnum.NotEnabled:
                    {
                        this.toolFrameStatusVal.Text = "未启用";
                        this.toolFrameStatusVal.ForeColor = Color.Gray;
                        this.toolFrameStatusVal.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\icon_status-dot.png");
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
            this.ShowForm("BatchAdjustment");
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
            NoConnected = 0, //未连接
            Connected = 1, //已连接
            NotEnabled = 3,//未启用
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

        private void 系统配置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowForm("SystemConfig");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            //Dispose();
        }

        /// <summary>
        /// 设置中软状态
        /// </summary>
        /// <param name="frameStatusEnum"></param>
        public void SetZRStatus(FrameStatusEnum frameStatusEnum)
        {
            this.ZRStatus = frameStatusEnum;
            switch (frameStatusEnum)
            {
                case FrameStatusEnum.NoConnected:
                    {
                        this.toolS_zr.Text = "未连接";
                        this.toolS_zr.ForeColor = Color.Red;
                        this.toolS_zr.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\red.ico");
                    }
                    break;
                case FrameStatusEnum.Connected:
                    {
                        this.toolS_zr.Text = "已连接";
                        this.toolS_zr.ForeColor = Color.Green;
                        this.toolS_zr.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\green.ico");
                    }
                    break;
                case FrameStatusEnum.NotEnabled:
                    {
                        this.toolS_zr.Text = "未启用";
                        this.toolS_zr.ForeColor = Color.Gray;
                        this.toolS_zr.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\icon_status-dot.png");
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 设置读码器状态
        /// </summary>
        /// <param name="frameStatusEnum"></param>
        public void SetScannerStatus(FrameStatusEnum frameStatusEnum)
        {
            this.ScannerStatus = frameStatusEnum;
            switch (frameStatusEnum)
            {
                case FrameStatusEnum.NoConnected:
                    {
                        this.toolS_scan.Text = "未连接";
                        this.toolS_scan.ForeColor = Color.Red;
                        this.toolS_scan.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\red.ico");
                    }
                    break;
                case FrameStatusEnum.Connected:
                    {
                        this.toolS_scan.Text = "已连接";
                        this.toolS_scan.ForeColor = Color.Green;
                        this.toolS_scan.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\green.ico");
                    }
                    break;
                case FrameStatusEnum.NotEnabled:
                    {
                        this.toolS_scan.Text = "未启用";
                        this.toolS_scan.ForeColor = Color.Gray;
                        this.toolS_scan.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + @"\Resources\icon_status-dot.png");
                    }
                    break;
                default:
                    break;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Thread.Sleep(30);//当保存配置调用System.Windows.Forms.Application.Exit()关闭窗口需要等它执行一会儿Environment.Exit(0);执行才不会出错
            Environment.Exit(0);
        }

        private void 系统用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm("UserInfo");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutSystem form = new AboutSystem();
            form.ShowDialog();
        }
    }
}
