﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class GeneralStatementHandler : CyclomaticComplexityHandler
    {

        public override int EvaluateCyclomaticComplexity(string[] codeLines,
            int position)
        {
            return 0;
        }
    }
}
