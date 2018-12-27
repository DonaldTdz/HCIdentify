using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Common
{
   public class COMDto
    {
        /// <summary>
        /// COM口名
        /// </summary>
        public string COMName { get; set; }
        /// <summary>
        /// 比特率
        /// </summary>
        public int COMRate { get; set; }

        /// <summary>
        /// 校验位
        /// </summary>
        public int COMParity { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        public int ComData { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        public int ComStop { get; set; }
    }
}
