using HC.Identify.Dto.Ms01;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.Services.Ms01
{
    public class OrderSumMsService
    {
        public IList<OrderSumMsDto> GetOrderSumMs()
        {
            using (Ms01Context context = new Ms01Context())
            {
                List<SqlParameter> paras = new List<SqlParameter>();
                var sql = "select OI_UUID,OI_DL_NAME,B_CODE,OI_RETAILER_CODE,OI_RETAILER_NAME, OI_SEQUENCE,OI_ALL_NUM from BP_BATCH,BP_ORDER_INFO where CONVERT(varchar(100),b_sort_date, 23)=CONVERT(varchar(100),getdate(), 23) and oi_b_uuid=b_uuid";
                var result = context.Database.SqlQuery<OrderSumMsDto>(sql, paras.ToArray()).ToList();
                return result;
            }
        }
    }
}
