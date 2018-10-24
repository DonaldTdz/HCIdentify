using HC.Identify.Dto.Ksecpick;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.Services.Ksecpick
{
    public class KsecOrderInfoServic
    {
        public IList<VTaskOrderInfoDto> GetOrderInfo(int orderStartNum, string sortLine, int orderSum)
        {

            using (KsecpickContext context = new KsecpickContext())
            {
                sortLine = string.IsNullOrEmpty(sortLine) ? "L0204P-S09" : sortLine;

                var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, * from[pick].[v_task] where SORTLINE = '{0}') temp where IndexNum  between {1}  and {2} order by IndexNum,unitno", sortLine, orderStartNum + 1, orderStartNum + orderSum);
                var result = context.Database.SqlQuery<VTaskOrderInfoDto>(sql).ToList();
                return result;
            }
        }
        /// <summary>
        /// 根据任务号获取
        /// </summary>
        /// <param name="jobNum"></param>
        /// <param name="sortLine"></param>
        /// <returns></returns>
        public IList<VTaskOrderInfoDto> GetSingleRetailerOrderInfo(string uuidIn, string sortLine)
        {
            using (KsecpickContext context = new KsecpickContext())
            {
                sortLine = string.IsNullOrEmpty(sortLine) ? "L0204P-S09" : sortLine;
                var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, * from[pick].[v_task] where SORTLINE = '{0}' ) temp where uuid='{1}' or IndexNum='{1}' order by IndexNum,unitno", sortLine, uuidIn);
                var result = context.Database.SqlQuery<VTaskOrderInfoDto>(sql).ToList();
                return result;
            }
        }
    }
}
