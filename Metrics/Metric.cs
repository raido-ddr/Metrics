using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metrics
{
    abstract class Metric
    {
        public double Value { get; set; }
        public int ConditionalStatementCount { get; set; }
    }
}
