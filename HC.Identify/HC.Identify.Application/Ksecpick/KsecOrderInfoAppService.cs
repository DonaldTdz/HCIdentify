using HC.Identify.Dto.Identify;
using HC.Identify.Dto.Kesc;
using HC.Identify.Dto.Ksecpick;
using HC.Identify.EntityFramework.Services.Kesc;
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
        private KsecOrderInfoServic ksecOrderInfoServic;//Sql
        private KescOrderInfoService kescOrderInfoService;//DB2
        public KsecOrderInfoAppService()
        {
            ksecOrderInfoServic = new KsecOrderInfoServic();
            kescOrderInfoService = new KescOrderInfoService();
        }

        /// <summary>
        /// 获取订单、户数信息
        /// </summary>
        public OrderInfoSum GetOrderInfoSum(int orderStartNum, string sortLine, int orderSum,string subSortLine)
        {
            var OrderInfoSum = new OrderInfoSum();
            //var result = ksecOrderInfoServic.GetOrderInfo(orderStartNum, sortLine, orderSum).OrderBy(o => o.SJOBNUM).ToList();
            var result = kescOrderInfoService.GetOrderInfo(orderStartNum, sortLine, orderSum, subSortLine).OrderBy(o => o.SJOBNUM).ToList();
            #region 测试
            //var jobNUM = "";
            //if (result != null && result.Count > 0)
            //{
            //    foreach (var item in result)
            //    {
            //        if (item.SJOBNUM != jobNUM || string.IsNullOrEmpty(jobNUM))
            //        {
            //            OrderInfoSum.OrderSum.Add(new OrderSumDto
            //            {
            //                Id = Guid.NewGuid(),
            //                UUID = item.uuid,
            //                AreaName = item.SORTLINE,
            //                RetailerCode = item.CUSTOMCODE,
            //                RetailerName = item.CUSTOMNAME,
            //                Num = (int)Math.Round(result.Where(o => o.SJOBNUM == item.SJOBNUM).Sum(o => o.orderqty), 0),
            //                PostData = Convert.ToDateTime(item.MAKEBATCH),
            //                JobNum = item.SJOBNUM,
            //                RIndex = item.IndexNum,
            //                Batch = item.batch
            //            });
            //            jobNUM = item.SJOBNUM;
            //        }
            //        var orderInfo = new OrderInfoDto();
            //        orderInfo.Id = Guid.NewGuid();
            //        orderInfo.UUID = item.uuid;
            //        orderInfo.Brand = item.BARCODE;
            //        orderInfo.Specification = item.BARCODE;
            //        orderInfo.Num = (int)Math.Round(item.orderqty, 0); 
            //        orderInfo.Matched = 0;
            //        orderInfo.Sequence =(decimal) item.unitno;
            //        orderInfo.JobNum = item.SJOBNUM;
            //        OrderInfoSum.OrderInfoList.Add(orderInfo);
            //    }
            //}
            #endregion
            #region 正式
            var jobNUM = "";
            if (result != null && result.Count > 0)
            {
                foreach (var item in result)
                {
                    if (item.SJOBNUM != jobNUM || string.IsNullOrEmpty(jobNUM))
                    {
                        OrderInfoSum.OrderSum.Add(new OrderSumDto
                        {
                            Id = Guid.NewGuid(),
                            UUID = item.ORDERNUM,
                            AreaName = item.SORTLINE,
                            RetailerCode = item.CUSTOMCODE,
                            RetailerName = item.CUSTOMDESC,
                            Num = (int)Math.Round(result.Where(o => o.SJOBNUM == item.SJOBNUM).Sum(o => o.ITEMTOTAL), 0),
                            PostData = Convert.ToDateTime(item.MAKEBATCH),
                            JobNum = item.SJOBNUM,
                            RIndex = item.IndexNum,
                            Batch = item.BATCHCODE
                        });
                        jobNUM = item.SJOBNUM;
                    }
                    var orderInfo = new OrderInfoDto();
                    orderInfo.Id = Guid.NewGuid();
                    orderInfo.UUID = item.ORDERNUM;
                    orderInfo.Brand = item.BARCODE;
                    orderInfo.Specification = item.ITEMNAME;
                    orderInfo.Num = (int)Math.Round(item.ITEMTOTAL, 0);
                    orderInfo.Matched = 0;
                    orderInfo.Sequence = item.UNITSEQ;
                    orderInfo.JobNum = item.SJOBNUM;
                    OrderInfoSum.OrderInfoList.Add(orderInfo);
                }
            }
            #endregion
            return OrderInfoSum;
        }

        public IList<KescOrderInfoDto> GetSingleRetailerOrderInfo(string jobNum, string sortLine, string subSortLine)
        {
            //var result = ksecOrderInfoServic.GetSingleRetailerOrderInfo(jobNum, sortLine);
            var result = kescOrderInfoService.GetSingleRetailerOrderInfo(jobNum, sortLine,subSortLine);
            return result;
        }
    }
}
