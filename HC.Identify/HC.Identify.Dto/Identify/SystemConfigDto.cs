using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HC.Identify.Core.Identify.IdentifyEnum;

namespace HC.Identify.Dto.Identify
{
   public class SystemConfigDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public ConfigEnum? Code { get; set; }

        /// <summary>
        /// 值（ip）
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 附加值（端口）
        /// </summary>
        public string AdditiValue { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsAction { get; set; }
    }
}
