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
    public class CameraSettingService
    {
        public bool SaveCameraSetting(List<CameraSettingCreateDto> cameraSettings)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var sql = new StringBuilder();
                foreach (var item in cameraSettings)
                {
                    var extends = context.CameraSetting.Any(c => c.Code == item.Code);
                    if (extends)
                    {
                        sql.AppendFormat(@"update CameraSetting set Value='{0}' where Code={1}", item.Value, (int)item.Code);
                    }
                    else
                    {
                        sql.AppendFormat(@"insert into CameraSetting (Code,Value,Descs) values('{0}','{1}','{2}');", (int)item.Code, item.Value, item.Descs);
                    }

                }
                var result = context.Database.ExecuteSqlCommand(sql.ToString());
                return result == cameraSettings.Count;
            }
        }

        /// <summary>
        /// 获取相机的所有配置信息
        /// </summary>
        /// <returns></returns>
        public IList<CameraSettingCreateDto> GetCameraSetting()
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var list = context.CameraSetting.Select(c => new CameraSettingCreateDto
                {
                    Id = c.Id,
                    Code = c.Code,
                    Value = c.Value,
                    Descs = c.Descs
                }).ToList();
                return list;
            }
        }

        public int UpdateSingleSetting(CameraSettingCreateDto dto)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var entity = context.CameraSetting.Where(c => c.Code == dto.Code).FirstOrDefault();
                entity.Code = dto.Code;
                entity.Value = dto.Value;
                entity.Descs = dto.Descs;
                var result = context.SaveChanges();
                return result;
            }
        }

    }
}
