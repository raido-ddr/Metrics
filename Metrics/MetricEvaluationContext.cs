using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class MetricEvaluationContext
    {
        private MetricEvaluationStrategy Strategy { get; set; }

        public MetricEvaluationContext(MetricEvaluationStrategy strategy)
        {
            Strategy = strategy;
        }

        public Metric EvaluateMetric(AnalyzableSource sourceCode)
        {
            return Strategy.EvaluateMetric(sourceCode);
        }
    }
}
