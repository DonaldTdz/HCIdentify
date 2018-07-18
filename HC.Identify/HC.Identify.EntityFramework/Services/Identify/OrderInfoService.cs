using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace HC.Identify.EntityFramework.Services.Identify
{
    public class OrderInfoService
    {
        /// <summary>
        /// 根据UUID获取订信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public IList<OrderInfoTableDto> GetOrderInfoByUUID(string uuid)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.OrderInfo.Where(o => o.UUID == uuid)
                    .Select(o => new OrderInfoTableDto
                    {
                        Id = o.Id,
                        UUID = o.UUID,
                        Brand = o.Brand,
                        Specification = o.Specification,
                        Num = o.Num,
                        Matched=0,
                        Unmatched=o.Num
                    });
                var result = query.ToList();
                return result;
            }
        }
    }
}
