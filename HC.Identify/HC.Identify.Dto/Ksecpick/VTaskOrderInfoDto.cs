using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Ksecpick
{
    public class VTaskOrderInfoDto
    {
        public string uuid { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        public string SJOBNUM { get; set; }

        /// <summary>
        /// 线路
        /// </summary>
        public string SORTLINE { get; set; }

        /// <summary>
        /// 零售户编码
        /// </summary>
        public string CUSTOMCODE { get; set; }

        /// <summary>
        /// 零售户名
        /// </summary>
        public string CUSTOMNAME { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string BARCODE{get;set;}

        /// <summary>
        /// 品规
        /// </summary>
        public string brandname { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public decimal orderqty { get; set; }

        /// <summary>
        /// 落烟顺序
        /// </summary>
        public int? unitno { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        public string MAKEBATCH { get; set; }


    }
}
