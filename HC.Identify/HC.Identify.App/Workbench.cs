using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application.Identify;
using HC.Identify.Dto.Identify;
using HC.Identify.Dto.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC.Identify.App
{
    public partial class Workbench : FormMainChildren
    {
        //定义全局主窗口 刷新状态
        public Main MainForm;
        private int sequence = 1;
        private int count = 0;//当前选项的所有打包订单信息总数
        private IList<OrderSumDto> orderSums;//当前选项的所有打包订单信息
        private OrderSumAppService orderSumAppService;
        private OrderInfoAppService orderInfoAppService;
        private IList<OrderInfoTableDto> orderInfos;//当前选项的详细订单信息
        private bool IsStart = false; //是否开始
        public Workbench()
        {
            InitializeComponent();
        }

        public Workbench(Main mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
            InitServices();         //初始化服务
            BindDistributionLine(); //配送线路
            InitFrame();            //初始化相机
        }

        #region 初始化服务

        private void InitServices()
        {
            orderSumAppService = new OrderSumAppService();
            orderInfoAppService = new OrderInfoAppService();
        }
        #region 绑定下拉数据

        private void BindDistributionLine()
        {

            //获取下拉框数据
            ComboxGetValue();
            if (combo_area.SelectedValue != null)
            {
                //获取下拉框选中的值
                var item = combo_area.SelectedValue.ToString();
                var code = int.Parse(item);
                //获取当前选中项下的打包订单信息数量
                count = orderSumAppService.GetOrderSumCount(code);
                //获取当前选中项下的打包订单信息
                orderSums = orderSumAppService.GetOrderSumByAreaCode(code);
                //获取单个用户订单信息
                GetOrderSum(sequence);
            }
        }
        #endregion

        #endregion

        #region 相机相关处理

        ICogAcqFifo icogAcqFifo;  //获取数据
        ICogImage icogColorImage; //图像控件
        CogToolBlock cogToolBlock = new CogToolBlock();       //图像连接工具

        /// <summary>
        /// 相机初始化
        /// </summary>
        private void InitFrame()
        {
            CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
            if (mFrameGrabbers.Count == 0)
            {
                this.MainForm.SetFrameStatus(FrameStatusEnum.None);
            }
            else//相机模式运行
            {
                //获取第一个相机图片
                icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
                // icogAcqFifo = mFrameGrabbers[0].CreateAcqFifo("Generic GigEVision (Bayer Color)", CogAcqFifoPixelFormatConstants.Format3Plane, 0, true);//Format3Plane
                //添加获取完成处理事件
                icogAcqFifo.Complete += new CogCompleteEventHandler(CompleteAcquire);
                int numReadyVal;   //读取值
                int numPendingVal; //等待值
                int iNum = icogAcqFifo.StartAcquire(); //开始获取
                                                       //获取图片
                icogColorImage = icogAcqFifo.CompleteAcquire(iNum, out numReadyVal, out numPendingVal);
                //显示图片
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit(false);
                this.MainForm.SetFrameStatus(FrameStatusEnum.Connected);
            }
        }

        private void CompleteAcquire(Object sender, CogCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(CompleteAcquire), new object[] { sender, e });
                return;
            }
            int numReadyVal;   //读取值
            int numPendingVal; //等待值
            bool busyVal;
            CogAcqInfo info = new CogAcqInfo();
            try
            {
                icogAcqFifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);
                if (numReadyVal > 0)
                {
                    icogColorImage = icogAcqFifo.CompleteAcquireEx(info);
                    cogRecordDisplay.Image = icogColorImage;
                    cogRecordDisplay.Fit(false);
                }
            }
            catch (CogException ce)
            {
                MessageBox.Show("The following error has occured\n" + ce.Message);
            }
            //自动存图
            //if (chkAutoSaveImage.Checked)
            //{
            //    AutoSaveImage();
            //}

            //匹配计算
            RunCalculation();
        }

        private void RunCalculation()
        {

            //运行
            var cogResultArray = ToolBlockRun();
            //计算
            var spec = Calculation(cogResultArray);

            //自动保存计算结果
            //if (chkAutoSaveData.Checked)
            //{
            //    SaveData(spec);
            //}
        }

        FileSystemInfo[] fileInfos;
        int imgIndex;
        ArrayList cogResultArray = new ArrayList();

        private ArrayList ToolBlockRun()
        {
            cogToolBlock.Inputs["InputImage"].Value = icogColorImage;
            cogToolBlock.Inputs["iRow"].Value = 4;
            cogToolBlock.Inputs["iCol"].Value = 12;
            cogToolBlock.Inputs["bForceLeft"].Value = false;    //左边线错误
            cogToolBlock.Inputs["bForceRight"].Value = false;   //右边线错误
            cogToolBlock.Inputs["bShowGraphic"].Value = false;  //显示图形
            cogToolBlock.Run();

            ICogRecords SubRecords = cogToolBlock.CreateLastRunRecord().SubRecords;
            cogRecordDisplay.Record = SubRecords["CogIPOneImageTool1.OutputImage"];
            cogRecordDisplay.Fit(true);
            cogResultArray = (ArrayList)cogToolBlock.Outputs["SubRectValues"].Value;
            if (cogResultArray.Count == 0)
            {
                MessageBox.Show("ToolBlock结果为空！");
                return null;
            }
            return cogResultArray;
        }


        List<CsvSpecification> csvSpecList = new List<CsvSpecification>();      //已注册产品数据
        private string Calculation(ArrayList cogResultArray)
        {
            int totalType = csvSpecList.Count();
            //相关矩阵计算
            double[] dMatchScore = new double[totalType];   //50种型号的匹配分数
                                                            //  int iPointsNum = this.Inputs.iRow * this.Inputs.iCol;
            double dMaxScore = -9999;
            string maxSpec = string.Empty;
            int i = 0;
            foreach (var item in csvSpecList)
            {
                double dSumXY = 0;
                double dSumX = 0;
                double dSumY = 0;
                double dSumXBy2 = 0;
                double dSumYBy2 = 0;
                int iPointsNum = item.Values.Length;
                int k = 0;
                foreach (var readVal in item.Values)
                {
                    dSumXY += (double)cogResultArray[k] * readVal;
                    dSumX += (double)cogResultArray[k];
                    dSumY += readVal;
                    dSumXBy2 += (double)cogResultArray[k] * (double)cogResultArray[k];
                    dSumYBy2 += readVal * readVal;
                    k++;
                }
                dMatchScore[i] = (iPointsNum * dSumXY - dSumX * dSumY) / (Math.Sqrt(iPointsNum * dSumXBy2 - dSumX * dSumX) * Math.Sqrt(iPointsNum * dSumYBy2 - dSumY * dSumY));
                // MessageBox.Show(dMatchScore[l].ToString()+"   "+ReadType[l]);
                if (dMatchScore[i] > dMaxScore)
                {
                    dMaxScore = dMatchScore[i];
                    maxSpec = item.Specification;
                }
                i++;
            }
            //配置结果值
            if (dMaxScore > 0.81)
            {
                //"OK"
            }
            else
            {
                //"NG"; 
            }
            return maxSpec;
        }
        #endregion

        #region 用户订单
        /// <summary>
        /// 下一户
        /// </summary>
        private void btn_nexthouse_Click(object sender, EventArgs e)
        {
            //var order = int.Parse(lab_areacode_hide.Text)+1;

            if (sequence < count)
            {
                sequence = sequence + 1;
                GetOrderSum(sequence);
            }
            else
            {
                MessageBox.Show("没有下一户了哦");
            }
        }
        /// <summary>
        /// 页面数据赋值
        /// </summary>
        public void GetOrderSum(int order)
        {
            //var item = combo_area.SelectedValue.ToString();
            //var code = int.Parse(item);
            //var orderSum = orderSumAppService.GetSigleOrderSum(code, order);
            var orderSum = GetSingleOrderSum();
            //var count = orderSumAppService.GetOrderSumCount(code);
            lab_areaName.Text = orderSum.AreaName;
            lab_retaName.Text = orderSum.RetailerName;
            //lab_houseNum.Text = "第"+ orderSum.Sequence+"户/" + "共" + count + "户";
            lab_houseNum.Text = "第" + sequence + "户/" + "共" + count + "户";
            lab_num.Text = orderSum.Num.ToString();
            lab_lastHose.Text = orderSum.LastHouse.Length > 5 ? orderSum.LastHouse.Substring(0, 5) + "..." : orderSum.LastHouse;//上一户
            lab_lastlHose.Text = orderSum.LastLHouse.Length > 5 ? orderSum.LastLHouse.Substring(0, 5) + "..." : orderSum.LastLHouse;//上上户
            lab_nextHose.Text = orderSum.NextHouse.Length > 5 ? orderSum.NextHouse.Substring(0, 5) + "..." : orderSum.NextHouse; ;//下一户
            lab_nextnHose.Text = orderSum.NextNHouse.Length > 5 ? orderSum.NextNHouse.Substring(0, 5) + "..." : orderSum.NextNHouse; ;
            //下下户

            //获取订单信息
            orderInfos = orderInfoAppService.GetOrderInfoByUUID(orderSum.UUID);
            GV_orderInfo.DataSource = orderInfos;
        }
        /// <summary>
        /// 获取当前用户订单信息
        /// </summary>
        public OrderSumDto GetSingleOrderSum()
        {
            //var orderSum = orderSums.OrderBy(o => o.Sequence).Skip(sequence - 1).Take(1).FirstOrDefault();
            var orderSum = orderSums.Where(o => o.RIndex == sequence).FirstOrDefault();

            var se = 0;
            //上一户
            if (sequence > 1)
            {
                se = sequence - 1;
                //orderSum.LastHouse = orderSums.OrderBy(o => o.Sequence).Skip(sequence - 2).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                orderSum.LastHouse = orderSums.Where(o => o.RIndex == se).Select(o => o.RetailerName).FirstOrDefault();

            }
            //上上户
            if (sequence > 2)
            {
                se = sequence - 2;
                //orderSum.LastLHouse = orderSums.OrderBy(o => o.Sequence).Skip(sequence - 3).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                orderSum.LastLHouse = orderSums.Where(o => o.RIndex == se).Select(o => o.RetailerName).FirstOrDefault();

            }
            //下一户
            if (sequence < count)
            {
                se = sequence + 1;
                //orderSum.NextHouse = orderSums.OrderBy(o => o.Sequence).Skip(sequence).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                orderSum.NextHouse = orderSums.Where(o => o.RIndex == se).Select(o => o.RetailerName).FirstOrDefault();

            }
            //下下户
            if (count - sequence >= 2)
            {
                se = sequence + 2;
                //orderSum.NextNHouse = orderSums.OrderBy(o => o.Sequence).Skip(sequence + 1).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                orderSum.NextNHouse = orderSums.Where(o => o.RIndex == se).Select(o => o.RetailerName).FirstOrDefault();

            }
            orderSum.LastHouse = orderSum.LastHouse ?? "";
            orderSum.LastLHouse = orderSum.LastLHouse ?? "";
            orderSum.NextHouse = orderSum.NextHouse ?? "";
            orderSum.NextNHouse = orderSum.NextNHouse ?? "";
            return orderSum;
        }

        /// <summary>
        /// 下拉框数据改变时的重新获取选项下数据数量和所有数据（由用户触发）
        /// </summary>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var item = combo_area.SelectedValue.ToString();
            var code = int.Parse(item);
            sequence = 1;
            count = orderSumAppService.GetOrderSumCount(code);
            orderSums = orderSumAppService.GetOrderSumByAreaCode(code);
            lab_areaName.Text = "";
            lab_retaName.Text = "";
            //lab_houseNum.Text = "第"+ orderSum.Sequence+"户/" + "共" + count + "户";
            lab_houseNum.Text = "第" + 0 + "户/" + "共" + 0 + "户";
            lab_num.Text = "";
            lab_lastHose.Text = "";//上一户
            lab_lastlHose.Text = "";//上上户
            lab_nextHose.Text = "";//下一户
            lab_nextnHose.Text = "";//下下户
            if (count > 0)
            {
                GetOrderSum(1);
            }
        }

        /// <summary>
        /// 上一户
        /// </summary>
        private void btn_lasthouse_Click(object sender, EventArgs e)
        {
            //var order = int.Parse(lab_areacode_hide.Text) + 1;
            if (sequence > 1)
            {
                sequence = sequence - 1;
                GetOrderSum(sequence);
            }
            else
            {
                MessageBox.Show("没有上一户了哦");
            }
        }

        private void btn_dowload_Click(object sender, EventArgs e)
        {
            btn_dowload.Visible = false;
            var result = orderSumAppService.DowloadData();
            ComboxGetValue();
            if (combo_area.SelectedValue != null)
            {
                var item = combo_area.SelectedValue.ToString();
                var code = int.Parse(item);
                count = orderSumAppService.GetOrderSumCount(code);
                orderSums = orderSumAppService.GetOrderSumByAreaCode(code);
            }
            sequence = 1;
            if (count > 0)
            {
                GetOrderSum(1);
            }
            btn_dowload.Visible = true;
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
                combo_area.DataSource = datas;
                combo_area.DisplayMember = "name";
                combo_area.ValueMember = "value";
            }
        }
        #endregion

        #region 开始工作

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 订单初始化

        private void Workbench_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“identifyDBDataSet.OrderInfo”中。您可以根据需要移动或删除它。
            //this.orderInfoTableAdapter.Fill(this.identifyDBDataSet.OrderInfo);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_init_Click(object sender, EventArgs e)
        {
            foreach (var item in orderInfos)
            {
                item.Matched = 0;
                item.Unmatched = item.Num;
            }
            GV_orderInfo.DataSource = orderInfos;
        }

        public void GreateTable()
        {
            //显示table显示高度
            //var maxHeight = 10 * GV_orderInfo.RowTemplate.Height + GV_orderInfo.ColumnHeadersHeight;
            //var nowHeignt = GV_orderInfo.Rows.Count * GV_orderInfo.RowTemplate.Height + GV_orderInfo.ColumnHeadersHeight;
            //GV_orderInfo.Height = nowHeignt > maxHeight ? maxHeight : nowHeignt;
            //GV_orderInfo.AllowUserToAddRows = false;
        }

        #endregion
    }

}
