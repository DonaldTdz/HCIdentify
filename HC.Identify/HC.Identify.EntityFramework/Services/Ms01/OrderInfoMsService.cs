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
    public class OrderInfoMsService
    {
        public IList<OderInfoMsDto> GetOrderInfoMsList()
        {
            using (Ms01Context context = new Ms01Context())
            {
                //List<SqlParameter> paras = new List<SqlParameter>();
                var sql = @"select oci_uuid,oci_cig_brand,oci_cig_trademark,oci_order_num 
                           from bp_order_cig_info where oci_uuid in 
                          (SELECT oi_uuid FROM BP_ORDER_INFO where  CONVERT(varchar(100),oi_sort_date, 23)=CONVERT(varchar(100),getdate(), 23))";
                var result = context.Database.SqlQuery<OderInfoMsDto>(sql).ToList();
                return result;
            }
        }
    }
}
