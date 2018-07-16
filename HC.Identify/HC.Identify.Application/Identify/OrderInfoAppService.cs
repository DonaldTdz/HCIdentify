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
        public OrderInfoAppService()
        {
            orderInfoService = new OrderInfoService();
        }

        /// <summary>
        /// 根据UUID获取订信息
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public IList<OrderInfoDto> GetOrderInfoByUUID(string uuid)
        {
            return orderInfoService.GetOrderInfoByUUID(uuid);
        }
    }
}
