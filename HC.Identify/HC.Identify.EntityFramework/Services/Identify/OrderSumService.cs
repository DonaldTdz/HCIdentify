using HC.Identify.Dto.Identify;
using HC.Identify.Dto.Ms01;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
                    Name = u.AreaName,
                    Value = u.AreaCode
                }).Distinct();

                return query.OrderBy(q => q.Name).ToList();
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
        public IList<OrderSumDto> GetOrderSumByAreaCode(int code)
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
                    RNum = o.RNum,
                    RIndex=o.RIndex
                }).ToList();
                return query;
            }
        }

        /// <summary>
        /// 批量导入户数信息
        /// </summary>
        public int DownloadData(IList<OrderSumMsDto> orderSumMsList)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var deSql = "delete from OrderSums";
                context.Database.ExecuteSqlCommand(deSql);
                var sql = new StringBuilder();
                foreach (var item in orderSumMsList)
                {
                     sql.AppendFormat("insert into OrderSums (Id,UUID,AreaCode,AreaName,RetailerCode,RetailerName,Sequence,Num,PostData,RNum,RIndex) values(newid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}',GETDATE(),0,{7});", item.OI_UUID ,item.B_CODE , item.OI_DL_NAME , item.OI_RETAILER_CODE , item.OI_RETAILER_NAME ,item.OI_SEQUENCE , item.OI_ALL_NUM,item.RowIndex);
                }
                var result = context.Database.ExecuteSqlCommand(sql.ToString());
                return result ;
            }
        }

        public IList<OrderSumForUpDoen> GetOrderSums(int code)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.OrderSums.Where(o => o.AreaCode == code).Select(o => new OrderSumForUpDoen
                {
                    Id = o.Id,
                    AreaName = o.AreaName,
                    RetailerName = o.RetailerName,
                    Sequence = o.Sequence,
                    Num = o.Num,
                    RIndex = o.RIndex
                }).ToList();
                return query;
            }
        }

        public int BatchUpdateOrderSum(IList<OrderSumForUpDoen> orderSumDtos)
        {
            using (IdentifyContext context=new IdentifyContext())
            {
                var sql = new StringBuilder();
                foreach (var item in orderSumDtos)
                {
                    sql.AppendFormat("update OrderSums set RIndex={0} where Id='{1}'", item.RIndex, item.Id);
                    //context.Entry(item).State = EntityState.Modified;
                }
                var result = context.Database.ExecuteSqlCommand(sql.ToString());
                //context.SaveChanges();
                return result;

            }
        }

        public string[] GetUUIDsByLineCode(int lineCode)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                return context.OrderSums.Where(o => o.AreaCode == lineCode).Select(o => o.UUID).ToArray();
            }
        }
    }
}
