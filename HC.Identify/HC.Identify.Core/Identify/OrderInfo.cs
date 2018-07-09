using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Core.Identify
{
    [Table("OrderInfo", Schema = "dbo")]
    public class OrderInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// uuid
        /// </summary>
        [StringLength(50)]
        public string UUID { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        [StringLength(15)]
        public string Brand { get; set; }

        /// <summary>
        /// 品规
        /// </summary>
        [StringLength(200)]
        public string Specification { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int? Num { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        public DateTime? PostData { get; set; }

    }
}
