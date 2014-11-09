using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metrics
{
    class CaseHandler : CyclomaticComplexityHandler
    {
        private string regex = "\\bcase\\b.*?\\bof\\b";
        private string beginsBlockRegex = "\\bcase\\b.*?\\bof\\b|begin";
        private string endsBlockRegex = "\\bend\\b;?";
        private string optionIndicatorRegex = ".*?:(?!=)";

        public override int EvaluateCyclomaticComplexity(string[] codeLines, int position)
        {

            if (Regex.IsMatch(codeLines[position], regex, RegexOptions.IgnoreCase))
            {
                return CountChoiceOptions(codeLines, position + 1) - 1;
            }
            else
            {
                return successor.EvaluateCyclomaticComplexity(codeLines, position);
            }
        }

        private int CountChoiceOptions(string[] codeLines, int position)
        {
            int blockCounter = 1;
            int optionsCount = 0;
            bool inOutmostCaseBlock = (blockCounter == 1);

            while (blockCounter > 0)
            {
                if (Regex.IsMatch(codeLines[position], beginsBlockRegex,
                    RegexOptions.IgnoreCase))
                {
                    blockCounter++;
                }
                else if (Regex.IsMatch(codeLines[position], endsBlockRegex,
                    RegexOptions.IgnoreCase))
                {
                    blockCounter--;
                }
                else
                {
                    if ((Regex.IsMatch(codeLines[position], optionIndicatorRegex))
                        && inOutmostCaseBlock)
                    {
                        optionsCount++;
                    }
                }

                position++;
            }

            return optionsCount;
        }
    }
}
