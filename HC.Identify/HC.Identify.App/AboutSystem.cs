using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HC.Identify.App.Main;

namespace HC.Identify.App
{
    public partial class AboutSystem : FormMainChildren//Form
    {
        //定义全局主窗口 刷新状态
        public Main MainForm;
        public AboutSystem()
        {
            InitializeComponent();
        }

        public AboutSystem(Main mainForm)
        {
            this.MainForm = mainForm;
        }
    }
}
