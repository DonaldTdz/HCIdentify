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
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.App
{
    public partial class SystemConfig : Form
    {
        public SystemConfigAppService systemConfigAppService;
        public List<SystemConfigDto> configs;
        public SystemConfig()
        {
            InitializeComponent();
        }
        public SystemConfig(Main mainForm)
        {
            InitAddress();
        }
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
                    if (item.Code == ConfigEnum.条码)
                    {
                        txt_brandIP.Text = item.Value;
                        txt_brandPort.Text = item.AdditiValue;
                        check_isActionBr.Checked = item.IsAction;
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var creConfig = new List<SystemConfigDto>();
            var upConfig = new List<SystemConfigDto>();
            //中软
            var zrConfig = new SystemConfigDto();
            zrConfig.Code = ConfigEnum.中软;
            zrConfig.Value = txt_ZRIP.Text;
            zrConfig.AdditiValue = txt_ZRPort.Text;
            zrConfig.IsAction = check_isActionzr.Checked;
            var resultzr = configs.Where(c => c.Code == ConfigEnum.中软).FirstOrDefault();
            if (resultzr != null)
            {
                zrConfig.Id = resultzr.Id;
                upConfig.Add(zrConfig);
            }
            //条码
            var brConfig = new SystemConfigDto();
            brConfig.Code = ConfigEnum.中软;
            brConfig.Value = txt_ZRIP.Text;
            brConfig.AdditiValue = txt_ZRPort.Text;
            brConfig.IsAction = check_isActionzr.Checked;
            var resultbr = configs.Where(c => c.Code == ConfigEnum.中软).FirstOrDefault();
            if (resultbr != null)
            {
                zrConfig.Id = resultbr.Id;
                creConfig.Add(zrConfig);
            }
            if (creConfig.Count > 0)
            {
                systemConfigAppService.CreateSystemConfig(creConfig);
            }
            if (upConfig.Count > 0)
            {
                systemConfigAppService.Update(upConfig);
            }
        }

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
                    if (item.Code == ConfigEnum.条码)
                    {
                        txt_brandIP.Text = item.Value;
                        txt_brandPort.Text = item.AdditiValue;
                        check_isActionBr.Checked = item.IsAction;
                    }
                }
            }
        }
    }
}
