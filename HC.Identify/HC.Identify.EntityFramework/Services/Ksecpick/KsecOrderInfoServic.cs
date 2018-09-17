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
        public  IList<VTaskOrderInfoDto> GetOrderInfo(int orderStartNum, string sortLine,int orderSum)
        {
            
                using (KsecpickContext context = new KsecpickContext())
                {
                    //var sql= String.Format(@"select uuid,SJOBNUM,SORTLINE,CUSTOMCODE,CUSTOMNAME,BARCODE,brandname,orderqty,unitno,MAKEBATCH
                    //             from [pick].[v_task] where SJOBNUM={0}", jobNum);

                    sortLine = string.IsNullOrEmpty(sortLine) ? "L0204P-S09" : sortLine;
                //var sql = String.Format(@"select  uuid,SJOBNUM,SORTLINE,CUSTOMCODE,CUSTOMNAME,BARCODE,brandname,orderqty,unitno,MAKEBATCH
                //           from [pick].[v_task] where[SJOBNUM]=(select top 1 t.[SJOBNUM] from (select distinct top {0} [SJOBNUM]  from [pick].[v_task] where SORTLINE='{1}' order by [SJOBNUM] ) t order by t.SJOBNUM desc)  and SORTLINE='{1}'", jobNum, sortLine);
                //var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, *from[pick].[v_task] where SORTLINE = '{0}') temp where IndexNum= {1} order by unitno", sortLine, jobNum);

                var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, *from[pick].[v_task] where SORTLINE = '{0}') temp where IndexNum  between {1}  and {2} order by IndexNum,unitno", sortLine, orderStartNum+1, orderStartNum+orderSum);
                var result = context.Database.SqlQuery<VTaskOrderInfoDto>(sql).ToList();
                    return result;
                }
        }
    }
}
