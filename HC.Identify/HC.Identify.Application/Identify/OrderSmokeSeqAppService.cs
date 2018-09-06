using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Identify
{
   public  class OrderSmokeSeqAppService: IdentifyAppServiceBase
    {
        private OrderSmokeSeqService orderSmokeSeqService;
        public OrderSmokeSeqAppService()
        {
            orderSmokeSeqService = new OrderSmokeSeqService();
        }

        public List<OrderInfoMatchRe> GetAllOrderSmokeSeq()
        {
            return orderSmokeSeqService.GetAllOrderSmokeSeq();
        }
    }
}
