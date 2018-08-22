using HC.Identify.Dto.Identify;
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
                        Matched=0
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
    }
}
