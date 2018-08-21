using HC.Identify.Application.Identify;
using HC.Identify.Dto.Identify;
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
    public partial class UserInfo : FormMainChildren  //Form 
    {

        //定义全局主窗口 刷新状态
        public Main MainForm;
        private UserAppService userAppService = new UserAppService();
        public IList<UserDto> list;
        public UserInfo()
        {
            InitializeComponent();
        }

        public UserInfo(Main mainForm)
        {
            this.MainForm = mainForm;
            userAppService = new UserAppService();
            InitTable();
        }

        public void InitTable()
        {
            list = userAppService.GetAllUser();
            //gv_useInfo.DataSource = list;
            GV_userInfo.DataSource = list;
        }
    }
}
