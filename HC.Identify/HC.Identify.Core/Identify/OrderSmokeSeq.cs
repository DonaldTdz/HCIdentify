using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Core.Identify
{
    [Table("OrderSmokeSeq", Schema = "dbo")]
    public class OrderSmokeSeq
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string UUID { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        [StringLength(15)]
        public string Brand { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [StringLength(200)]
        public string Specification { get; set; }

        /// <summary>
        /// 落烟顺序
        /// </summary>
        public int Sequence { get; set; }
    }
}
