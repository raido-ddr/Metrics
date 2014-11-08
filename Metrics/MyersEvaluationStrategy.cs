using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class MyersEvaluationStrategy : MetricEvaluationStrategy
    {
        public override Metric EvaluateMetric(AnalyzableSource sourceCode)
        {
            SourceCodeAnalyzer analyzer = new SourceCodeAnalyzer(sourceCode);
            int cyclomaticComplexity = analyzer.EvaluateCyclomaticComplexity();

            return new MyersMetric(cyclomaticComplexity);
        }
    }
}
