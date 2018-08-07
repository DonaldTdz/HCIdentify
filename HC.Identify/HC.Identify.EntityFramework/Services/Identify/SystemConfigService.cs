using HC.Identify.Core.Identify;
using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.EntityFramework.Services.Identify
{
    public class SystemConfigService
    {
        public List<SystemConfigDto> GetAllConfig()
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var result = context.SystemConfig.Select(s => new SystemConfigDto
                {
                    Id = s.Id,
                    Code = s.Code,
                    Value = s.Value,
                    AdditiValue = s.AdditiValue,
                    IsAction = s.IsAction
                }).ToList();
                return result;
            }
        }

        public SystemConfigDto GetSingleConfig(ConfigEnum code)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var result = context.SystemConfig.Where(s => s.Code == code).Select(s => new SystemConfigDto
                {
                    Id = s.Id,
                    Code = s.Code,
                    Value = s.Value,
                    AdditiValue = s.AdditiValue,
                    IsAction = s.IsAction
                }).FirstOrDefault();
                return result;
            }
        }
        public int CreateSystemConfig(List<SystemConfig> configs)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var result = context.SystemConfig.AddRange(configs).Count();
                context.SaveChanges();
                return result;
            }
        }
        public int Update(List<SystemConfig> configs)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                foreach (var item in configs)
                {
                    var query = context.SystemConfig.Where(s => s.Id == item.Id).FirstOrDefault();
                    query.Code = item.Code;
                    query.Value = item.Value;
                    query.AdditiValue = item.AdditiValue;
                    query.IsAction = item.IsAction;
                }
                var result = context.SaveChanges();
                return result;
            }
        }
    }
}
