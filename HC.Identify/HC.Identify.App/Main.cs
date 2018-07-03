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
        UserAppServer userAppServer;
        public Main()
        {
            InitializeComponent();
            userAppServer = new UserAppServer();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitData();
        }

        public void InitData()
        {
            var dataList = userAppServer.GetUserList();
            grdUser.DataSource = dataList;
        }
    }
}
