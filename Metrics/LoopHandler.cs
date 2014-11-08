using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metrics
{
    class LoopHandler : CyclomaticComplexityHandler
    {
        private string regex = "\\bfor\\b.*?\\bdo\\b|\\bwhile\\b.*?\\bdo\\b|\\buntil\\b.*?;";

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
