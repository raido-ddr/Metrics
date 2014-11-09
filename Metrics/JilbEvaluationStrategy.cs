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
            SourceCodeAnalyzer analyzer = new SourceCodeAnalyzer(sourceCode);
            int totalStatementCount = analyzer.CountAllStatements();
            int conditionalStatementCount = analyzer.CountConditionalStatements();
            int conditionNestingLevel = analyzer.CountConditionalNestingLevel();

            return new JilbMetric(totalStatementCount, conditionalStatementCount,
                conditionNestingLevel);

        }

     
    }
}
