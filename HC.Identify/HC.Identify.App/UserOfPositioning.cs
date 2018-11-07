﻿using HC.Identify.Dto.Ksecpick;
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
    public partial class UserOfPositioning : Form
    {
        public VTaskOrderInfoDto retailer;
        public string serialNum;//烟的序号
        public UserOfPositioning(VTaskOrderInfoDto entity)
        {
            InitializeComponent();
            retailer = entity;
            labRetailerName.Text = retailer.CUSTOMNAME.Length > 15 ? retailer.CUSTOMNAME.Substring(0, 15) + "..." : retailer.CUSTOMNAME;
            //labRetailerName.Text = retailer.CUSTOMNAME;
            labCode.Text = retailer.CUSTOMCODE;
            labIndex.Text = retailer.IndexNum.ToString();
            labNum.Text = retailer.orderqty.ToString();
            labOrderNum.Text = retailer.SJOBNUM;
            labLine.Text = retailer.SORTLINE;
            labBatch.Text = retailer.batch;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            serialNum = txtSerNum.Text;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 限制烟序号只能输入数字
        /// </summary>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char result = e.KeyChar;
            if (char.IsDigit(result) || result == 8)//8表示ASCII码代表退格
            {

                var txtNum = txtSerNum.Text + (result == 8 ? "" : e.KeyChar.ToString());

                if (!string.IsNullOrEmpty(txtNum))
                {
                    if (0 < int.Parse(txtNum) && int.Parse(txtNum) <= retailer.orderqty)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;//不会将输入的内容显示
                        MessageBox.Show(string.Format("只能输入1-{0}的数字", (int)retailer.orderqty));
                    }
                }
                else
                {
                    e.Handled = false;
                }

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
