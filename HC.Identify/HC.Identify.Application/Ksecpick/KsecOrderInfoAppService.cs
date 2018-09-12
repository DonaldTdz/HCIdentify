using HC.Identify.Dto.Identify;
using HC.Identify.Dto.Ksecpick;
using HC.Identify.EntityFramework.Services.Ksecpick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Application.Ksecpick
{
    public class KsecOrderInfoAppService
    {
        private KsecOrderInfoServic ksecOrderInfoServic;
        public KsecOrderInfoAppService()
        {
            ksecOrderInfoServic = new KsecOrderInfoServic();
        }

        /// <summary>
        /// 获取订单、户数信息
        /// </summary>
        public OrderInfoSum GetOrderInfoSum(string jobNum)
        {
            var OrderInfoSum = new OrderInfoSum();
            var result = ksecOrderInfoServic.GetOrderInfo(jobNum);
            if (result != null && result.Count > 0)
            {

                //var orderSum = new OrderSumDto();
                //orderSum.Id = Guid.NewGuid();
                //orderSum.AreaName = result[0].SORTLINE;
                //orderSum.RetailerCode = result[0].CUSTOMCODE;
                //orderSum.RetailerName = result[0].CUSTOMNAME;
                //orderSum.Num = (int)Math.Round(result[0].orderqty, 0);
                //orderSum.PostData = Convert.ToDateTime(result[0].MAKEBATCH);
                //orderSum.JobNum = result[0].SJOBNUM;
                OrderInfoSum.OrderSum.Add(new OrderSumDto
                {
                    Id = Guid.NewGuid(),
                    AreaName = result[0].SORTLINE,
                    RetailerCode = result[0].CUSTOMCODE,
                    RetailerName = result[0].CUSTOMNAME,
                    Num = (int)Math.Round(result.Sum(o=>o.orderqty), 0),
                    PostData = Convert.ToDateTime(result[0].MAKEBATCH),
                    JobNum = result[0].SJOBNUM
                });

                foreach (var item in result)
                {
                    var orderInfo = new OrderInfoDto();
                    orderInfo.Id = Guid.NewGuid();
                    orderInfo.UUID = item.uuid;
                    orderInfo.Brand = item.BARCODE;
                    orderInfo.Specification = item.brandname;
                    orderInfo.Num = (int)Math.Round(item.orderqty, 0);
                    orderInfo.Matched = 0;
                    orderInfo.Sequence = item.unitno;
                    OrderInfoSum.OrderInfoList.Add(orderInfo);
                }
            }
            return OrderInfoSum;
        }
    }
}
