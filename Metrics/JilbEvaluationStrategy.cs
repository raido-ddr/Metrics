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
            int totalStatementCount = CountAllStatements(sourceCode);
            int conditionalStatementCount = CountConditionalStatements(sourceCode);
            int conditionNestingLevel = DetermineConditionNestingLevel(sourceCode);

            return new JilbMetric(totalStatementCount, conditionalStatementCount,
                conditionNestingLevel);

        }

        private int CountConditionalStatements(AnalyzableSource sourceCode)
        {
            throw new NotImplementedException();
        }

        private int CountAllStatements(AnalyzableSource sourceCode)
        {
            throw new NotImplementedException();
        }

        private int DetermineConditionNestingLevel(AnalyzableSource sourceCode)
        {
            throw new NotImplementedException();
        }
    }
}
