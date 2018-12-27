using HC.Identify.Dto.Kesc;
using HC.Identify.Dto.Ksecpick;
using HC.Identify.EntityFramework.DBContexts;
using IBM.Data.DB2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC.Identify.EntityFramework.Services.Kesc
{
    public class KescOrderInfoService
    {
        public IList<KescOrderInfoDto> GetOrderInfo(int orderStartNum, string sortLine, int orderSum, string subSortLine)
        {
            using (KescContext context = new KescContext())
            {
                //sortLine = string.IsNullOrEmpty(sortLine) ? "L0204P-S09" : sortLine;

                //var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, * from[pick].[v_task] where SORTLINE = '{0}') temp where IndexNum  between {1}  and {2} order by IndexNum,unitno", sortLine, orderStartNum + 1, orderStartNum + orderSum);
                //var result = context.Database.SqlQuery<VTaskOrderInfoDto>(sql).ToList();
                //return result;
                IList<KescOrderInfoDto> result = null;
                List<DB2Parameter> para = new List<DB2Parameter>();
                sortLine = string.IsNullOrEmpty(sortLine) ? "SortlineSpe10" : sortLine;
                subSortLine = string.IsNullOrEmpty(subSortLine) ? "2" : subSortLine;

                para.Add(new DB2Parameter("@startNum", orderStartNum + 1));
                para.Add(new DB2Parameter("@sortLine", sortLine));
                para.Add(new DB2Parameter("@orderSum", orderStartNum + orderSum));
                para.Add(new DB2Parameter("@subSortLine", subSortLine));

                var sql = string.Format("select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, a.* from INF_V_TASK a where SORTLINE =@sortLine and SUBSORTLINE=@subSortLine) temp where IndexNum  between @startNum  and @orderSum order by IndexNum,UNITSEQ");

                try
                {
                    result = context.Database.SqlQuery<KescOrderInfoDto>(sql, para.ToArray()).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("获取数据失败，请检查数据库连接是否正常,具体错误信息为：" + ex.InnerException.Message);
                }
                return result;
            }


        }
        /// <summary>
        /// 根据任务号获取
        /// </summary>
        /// <param name="jobNum"></param>
        /// <param name="sortLine"></param>
        /// <returns></returns>
        public IList<KescOrderInfoDto> GetSingleRetailerOrderInfo(string uuidIn, string sortLine, string subSortLine)
        {
            using (KescContext context = new KescContext())
            {
                //sortLine = string.IsNullOrEmpty(sortLine) ? "L0204P-S09" : sortLine;
                //var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, * from[pick].[v_task] where SORTLINE = '{0}' ) temp where uuid='{1}' or SJOBNUM='{1}' order by IndexNum,unitno", sortLine, uuidIn);
                //var result = context.Database.SqlQuery<VTaskOrderInfoDto>(sql).ToList();
                //return result;
                IList<KescOrderInfoDto> result = null;
                List<DB2Parameter> para = new List<DB2Parameter>();
                sortLine = string.IsNullOrEmpty(sortLine) ? "SortlineSpe10" : sortLine;
                subSortLine = string.IsNullOrEmpty(subSortLine) ? "2" : subSortLine;

                para.Add(new DB2Parameter("@uuidIn", uuidIn));
                para.Add(new DB2Parameter("@sortLine", sortLine));
                para.Add(new DB2Parameter("@subSortLine", subSortLine));

                var sql = String.Format(@"select * from( select DENSE_RANK() over(order by SJOBNUM) IndexNum, a.* from INF_V_TASK a where SORTLINE = @sortLine and SUBSORTLINE=@subSortLine) temp where ORDERNUM=@uuidIn or SJOBNUM=@uuidIn order by IndexNum,UNITSEQ");
                try
                {
                     result = context.Database.SqlQuery<KescOrderInfoDto>(sql, para.ToArray()).ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("获取数据失败，请检查数据库连接是否正常,具体错误信息为：" + ex.InnerException.Message);
                }
                return result;
            }
        }
    }
}
