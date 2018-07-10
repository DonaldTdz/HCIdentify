using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Identify
{
   public class OrderSumAppService
    {
        private OrderSumService orderSumService;
        public OrderSumAppService()
        {
            orderSumService = new OrderSumService();
        }
        public IList<AreaInfo> GetAreaList()
        {
            return orderSumService.GetAreaList();
        }

        public OrderSumAddCountDtos GetOrderSum()
        {
            return orderSumService.GetOrderSum();
        }
        public int GetOrderSumCount(int code)
        {
            return orderSumService.GetOrderSumCount(code);
        }

        public IList<OrderSumDto> GetSigleOrderSum(int code)
        {
            return orderSumService.GetSigleOrderSum(code);
        }
    }
}
