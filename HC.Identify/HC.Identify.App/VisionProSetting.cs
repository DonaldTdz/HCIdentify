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
    }
}
