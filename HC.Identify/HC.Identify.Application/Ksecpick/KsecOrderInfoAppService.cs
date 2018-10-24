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
        public OrderInfoSum GetOrderInfoSum(int orderStartNum, string sortLine, int orderSum)
        {
            var OrderInfoSum = new OrderInfoSum();
            var result = ksecOrderInfoServic.GetOrderInfo(orderStartNum, sortLine, orderSum).OrderBy(o => o.SJOBNUM).ToList();
            var jobNUM = "";
            if (result != null && result.Count > 0)
            {
                //OrderInfoSum.OrderSum.Add(new OrderSumDto
                //{
                //    Id = Guid.NewGuid(),
                //    UUID = result[0].uuid,
                //    AreaName = result[0].SORTLINE,
                //    RetailerCode = result[0].CUSTOMCODE,
                //    RetailerName = result[0].CUSTOMNAME,
                //    Num = (int)Math.Round(result.Where(o => o.SJOBNUM == result[0].SJOBNUM).Sum(o => o.orderqty), 0),
                //    PostData = Convert.ToDateTime(result[0].MAKEBATCH),
                //    JobNum = result[0].SJOBNUM,
                //    RIndex = result[0].IndexNum,

                //});
                //jobNUM = result[0].SJOBNUM;
                foreach (var item in result)
                {
                    if (item.SJOBNUM != jobNUM || string.IsNullOrEmpty(jobNUM))
                    {
                        OrderInfoSum.OrderSum.Add(new OrderSumDto
                        {
                            Id = Guid.NewGuid(),
                            UUID = item.uuid,
                            AreaName = item.SORTLINE,
                            RetailerCode = item.CUSTOMCODE,
                            RetailerName = item.CUSTOMNAME,
                            Num = (int)Math.Round(result.Where(o => o.SJOBNUM == item.SJOBNUM).Sum(o => o.orderqty), 0),
                            PostData = Convert.ToDateTime(item.MAKEBATCH),
                            JobNum = item.SJOBNUM,
                            RIndex = item.IndexNum,
                            Batch = item.batch
                        });
                        jobNUM = item.SJOBNUM;
                    }
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

        public IList<VTaskOrderInfoDto> GetSingleRetailerOrderInfo(string jobNum, string sortLine)
        {
            var result = ksecOrderInfoServic.GetSingleRetailerOrderInfo(jobNum, sortLine);
            return result;
        }
    }
}
