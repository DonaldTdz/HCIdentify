using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Identify
{
    public class OrderSumDto
    {
        public Guid Id { get; set; }

        public string UUID { get; set; }

        public int? AreaCode { get; set; }

        public string AreaName { get; set; }

        public string RetailerCode { get; set; }

        public string RetailerName { get; set; }

        public int? Sequence { get; set; }

        public int? Num { get; set; }

        public DateTime? PostData { get; set; }

        public int? RNum { get; set; }

        /// <summary>
        /// 上一户
        /// </summary>
        public string LastHouse { get; set; }

        /// <summary>
        /// 上上户
        /// </summary>
        public string LastLHouse { get; set; }

        /// <summary>
        /// 下一户
        /// </summary>
        public string NextHouse { get; set; }

        /// <summary>
        /// 下下户
        /// </summary>
        public string NextNHouse { get; set; }


    }

    public class AreaInfo
    {
        public int? Value { get; set; }
        public string Name{ get; set; }
    }

    public class OrderSumAddCountDtos
    {
        public List<OrderSumDto> OrderSumDtos { get; set; }
        public int? Count { get; set; }
    }
    public class OrderSumAddCountDto
    {
        public OrderSumDto OrderSumDto { get; set; }
        public int? Count { get; set; }
    }
}
