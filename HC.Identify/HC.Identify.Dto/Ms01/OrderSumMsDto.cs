using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Ms01
{
   public class OrderSumMsDto
    {
        /// <summary>
        /// UUID
        /// </summary>
        public string OI_UUID { get; set; }
        /// <summary>
        /// 区域Code
        /// </summary>
        public string B_CODE { get; set; }
        /// <summary>
        /// 区域名
        /// </summary>
        public string OI_DL_NAME { get; set; }
        /// <summary>
        /// 零售户Code
        /// </summary>
        public string OI_RETAILER_CODE { get; set; }
        /// <summary>
        /// 零售户名字
        /// </summary>
        public string OI_RETAILER_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? OI_SEQUENCE { get; set; }
        /// <summary>
        /// 订购数量
        /// </summary>
        public int? OI_ALL_NUM { get; set; }
    }
}
