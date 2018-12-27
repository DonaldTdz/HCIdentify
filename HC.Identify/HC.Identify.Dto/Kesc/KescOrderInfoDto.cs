using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Kesc
{
   public class KescOrderInfoDto
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string ORDERNUM { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        public string SJOBNUM { get; set; }

        /// <summary>
        /// 线路
        /// </summary>
        public string SORTLINE { get; set; }
        /// <summary>
        /// 分拣支线
        /// </summary>
        public string SUBSORTLINE { get; set; }

        /// <summary>
        /// 零售户编码
        /// </summary>
        public string CUSTOMCODE { get; set; }

        /// <summary>
        /// 零售户名
        /// </summary>
        public string CUSTOMDESC { get; set; }

        /// <summary>
        /// 零售户地址
        /// </summary>
        public string CUSTOMADDRESS { get; set; }


        /// <summary>
        /// 条码
        /// </summary>
        public string BARCODE { get; set; }

        /// <summary>
        /// 品规
        /// </summary>
        public string ITEMNAME { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public decimal ITEMTOTAL { get; set; }

        /// <summary>
        /// 落烟顺序
        /// </summary>
        public decimal UNITSEQ { get; set; }

        /// <summary>
        /// 订单提交时间
        /// </summary>
        public string MAKEBATCH { get; set; }//未定

        /// <summary>
        /// 订单顺序
        /// </summary>
        public long IndexNum { get; set; }
        

        /// <summary>
        /// 批次
        /// </summary>
        public string BATCHCODE { get; set; }

    }

    public class adminDto
    {
        public Int16 ACTNO { get; set; }

        public string ACTKWD { get; set; }

        public string ACTDESC { get; set; }
    }
}
