using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Identify
{
   //public class OrderInfoDto
   // {
   //     public Guid Id { get; set; }

   //     public string UUID { get; set; }

   //     public string Brand { get; set; }

   //     public string Specification { get; set; }

   //     public int? Num { get; set; }

   //     public DateTime? PostDate { get; set; }

   //     /// <summary>
   //     /// 已匹配数量
   //     /// </summary>
   //     public int? Matched { get; set; }

   //     /// <summary>
   //     /// 未匹配数量
   //     /// </summary>
   //     public int? Unmatched { get; set; }

   // }
    public class OrderInfoDto
    {
        public Guid Id { get; set; }

        public string UUID { get; set; }

        public string Brand { get; set; }

        public string Specification { get; set; }

        public int? Num { get; set; }

        /// <summary>
        /// 已匹配数量
        /// </summary>
        public int? Matched { get; set; }

        /// <summary>
        /// 未匹配数量
        /// </summary>
        public int? Unmatched
        {
            get
            {
                return Num - Matched;
            }
        }
    }

    public class OrderInfoMatchResult
    {
        public bool IsExists { get; set; }

        public OrderInfoDto OrderInfo { get; set; }
    }

    /// <summary>
    /// 匹配结果
    /// </summary>
    public class OrderInfoMatchRe
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Specification { get; set; }
        /// <summary>
        /// 匹配状态
        /// </summary>
        public string MatchStatus { get; set; }
        /// <summary>
        /// 匹配时间
        /// </summary>
        public string MatchTime { get; set; }

        /// <summary>
        /// 落烟顺序
        /// </summary>
        public int Sequence { get; set; }

        public string UUID { get; set; }
    }
}
