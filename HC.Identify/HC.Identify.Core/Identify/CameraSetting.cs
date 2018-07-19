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
    [Table("CameraSetting", Schema = "dbo")]
    public class CameraSetting
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 配置项类型
        /// </summary>
        public CameraEnum? Code { get; set; }

        /// <summary>
        /// 配置项值
        /// </summary>
        [StringLength(400)]
        public string Value { get; set; }

        /// <summary>
        /// 配置项描述
        /// </summary>
        [StringLength(100)]
        public string Desc { get; set; }
    }
}
