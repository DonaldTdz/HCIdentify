using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Ms01
{
    public class OderInfoMsDto
    {
        /// <summary>
        /// UUID
        /// </summary>
        public string OCI_UUID { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string OCI_CIG_BRAND { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string OCI_CIG_TRADEMARK { get; set; }

        /// <summary>
        /// 订单量
        /// </summary>
        public int OCI_ORDER_NUM { get; set; }

    }
}
