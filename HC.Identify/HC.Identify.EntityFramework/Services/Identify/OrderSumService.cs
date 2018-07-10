using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.Services.Identify
{
    public class OrderSumService
    {
        /// <summary>
        /// 获取订单区域信息
        /// </summary>
        /// <returns></returns>
        public IList<AreaInfo> GetAreaList()
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.OrderSums.Select(u => new AreaInfo
                {
                    Name = u.AreaCode.ToString() + u.AreaName,
                    Value = u.AreaCode
                }).Distinct();

                return query.ToList();
            }
        }

        /// <summary>
        /// 获取订单打包信息
        /// </summary>
        /// <returns></returns>
        public OrderSumAddCountDtos GetOrderSum()
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                OrderSumAddCountDtos dto = new OrderSumAddCountDtos();
                var query = context.OrderSums.Select(u => new OrderSumDto
                {
                    Id = u.Id,
                    UUID = u.UUID,
                    AreaCode = u.AreaCode,
                    AreaName = u.AreaName,
                    RetailerCode = u.RetailerCode,
                    RetailerName = u.RetailerName,
                    Sequence = u.Sequence,
                    Num = u.Num,
                    PostData = u.PostData,
                    RNum = u.RNum
                });
                dto.OrderSumDtos = query.ToList();
                dto.Count = query.Count();
                return dto;
            }
        }
        public int GetOrderSumCount(int code)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var count = context.OrderSums.Where(o => o.AreaCode == code).Count();
                return count;
            }
        }

        //public OrderSumDto GetSigleOrderSum(int code, int sequence)
        //{
        //    using (IdentifyContext context = new IdentifyContext())
        //    {
        //        var query = context.OrderSums.Where(o => o.AreaCode == code).Select(o => new OrderSumDto
        //        {
        //            Id = o.Id,
        //            UUID = o.UUID,
        //            AreaCode = o.AreaCode,
        //            AreaName = o.AreaName,
        //            RetailerCode = o.RetailerCode,
        //            RetailerName = o.RetailerName,
        //            Sequence = o.Sequence,
        //            Num = o.Num,
        //            PostData = o.PostData,
        //            RNum = o.RNum
        //        }).ToList();
        //        var count = query.Count();
        //        var orderSum = query.OrderBy(o => o.Sequence).Skip(sequence - 1).Take(1).FirstOrDefault();
        //        var se = 0;
        //        if (sequence > 1)
        //        {
        //            se = sequence - 1;
        //            orderSum.LastHouse = query.OrderBy(o => o.Sequence).Skip(sequence - 2).Take(1).Select(o => o.RetailerName).FirstOrDefault();
        //        }
        //        if (sequence > 2)
        //        {
        //            se = sequence - 2;
        //            orderSum.LastLHouse = query.OrderBy(o => o.Sequence).Skip(sequence-3).Take(1).Select(o => o.RetailerName).FirstOrDefault();
        //        }
        //        if (sequence < count)
        //        {
        //            se = sequence + 1;
        //            orderSum.NextHouse = query.OrderBy(o=>o.Sequence).Skip(sequence).Take(1).Select(o => o.RetailerName).FirstOrDefault();
        //        }
        //        if (count - sequence > 2)
        //        {
        //            se = sequence + 2;
        //            orderSum.NextNHouse = query.OrderBy(o => o.Sequence).Skip(sequence+1).Take(1).Select(o => o.RetailerName).FirstOrDefault();
        //        }
        //        return orderSum;
        //    }
        //}
        public IList<OrderSumDto> GetSigleOrderSum(int code)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.OrderSums.Where(o => o.AreaCode == code).Select(o => new OrderSumDto
                {
                    Id = o.Id,
                    UUID = o.UUID,
                    AreaCode = o.AreaCode,
                    AreaName = o.AreaName,
                    RetailerCode = o.RetailerCode,
                    RetailerName = o.RetailerName,
                    Sequence = o.Sequence,
                    Num = o.Num,
                    PostData = o.PostData,
                    RNum = o.RNum
                }).ToList();
                //var count = query.Count();
                //var orderSum = query.OrderBy(o => o.Sequence).Skip(sequence - 1).Take(1).FirstOrDefault();
                //var se = 0;
                //if (sequence > 1)
                //{
                //    se = sequence - 1;
                //    orderSum.LastHouse = query.OrderBy(o => o.Sequence).Skip(sequence - 2).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                //}
                //if (sequence > 2)
                //{
                //    se = sequence - 2;
                //    orderSum.LastLHouse = query.OrderBy(o => o.Sequence).Skip(sequence - 3).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                //}
                //if (sequence < count)
                //{
                //    se = sequence + 1;
                //    orderSum.NextHouse = query.OrderBy(o => o.Sequence).Skip(sequence).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                //}
                //if (count - sequence > 2)
                //{
                //    se = sequence + 2;
                //    orderSum.NextNHouse = query.OrderBy(o => o.Sequence).Skip(sequence + 1).Take(1).Select(o => o.RetailerName).FirstOrDefault();
                //}
                return query;
            }
        }
    }
}
