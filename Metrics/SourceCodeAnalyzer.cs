using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metrics
{
    internal class SourceCodeAnalyzer
    {
        private string OperatorRegex =
            "=|>=|<=|<>|>|<|\\+|-|\\*|\\\\|:=|\\bmod\\b|\\bdiv\\b|" +
            "\\bif\\b|\\bin\\b|" +
            "\\bfor\\b|\\bwhile\\b|\\brepeat\\b|" +
            "\\bcase\\b|" +
            "\\bor\\b|\\band\\b|\\bnot\\b|\\bxor\\b|" +
            "\\bshr\\b|\\bshl\\b";

        private string LoopRegex = "\\bfor\\b.*?\\bdo\\b|\\bwhile\\b.*?\\bdo\\b|\\buntil\\b.*?;";
        private string ConditionalRegex = "\\bcase\\b.*?\\bof\\b|\\bif\\b.*?\\bthen\\b";

        private string ConditionalStatementRegex = "\\bif\\b|\\belse\\b";

        private string WordRegex = "\\b\\w+\\b|;";

        private AnalyzableSource SourceCode { get; set; }

        public SourceCodeAnalyzer(AnalyzableSource sourceCode)
        {
            SourceCode = sourceCode;
        }

        public int CountAllStatements()
        {
            string sourceString = SourceCode.NormalizedRepresentation;

            MatchCollection matches =
                    Regex.Matches(sourceString, OperatorRegex, RegexOptions.IgnoreCase);
              
            return matches.Count;
        }

        public int CountConditionalStatements()
        {
            string sourceString = SourceCode.NormalizedRepresentation;

            MatchCollection matches = Regex.Matches(sourceString,
                ConditionalStatementRegex, RegexOptions.IgnoreCase);

            return matches.Count;
        }

        public int CountConditionalNestingLevel()
        {
            int nestingLevel = 0;
            string sourceString = SourceCode.NormalizedRepresentation;

            MatchCollection matches =
                Regex.Matches(sourceString, WordRegex, RegexOptions.IgnoreCase);

            int i = 0;
            int maxNestingLevel = 0;
            int levelIndicator = 0;

            //nestingLevel = CountCurrentBlockLevel(matches, 0);

            return nestingLevel;
        }

        private int CountCurrentBlockLevel(MatchCollection matches, ref int i, int baseBlockLevel)
        {
            int blockLevel = baseBlockLevel + 1;
            int levelIndicator = 0;

            while (blockLevel > baseBlockLevel)
            {

            }
            return levelIndicator;

        }

        public int EvaluateCyclomaticComplexity()
        {
            CyclomaticComplexityEvaluator evaluator = 
                CyclomaticComplexityEvaluator.Instance;

            return evaluator.EvaluateCyclomaticComplexity(SourceCode);
        }

    }
}
