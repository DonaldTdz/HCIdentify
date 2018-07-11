using HC.Identify.Dto.Identify;
using HC.Identify.Dto.Ms01;
using HC.Identify.EntityFramework.Services.Identify;
using HC.Identify.EntityFramework.Services.Ms01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Identify
{
    public class OrderSumAppService : IdentifyAppServiceBase
    {
        private OrderSumMsService orderSumMsService;
        private OrderSumService orderSumService;
        public OrderSumAppService()
        {
            orderSumService = new OrderSumService();
            orderSumMsService = new OrderSumMsService();
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
        public int DowloadData()
        {
            var list = orderSumMsService.GetOrderSumMs();
            if (list.Count > 0)
            {
                return orderSumService.DowloadData(list);
            }
            else
            {
                return 0;
            }
        }
    }
}
