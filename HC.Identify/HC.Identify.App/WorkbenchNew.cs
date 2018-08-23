using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application;
using HC.Identify.Application.Identify;
using HC.Identify.Application.VisionPro;
using HC.Identify.Dto.Identify;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HC.Identify.App.Main;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.App
{
    public partial class WorkbenchNew : Form
    {
        public Main MainForm;
        //定义全局服务
        private OrderSumAppService orderSumAppService;
        private OrderInfoAppService orderInfoAppService;
        private SystemConfigAppService systemConfigAppService;
        private VisionProAppService visionProAppService;

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
        }

        #region 页面事件

        //初始化数据和服务
        private void WorkbenchNew_Load(object sender, EventArgs e)
        {
            InitServices();         //初始化服务
            GetSystemConfig();      //获取系统配置
            InitZRSocketClient();   //初始化中软通讯
            InitAeareLine();        //初始化批次信息

            BindOrderMatchResult();
            InitFrame();
            InitReadCodeSocketClient(); //初始化读码通讯   
        }

        //关闭
        private void WorkbenchNew_FormClosing(object sender, FormClosingEventArgs e)
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
        int CurrentHouseNum = 1;
        int CurrentOrderSumCount = 0;

        /// <summary>
        /// 线路初始化
        /// </summary>
        private void InitAeareLine()
        {
            BindAareaLineData();
            GetHoseListByLine();
            ShowCurrentAareaLine();
            ShowHouseInfo();
            //获取第一个线路的订单列表
            GetOrderListByLineCode();
            //绑定默认一户的订单信息
            BindOrderList();
        }

        /// <summary>
        /// 下载批次数据
        /// </summary>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.btnDownload.Enabled = false;
            //还没处理下载是否成功的结果
            orderSumAppService.DowloadData();
            //初始化
            InitAeareLine();
            this.btnDownload.Enabled = true;
        }

        /// <summary>
        /// 根据当前选择线路获取它的户数信息
        /// </summary>
        private void GetHoseListByLine()
        {
            if (ddlAareaLine.SelectedValue != null)
            {
                int areaCode = (int)ddlAareaLine.SelectedValue;
                OrderSumList = orderSumAppService.GetOrderSumByAreaCode(areaCode);
                CurrentOrderSumCount = OrderSumList.Count();
            }
        }

        /// <summary>
        /// 绑定批次信息
        /// </summary>
        private void BindAareaLineData()
        {
            var datas = orderSumAppService.GetAreaList();
            if (datas.Count > 0)
            {
                ddlAareaLine.DataSource = datas;
                ddlAareaLine.DisplayMember = "name";
                ddlAareaLine.ValueMember = "value";
            }
        }

        /// <summary>
        /// 设置当前批次信息
        /// </summary>
        private void ShowCurrentAareaLine()
        {
            if (CurrentOrderSumCount > 0)
            {
                var orderSum = OrderSumList.Where(o => o.RIndex == CurrentHouseNum).First();
                labAareaLineName.Text = orderSum.AreaName; //线路
                labRetaName.Text = orderSum.RetailerName;  //客户
                OrderTotalNum = orderSum.Num.Value;
                labOrderTotalNum.Text = OrderTotalNum.ToString(); //订单总量
                labHouseNum.Text = "第" + CurrentHouseNum + "户/" + "共" + CurrentOrderSumCount + "户"; //户数
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
            labNextHouse.Text = nextRetailerName.Length > 5 ? nextRetailerName.Substring(0, 5) + "..." : nextRetailerName; ;//下一户
            labNextNHouse.Text = nextNRetailerName.Length > 5 ? nextNRetailerName.Substring(0, 5) + "..." : nextNRetailerName; ;//下下户
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        private void SwitchHouse(SwitchEnum switchEnum)
        {
            if (switchEnum == SwitchEnum.上一户)
            {
                CurrentHouseNum--;
            }
            else
            {
                CurrentHouseNum++;
            }
            //刷新批次信息
            GetHoseListByLine();
            //刷新户数信息
            ShowHouseInfo();
            //重新绑定订单信息
            BindOrderList();
            //清理订单匹配结果
            ClearOrderMatchResult();
        }

        /// <summary>
        /// 上一户
        /// </summary>
        private void btnPreviousHouse_Click(object sender, EventArgs e)
        {
            if (CurrentHouseNum > 1)
            {
                SwitchHouse(SwitchEnum.上一户);
            }
            else
            {
                MessageBox.Show("没有上一户了哦");
            }
        }

        /// <summary>
        /// 下一户
        /// </summary>
        private void btnNextHouse_Click(object sender, EventArgs e)
        {
            if (CurrentHouseNum < CurrentOrderSumCount)
            {
                SwitchHouse(SwitchEnum.下一户);
            }
            else
            {
                MessageBox.Show("没有下一户了哦");
            }
        }

        /// <summary>
        /// 选择线路
        /// </summary>
        private void ddlAareaLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetHoseListByLine();
            ShowCurrentAareaLine();
            ShowHouseInfo();
            //重新获取订单信息
            BindOrderList();
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
        /// 根据线路获取订单列表
        /// </summary>
        private void GetOrderListByLineCode()
        {
            if (ddlAareaLine.SelectedValue != null)
            {
                int areaCode = (int)ddlAareaLine.SelectedValue;
                LineOrderList = orderInfoAppService.GetOrderInfoByLineCode(areaCode);
            }
        }

        /// <summary>
        /// 绑定订单数据
        /// </summary>
        private void BindOrderList()
        {
            var orderSum = OrderSumList.Where(o => o.RIndex == CurrentHouseNum).FirstOrDefault();
            if (orderSum != null)
            {
                CurrentOrderList = LineOrderList.Where(o => o.UUID == orderSum.UUID).ToList();
                gvOrderInfo.DataSource = CurrentOrderList;
            }
        }

        /// <summary>
        /// 订单初始化
        /// </summary>
        private void btnOrderInit_Click(object sender, EventArgs e)
        {
            foreach (var item in CurrentOrderList)
            {
                item.Matched = 0;
            }
            OrderCheckedNum = 0;
            RefreshOrderSummary();
        }

        /// <summary>
        /// 刷新订单检测数据
        /// </summary>
        private void RefreshOrderSummary()
        {
            //订单数据
            this.labOrderCheck.Text = OrderCheckedNum.ToString();                 //已检数
            this.labOrderNotCheck.Text = (OrderTotalNum - OrderCheckedNum).ToString(); //未检数
        }

        /// <summary>
        /// 匹配订单信息
        /// </summary>
        private OrderInfoMatchResult MatchOrderBrand(string brand)
        {
            var result = new OrderInfoMatchResult();
            var orderinfo = CurrentOrderList.Where(o => o.Brand == brand).FirstOrDefault();

            if (orderinfo != null)
            {
                result.IsExists = true;
                OrderCheckedNum++;      //订单已检量
                orderinfo.Matched++;    //订单商品已检数
                if (true) //...当选中订单列表需要刷新...
                {
                    gvOrderInfo.Refresh();
                }
            }

            return result;
        }

        #endregion

        #region 匹配订单结果

        IList<OrderInfoMatchRe> OrderMatchResult = new List<OrderInfoMatchRe>();

        /// <summary>
        /// 绑定订单匹配结果
        /// </summary>
        private void BindOrderMatchResult()
        {
            this.gvMatchResult.DataSource = OrderMatchResult;
        }

        /// <summary>
        /// 清理匹配结果
        /// </summary>
        private void ClearOrderMatchResult()
        {
            OrderMatchResult.Clear();
            BindOrderMatchResult();
            this.gvMatchResult.Refresh();
        }

        /// <summary>
        /// 更新匹配订单列表
        /// </summary>
        private void UpdateMatchOrderList(OrderInfoDto orderInfo)
        {
            OrderMatchResult.Add(new OrderInfoMatchRe()
            {
                Id = orderInfo.Id,
                Brand = orderInfo.Brand,
                MatchStatus = "OK",
                Specification = orderInfo.Specification,
                MatchTime = DateTime.Now.ToString("HH:mm ss")
            });
            //注意：需要验证刷新可行性
            this.gvMatchResult.Refresh();
        }

        #endregion

        #region 相机识别

        ICogAcqFifo icogAcqFifo;  //获取数据
        //图像识别结果
        string ImgBrand;
        int IdentifyTotal = 0;//识别总数
        int IdentifyNum = 0;  //已识别

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
                icogAcqFifo.OwnedExposureParams.Exposure = 0.5;
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
                icogAcqFifo.OwnedExposureParams.Exposure = 0.5;
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
            this.lblIdentifiedRate.Text = (IdentifyTotal == 0 ? string.Empty : (Math.Round((double)IdentifyNum / IdentifyTotal, 2) * 100).ToString() + "%");
        }

        /// <summary>
        /// 订单匹配结果
        /// </summary>
        private void MatchResult(string brand)
        {
            if (this.MainForm.RunStatus == RunStatusEnum.Running)
            {
                IdentifyTotal++; //识别总数+1
                if (string.IsNullOrEmpty(brand))//不匹配结果保存异常图片
                {
                    RefreshMatchResult(string.Empty, string.Empty, "未匹配模板", Color.Red);
                    MatchStopDebugControl();
                }
                else
                {
                    IdentifyNum++; //已识别 + 1
                    //显示识别结果
                    this.txtSpecHistry.AppendText(string.Format("[{0}]:{1}\r\n", DateTime.Now.ToString("HH:mm ss"), brand));
                    //如识别到 判断当前订单是否存在该商品
                    //CommHelper.WriteLog(_appPath, "最终读取结果：", photoRe);
                    var result = MatchOrderBrand(brand);
                    if (result.IsExists)//匹配正常
                    {
                        if (result.OrderInfo.Num > result.OrderInfo.Matched)//订单总数 > 订单匹配数
                        {
                            RefreshMatchResult(brand, result.OrderInfo.Specification, "匹配成功", Color.Green);
                            //发送中软匹配成功
                            ZRSocketSend(brand);
                            //更新匹配结果
                            UpdateMatchOrderList(result.OrderInfo);
                            //刷新订单检测量
                            RefreshOrderSummary();
                        }
                        else
                        {
                            RefreshMatchResult(brand, result.OrderInfo.Specification, "匹配已满", Color.Red);
                            MatchStopDebugControl();
                        }
                    }
                    else //当前订单不存在
                    {
                        RefreshMatchResult(brand, string.Empty, "订单不存在", Color.Red);
                        MatchStopDebugControl();
                    }
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
                    threadReadCode.IsBackground = true;
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
        /// 接收读码结果
        /// </summary>
        private void ReceiveReadCode()
        {
            DateTime benginDate;
            DateTime endDates;
            string brand;
            while (true)
            {
                benginDate = DateTime.Now;
                var readCode = readCodeSocketClient.Recive();
                var token = readCode.Split(new string[] { "|" }, StringSplitOptions.None);
                switch (token[0])
                {
                    case "Exit":
                        readCodeSocketClient.IsConnection = false;
                        readCodeSocketClient.Close();
                        break;
                    case "Chat":
                        //BeginInvoke(New EventHandler(AddressOf tmAddInfo), tokens(1));  //Invoke保证线程安全
                        break;
                }

                //CommHelper.WriteLog(_appPath, "扫码器读取条码：", scanRe);
                if (readCode.ToString().Length == 13)//如果读取的是13位条码信息
                {
                    brand = readCode;
                }
                else //否则取图像结果
                {
                    if (SystemConfig[ConfigEnum.图像].IsAction)
                    {
                        Thread.Sleep(50);//注意:需要加配置 
                        brand = ImgBrand;
                    }
                    else
                    {
                        brand = null;
                    }
                }
                endDates = DateTime.Now;
                Invoke(new MethodInvoker(delegate ()//线程安全
                {
                    lblIdentifyTime.Text = (endDates - benginDate).Milliseconds.ToString() + "ms";
                    MatchResult(brand);
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
                    visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay);
                    this.MainForm.SetFrameStatus(FrameStatusEnum.Connected);
                }
            }
            else
            {
                this.MainForm.SetFrameStatus(FrameStatusEnum.NotEnabled);
            }
        }

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
                benginDate = DateTime.Now;
                var csvSpec = visionProAppService.GetMatchSpecification(out cogResultArray);//获取匹配结果
                endDate = DateTime.Now;
                if (csvSpec == null)
                {
                    visionProAppService.SaveImage();//保存没有匹配到模板的图片
                    MatchResult(null);
                    //photoRe = "相机未匹配到模板" + "," + DateTime.Now;
                }
                else
                {
                    ImgBrand = csvSpec.Specification;
                    if (!SystemConfig[ConfigEnum.读码].IsAction)//如果读码没有启用直接匹配
                    {
                        MatchResult(ImgBrand);
                        ImgBrand = null;
                        lblIdentifyTime.Text = (endDate - benginDate).Milliseconds.ToString() + "ms";
                    }
                }
                //CommHelper.WriteLog(_appPath, "最终读取结果：", photoRe);   
            }
            catch (CogException ce)
            {
                MessageBox.Show("The following error has occured\n" + ce.Message);
            }
        }

        #endregion

        #endregion

      
    }
}
