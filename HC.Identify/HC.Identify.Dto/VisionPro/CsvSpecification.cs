using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.Dto.VisionPro
{
    public class CsvSpecification
    {
        public string Specification { get; set; }

        public double[] Values { get; set; }

        public double dMaxScore { get; set; }
    }
}
