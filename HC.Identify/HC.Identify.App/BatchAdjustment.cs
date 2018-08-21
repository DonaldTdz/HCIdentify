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
    public partial class BatchAdjustment : FormMainChildren  // Form
    {
        //定义全局主窗口，刷新状态
        public Main MainForm;
        private OrderSumAppService orderSumAppService;
        private IList<OrderSumForUpDoen> orderSums;//当前选项的所有打包订单信息
        public BatchAdjustment()
        {
            InitializeComponent();
        }
        public BatchAdjustment(Main mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            InitServices();
            InitData();
        }
        private void InitServices()
        {
            orderSumAppService = new OrderSumAppService();
        }

        private void InitData()
        {
            ComboxGetValue();
            if (combo_OrderSum.SelectedValue != null)
            {
                //获取下拉框选中的值
                var item = combo_OrderSum.SelectedValue.ToString();
                var code = int.Parse(item);
                //获取当前选中项下的打包订单信息
                orderSums = orderSumAppService.GetOrderSums(code).OrderBy(o => o.RIndex).ToList();
                GV_OrderSum.DataSource = orderSums;
                //this.GV_OrderSum.Sort(this.GV_OrderSum.Columns[5], ListSortDirection.Ascending);
            }
        }
        /// <summary>
        /// 下拉框赋值
        /// </summary>
        public void ComboxGetValue()
        {
            var datas = orderSumAppService.GetAreaList();
            if (datas.Count > 0)
            {
                //下拉框数据赋值
                combo_OrderSum.DataSource = datas;
                combo_OrderSum.DisplayMember = "name";
                combo_OrderSum.ValueMember = "value";
            }
        }

        private void combo_OrderSum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var item = combo_OrderSum.SelectedValue.ToString();
            var code = int.Parse(item);
            orderSums = orderSumAppService.GetOrderSums(code).OrderBy(o => o.RIndex).ToList();
            GV_OrderSum.DataSource = orderSums;
        }

        /// <summary>
        /// 向上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_up_Click(object sender, EventArgs e)
        {
            var index = GV_OrderSum.CurrentRow.Index;
            var rIndex = int.Parse(GV_OrderSum.Rows[index].Cells[5].Value.ToString());
            if (index == 0)
            {
                MessageBox.Show("已经是第一位了哟");
            }
            else
            {
                var rIndexLast = int.Parse(GV_OrderSum.Rows[index - 1].Cells[5].Value.ToString());
                var Id = new Guid(GV_OrderSum.Rows[index].Cells[0].Value.ToString());
                var IdLast = new Guid(GV_OrderSum.Rows[index - 1].Cells[0].Value.ToString());
                var update = false;
                var updateLast = false;
                for (var i = 0; i < orderSums.Count; i++)
                {
                    if (orderSums[i].Id == Id)
                    {
                        //var covert1 = orderSums[i].RIndex;
                        //var covert2 = orderSums[i - 1].RIndex;
                        //orderSums[i].RIndex = covert2;
                        //orderSums[i - 1].RIndex = covert1;
                        //selectIndex = i - 1;
                        //break;
                        orderSums[i].RIndex = rIndexLast;
                        update = true;
                    }
                    if (orderSums[i].Id == IdLast)
                    {
                        orderSums[i].RIndex = rIndex;
                        updateLast = true;
                    }
                    if (update && updateLast)
                    {
                        break;
                    }
                }
                var selectIndex = index - 1;
                orderSums = orderSums.OrderBy(o => o.RIndex).ToList();
                GV_OrderSum.DataSource = orderSums;
                GV_OrderSum.Refresh();
                GV_OrderSum.ClearSelection();
                GV_OrderSum.Rows[selectIndex].Selected = true;
                GV_OrderSum.CurrentCell = GV_OrderSum.Rows[selectIndex].Cells[1];
                GV_OrderSum.CurrentRow.Selected = true;
            }


        }
        /// <summary>
        /// 向下
        /// </summary>
        private void btn_down_Click(object sender, EventArgs e)
        {
            var index = GV_OrderSum.CurrentRow.Index;
            var cindex = GV_OrderSum.CurrentCell.RowIndex;
            var rIndex = int.Parse(GV_OrderSum.Rows[index].Cells[5].Value.ToString());//选中行rIndex
            if (index == orderSums.Count - 1)
            {
                MessageBox.Show("已经是最后一位了哟");
            }
            else
            {
                var rIndexNext = int.Parse(GV_OrderSum.Rows[index + 1].Cells[5].Value.ToString());//下一行rIndex
                var Id = new Guid(GV_OrderSum.Rows[index].Cells[0].Value.ToString());//选中行Id
                var nextId = new Guid(GV_OrderSum.Rows[index + 1].Cells[0].Value.ToString());//下一行Id
                var update = false;
                var updateNext = false;
                for (var i = 0; i < orderSums.Count; i++)
                {
                    if (orderSums[i].Id == Id)
                    {
                        //var covert1 = orderSums[i].RIndex;
                        //var covert2 = orderSums[i + 1].RIndex;
                        //orderSums[i].RIndex = covert2;//orderSums[i + 1].RIndex;
                        //orderSums[i + 1].RIndex = covert1;// covert;
                        //selectIndex = i + 1;
                        //break;
                        orderSums[i].RIndex = rIndexNext;//将下一行数据的rIdex付给选中行
                        update = true;
                    }
                    if (orderSums[i].Id == nextId)
                    {
                        orderSums[i].RIndex = rIndex;//将选中行数据的rIdex付给下一行行
                        updateNext = true;
                    }
                    if (update && updateNext)
                    {
                        break;
                    }
                }
                var selectIndex = index + 1;
                orderSums = orderSums.OrderBy(o => o.RIndex).ToList();
                GV_OrderSum.DataSource = orderSums;
                GV_OrderSum.Refresh();//刷新DataGridView
                //定位到向下的目标行
                GV_OrderSum.ClearSelection();
                GV_OrderSum.Rows[selectIndex].Selected = true;
                GV_OrderSum.CurrentCell = GV_OrderSum.Rows[selectIndex].Cells[1];
                GV_OrderSum.CurrentRow.Selected = true;

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var result = orderSumAppService.BatchUpdateOrderSum(orderSums);
            if (result == orderSums.Count)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }
    }
}
