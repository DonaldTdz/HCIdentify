using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.Identify
{
   public class OrderInfoDto
    {
        public int Id { get; set; }

        public string UUID { get; set; }

        public string Brand { get; set; }

        public string Specification { get; set; }

        public int? Num { get; set; }

        public DateTime? PostData { get; set; }

    }
}
