using HC.Identify.Core.Identify;
using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.Application.Identify
{
    public class SystemConfigAppService
    {
        private SystemConfigService systemConfigService;
        public SystemConfigAppService()
        {
            systemConfigService = new SystemConfigService();
        }

        public List<SystemConfigDto> GetAllConfig()
        {
            return systemConfigService.GetAllConfig();
        }

        public SystemConfigDto GetSingleConfig(ConfigEnum code)
        {
            return systemConfigService.GetSingleConfig(code);
        }

        public int CreateSystemConfig(List<SystemConfigDto> configs)
        {
            var sconfig = new List<SystemConfig>();
            foreach (var item in configs)
            {
                var config = new SystemConfig();
                config.Id = item.Id;
                config.Code = item.Code;
                config.AdditiValue = item.AdditiValue;
                config.Value = item.Value;
                config.IsAction = item.IsAction;
                sconfig.Add(config);
            }
            return systemConfigService.CreateSystemConfig(sconfig);
        }
        public int UpdateOrCreate(List<SystemConfigDto> configs)
        {
            var crsConfig = new List<SystemConfig>();
            var upConFig = new List<SystemConfig>();
            var crCount = 0;
            var upCount = 0;
            foreach (var item in configs)
            {
                var isExist = systemConfigService.IsExtend(item.Code);

                var config = new SystemConfig();
                config.Id = item.Id;
                config.Code = item.Code;
                config.AdditiValue = item.AdditiValue;
                config.Value = item.Value;
                config.IsAction = item.IsAction;
                if (isExist)
                {
                    upConFig.Add(config);
                }
                else
                {
                    config.Id = Guid.NewGuid();
                    crsConfig.Add(config);
                }
            }
            if (upConFig.Count > 0)
            {
                upCount = systemConfigService.Update(upConFig);
            }
            if (crsConfig.Count > 0)
            {
                crCount = systemConfigService.CreateSystemConfig(crsConfig);
            }
            return upCount + crCount;
        }

        public int Update(List<SystemConfigDto> configs)
        {
            var upConFig = new List<SystemConfig>();
            foreach (var item in configs)
            {
                var config = new SystemConfig();
                config.Id = item.Id;
                config.Code = item.Code;
                config.AdditiValue = item.AdditiValue;
                config.Value = item.Value;
                config.IsAction = item.IsAction;
                upConFig.Add(config);
            }
            return systemConfigService.Update(upConFig);
        }
    }
}
