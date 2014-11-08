using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metrics
{
    class ConditionalHandler : CyclomaticComplexityHandler
    {
        private string regex = "\\bif\\b.*?\\bthen\\b";

        public override int EvaluateCyclomaticComplexity(string[] codeLines, int position)
        {

            if (Regex.IsMatch(codeLines[position], regex, RegexOptions.IgnoreCase))
            {
                return 1;
            }
            else
            {
                return successor.EvaluateCyclomaticComplexity(codeLines, position);
            }
        }

        
    }
}
