using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.Services.Identify
{
   public class OrderSmokeSeqService
    {
        public List<OrderInfoMatchRe> GetAllOrderSmokeSeq()
        {
            using (IdentifyContext context=new IdentifyContext())
            {
                var list = context.OrderSmokeSeq.Select(o => new OrderInfoMatchRe
                {
                    Id = o.Id,
                    Brand = o.Brand,
                    Specification = o.Specification,
                    Sequence = o.Sequence,
                    UUID=o.UUID,
                    MatchStatus = ""
                }).ToList();
                return list;
            }
        }
    }
}
