using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.Core.Identify
{
    [Table("SystemConfig", Schema = "dbo")]
    public class SystemConfig
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public ConfigEnum? Code { get; set; }

        /// <summary>
        /// 值（ip）
        /// </summary>
        [StringLength(50)]
        public string Value { get; set; }

        /// <summary>
        /// 附加值（端口）
        /// </summary>
        [StringLength(50)]
        public string AdditiValue { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsAction { get; set; }
    }
}
