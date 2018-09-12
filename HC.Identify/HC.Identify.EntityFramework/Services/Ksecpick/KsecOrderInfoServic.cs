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
        public IList<VTaskOrderInfoDto> GetOrderInfo(string jobNum)
        {
            using (KsecpickContext context=new KsecpickContext())
            {
              var sql= String.Format(@"select uuid,SJOBNUM,SORTLINE,CUSTOMCODE,CUSTOMNAME,BARCODE,brandname,orderqty,unitno,MAKEBATCH
                           from [pick].[v_task] where SJOBNUM={0}", jobNum);
                var result = context.Database.SqlQuery<VTaskOrderInfoDto>(sql).ToList();
                return result;
            }
        }
    }
}
