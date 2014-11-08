using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class MyersMetric : Metric
    {
        public override double Value
        {
            get { return CyclomaticComplexity; }
        }

        public int CyclomaticComplexity { get; set; }

        public MyersMetric(int cyclomaticComplexity)
        {
            CyclomaticComplexity = cyclomaticComplexity;
        }


    }
}
