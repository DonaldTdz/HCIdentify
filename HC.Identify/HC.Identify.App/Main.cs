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
            //Workbench frm = new Workbench(this);
            //frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            //frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ParentMainForm = this;
            //this.MainChildList["Workbench"] = frm;
            //this.MainChildList["Workbench"].Show();
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
            //if (this.MainChildList.ExistsForm("VisionProSetting"))
            //{
            //    this.MainChildList["VisionProSetting"].WindowState = FormWindowState.Maximized;
            //    this.MainChildList["VisionProSetting"].Show();
            //}
            //else
            //{
            //    VisionProSetting visionProSetting;
            //    visionProSetting = new VisionProSetting();
            //    visionProSetting.MdiParent = this;
            //    visionProSetting.WindowState = FormWindowState.Maximized;
            //    visionProSetting.ParentMainForm = this;
            //    this.MainChildList["VisionProSetting"] = visionProSetting;
            //    visionProSetting.Show();
            //}

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
