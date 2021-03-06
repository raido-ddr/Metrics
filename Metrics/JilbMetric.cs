﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class JilbMetric : Metric
    {
        public override double Value
        {
            get { return  (double) ConditionalStatementCount / (double)TotalStatementCount; }
        }

        public int TotalStatementCount { get; set; }

        public int ConditionalStatementCount { get; set; }

        public int ConditionNestingLevel { get; set; }

        public JilbMetric(int totalStatementCount, 
            int conditionalStatementCount, int conditionNestingLevel)
        {
            ConditionalStatementCount = conditionalStatementCount;
            TotalStatementCount = totalStatementCount;
            ConditionNestingLevel = conditionNestingLevel;
        }

    }
}
