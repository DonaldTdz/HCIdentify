using HC.Identify.Application;
using HC.Identify.Application.Common;
using HC.Identify.Application.Identify;
using HC.Identify.Dto.Common;
using HC.Identify.Dto.Identify;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HC.Identify.App.Main;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.App
{
    public partial class SystemConfig : FormMainChildren //Form
    {
        public SystemConfigAppService systemConfigAppService;
        public List<SystemConfigDto> configs;
        SocketClient socketClient;
        Workbench workbench;
        public Main MainForm;
        List<ComboBoxDto> ParityBit = new List<ComboBoxDto>();
        List<ComboBoxDto> StopBit = new List<ComboBoxDto>();
        COMDto cOMDto = new COMDto();//切户相关COM口信息
        public SystemConfig()
        {
            InitializeComponent();
        }
        public SystemConfig(Main mainForm)
        {
            InitializeComponent();
            InitPartityBit();//初始化校验位下拉框值
            InitStopBit();//初始化停止位下拉框值
            InitAddress();
            MainForm = mainForm;
        }
        #region 串口配置下拉框值初始化
        /// <summary>
        /// 初始化数据位数据
        /// </summary>
        public void InitPartityBit()
        {
            ParityBit.Add(new ComboBoxDto
            {
                Name = "None",
                Value = 0,
            });
            ParityBit.Add(new ComboBoxDto
            {
                Name = "Odd",
                Value = 1,
            });
            ParityBit.Add(new ComboBoxDto
            {
                Name = "Even",
                Value = 2,
            });
            ParityBit.Add(new ComboBoxDto
            {
                Name = "Mark",
                Value = 3,
            });
            ParityBit.Add(new ComboBoxDto
            {
                Name = "Space",
                Value = 4,
            });
            coboComParity.DataSource = ParityBit;
            coboComParity.DisplayMember = "name";
            coboComParity.ValueMember = "value";
        }
        /// <summary>
        /// 初始化停止位数据
        /// </summary>
        public void InitStopBit()
        {
            StopBit.Add(new ComboBoxDto
            {
                Name = "None",
                Value = 0,
            });
            StopBit.Add(new ComboBoxDto
            {
                Name = "One",
                Value = 1,
            });
            StopBit.Add(new ComboBoxDto
            {
                Name = "Two",
                Value = 2,
            });
            StopBit.Add(new ComboBoxDto
            {
                Name = "OnePointFive",
                Value = 3,
            });

            coboComStop.DataSource = StopBit;
            coboComStop.DisplayMember = "name";
            coboComStop.ValueMember = "value";
        }
        #endregion
        public void ComboxGetValue()
        {
            //var datas = orderSumAppService.GetAreaList();
            //if (datas.Count > 0)
            //{
            //    //下拉框数据赋值
            //    coboComParity.DataSource = StopBits;
            //    coboComParity.DisplayMember = "name";
            //    coboComParity.ValueMember = "value";
            //}
        }
        //public void InitCoBoData()
        //{
        //    var data = new List<CommonEnumData>();
        //    data.Add({ });

        //}
        public void InitAddress()
        {
            systemConfigAppService = new SystemConfigAppService();
            configs = systemConfigAppService.GetAllConfig();
            if (configs.Count > 0)
            {
                foreach (var item in configs)
                {
                    if (item.Code == ConfigEnum.中软)
                    {
                        txt_ZRIP.Text = item.Value;
                        txt_ZRPort.Text = item.AdditiValue;
                        check_isActionzr.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.读码)
                    {
                        txt_brandIP.Text = item.Value.ToString();
                        txt_brandPort.Text = item.AdditiValue.ToString();
                        check_isActionBr.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.图像)
                    {
                        ck_photo.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.调试模式)
                    {
                        check_debug.Checked = item.IsAction;
                    }
                    //if (item.Code == ConfigEnum.视觉相机沉睡)
                    //{
                    //    txtSleepTime.Text = item.Value;
                    //}
                    if (item.Code == ConfigEnum.订单顺序模式)
                    {
                        ckOrderSeq.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.分拣线路)
                    {
                        txtBoxSortLine.Text = string.IsNullOrEmpty(item.Value) ? "SortlineSpe10" : item.Value;
                        txtSubSortLine.Text = string.IsNullOrEmpty(item.AdditiValue) ? "2" : item.AdditiValue;
                    }
                    if (item.Code == ConfigEnum.相机曝光度)
                    {
                        txtExposure.Text = item.Value;
                    }
                    if (item.Code == ConfigEnum.匹配值)
                    {
                        textMatchVal.Text = item.Value;
                    }
                    if (item.Code == ConfigEnum.Com口)
                    {
                        ckAutoSwitchUser.Checked = item.IsAction;
                        cOMDto.COMName = string.IsNullOrEmpty(item.Value) ? "COM8" : item.Value;
                        string[] arry = { };
                        if (item.AdditiValue != null)
                        {
                            if (item.AdditiValue.Length > 0)
                            {
                                arry = item.AdditiValue.Split(',');
                                cOMDto.COMRate = (arry.Length > 0 && arry[0] != "") ? int.Parse(arry[0]) : 9600;
                                cOMDto.COMParity = (arry.Length > 1 && arry[1] != "") ? int.Parse(arry[1]) : 0;
                                cOMDto.ComData = (arry.Length > 2 && arry[2] != "") ? int.Parse(arry[2]) : 8;
                                cOMDto.ComStop = (arry.Length > 3 && arry[3] != "") ? int.Parse(arry[3]) : 1;
                            }
                            txtComName.Text = item.Value;
                            //以下的数据位置不能错位
                            txtComRate.Text = cOMDto.COMRate != 0 ? cOMDto.COMRate.ToString() : "";
                            coboComParity.SelectedValue = cOMDto.COMParity;
                            txtComData.Text = cOMDto.ComData.ToString();
                            coboComStop.SelectedValue = cOMDto.ComStop;
                        }
                    }
                    if (item.Code == ConfigEnum.烟序模板)
                    {
                        checkSmokeMode.Checked = item.IsAction;
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("保存之后需要重启，请确认？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var Configs = new List<SystemConfigDto>();
                //var upConfig = new List<SystemConfigDto>();
                //中软
                var zrConfig = new SystemConfigDto();
                zrConfig.Code = ConfigEnum.中软;
                zrConfig.Value = txt_ZRIP.Text;
                zrConfig.AdditiValue = txt_ZRPort.Text;
                zrConfig.IsAction = check_isActionzr.Checked;
                if (!string.IsNullOrEmpty(txt_ZRIP.Text) && !string.IsNullOrEmpty(txt_ZRPort.Text))
                {
                    Configs.Add(zrConfig);
                }

                //条码
                var brConfig = new SystemConfigDto();
                brConfig.Code = ConfigEnum.读码;
                brConfig.Value = txt_brandIP.Text;
                brConfig.AdditiValue = txt_brandPort.Text;
                brConfig.IsAction = check_isActionBr.Checked;
                if (!string.IsNullOrEmpty(txt_brandIP.Text) && !string.IsNullOrEmpty(txt_brandPort.Text))
                {
                    Configs.Add(brConfig);
                }
                //视觉相机
                var phConfig = new SystemConfigDto();
                phConfig.Code = ConfigEnum.图像;
                phConfig.IsAction = ck_photo.Checked;
                Configs.Add(phConfig);

                //调试模式
                var debugConfig = new SystemConfigDto();
                debugConfig.Code = ConfigEnum.调试模式;
                debugConfig.IsAction = check_debug.Checked;
                Configs.Add(debugConfig);

                ////视觉相机沉睡时间
                //var sleepTimeConfig = new SystemConfigDto();
                //sleepTimeConfig.Code = ConfigEnum.视觉相机沉睡;
                //sleepTimeConfig.Value = txtSleepTime.Text;
                //Configs.Add(sleepTimeConfig);

                //订单顺序模式
                var orderSeqConfig = new SystemConfigDto();
                orderSeqConfig.Code = ConfigEnum.订单顺序模式;
                orderSeqConfig.IsAction = ckOrderSeq.Checked;
                Configs.Add(orderSeqConfig);

                //分拣线路
                var sortLineConfig = new SystemConfigDto();
                sortLineConfig.Code = ConfigEnum.订单顺序模式;
                sortLineConfig.Value = txtBoxSortLine.Text;
                sortLineConfig.AdditiValue = txtSubSortLine.Text;
                Configs.Add(sortLineConfig);

                //相机曝光度
                var exposureConfig = new SystemConfigDto();
                exposureConfig.Code = ConfigEnum.相机曝光度;
                exposureConfig.Value = txtExposure.Text;
                Configs.Add(exposureConfig);

                //匹配值
                var matchValueConfig = new SystemConfigDto();
                matchValueConfig.Code = ConfigEnum.匹配值;
                matchValueConfig.Value = textMatchVal.Text;
                Configs.Add(matchValueConfig);

                //自动切户
                var autoSwitchUserConfig = new SystemConfigDto();
                autoSwitchUserConfig.Code = ConfigEnum.Com口;
                autoSwitchUserConfig.IsAction = ckAutoSwitchUser.Checked;
                autoSwitchUserConfig.Value = txtComName.Text;
                var comValue = "";//下列的数据顺序要与上面获取的顺序保持一致
                comValue += txtComRate.Text + ",";
                comValue += coboComParity.SelectedValue + ",";
                comValue += txtComData.Text + ",";
                comValue += coboComStop.SelectedValue;
                autoSwitchUserConfig.AdditiValue = comValue;
                Configs.Add(autoSwitchUserConfig);

                //烟序模板
                var SmokeModeConfig = new SystemConfigDto();
                SmokeModeConfig.Code = ConfigEnum.烟序模板;
                SmokeModeConfig.IsAction = checkSmokeMode.Checked;
                Configs.Add(SmokeModeConfig);
                try
                {
                    systemConfigAppService.UpdateOrCreate(Configs);
                    //configs = systemConfigAppService.GetAllConfig();
                    MessageBox.Show("保存成功");
                    //this.MainForm.Close();
                    //System.Windows.Forms.Application.Exit();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，详细信息：" + ex.InnerException.Message);
                }
            }
        }
        /// <summary>
        /// 取消（已去除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (configs.Count > 0)
            {
                foreach (var item in configs)
                {
                    if (item.Code == ConfigEnum.中软)
                    {
                        txt_ZRIP.Text = item.Value;
                        txt_ZRPort.Text = item.AdditiValue;
                        check_isActionzr.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.读码)
                    {
                        txt_brandIP.Text = item.Value;
                        txt_brandPort.Text = item.AdditiValue;
                        check_isActionBr.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.图像)
                    {
                        ck_photo.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.调试模式)
                    {
                        check_debug.Checked = item.IsAction;
                    }
                    //if (item.Code == ConfigEnum.视觉相机沉睡)
                    //{
                    //    txtSleepTime.Text = item.Value;
                    //}
                    if (item.Code == ConfigEnum.订单顺序模式)
                    {
                        ckOrderSeq.Checked = item.IsAction;
                    }
                    if (item.Code == ConfigEnum.分拣线路)
                    {
                        txtBoxSortLine.Text = item.Value;
                        txtSubSortLine.Text = item.AdditiValue;
                    }
                    if (item.Code == ConfigEnum.相机曝光度)
                    {
                        txtExposure.Text = item.Value;
                    }
                    if (item.Code == ConfigEnum.匹配值)
                    {
                        textMatchVal.Text = item.Value;
                    }
                    if (item.Code == ConfigEnum.Com口)
                    {
                        ckAutoSwitchUser.Checked = item.IsAction;
                    }
                }
            }
        }

        /// <summary>
        /// 重新连接（已去除）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_Click(object sender, EventArgs e)
        {
            var zrIp = txt_ZRIP.Text;
            var zrPort = txt_ZRPort.Text;
            var zrIsCheck = check_isActionzr.Checked;
            if (!string.IsNullOrEmpty(zrIp) && !string.IsNullOrEmpty(zrPort))
            {
                socketClient = new SocketClient(zrIp, int.Parse(zrPort), zrIsCheck);
                socketClient.Open();
            }
            var brIp = txt_brandIP.Text;
            var brPort = txt_brandPort.Text;
            var brIsCheck = check_isActionBr.Checked;
            if (!string.IsNullOrEmpty(brIp) && !string.IsNullOrEmpty(brPort) && brIsCheck)
            {
                workbench = new Workbench();
                workbench.configs = systemConfigAppService.GetAllConfig();
                workbench.ScanIsAction = brIsCheck;
                workbench.Scanner();
            }
        }
        /// <summary>
        /// 限制曝光度只能输入浮点数据
        /// </summary>
        private void txtExposure_KeyPress(object sender, KeyPressEventArgs e)
        {
            int kc = (int)e.KeyChar;
            if (kc == 46)
            {
                if (txtExposure.Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txtExposure.Text, out oldf);
                    b2 = float.TryParse(txtExposure.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }

        }
        /// <summary>
        /// 限制匹配值只能输入浮点数据
        /// </summary>
        private void textMatchVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int kc = (int)e.KeyChar;
            if (kc == 46)
            {
                if (textMatchVal.Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(textMatchVal.Text, out oldf);
                    b2 = float.TryParse(textMatchVal.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }
    }
}
