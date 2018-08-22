using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Identify
{
    public class OrderInfoAppService : IdentifyAppServiceBase
    {
        private OrderInfoService orderInfoService;
        private OrderSumService orderSumService;
        public OrderInfoAppService()
        {
            orderInfoService = new OrderInfoService();
            orderSumService = new OrderSumService();
        }

        /// <summary>
        /// 根据UUID获取订信息
        /// </summary>
        public IList<OrderInfoDto> GetOrderInfoByUUID(string uuid)
        {
            return orderInfoService.GetOrderListByUUID(uuid);
        }

        /// <summary>
        /// 根据线路获取该线路下所有订单
        /// </summary>
        public IList<OrderInfoDto> GetOrderInfoByLineCode(int lineCode)
        {
            var uuids = orderSumService.GetUUIDsByLineCode(lineCode);
            return orderInfoService.GetOrderListByUUIDs(uuids);
        }
    }
}
