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
        UserAppServer userAppServer;
        public Main()
        {
            InitializeComponent();
            userAppServer = new UserAppServer();
            InitControles();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();
        }

        //初始化控件
        public void InitControles()
        {
            Workbench frm = new Workbench(this);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.ParentMainForm = this;
            this.MainChildList["Workbench"] = frm;
            this.MainChildList["Workbench"].Show();
        }

        public void InitData()
        {
           
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
