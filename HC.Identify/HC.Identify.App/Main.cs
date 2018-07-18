using HC.Identify.Application.Identify;
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
    public partial class Main : Form
    {
        public MainChildrenCollection MainChildList = new MainChildrenCollection();
        UserAppService userAppServer;
        public Main()
        {
            InitializeComponent();
            userAppServer = new UserAppService();
            InitControles();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();
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
    }

    public enum FrameStatusEnum
    {
        None = 0, //未连接
        Connected = 1 //已连接
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
