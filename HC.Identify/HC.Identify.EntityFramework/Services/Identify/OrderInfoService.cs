using HC.Identify.Dto.Identify;
using HC.Identify.Dto.Ms01;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.Services.Identify
{
    public class OrderInfoService
    {
        /// <summary>
        /// 根据UUID获取订信息
        /// </summary>
        public IList<OrderInfoDto> GetOrderListByUUID(string uuid)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.OrderInfo.Where(o => o.UUID == uuid)
                    .Select(o => new OrderInfoDto
                    {
                        Id = o.Id,
                        UUID = o.UUID,
                        Brand = o.Brand,
                        Specification = o.Specification,
                        Num = o.Num,
                        Matched = 0
                    });
                var result = query.ToList();
                return result;
            }
        }

        /// <summary>
        /// 根据uuids 获取订单信息
        /// </summary>
        public IList<OrderInfoDto> GetOrderListByUUIDs(string[] uuids)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.OrderInfo.Where(o => uuids.Contains(o.UUID))
                    .Select(o => new OrderInfoDto
                    {
                        Id = o.Id,
                        UUID = o.UUID,
                        Brand = o.Brand,
                        Specification = o.Specification,
                        Num = o.Num,
                        Matched = 0
                    });
                var result = query.ToList();
                return result;
            }
        }

        /// <summary>
        /// 批量导入订单信息信息
        /// </summary>
        public int DownloadOrderInfoData(IList<OderInfoMsDto> orderInfoMsList)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var deSql = "delete from OrderInfo";
                context.Database.ExecuteSqlCommand(deSql);
                var sql = new StringBuilder();
                var count = 0;
                int result = 0;
                foreach (var item in orderInfoMsList)
                {

                    sql.AppendFormat("insert into OrderInfo (Id,UUID,Brand,Specification,Num,PostDate) values(newid(),'{0}','{1}','{2}','{3}',GETDATE());", item.OCI_UUID, item.OCI_CIG_BRAND, item.OCI_CIG_TRADEMARK, item.OCI_ORDER_NUM);
                    count++;
                    var condition1 = orderInfoMsList.Count / 5000 * 5000;
                    var condition2 = orderInfoMsList.Count - condition1;
                    if (count == 5000 || (result >= condition1 && count == condition2))
                    {
                        var resultLocal = context.Database.ExecuteSqlCommand(sql.ToString());
                        count = 0;
                        sql.Clear();
                        result += resultLocal;
                    }
                }
                //var result = context.Database.ExecuteSqlCommand(sql.ToString());
                return result;
            }
        }
    }
}
