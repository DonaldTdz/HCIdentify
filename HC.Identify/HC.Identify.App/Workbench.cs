using Cognex.VisionPro;
using Cognex.VisionPro.Exceptions;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using HC.Identify.Application;
using HC.Identify.Application.Helpers;
using HC.Identify.Application.Identify;
using HC.Identify.Application.VisionPro;
using HC.Identify.Dto.Identify;
using HC.Identify.Dto.VisionPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
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
    public partial class Workbench : FormMainChildren            //  Form    
    {
        //定义全局主窗口 刷新状态
        public Main MainForm;
        private int sequence = 1;
        private int count = 0;//当前选项的所有打包订单信息总数
        private IList<OrderSumDto> orderSums;//当前选项的所有打包订单信息
        private OrderSumAppService orderSumAppService;
        private OrderInfoAppService orderInfoAppService;
        private VisionProAppService visionProAppService;
        private IList<OrderInfoDto> orderInfos;//当前选项的详细订单信息
        private SystemConfigAppService systemConfigAppService;
        private SystemConfigDto config;
        public IList<SystemConfigDto> configs;
        public CsvSpecification imgData;

        //扫码器
        public Thread threadScanner = null;
        SocketClient scannerSocket = null;
        public bool scanConnected = false;
        //测试
        FileSystemInfo[] fileInfos;
        int imgIndex;
        int totalImgCount = 0;
        CogImageFileTool cogImageFile = new CogImageFileTool(); //图像处理工具
        string currentrDirectory;//当前根文件夹

        COMServer cOMServer;//串口通信测试
        SocketClient socketClient;
        public bool IsConnection = false;//中软通信是否连接
        public bool ScanIsAction = false;//扫码器是否启用
        public bool isDebug = false;
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
            initCommunication();//在相机初始化（InitFrame()）之前初始化
            InitFrame(); //初始化相机
            //InitImage();//测试-图片集初始化
        }
        /// <summary>
        /// 初始化通信
        /// </summary>
        private void initCommunication()
        {
            systemConfigAppService = new SystemConfigAppService();
            configs = systemConfigAppService.GetAllConfig();
            config = configs.Where(s => s.Code == ConfigEnum.中软).FirstOrDefault();
            var deConfig = configs.Where(s => s.Code == ConfigEnum.调试模式).FirstOrDefault();
            if (deConfig != null)
            {
                isDebug = deConfig.IsAction;
            }
            #region 测试代码
            //串口测试初始化
            //cOMServer = new COMServer("COM4", 9600, 7, StopBits.One, Parity.Even);
            //cOMServer.Open();
            //Socket通信初始化
            //服务端
            //socketServer = new SocketServer();
            //socketServer.Open();
            #endregion
            //客户端
            if (config != null)
            {
                socketClient = new SocketClient(config.Value, int.Parse(config.AdditiValue), config.IsAction);
                socketClient.Open();
                if (socketClient.IsConnection)
                {
                    this.MainForm.SetZRStatus(FrameStatusEnum.Connected);
                }
                else if (socketClient.IsAction)
                {
                    this.MainForm.SetZRStatus(FrameStatusEnum.NoConnected);
                }
            }
            //else
            //{
            //    MessageBox.Show("请配置中软ip地址信息");
            //}
            var scanConfig = configs.Where(s => s.Code == ConfigEnum.读码).FirstOrDefault();
            if (scanConfig != null)
            {
                ScanIsAction = scanConfig.IsAction;//用于判断读码或相机结果匹配方法的调用位置
                if (scanConfig.IsAction)
                {
                    this.MainForm.SetScannerStatus(FrameStatusEnum.NoConnected);
                }
            }

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
                InitRunData();
            }
            GV_orderInfo.Columns[6].DefaultCellStyle.ForeColor = Color.Red;
            GV_orderInfo.Columns[5].DefaultCellStyle.ForeColor = Color.LightGreen;
            dataGrid_match.Sort(dataGrid_match.Columns[4], ListSortDirection.Descending);
        }
        #endregion

        #endregion

        #region 测试数据初始化
        /// <summary>
        /// 初始化图片模板集
        /// </summary>
        private void InitImage()
        {
            imgIndex = 0;
            var imgPath = @"D:\CodeWord\资料\视觉系统\Image0318";
            if (!string.IsNullOrEmpty(imgPath))
            {
                var imgDir = new DirectoryInfo(imgPath);
                totalImgCount = imgDir.GetFiles().Length;
                fileInfos = imgDir.GetFileSystemInfos();
            }
            if (fileInfos[imgIndex].Extension == ".bmp" || fileInfos[imgIndex].Extension == ".BMP" || fileInfos[imgIndex].Extension == ".jpg" ||
              fileInfos[imgIndex].Extension == ".JPG" || fileInfos[imgIndex].Extension == ".tif" || fileInfos[imgIndex].Extension == ".TIF")
            {
                cogImageFile.Operator.Open(fileInfos[imgIndex].FullName, CogImageFileModeConstants.Read);
                cogImageFile.Run();
                icogColorImage = cogImageFile.OutputImage;
                cogRecordDisplay.Image = icogColorImage;
                cogRecordDisplay.Fit();
            }
            currentrDirectory = Directory.GetCurrentDirectory();
            cogToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(currentrDirectory + "\\TB_Set.Vpp");
            var csvDataPath = currentrDirectory + "\\Data\\Data.csv";
            if (!File.Exists(csvDataPath))
            {
                MessageBox.Show("数据文件不存在或路径错误！");
                return;
            }
            VisionProDataAppService.Instance.CsvDataPath = csvDataPath;
            //csvSpecList = VisionProDataAppService.Instance.GetCsvSpecificationList();
            //ToolBlockRun();
            visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay);
        }
        #endregion

        #region 相机相关处理

        ICogAcqFifo icogAcqFifo;  //获取数据
        ICogImage icogColorImage; //图像控件
        CogToolBlock cogToolBlock = new CogToolBlock();       //图像连接工具

        int identifyTotal = 0;//识别总数
        int identifiedNum = 0;//已识别数
        int orderCheckNum = 0;//已检订单数
        int orderNum = 0; //订单数

        /// <summary>
        /// 相机初始化
        /// </summary>
        private void InitFrame()
        {
            var photoConfig = configs.Where(c => c.Code == ConfigEnum.图像).FirstOrDefault();
            if (photoConfig != null && photoConfig.IsAction)
            {
                CogFrameGrabbers mFrameGrabbers = new CogFrameGrabbers();
                if (mFrameGrabbers.Count == 0)
                {
                    this.MainForm.SetFrameStatus(FrameStatusEnum.NoConnected);
                }
                else//相机模式运行
                {
                    ////相机外部模式（后期需验证）
                    //icogAcqFifo.OwnedTriggerParams.TriggerEnabled = false;
                    //icogAcqFifo.Flush();
                    //icogAcqFifo.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Auto;
                    //icogAcqFifo.OwnedExposureParams.Exposure = 0.5;
                    //icogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;

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
                    currentrDirectory = Directory.GetCurrentDirectory();
                    cogToolBlock = (CogToolBlock)CogSerializer.LoadObjectFromFile(currentrDirectory + "\\TB_Set.Vpp");
                    visionProAppService = new VisionProAppService(cogToolBlock, icogColorImage, cogRecordDisplay);
                    this.MainForm.SetFrameStatus(FrameStatusEnum.Connected);
                }
            }
            else
            {
                this.MainForm.SetFrameStatus(FrameStatusEnum.NotEnabled);
            }
            if (ScanIsAction)
            {
                Scanner();
            }
        }
        ArrayList cogResultArray = new ArrayList();
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
                imgData = visionProAppService.GetMatchSpecification(out cogResultArray);//获取匹配结果
                endDate = DateTime.Now;
                #region 写日志
                var photoRe = "";
                if (imgData == null)
                {
                    visionProAppService.SaveImage();//保存没有匹配到模板的图片
                    photoRe = "相机未匹配到模板" + "," + DateTime.Now;
                }
                else
                {
                    var good = orderInfos.Where(o => o.Brand == imgData.Specification).FirstOrDefault();
                    var goName = good != null ? good.Specification : "";
                    photoRe = imgData.Specification.ToString() + "," + goName + "," + DateTime.Now;
                }
                CommHelper.WriteLog(_appPath, "最终读取结果：", photoRe);
                #endregion
                if (!ScanIsAction)
                {
                    PhotoMatch();
                    lblIdentifyTime.Text = (endDate - benginDate).Milliseconds.ToString() + "ms";
                }
            }
            catch (CogException ce)
            {
                MessageBox.Show("The following error has occured\n" + ce.Message);
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshRunData()
        {
            //识别数据
            this.lblIdentifyTotal.Text = identifyTotal.ToString();
            this.lblIdentifiedNum.Text = identifiedNum.ToString();
            this.lblNoIdentifiedNum.Text = (identifyTotal - identifiedNum).ToString();
            this.lblIdentifiedRate.Text = (identifyTotal == 0 ? string.Empty : (Math.Round((double)identifiedNum / identifyTotal, 2) * 100).ToString() + "%");

            //订单数据
            this.labOrderCheck.Text = orderCheckNum.ToString();
            this.labOrderNotCheck.Text = (orderNum - orderCheckNum).ToString();
        }

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        private void InitRunData()
        {
            orderCheckNum = 0;//已检订单数

            //识别数据
            this.lblSpecText.Text = string.Empty;
            this.lblSpecName.Text = string.Empty;
            this.lblSpecResult.Text = string.Empty;

            //订单数据
            this.labOrderCheck.Text = orderCheckNum.ToString();
            this.labOrderNotCheck.Text = (orderNum - orderCheckNum).ToString();

        }

        #endregion

        #region 用户订单
        /// <summary>
        /// 下一户
        /// </summary>
        private void btn_nexthouse_Click(object sender, EventArgs e)
        {
            if (sequence < count)
            {
                SwitchHouse(SwitchEnum.下一户);
                //sequence = sequence + 1;
                //GetOrderSum(sequence);
                //imgIndex = 0;//测试
                //InitRunData();
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
            lab_nextnHose.Text = orderSum.NextNHouse.Length > 5 ? orderSum.NextNHouse.Substring(0, 5) + "..." : orderSum.NextNHouse; ;//下下户
                                                                                                                                      //lab_areacode_hide.Text = orderSum.Sequence.ToString();
                                                                                                                                      //lab_areacode_hide.Hide();
                                                                                                                                      //获取订单信息
            orderInfos = orderInfoAppService.GetOrderInfoByUUID(orderSum.UUID);
            GV_orderInfo.DataSource = orderInfos;

            orderNum = orderSum.Num.Value;//订单总数
            orderCheckNum = orderInfos.Sum(o => o.Matched).Value;//已检订单数
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
            if (sequence > 1)
            {
                SwitchHouse(SwitchEnum.上一户);
                //sequence = sequence - 1;
                //GetOrderSum(sequence);
                //imgIndex = 0;//测试
                //InitRunData();
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
            if (this.MainForm.FrameStatus != FrameStatusEnum.Connected && this.MainForm.ScannerStatus != FrameStatusEnum.Connected)
            {
                MessageBox.Show("请至少启用一种识别相机再试");
                return;
            }
            //if (cogRecordDisplay.LiveDisplayRunning)
            //{
            //    StartRun();
            //    this.MainForm.SetRunStatus(RunStatusEnum.Running);
            //}
            //else
            //{
            //    StopRun();
            //    this.MainForm.SetRunStatus(RunStatusEnum.Suspend);
            //}
            //当读码器连接成功后启用线程
            //if (this.MainForm.ScannerStatus == FrameStatusEnum.Connected)
            //{
            //    threadScanner.Start();
            //    scanConnected = true;
            //}

            if (this.MainForm.RunStatus == RunStatusEnum.Running)
            {
                StopRun();
            }
            else
            {
                StartRun();
            }
        }

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
            //初始化页面订信息
            foreach (var item in orderInfos)
            {
                item.Matched = 0;
            }
            GV_orderInfo.DataSource = orderInfos;
            GV_orderInfo.Refresh();
            //初始化页面信息（已检量等数据初始化）
            InitRunData();
        }

        #endregion

        #region 测试
        private void btn_test_Click(object sender, EventArgs e)
        {
            //OrderMatch();
        }

        private void RunCalculation()
        {
            //OrderMatch();
        }

        #endregion
        /// <summary>
        /// 相机视觉
        /// </summary>
        private void PhotoMatch()
        {
            //identifyTotal++;//识别总数+1
            var sepec = imgData != null ? imgData.Specification : null;
            ////// 测试--正式环境需注释
            ////CheckImage();//切换图片---测试使用（最后改成相机模式切换）
            ////var sepVio = visionProAppService.GetMatchSpecification();//获取匹配结果
            ////var sepec = sepVio != null ? sepVio.Specification : null;
            MatchResult(sepec);
            imgData = null;
        }
        #region 备份
        private void OrderMatchBackUP()
        {
            identifyTotal++;//识别总数+1
            //匹配计算
            visionProAppService._icogColorImage = icogColorImage;//将最新的图像传入公共服务中（图像才会更新到下一张）

            var sepec = visionProAppService.GetMatchSpecification(out cogResultArray);//获取匹配结果
            if (sepec == null)//不匹配结果保存异常图片
            {
                visionProAppService.SaveImage();
                this.lblSpecText.Text = string.Empty;
                this.lblSpecName.Text = string.Empty;
                this.lblSpecResult.Text = "未匹配模板";
                this.lblSpecResult.ForeColor = Color.Red;
                //发送暂停指令
                //ComSeverSend("NG");//串口通信
                SocketSend("NG");//socket通信
                // .....
                if (!isDebug)
                {
                    StopRun();
                }
                this.MainForm.SetRunStatus(RunStatusEnum.Suspend);
            }
            else
            {
                identifiedNum++; //已识别 + 1
                this.txtSpecHistry.AppendText(string.Format("[{0}]:{1}\r\n", DateTime.Now.ToString("HH:mm ss"), sepec.Specification));
                this.lblSpecText.Text = sepec.Specification;
                //如识别到 判断当前订单是否存在该商品
                var goods = orderInfos.Where(o => o.Brand == sepec.Specification).FirstOrDefault();
                if (goods != null)//匹配正常
                {
                    if (goods.Num > goods.Matched)
                    {
                        this.lblSpecName.Text = goods.Specification;
                        this.lblSpecResult.Text = "匹配成功";
                        this.lblSpecResult.ForeColor = Color.Green;
                        goods.Matched++;
                        orderCheckNum++;//订单匹配总数+1
                        //发送中软匹配成功
                        //ComSeverSend(goods.Brand);//串口通信
                        SocketSend(goods.Brand);//socket通信
                                                // ......
                                                //更新订单信息的datagrid
                        orderInfos.Remove(goods);
                        goods.Matched = goods.Matched++;
                        orderInfos.Add(goods);
                        GV_orderInfo.DataSource = orderInfos;
                        GV_orderInfo.Refresh();
                    }
                    else
                    {
                        this.lblSpecName.Text = goods.Specification;
                        this.lblSpecResult.Text = "匹配已满";
                        this.lblSpecResult.ForeColor = Color.Red;
                        //发送暂停指令
                        //ComSeverSend("NG");//串口通信
                        SocketSend("NG");//socket通信
                        // ......
                        if (!isDebug)
                        {
                            StopRun();
                        }
                        this.MainForm.SetRunStatus(RunStatusEnum.Suspend);
                    }

                }
                else //当前订单不存在
                {
                    this.lblSpecName.Text = string.Empty;
                    this.lblSpecResult.Text = "订单不存在";
                    this.lblSpecResult.ForeColor = Color.Red;
                    //发送暂停指令
                    //ComSeverSend("NG");//串口通信
                    SocketSend("NG");//socket通信
                    // ......
                    if (!isDebug)
                    {
                        StopRun();
                    }
                    this.MainForm.SetRunStatus(RunStatusEnum.Suspend);
                }
            }
            RefreshRunData();
        }
        #endregion
        /// <summary>
        /// 相机读码
        /// </summary>
        public void Scanner()
        {
            var scanConfig = configs.Where(s => s.Code == ConfigEnum.读码).FirstOrDefault();
            if (scanConfig != null)
            {
                #region 原读码器通信
                //设定服务器IP地址  
                //IPAddress ip = IPAddress.Parse(scanConfig.Value);
                ////Socket串口通信
                //scannerSocket = new SocketClient(scanConfig.Value, int.Parse(scanConfig.AdditiValue), scanConfig.IsAction);
                //scannerSocket.Open();
                //scannerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(scanConfig.AdditiValue)); // 用指定的ip和端口号初始化IPEndPoint实例
                //scannerSocket.Connect(endPoint);
                #endregion

                InstantiationScan(scanConfig);
                if (scannerSocket.IsConnection)
                {
                    threadScanner = new Thread(GetScannerOfData);
                    threadScanner.IsBackground = true;
                    //启动线程
                    threadScanner.Start();
                    scanConnected = true;
                }
            }
            else
            {
                MessageBox.Show("请配置扫码器ip地址信息");
            }
        }
        string _appPath = System.Windows.Forms.Application.StartupPath;
        public void GetScannerOfData()
        {
            string[] token = { };
            DateTime benginDate;
            DateTime endDates;
            string sepec = "";
            while (true)
            {
                //byte[] receive = new byte[1024];
                //var data = scannerSocket.clientSocket.Receive(receive);
                //var sepScan = Encoding.UTF8.GetString(receive, 0, data);
                //if (scannerSocket.IsAction && scannerSocket.IsConnection && scannerSocket.clientSocket.Available <= 0) continue;
                var sepScan = scannerSocket.Recive();
                //identifyTotal++;//识别总数+1
                string[] split = { "|" };
                token = sepScan.Split(split, StringSplitOptions.None);
                switch (token[0])
                {
                    case "Exit":
                        scanConnected = false;
                        //BeginInvoke(new EventHandler(), token[1]);  // Invoke保证线程安全
                        //scannerSocket.Shutdown(SocketShutdown.Both);
                        scannerSocket.Close();
                        break;
                    case "Chat":
                        //BeginInvoke(New EventHandler(AddressOf tmAddInfo), tokens(1));  //Invoke保证线程安全
                        break;
                }
                benginDate = DateTime.Now;
                var scanGood = orderInfos.Where(o => o.Brand == sepScan).FirstOrDefault();
                var name = scanGood != null ? scanGood.Specification + "," : "";
                var scanRe = sepScan.ToString() + "," + name + DateTime.Now;
                CommHelper.WriteLog(_appPath, "扫码器读取条码：", scanRe);
                if (sepScan.ToString().Length == 13)
                {
                    sepec = sepScan;
                    endDates = DateTime.Now;
                }
                else
                {
                    Thread.Sleep(50);
                    //正式环境
                    sepec = imgData != null ? imgData.Specification : null;
                    endDates = DateTime.Now;
                }
                Invoke(new MethodInvoker(delegate ()//线程安全
                {
                    lblIdentifyTime.Text = (endDates - benginDate).Milliseconds.ToString() + "ms";
                    MatchResult(sepec);
                }));
                imgData = null;
                sepScan = null;
                sepec = null;
            }
        }


        public void ComSeverSend(string data)
        {
            var sendByte = Encoding.ASCII.GetBytes(data);
            cOMServer.Send(sendByte);
        }
        public void SocketSend(string data)
        {
            if (config != null)
            {
                socketClient.Send(data);//socket通信
            }
        }
        public void CheckImage()
        {
            if (imgIndex < totalImgCount)
            {
                if (fileInfos[imgIndex].Extension == ".bmp" || fileInfos[imgIndex].Extension == ".BMP" || fileInfos[imgIndex].Extension == ".jpg" ||
                  fileInfos[imgIndex].Extension == ".JPG" || fileInfos[imgIndex].Extension == ".tif" || fileInfos[imgIndex].Extension == ".TIF")
                {
                    cogImageFile.Operator.Open(fileInfos[imgIndex].FullName, CogImageFileModeConstants.Read);
                    cogImageFile.Run();
                    icogColorImage = cogImageFile.OutputImage;
                    if (imgIndex <= totalImgCount)
                    {
                        imgIndex++;
                    }
                    visionProAppService._icogColorImage = icogColorImage;//将最新的图像传入公共服务中（图像才会更新到下一张）
                }
            }
        }

        public List<OrderInfoMatchRe> orderInfoMatchRes = new List<OrderInfoMatchRe>();
        public void MatchResult(string sepec)
        {
            if (this.MainForm.RunStatus == RunStatusEnum.Running)
            {
                identifyTotal++;//识别总数+1
                if (sepec == null)//不匹配结果保存异常图片
                {
                    //visionProAppService.SaveImage();
                    this.lblSpecText.Text = string.Empty;
                    this.lblSpecName.Text = string.Empty;
                    this.lblSpecResult.Text = "未匹配模板";
                    this.lblSpecResult.ForeColor = Color.Red;
                    //发送暂停指令
                    //ComSeverSend("NG");//串口通信
                    SocketSend("NG");//socket通信
                                     // .....
                    if (!isDebug)
                    {
                        StopRun();
                    }
                }
                else
                {
                    identifiedNum++; //已识别 + 1
                    this.txtSpecHistry.AppendText(string.Format("[{0}]:{1}\r\n", DateTime.Now.ToString("HH:mm ss"), sepec));
                    this.lblSpecText.Text = sepec;
                    //如识别到 判断当前订单是否存在该商品
                    var goods = orderInfos.Where(o => o.Brand == sepec).FirstOrDefault();
                    var goName = goods != null ? goods.Specification + "," : "";
                    var photoRe = sepec.ToString() + "," + goName + DateTime.Now;
                    CommHelper.WriteLog(_appPath, "最终读取结果：", photoRe);
                    if (goods != null)//匹配正常
                    {
                        if (goods.Num > goods.Matched)
                        {
                            this.lblSpecName.Text = goods.Specification;
                            this.lblSpecResult.Text = "匹配成功";
                            this.lblSpecResult.ForeColor = Color.Green;
                            goods.Matched++;
                            //订单匹配总数+1
                            orderCheckNum++;
                            //发送中软匹配成功
                            //ComSeverSend(goods.Brand);//串口通信
                            SocketSend(goods.Brand);//socket通信
                            // ......
                            //更新订单信息的datagrid
                            orderInfos.Remove(goods);
                            goods.Matched = goods.Matched++;
                            orderInfos.Add(goods);
                            GV_orderInfo.DataSource = orderInfos;
                            GV_orderInfo.Refresh();

                            //更新订单匹配状况
                            var orderInfoMatchRe = new OrderInfoMatchRe();
                            orderInfoMatchRe.Id = goods.Id;
                            orderInfoMatchRe.Brand = goods.Brand;
                            orderInfoMatchRe.Specification = goods.Specification;
                            orderInfoMatchRe.MatchStatus = "OK";
                            orderInfoMatchRe.MatchTime = DateTime.Now.ToString("yy-M-d HH:mm");
                            orderInfoMatchRes.Add(orderInfoMatchRe);
                            orderInfoMatchRes.OrderByDescending(o => o.MatchTime).ToList();
                            if (dataGrid_match.DataSource != null)
                            {
                                List<OrderInfoMatchRe> orderInfoMatchResnul = new List<OrderInfoMatchRe>();
                                dataGrid_match.DataSource = orderInfoMatchResnul;
                            }
                            else
                            {
                                dataGrid_match.Rows.Clear();
                            }
                            dataGrid_match.DataSource = orderInfoMatchRes;
                            //dataGrid_match.Sort(dataGrid_match.Columns[4], ListSortDirection.Descending);
                            dataGrid_match.Refresh();
                        }
                        else
                        {
                            this.lblSpecName.Text = goods.Specification;
                            this.lblSpecResult.Text = "匹配已满";
                            this.lblSpecResult.ForeColor = Color.Red;
                            //发送暂停指令
                            //ComSeverSend("NG");//串口通信
                            SocketSend("NG");//socket通信
                                             // ......
                            if (!isDebug)
                            {
                                StopRun();
                            }
                        }

                    }
                    else //当前订单不存在
                    {
                        this.lblSpecName.Text = string.Empty;
                        this.lblSpecResult.Text = "订单不存在";
                        this.lblSpecResult.ForeColor = Color.Red;
                        //发送暂停指令
                        //ComSeverSend("NG");//串口通信
                        SocketSend("NG");//socket通信
                                         // ......
                        if (!isDebug)
                        {
                            StopRun();
                        }
                    }
                }
                RefreshRunData();
            }
        }

        private void Workbench_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {
            if (icogAcqFifo != null)
            {
                icogAcqFifo.Flush();
                icogAcqFifo.FrameGrabber.Disconnect(false);
            }
        }

        private void Workbench_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadScanner != null)
            {
                threadScanner.Abort();//终止线程
            }
            if (socketClient != null)
            {
                socketClient.IsConnection = false;
                socketClient.Close();//需要判断曾经是否连接中软
            }
            if (scannerSocket != null)
            {
                scannerSocket.IsConnection = false;
                scannerSocket.Close();//扫码器
            }
        }

        private void Workbench_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// 重新连接通信设备（已去除）
        /// </summary>
        private void btn_connect_Click(object sender, EventArgs e)
        {
            configs = systemConfigAppService.GetAllConfig();
            ////中软
            //var zrconfig = configs.Where(s => s.Code == ConfigEnum.中软).FirstOrDefault();
            //if (zrconfig != null)
            //{
            //    if (socketClient != null)
            //    {
            //        socketClient.Address = zrconfig.Value;
            //        socketClient.Port = int.Parse(zrconfig.AdditiValue);
            //        socketClient.IsAction = zrconfig.IsAction;
            //        socketClient.Close();
            //        socketClient.Open();
            //    }
            //    else
            //    {
            //        socketClient = new SocketClient(zrconfig.Value, int.Parse(zrconfig.AdditiValue), zrconfig.IsAction);
            //    }

            //}
            //条码
            //scannerSocket.Close();
            var brConfig = configs.Where(s => s.Code == ConfigEnum.读码).FirstOrDefault();
            if (brConfig != null && brConfig.IsAction)
            {
                Scanner();
                ScanIsAction = brConfig.IsAction;
                var aa = scannerSocket.Port;
            }
        }
        /// <summary>
        /// 连接读码器通信
        /// </summary>
        /// <param name="brconfig"></param>
        public void InstantiationScan(SystemConfigDto brconfig)
        {
            if (scannerSocket != null)
            {
                scannerSocket.Address = brconfig.Value;
                scannerSocket.Port = int.Parse(brconfig.AdditiValue);
                scannerSocket.IsAction = brconfig.IsAction;
                scannerSocket.Close();
                scannerSocket.Open();
            }
            else
            {
                scannerSocket = new SocketClient(brconfig.Value, int.Parse(brconfig.AdditiValue), brconfig.IsAction);
                scannerSocket.Open();
            }
            //设置读码器状态
            if (scannerSocket.IsConnection)
            {
                this.MainForm.SetScannerStatus(FrameStatusEnum.Connected);
            }
            else if (scannerSocket.IsAction)
            {
                this.MainForm.SetScannerStatus(FrameStatusEnum.NoConnected);
            }
            else
            {
                this.MainForm.SetScannerStatus(FrameStatusEnum.NotEnabled);
            }
        }

        /// <summary>
        /// 切换用户
        /// </summary>
        /// <param name="switchEnum"></param>
        public void SwitchHouse(SwitchEnum switchEnum)
        {
            if (this.MainForm.RunStatus == RunStatusEnum.Running)
            {
                if (switchEnum == SwitchEnum.上一户)
                {
                    if (orderNum == orderCheckNum)
                    {
                        sequence = sequence - 1;
                        GetOrderSum(sequence);
                        imgIndex = 0;//测试
                        InitRunData();
                        //已识别界面数据清空...
                        ClearDataGridMatch();
                    }
                    else
                    {
                        SocketSend("NG");//socket通信
                        MessageBox.Show("当前用户订单未处理完！！！,无法切换");
                    }
                }
                else if (switchEnum == SwitchEnum.下一户)
                {
                    if (orderNum == orderCheckNum)
                    {
                        sequence = sequence + 1;
                        GetOrderSum(sequence);
                        imgIndex = 0;//测试
                        InitRunData();
                        //已识别界面数据清空...
                        ClearDataGridMatch();
                    }
                    else
                    {
                        SocketSend("NG");//socket通信
                        MessageBox.Show("当前用户订单未处理完！！！,无法切换");
                    }
                }
            }
            else
            {
                MessageBox.Show("请点击开始");
            }

        }

        private void dataGrid_match_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加匹配结果表序号
            foreach (DataGridViewRow dr in dataGrid_match.Rows)
            {
                dr.Cells[0].Value = dr.Index + 1;
            }
        }

        public void ClearDataGridMatch()
        {
            List<OrderInfoMatchRe> orderInfoMatchResnul = new List<OrderInfoMatchRe>();
            dataGrid_match.DataSource = orderInfoMatchResnul;
            orderInfoMatchRes.RemoveRange(0, orderInfoMatchRes.Count);
        }
    }
}
