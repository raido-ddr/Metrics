using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class JilbEvaluationStrategy : MetricEvaluationStrategy
    {
        public override Metric EvaluateMetric(AnalyzableSource sourceCode)
        {
            return new JilbMetric();
        }
    }
}
