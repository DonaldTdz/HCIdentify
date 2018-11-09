using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application;
using HC.Identify.Application.Helpers;
using HC.Identify.Application.Identify;
using HC.Identify.Application.Ksecpick;
using HC.Identify.Application.VisionPro;
using HC.Identify.Dto.Common;
using HC.Identify.Dto.Identify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HC.Identify.App.Main;
using static HC.Identify.Core.Identify.IdentifyEnum;
namespace HC.Identify.App
{
    public partial class WorkbenchNew : FormMainChildren   //Form 
    {
        public Main MainForm;
        //定义全局服务
        private OrderSumAppService orderSumAppService;
        private OrderInfoAppService orderInfoAppService;
        private SystemConfigAppService systemConfigAppService;
        private VisionProAppService visionProAppService;
        private OrderSmokeSeqAppService orderSmokeSeqAppService;
        private KsecOrderInfoAppService ksecOrderInfoAppService;
        CommHelper helper = new CommHelper(System.Windows.Forms.Application.StartupPath, "",false);//日志
        /// <summary>
        /// 算法配置路径
        /// </summary>
        public static string VppPath
        {
            get
            {
                return string.Format("{0}\\TB_Set.Vpp", Directory.GetCurrentDirectory());
            }
        }

        public WorkbenchNew()
        {
            InitializeComponent();
        }

        public WorkbenchNew(Main mainForm)
        {
            InitializeComponent();
            this.MainForm = mainForm;
            InitServices();         //初始化服务
            GetSystemConfig();      //获取系统配置
            InitZRSocketClient();   //初始化中软通讯
            InitFrame();
            InitReadCodeSocketClient(); //初始化读码通讯
            DownLoadOrderFromKsec();//实时订单
            Thread.Sleep(4000);//等待线程获取订单信息--实时订单
            InitAeareLine();        //初始化批次信息
            BindOrderMatchResult();
            RefreshIdentifyData();//初始化识别数据
            //ReadCodeCountConnect();//测试读码次数
        }

        #region 页面事件

        //初始化数据和服务
        private void WorkbenchNew_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void WorkbenchNew_FormClosed(object sender, FormClosedEventArgs e)
        {
            //断开图像相机连接
            if (icogAcqFifo != null)
            {
                icogAcqFifo.Flush();
                icogAcqFifo.FrameGrabber.Disconnect(false);
            }
            //断开识别相机连接
            if (zrSocketClient != null)
            {
                zrSocketClient.Close();
            }
            //断开中软连接
            if (readCodeSocketClient != null)
            {
                readCodeSocketClient.Close();
            }
        }

        /// <summary>
        /// 启动运行
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.MainForm.FrameStatus != FrameStatusEnum.Connected && this.MainForm.ScannerStatus != FrameStatusEnum.Connected)
            {
                MessageBox.Show("请至少启用一种识别相机再试");
                return;
            }

            if (this.MainForm.RunStatus == RunStatusEnum.Running)
            {
                StopRun();
            }
            else
            {
                StartRun();
            }
        }

        #endregion

        #region 初始化

        //初始化服务
        private void InitServices()
        {
            orderSumAppService = new OrderSumAppService();
            orderInfoAppService = new OrderInfoAppService();
            systemConfigAppService = new SystemConfigAppService();
            orderSmokeSeqAppService = new OrderSmokeSeqAppService();
            ksecOrderInfoAppService = new KsecOrderInfoAppService();//从昆船获取数据
            
        }

        #endregion

        #region 配置信息

        Dictionary<ConfigEnum, SystemConfigDto> SystemConfig { get; set; }

        private void GetSystemConfig()
        {
            SystemConfig = systemConfigAppService.GetAllConfig().ToDictionary(k => k.Code, v => v);
        }

        #endregion

        #region 中软通讯
        //中软通讯Socket
        SocketClient zrSocketClient;

        //初始化中软通讯socket
        private void InitZRSocketClient()
        {
            var config = SystemConfig[ConfigEnum.中软];
            if (config.IsAction)//查看配置是否启用
            {
                zrSocketClient = new SocketClient(config.Value, int.Parse(config.AdditiValue), config.IsAction);
                zrSocketClient.Open();
                if (zrSocketClient.IsConnection)
                {
                    this.MainForm.SetZRStatus(FrameStatusEnum.Connected);
                }
                else
                {
                    this.MainForm.SetZRStatus(FrameStatusEnum.NoConnected);
                }
            }
            else
            {
                this.MainForm.SetZRStatus(FrameStatusEnum.NotEnabled);
            }
        }

        /// <summary>
        /// 发送消息给中软
        /// </summary>
        private void ZRSocketSend(string data)
        {
            var config = SystemConfig[ConfigEnum.中软];
            if (config.IsAction)//查看配置是否启用
            {
                zrSocketClient.Send(data);
            }
        }

        #endregion

        #region 批次信息

        IList<OrderSumDto> OrderSumList { get; set; }
        OrderInfoSum orderInfoSum = new OrderInfoSum();//用于实时订单
        int CurrentHouseNum = 1;//当前户数
        int CurrentOrderSumCount = 0;//当前线路总户数
        int CurrentJobNum = 1;
        int minIndex = 1;
        int maxIndex = 1;
        Thread threadDownLoad = null;
        /// <summary>
        /// 线路初始化
        /// </summary>
        private void InitAeareLine()
        {
            ShowCurrentAareaLine();
            //ShowHouseInfo();//固定订单
            //绑定默认一户的订单信息
            BindOrderList();
            //初始化订单检测数据
            InitOrderSummary();
        }

        /// <summary>
        /// 从昆船下载数据
        /// </summary>
        public void DownLoadOrderFromKsec()
        {
            threadDownLoad = new Thread(DownLoadOrderInfoThread);
            threadDownLoad.IsBackground = true;
            //启动获取订单信息的线程
            threadDownLoad.Start();
        }
        /// <summary>
        /// 循环获取订单信息
        /// </summary>
        public void DownLoadOrderInfoThread()
        {
            orderInfoSum = new OrderInfoSum();
            LineOrderList = new List<OrderInfoDto>();//实例化
            OrderSumList = new List<OrderSumDto>();//实例化
            while (true)
            {
                if (maxIndex - CurrentJobNum <= 10)
                {
                    //线路下的订单信息
                    var startNum = OrderSumList.Count > 0 ? (int)OrderSumList.Max(o => o.RIndex) : 0;
                    GetOrderInfo(startNum, 10);
                    Thread.Sleep(100);
                }
            }
        }
        /// <summary>
        /// 获取线路下的订单信息
        /// </summary>
        /// <param name="startNum">获取订单的其实位置</param>
        /// <param name="getNum">获取订单数量</param>
        public void GetOrderInfo(int startNum, int getNum)
        {
            orderInfoSum = ksecOrderInfoAppService.GetOrderInfoSum(startNum, SystemConfig[ConfigEnum.分拣线路].Value, getNum);
            //线路下的订单信息
            foreach (var item in orderInfoSum.OrderInfoList)
            {
                LineOrderList.Add(item);
            }
            foreach (OrderSumDto item in orderInfoSum.OrderSum)
            {
                OrderSumList.Add(item);
            }
            minIndex = OrderSumList.Count > 0 ? (int)OrderSumList.Min(o => o.RIndex):1;
            maxIndex = OrderSumList.Count > 0 ? (int)OrderSumList.Max(o => o.RIndex):1;
            CurrentOrderSumCount = OrderSumList != null ? OrderSumList.Count : 0;
        }


        /// <summary>
        /// 设置当前批次信息
        /// </summary>
        private void ShowCurrentAareaLine()
        {
            if (CurrentOrderSumCount > 0)
            {
                #region 实时订单
                var orderSum = OrderSumList.Where(o => o.RIndex == CurrentJobNum).First();
                labAareaLineName.Text = orderSum.AreaName; //线路
                labRetaName.Text = orderSum.RetailerName;  //客户
                OrderTotalNum = orderSum.Num.Value;
                labOrderTotalNum.Text = OrderTotalNum.ToString(); //订单总量
                labHouseNum.Text = CurrentJobNum.ToString(); //户数
                labReCode.Text = orderSum.RetailerCode;//客户编码
                labBatch.Text = orderSum.Batch;//批次
                proBarCheck.Maximum = OrderTotalNum;//已检量进度条总数
                proBarCheck.Value = 0;
                #endregion
            }
        }

        /// <summary>
        /// 显示户数信息
        /// </summary>
        private void ShowHouseInfo()
        {
            var seq = 0;
            string lastRetailerName = string.Empty;
            string lastLRetailerName = string.Empty;
            string nextRetailerName = string.Empty;
            string nextNRetailerName = string.Empty;
            //上一户
            if (CurrentHouseNum > 1)
            {
                seq = CurrentHouseNum - 1;
                lastRetailerName = OrderSumList.Where(o => o.RIndex == seq).Select(o => o.RetailerName).FirstOrDefault();
                lastRetailerName = lastRetailerName ?? string.Empty;

            }
            //上上户
            if (CurrentHouseNum > 2)
            {
                seq = CurrentHouseNum - 2;
                lastLRetailerName = OrderSumList.Where(o => o.RIndex == seq).Select(o => o.RetailerName).FirstOrDefault();
                lastLRetailerName = lastLRetailerName ?? string.Empty;

            }
            //下一户
            if (CurrentHouseNum < CurrentOrderSumCount)
            {
                seq = CurrentHouseNum + 1;
                nextRetailerName = OrderSumList.Where(o => o.RIndex == seq).Select(o => o.RetailerName).FirstOrDefault();
                nextRetailerName = nextRetailerName ?? string.Empty;
            }
            //下下户
            if (CurrentOrderSumCount - CurrentHouseNum >= 2)
            {
                seq = CurrentHouseNum + 2;
                nextNRetailerName = OrderSumList.Where(o => o.RIndex == seq).Select(o => o.RetailerName).FirstOrDefault();
                nextNRetailerName = nextNRetailerName ?? string.Empty;
            }
            labLastHose.Text = lastRetailerName.Length > 5 ? lastRetailerName.Substring(0, 5) + "..." : lastRetailerName;//上一户
            labLastlHose.Text = lastLRetailerName.Length > 5 ? lastLRetailerName.Substring(0, 5) + "..." : lastLRetailerName;//上上户
            labNextHouse.Text = nextRetailerName.Length > 5 ? nextRetailerName.Substring(0, 5) + "..." : nextRetailerName; //下一户
            labNextNHouse.Text = nextNRetailerName.Length > 5 ? nextNRetailerName.Substring(0, 5) + "..." : nextNRetailerName; //下下户
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        private void SwitchHouse(SwitchEnum switchEnum, BurstModeEnum burstModeEnum, bool isPosition = false)
        {
            if (this.MainForm.RunStatus != RunStatusEnum.Running || (this.MainForm.RunStatus == RunStatusEnum.Running && burstModeEnum == BurstModeEnum.自动))
            {
                //定位情况的切户
                if (isPosition)
                {
                    //刷新当前户数信息
                    ShowCurrentAareaLine();
                    //刷新户数信息--固定订单
                    //ShowHouseInfo();
                    //重新绑定订单信息
                    BindOrderList();
                    //清理订单匹配结果
                    ClearOrderMatchResult();
                    //初始化订单检测数据
                    InitOrderSummary();
                }
                else
                {
                    if (OrderTotalNum == OrderCheckedNum || OrderCheckedNum == 0)
                    {
                        if (switchEnum == SwitchEnum.上一户)
                        {
                            CurrentJobNum--;//实时订单
                        }
                        else
                        {
                            CurrentJobNum++;//实时订单
                            //当处理的订单数大于10时删除已处理的订单10条
                            if (CurrentJobNum - minIndex > 10)
                            {
                                var reorderInfos = OrderSumList.Where(o => o.RIndex < CurrentJobNum).Take(10).ToList();
                                var uuidList = reorderInfos.Select(s => s.UUID).ToList();
                                var lineOrders = LineOrderList.Where(l => uuidList.Contains(l.UUID)).ToList();
                                foreach (var item in lineOrders)
                                {
                                    LineOrderList.Remove(item);
                                }
                                foreach (var item in reorderInfos)
                                {
                                    OrderSumList.Remove(item);
                                }
                            }
                            minIndex = (int)OrderSumList.Min(o => o.RIndex);
                            maxIndex = (int)OrderSumList.Max(o => o.RIndex);

                        }
                        //刷新当前户数信息
                        ShowCurrentAareaLine();
                        //刷新户数信息--固定订单
                        //ShowHouseInfo();
                        //重新绑定订单信息
                        BindOrderList();
                        //清理订单匹配结果
                        ClearOrderMatchResult();
                        //初始化订单检测数据
                        InitOrderSummary();
                    }
                    else
                    {
                        ZRSocketSend("NG");//socket通信
                        MessageBox.Show("当前用户订单未处理完！！！,无法切换");
                    }
                }
            }
            else
            {
                MessageBox.Show("运行状态不能手动切换用户！！！");
            }
        }

        /// <summary>
        /// 上一户
        /// </summary>
        private void btnPreviousHouse_Click(object sender, EventArgs e)
        {
            #region 实时订单
            if (CurrentJobNum - 1 >= minIndex)
            {
                SwitchHouse(SwitchEnum.上一户, BurstModeEnum.手动);
            }
            else if (CurrentJobNum == 1)
            {
                MessageBox.Show("已经是第一户了哦");
            }
            else
            {
                MessageBox.Show("没有上一户了哦，可尝试使用户定位");
            }

            #endregion
        }

        /// <summary>
        /// 下一户
        /// </summary>
        private void btnNextHouse_Click(object sender, EventArgs e)
        {

            #region 实时订单
            if (CurrentJobNum + 1 <= maxIndex)
            {
                SwitchHouse(SwitchEnum.下一户, BurstModeEnum.手动);
            }
            else
            {
                MessageBox.Show("已经是最后一户了哦");
            }
            #endregion
        }


        #endregion

        #region 用户定位
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var search = txtJobNum.Text;
            var orderInfo = ksecOrderInfoAppService.GetSingleRetailerOrderInfo(search, SystemConfig[ConfigEnum.分拣线路].Value);
            if (orderInfo.Count > 0)
            {
                var retailer = orderInfo.FirstOrDefault();
                retailer.orderqty = orderInfo.Sum(o => o.orderqty);
                var index = (int)retailer.IndexNum;
                UserOfPositioning form = new UserOfPositioning(retailer);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    if (index < minIndex || index > maxIndex || maxIndex - index <= 10)
                    {
                        LineOrderList.Clear();
                        OrderSumList.Clear();
                        GetOrderInfo(index - 1, 10);
                    }
                    CurrentJobNum = (int)index;//户号
                    SwitchHouse(SwitchEnum.下一户, BurstModeEnum.手动, true);//第一个参数任何值都可（此时无作用）
                    if (!string.IsNullOrEmpty(form.serialNum))
                    {
                        orderSquence = int.Parse(form.serialNum);
                        //根据定位的烟序来更新此户的订单列表的已匹配值
                        if (CurrentOrderList.Count > 0)
                        {
                            foreach (var item in CurrentOrderList)
                            {
                                if (item.endSeq < orderSquence)
                                {
                                    item.Matched = item.Num;
                                }
                                if (item.beginSeq <= orderSquence && orderSquence <= item.endSeq)
                                {
                                    item.Matched = orderSquence - item.beginSeq;
                                }
                            }
                        }
                    }
                    OrderCheckedNum = orderSquence - 1;
                    RefreshOrderSummary();
                }
            }
            else
            {
                MessageBox.Show("该任务号无订单信息，请确认任务号无误！！！");
            }
        }
        #endregion

        #region 订单信息

        /// <summary>
        /// 每条线路的订单数据
        /// </summary>
        IList<OrderInfoDto> LineOrderList { get; set; }

        /// <summary>
        /// 当前订单列表
        /// </summary>
        IList<OrderInfoDto> CurrentOrderList { get; set; }

        int OrderCheckedNum = 0; //订单已检数量
        int OrderTotalNum = 0;   //订单总量


        /// <summary>
        /// 绑定订单数据
        /// </summary>
        private void BindOrderList()
        {
            #region 实时订单
            if (LineOrderList.Count > 0)
            {
                var orderSum = OrderSumList.Where(o => o.RIndex == CurrentJobNum).FirstOrDefault();
                CurrentOrderList = LineOrderList.Where(o => o.UUID == orderSum.UUID).OrderBy(o => o.Sequence).ToList();
                int beginSeq = 1;
                if (CurrentOrderList.Count > 0)
                {
                    foreach (var item in CurrentOrderList)
                    {
                        item.beginSeq = beginSeq;
                        item.endSeq = beginSeq + item.Num - 1;
                        beginSeq += item.Num.Value;
                    }
                }
                else
                {
                    MessageBox.Show("改用户不存在订单信息！！");
                }
                gvOrderInfo.DataSource = CurrentOrderList;
                labJobNum.Text = orderSum.JobNum;
            }
            #endregion
        }

        /// <summary>
        /// 订单初始化
        /// </summary>
        private void btnOrderInit_Click(object sender, EventArgs e)
        {
            if (this.MainForm.RunStatus != RunStatusEnum.Running)
            {
                foreach (var item in CurrentOrderList)
                {
                    item.Matched = 0;
                }
                proBarCheck.Value = 0;//初始化进度条
                OrderCheckedNum = 0;
                gvOrderInfo.Refresh();
                //初始化订单检测数据
                InitOrderSummary();
                //清空匹配结果
                ClearOrderMatchResult();
            }
            else
            {
                MessageBox.Show("运行状态不能初始化订单哟！！！");
            }

        }

        /// <summary>
        /// 刷新订单检测数据
        /// </summary>
        private void RefreshOrderSummary()
        {
            //订单数据
            this.labOrderCheck.Text = OrderCheckedNum.ToString();                 //已检数
            this.labOrderNotCheck.Text = (OrderTotalNum - OrderCheckedNum).ToString(); //未检数
            proBarCheck.Value = OrderCheckedNum;//进度条
            labCheckRate.Text = OrderTotalNum == 0 ? "0%" : (Math.Round((double)OrderCheckedNum / OrderTotalNum, 2) * 100).ToString() + "%";//订单检测数据比例
        }


        /// <summary>
        /// 初始化订单检测数据
        /// </summary>
        private void InitOrderSummary()
        {
            OrderCheckedNum = 0;//已检数

            this.labOrderCheck.Text = OrderCheckedNum.ToString();                 //已检数
            this.labOrderNotCheck.Text = (OrderTotalNum - OrderCheckedNum).ToString();//未检数
            labCheckRate.Text = OrderTotalNum == 0 ? "0%" : (Math.Round((double)OrderCheckedNum / OrderTotalNum, 2) * 100).ToString() + "%";//订单检测数据比例
        }


        /// <summary>
        /// 匹配订单信息
        /// </summary>
        private OrderInfoMatchResult MatchOrderBrand(string brand)
        {
            var result = new OrderInfoMatchResult();
            result.OrderInfo = CurrentOrderList.Where(o => o.Brand == brand).FirstOrDefault();
            if (result.OrderInfo != null)
            {
                result.IsExists = true;
            }
            return result;
        }
        /// <summary>
        /// 选择订单明细选项卡时刷新订单信息列表
        /// </summary>
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage2)
            {
                gvOrderInfo.Refresh();
            }
        }

        #endregion

        #region 匹配订单结果

        List<OrderInfoMatchRe> OrderMatchResult = new List<OrderInfoMatchRe>();
        int orderSquence = 1;//订单顺序 (按落烟顺序匹配)
        /// <summary>
        /// 绑定订单匹配结果
        /// </summary>
        private void BindOrderMatchResult()
        {
            this.gvMatchResult.DataSource = OrderMatchResult;
        }

        /// <summary>
        /// 设置匹配列表的背景颜色
        /// </summary>
        private void gvMatchResult_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= gvMatchResult.Rows.Count)
                return;
            DataGridViewRow dgr = gvMatchResult.Rows[e.RowIndex];
            try
            {
                if (dgr.Cells["Match"].Value.ToString() == "OK")   //列名是dataGridView中的列的Name值  不是数据库中的列名
                {

                    dgr.Cells["Match"].Style.BackColor = Color.Green;
                    dgr.Cells["Match"].Style.ForeColor = Color.White;
                }
                else
                {
                    dgr.Cells["Match"].Style.BackColor = Color.Red;
                    dgr.Cells["Match"].Style.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 清理匹配结果
        /// </summary>
        private void ClearOrderMatchResult()
        {
            orderSquence = 1;
            List<OrderInfoMatchRe> orderInfoMatchResult = new List<OrderInfoMatchRe>();
            gvMatchResult.DataSource = orderInfoMatchResult;
            OrderMatchResult.RemoveRange(0, OrderMatchResult.Count);
        }

        /// <summary>
        /// 更新匹配订单列表
        /// </summary>
        private bool UpdateMatchOrderList(OrderInfoDto orderInfo)
        {
            #region 实时订单
            //测试-漏烟
            if (orderInfo == null)
            {
                List<OrderInfoMatchRe> orderInfoMatchResnul2 = new List<OrderInfoMatchRe>();
                gvMatchResult.DataSource = orderInfoMatchResnul2;
                var matchOrderInfo2 = new OrderInfoMatchRe();
                matchOrderInfo2.Id = Guid.Empty;
                matchOrderInfo2.Brand = "未识别";
                matchOrderInfo2.MatchStatus = "NG";
                matchOrderInfo2.Specification = "未识别";
                matchOrderInfo2.MatchTime = DateTime.Now.ToString("HH:mm ss");
                OrderMatchResult.Add(matchOrderInfo2);
                gvMatchResult.DataSource = OrderMatchResult;
                orderSquence++;
                return false;
            }

            var result = false;
            List<OrderInfoMatchRe> orderInfoMatchResnul = new List<OrderInfoMatchRe>();
            gvMatchResult.DataSource = orderInfoMatchResnul;
            //正式解开
            //var ngOrderInfo = OrderMatchResult.Find(o => o.MatchStatus == "NG");//清除前面NG的数据
            //OrderMatchResult.Remove(ngOrderInfo);

            //按订单顺序是否存在错烟
            var currentOrderInfo = CurrentOrderList.Where(o => o.beginSeq <= orderSquence && o.endSeq >= orderSquence).FirstOrDefault();
            var matchOrderInfo = new OrderInfoMatchRe();
            matchOrderInfo.Id = orderInfo.Id;
            matchOrderInfo.Brand = orderInfo.Brand;
            matchOrderInfo.Specification = orderInfo.Specification;
            matchOrderInfo.MatchTime = DateTime.Now.ToString("HH:mm ss");
            if (currentOrderInfo.Brand == orderInfo.Brand)
            {
                matchOrderInfo.MatchStatus = "OK";
                result = true;
                //orderSquence++;//正式解开 
            }
            else /*if(SystemConfig[ConfigEnum.调试模式].IsAction)*/
            {
                matchOrderInfo.MatchStatus = "NG";
            }
            OrderMatchResult.Add(matchOrderInfo);
            gvMatchResult.DataSource = OrderMatchResult;
            //注意：需要验证刷新可行性(不清除刷新无效<针对增加数据源的数据，只是修改数据源的数据有效>)
            this.gvMatchResult.Refresh();
            //测试使用
            orderSquence++;
            //if (currentOrderInfo.Brand == orderInfo.Brand)
            //{
            //orderSquence++;//正式解开 
            //}
            return result;
            #endregion
        }

        #endregion

        #region 相机识别

        ICogAcqFifo icogAcqFifo;  //获取数据
        //图像识别结果
        string ImgBrand;
        int IdentifyTotal = 0;//识别总数
        int IdentifyNum = 0;  //已识别
        string _appPath = System.Windows.Forms.Application.StartupPath;

        /// <summary>
        /// 停止运行
        /// </summary>
        private void StopRun()
        {
            btnStart.Text = "开始";
            this.MainForm.SetRunStatus(RunStatusEnum.Suspend);
            if (this.MainForm.FrameStatus == FrameStatusEnum.Connected)
            {
                icogAcqFifo.OwnedTriggerParams.TriggerEnabled = false;
                icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
                icogAcqFifo.Flush();
                icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Manual;
                icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
            }
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        private void StartRun()
        {
            btnStart.Text = "停止";
            this.MainForm.SetRunStatus(RunStatusEnum.Running);
            if (this.MainForm.FrameStatus == FrameStatusEnum.Connected)
            {
                ////相机外部模式（后期需验证）
                icogAcqFifo.OwnedTriggerParams.TriggerEnabled = false;
                icogAcqFifo.Flush();
                icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;
                icogAcqFifo.OwnedExposureParams.Exposure = double.Parse(SystemConfig[ConfigEnum.相机曝光度].Value);
                icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;

            }
        }

        /// <summary>
        /// 刷新匹配结果
        /// </summary>
        private void RefreshMatchResult(string brand, string spec, string matchResult, Color color)
        {
            this.lblBrandText.Text = brand;
            this.lblSpecName.Text = spec;
            this.lblSpecResult.Text = matchResult;
            this.lblSpecResult.ForeColor = color;
        }

        /// <summary>
        /// 匹配调试控制
        /// </summary>
        private void MatchStopDebugControl()
        {
            if (!SystemConfig[ConfigEnum.调试模式].IsAction)
            {
                //发送暂停指令
                ZRSocketSend("NG");
                StopRun();
            }
        }

        /// <summary>
        /// 刷新识别数据
        /// </summary>
        private void RefreshIdentifyData()
        {
            this.lblIdentifyTotal.Text = IdentifyTotal.ToString();//识别总数
            this.lblIdentifiedNum.Text = IdentifyNum.ToString();
            this.lblNoIdentifiedNum.Text = (IdentifyTotal - IdentifyNum).ToString();
            this.lblIdentifiedRate.Text = (IdentifyTotal == 0 ? string.Empty : (Math.Round((double)IdentifyNum / IdentifyTotal, 4) * 100).ToString() + "%");
        }

        bool isStop = false;//测试
        /// <summary>
        /// 订单匹配结果
        /// </summary>
        private void MatchResult(string brand, string t)
        {
            if (this.MainForm.RunStatus == RunStatusEnum.Running)
            {
                IdentifyTotal++; //识别总数+1
                OrderCheckedNum++;//订单已检量（测试专用）
                if (string.IsNullOrEmpty(brand))//不匹配结果保存异常图片
                {
                    UpdateMatchOrderList(null);
                    RefreshMatchResult(string.Empty, string.Empty, "未匹配", Color.Red);
                    MatchStopDebugControl();
                }
                else
                {
                    IdentifyNum++; //已识别 + 1
                    //显示识别结果
                    this.txtSpecHistry.AppendText(string.Format("[{0}]:{1}[{2}]\r\n", DateTime.Now.ToString("HH:mm ss"), brand, t));
                    var result = MatchOrderBrand(brand);
                    if (result.IsExists)//匹配正常
                    {
                        #region 实时订单
                        var matchRe = UpdateMatchOrderList(result.OrderInfo);
                        if (matchRe)
                        {
                            result.OrderInfo.Matched++;
                            //OrderCheckedNum++;//正式时解开
                            RefreshMatchResult(brand, result.OrderInfo.Specification, "匹配成功", Color.Green);
                            ZRSocketSend(brand);
                            RefreshOrderSummary();
                        }
                        else
                        {
                            RefreshMatchResult(brand, result.OrderInfo.Specification, "烟序错误", Color.Red);
                            MatchStopDebugControl();
                            //isStop = true;
                        }
                       
                        #endregion
                    }
                    else //当前订单不存在
                    {
                        #region 测试
                        OrderInfoDto order = new OrderInfoDto();
                        order.Brand = brand;
                        order.Specification = "订单不存在";
                        UpdateMatchOrderList(order);
                        #endregion
                        RefreshMatchResult(brand, string.Empty, "订单不存在", Color.Red);
                        MatchStopDebugControl();
                    }
                    //测试-漏烟
                    if (isStop)
                    {
                        var config = SystemConfig[ConfigEnum.图像];
                        if (this.MainForm.FrameStatus == FrameStatusEnum.Connected)
                        {
                            visionProAppService.SaveDebugImage();//保存开始出现错误的图片
                        }
                    }
                }
                //测试-漏烟
                if (OrderTotalNum == OrderCheckedNum && isStop)
                {
                    isStop = false;//
                    StopRun();
                    RefreshOrderSummary();
                    RefreshIdentifyData();
                    return;
                }
                if (OrderTotalNum == OrderCheckedNum)
                {
                    SwitchHouse(SwitchEnum.下一户, BurstModeEnum.自动);
                }
                //刷新识别数据
                RefreshIdentifyData();
            }
        }

        #region 读码识别

        //读码通讯Socket
        SocketClient readCodeSocketClient;
        Thread threadReadCode = null;

        //初始化读码通讯socket
        private void InitReadCodeSocketClient()
        {
            var config = SystemConfig[ConfigEnum.读码];
            if (config.IsAction)//查看配置是否启用
            {
                readCodeSocketClient = new SocketClient(config.Value, int.Parse(config.AdditiValue), config.IsAction);
                readCodeSocketClient.Open();
                if (readCodeSocketClient.IsConnection)
                {
                    threadReadCode = new Thread(ReceiveReadCode);
                    threadReadCode.IsBackground = true;//后台线程
                    //启动处理读码结果线程
                    threadReadCode.Start();
                    this.MainForm.SetScannerStatus(FrameStatusEnum.Connected);
                }
                else
                {
                    this.MainForm.SetScannerStatus(FrameStatusEnum.NoConnected);
                }
            }
            else
            {
                this.MainForm.SetScannerStatus(FrameStatusEnum.NotEnabled);
            }
        }
        /// <summary>
        /// 订单匹配结果增加序号
        /// </summary>
        private void gvMatchResult_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加匹配结果表序号
            foreach (DataGridViewRow dr in gvMatchResult.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
            }
        }

        /// <summary>
        /// 接收读码结果
        /// </summary>
        private void ReceiveReadCode()
        {
            DateTime benginDate;
            DateTime endDates;
            string brand;
            string t = "";
            while (true)
            {
                //benginDate = DateTime.Now;
                var readCode = readCodeSocketClient.Recive();
                benginDate = DateTime.Now;
                var token = readCode.Split(new string[] { "|" }, StringSplitOptions.None);
                switch (token[0])
                {
                    case "Exit":
                        readCodeSocketClient.IsConnection = false;
                        readCodeSocketClient.Close();
                        break;
                    case "Chat":
                        break;
                }

                var scanRe = readCode.ToString() + ",开始时间：" + benginDate.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",结束时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",用时：" + (DateTime.Now - benginDate).Milliseconds.ToString() + "ms";

                #region 日志
                helper.AddLogs(new Logs
                {
                    Title = "读码器读取条码：",
                    Msg = scanRe,
                    DateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")
                });
                #endregion
                //CommHelper.WriteLog(_appPath, "读码器读取条码：", scanRe);
                if (readCode.ToString().Length == 13)//如果读取的是13位条码信息
                {
                    t = "I";
                    brand = readCode;
                }
                else //否则取图像结果
                {
                    if (SystemConfig[ConfigEnum.图像].IsAction)
                    {
                        if (!string.IsNullOrEmpty(SystemConfig[ConfigEnum.视觉相机沉睡].Value))
                        {
                            Thread.Sleep(int.Parse(SystemConfig[ConfigEnum.视觉相机沉睡].Value));//注意:需要加配置 
                        }
                        t = "V";
                        brand = ImgBrand;
                    }
                    else
                    {
                        brand = null;
                    }
                }
                endDates = DateTime.Now;
                var endScanRe = t + "," + brand + ",开始时间：" + benginDate.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",结束时间：" + endDates.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",用时：" + (endDates - benginDate).Milliseconds.ToString() + "ms";
                #region 日志
                helper.AddLogs(new Logs
                {
                    Title = "最终读取结果：",
                    Msg = endScanRe,
                    DateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")
                });
                #endregion
                //CommHelper.WriteLog(_appPath, "最终读取结果：", endScanRe);
                Invoke(new MethodInvoker(delegate ()//线程安全
                {
                    //brand = "";
                    lblIdentifyTime.Text = (endDates - benginDate).Milliseconds.ToString() + "ms";
                    MatchResult(brand, t);
                }));
                ImgBrand = null;
                readCode = null;
                brand = null;
            }
        }

        #endregion

        #region 图像识别

        ICogImage icogColorImage;                             //图像控件
        CogToolBlock cogToolBlock = new CogToolBlock();       //图像连接工具
        ArrayList cogResultArray = new ArrayList();

        /// <summary>
        /// 相机初始化
        /// </summary>
        private void InitFrame()
        {
            if (SystemConfig[ConfigEnum.图像].IsAction)
            {
                CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
                if (mFrameGrabbers.Count == 0)
                {
                    this.MainForm.SetFrameStatus(FrameStatusEnum.NoConnected);
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
                    cogToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(VppPath);
                    visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay, double.Parse(SystemConfig[ConfigEnum.匹配值].Value));
                    this.MainForm.SetFrameStatus(FrameStatusEnum.Connected);
                }
            }
            else
            {
                this.MainForm.SetFrameStatus(FrameStatusEnum.NotEnabled);
            }
        }
        int tiggerNum = 0;
        /// <summary>
        /// 相机外部模式触发
        /// </summary>
        private void CompleteAcquire(Object sender, CogCompleteEventArgs e)
        {
            if (this.MainForm.FrameStatus != FrameStatusEnum.Connected)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(CompleteAcquire), new object[] { sender, e });
                return;
            }
            int numReadyVal;   //读取值
            int numPendingVal; //等待值
            bool busyVal;
            CogAcqInfo info = new CogAcqInfo();
            DateTime benginDate;
            DateTime endDate;
            benginDate = DateTime.Now;
            //tiggerNum++;//触发次数
            //labTrigger.Text = tiggerNum.ToString();
            try
            {
                icogAcqFifo.GetFifoState(out numPendingVal, out numReadyVal, out busyVal);
                if (numReadyVal > 0)
                {
                    icogColorImage = icogAcqFifo.CompleteAcquireEx(info);
                    cogRecordDisplay.Image = icogColorImage;
                    cogRecordDisplay.Fit(false);
                }
                visionProAppService._icogColorImage = icogColorImage;//将最新的图像传入公共服务中（图像才会更新到下一张）
                double dMaxScore;
                var currentBrands = CurrentOrderList.Where(o => o.beginSeq <= orderSquence && o.endSeq >= orderSquence).Select(o => o.Brand).ToList();//获取当前订单信息
                var csvSpec = visionProAppService.GetMatchSpecification(out cogResultArray, out dMaxScore, currentBrands);//获取匹配结果
                endDate = DateTime.Now;
                var photoRe = "";
                if (csvSpec == null)
                {
                    visionProAppService.SaveImage();//保存没有匹配到模板的图片
                    if (!SystemConfig[ConfigEnum.读码].IsAction)//如果读码没有启用直接匹配
                    {
                        MatchResult(null, null);
                        lblIdentifyTime.Text = (endDate - benginDate).Milliseconds.ToString() + "ms";
                    }
                    photoRe = "相机未匹配到模板" + ",开始时间：" + benginDate.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",结束时间" + endDate.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",用时：" + (endDate - benginDate).Milliseconds.ToString() + "ms";
                }
                else
                {
                    ImgBrand = csvSpec.Specification;
                    photoRe = csvSpec.Specification.ToString() + ",开始时间：" + benginDate.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",结束时间" + endDate.ToString("yyyy-MM-dd HH:mm:ss:ffff") + ",用时：" + (endDate - benginDate).Milliseconds.ToString() + "ms";
                    if (!SystemConfig[ConfigEnum.读码].IsAction)//如果读码没有启用直接匹配
                    {
                        MatchResult(ImgBrand, "V");
                        ImgBrand = null;
                        lblIdentifyTime.Text = (endDate - benginDate).Milliseconds.ToString() + "ms";
                    }
                }
                #region 日志
                helper.AddLogs(new Logs
                {
                    Title = "视觉读取结果：",
                    Msg = photoRe,
                    DateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff")
                });
                #endregion
                //CommHelper.WriteLog(_appPath, "视觉读取结果：", photoRe);
            }
            catch (CogException ce)
            {
                MessageBox.Show("The following error has occured\n" + ce.Message);
            }
        }

        #endregion

        #endregion

        #region 读码触发次数测试
        public Socket clientSocketC;
        public void ReadCodeCountConnect()
        {
            try
            {
                //设定服务器IP地址  
                IPAddress ip = IPAddress.Parse("192.168.0.100");//10.88.164.212
                clientSocketC = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint endPoint = new IPEndPoint(ip, 5656); // 用指定的ip和端口号初始化IPEndPoint实例 //23
                clientSocketC.Connect(endPoint);
                var threadReadCodeC = new Thread(ReadCodeCount);
                threadReadCodeC.IsBackground = true;//后台线程
                //启动处理读码结果线程
                threadReadCodeC.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败,错误信息：" + ex.Message);
            }

        }
        int codeCount = 0;
        //计算读码触发次数
        public void ReadCodeCount()
        {
            while (true)
            {
                byte[] receive = new byte[1024];
                var data = clientSocketC.Receive(receive);
                var readCode = Encoding.UTF8.GetString(receive, 0, data);
                if (this.MainForm.RunStatus == RunStatusEnum.Running)
                {
                    if (readCode.Length == 13)
                    {
                        codeCount++;
                    }
                    //线程安全
                    Invoke(new MethodInvoker(delegate ()
                    {
                        labReadCode.Text = codeCount.ToString();
                    }));
                }
            }
        }

        #endregion

        #region 写日志
        //List<Logs> logs = new List<Logs>();
        ///// <summary>
        ///// 日志线程
        ///// </summary>
        //public void LogThread()
        //{
        //    var threadLog = new Thread(WriteLog);
        //    //后台线程
        //    threadLog.IsBackground = true;
        //    //启动处理读码结果线程
        //    threadLog.Start();
        //}

        ///// <summary>
        ///// 写日志
        ///// </summary>
        //public  void WriteLog()
        //{
        //    while (true)
        //    {
        //        var LogsWr = logs;
        //        logs.RemoveRange(0, LogsWr.Count);
        //        CommHelper.WriteLogByThread(_appPath, LogsWr,"");
        //        Thread.Sleep(200);
        //    }
        //}
        #endregion


    }
}
