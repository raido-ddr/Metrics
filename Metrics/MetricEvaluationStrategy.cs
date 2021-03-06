﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    abstract class MetricEvaluationStrategy
    {
        public abstract Metric EvaluateMetric(AnalyzableSource sourceCode);
    }

}
