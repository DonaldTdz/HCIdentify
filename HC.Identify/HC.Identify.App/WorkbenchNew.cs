using HC.Identify.Application;
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
        }

        //关闭
        private void WorkbenchNew_FormClosing(object sender, FormClosingEventArgs e)
        {

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

        #endregion

        #region 批次信息

        IList<OrderSumDto> OrderSumList { get; set; }
        int CurrentHouseNum = 1;
        int CurrentOrderSumCount = 0;

        private void InitAeareLine()
        {
            BindAareaLineData();
            GetHoseListByLine();
            ShowCurrentAareaLine();
            ShowHouseInfo();
            //初始化第一个订单信息
            //....
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
                labOrderTotalNum.Text = orderSum.Num.ToString(); //订单总量
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
                CurrentHouseNum --;
            }
            else 
            {
                CurrentHouseNum ++;
            }
            //刷新批次信息
            GetHoseListByLine();
            //刷新户数信息
            ShowHouseInfo();
            //刷新订单信息
            //....
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

        #endregion

        #region 订单信息

        #endregion

        #region 相机识别

        #region 读码识别

        #endregion

        #region 图像识别

        #endregion

        #endregion

        #region 识别结果处理

        #region 当前结果实时刷新

        #endregion

        #region 订单数据实时刷新

        #endregion

        #endregion


    }
}
