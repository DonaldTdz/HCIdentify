using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Core.Identify
{
    [Table("OrderSums", Schema = "dbo")]
    public class OrderSum
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        [StringLength(50)]
        public string UUID { get; set; }

        /// <summary>
        /// 区域Code
        /// </summary>
        public int? AreaCode { get; set; }

        /// <summary>
        /// 区域名
        /// </summary>
        [StringLength(200)]
        public string AreaName { get; set; }

        /// <summary>
        /// 零售客户Code
        /// </summary>
        [StringLength(50)]
        public string RetailerCode { get; set; }

        /// <summary>
        /// 零售客户名称
        /// </summary>
        [StringLength(100)]
        public string RetailerName { get; set; }

        /// <summary>
        /// 订单顺序
        /// </summary>
        public int? Sequence { get; set; }

        /// <summary>
        /// 订单商品总数
        /// </summary>
        public int? Num { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        public DateTime? PostData { get; set; }

        /// <summary>
        /// RNum
        /// </summary>
        public int? RNum { get; set; }
    }
}
