using HC.Identify.Application.Identify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HC.Identify.App
{
    public partial class Login : Form
    {
        private UserAppService userAppService;
        public Login()
        {
            InitializeComponent();
            userAppService = new UserAppService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var accont = Account.Text;
            var password = Password.Text;
          //var pas=FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");

            var isExtend = userAppService.UserIsExtend(accont, password);
            if (isExtend)
            {
                //Session["Account"] =accont;
                //Session["Password"] =password;
                Main ma = new Main();
                ma.Show();
                this.Visible=false;
            }
            else
            {
                label3.Text = "登录失败，请确认用户名或密码";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 记住登录账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    XDocument xdoc = XDocument.Load("userList.xml");
            //    var xe = xdoc.Element(XName.Get("users")).Elements(XName.Get("user")).SingleOrDefault(x => x.Attribute(XName.Get("UserName")).Value == txtUserName.Text.Trim()); //判断当前的用户名是否存在
            //    if (xe == null)  //不存在添加
            //    {
            //        XElement newxe = new XElement(XName.Get("user"));
            //        newxe.SetAttributeValue(XName.Get("UserName"), txtUserName.Text);
            //        newxe.SetAttributeValue(XName.Get("Password"), txtPassword.Text);
            //        xdoc.Element(XName.Get("users")).Add(newxe);
            //    }
            //    else  //存在修改
            //    {
            //        xe.Attribute(XName.Get("Password")).Value = txtPassword.Text;
            //    }
            //    xdoc.Save("userList.xml");
            //}
        }
    }
}
