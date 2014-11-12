using System;
using System.Collections.Generic;
using System.Data;
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

        private string ElseRegex = "\\belse\\b";

        private string CaseRegex = "\\bcase\\b.*?\\bof\\b";

        private string ConditionalStatementRegex = "\\bif\\b|\\bcase\\b";

        private string PredicateOperatorRegex = "\\bif\\b";

        private static string PredicateRegex =
            "(\\s*(<>|(?<!:)=|<|>)\\s*)(?=[^\\s0-9])|(?<=[^\\s0-9])(\\s*(<>|(?<!:)=|<|>)\\s*)";

        private string WordRegex = "\\b\\w+\\b|;";

        private string BlockStartRegex = "\\bbegin\\b";

        private string BlockEndRegex = "\\bend\\b";

        private AnalyzableSource SourceCode { get; set; }

        private int ConditionalNestingDepth = 0;

        public SourceCodeAnalyzer(AnalyzableSource sourceCode)
        {
            SourceCode = sourceCode;
        }

        public int CountAllStatements()
        {
            return CountRegexMatches(OperatorRegex);
        }

        public int CountConditionalStatements()
        {
            int m = CountRegexMatches(ConditionalStatementRegex);
            return m;
        }


        public int EvaluateCyclomaticComplexity()
        {
            CyclomaticComplexityEvaluator evaluator =
                CyclomaticComplexityEvaluator.Instance;

            return evaluator.EvaluateCyclomaticComplexity(SourceCode);
        }

        public int CountPredicates()
        {
            return CountRegexMatches(PredicateRegex);
        }

        public int CountOperatorsWithPredicates()
        {
            return CountRegexMatches(PredicateOperatorRegex);
        }

        private int CountRegexMatches(string regex)
        {

            MatchCollection matches =
                Regex.Matches(SourceCode.NormalizedRepresentation, regex,
                    RegexOptions.IgnoreCase);

            return matches.Count;
        }

        public int CountConditionalNestingLevel()
        {
            ConditionalNestingDepth = 0;
            ProcessConditionalNestingLevel(0, 0, false);

            return ConditionalNestingDepth;
        }


        private int ProcessConditionalNestingLevel(int position, int baseLevel, bool isImplicit)
        {
            int conditionalDepth = baseLevel;
            int nestingLevel = 0;
            string[] linewiseCode = SourceCode.LinewiseRepresentation;
            int i = position;

            while ((i < linewiseCode.Length) && (conditionalDepth >= baseLevel))
            {
                Console.WriteLine("{0}: {1}", conditionalDepth, i + 1);
                UpdateConditionalNestingDepth(conditionalDepth);

                if (Regex.IsMatch(linewiseCode[i], ConditionalRegex, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("cond: {0}", linewiseCode[i]);
                    bool notLastLine = i < (linewiseCode.Length - 2);

                    if (notLastLine && (!Regex.IsMatch(linewiseCode[i + 1], BlockStartRegex,
                        RegexOptions.IgnoreCase)) && (!Regex.IsMatch(linewiseCode[i], CaseRegex,
                        RegexOptions.IgnoreCase)))
                    {
                        Console.WriteLine("to implicit");
                        i = ProcessConditionalNestingLevel(i + 1, baseLevel + 1, true);
                    }
                    else
                    {
                        i = ProcessConditionalNestingLevel(i + 2, baseLevel + 1, false);
                    }

                    if (isImplicit)
                    {
                        Console.WriteLine("{0}: end implicit", conditionalDepth);
                        conditionalDepth--;
                    }

                }
                else if (Regex.IsMatch(linewiseCode[i], BlockStartRegex,
                    RegexOptions.IgnoreCase))
                {
                    if (!Regex.IsMatch(linewiseCode[i - 1], ElseRegex,
                        RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine("begin");
                        nestingLevel++;
                        
                    }
                    i++;
                    
                }
                else if (Regex.IsMatch(linewiseCode[i], BlockEndRegex,
                RegexOptions.IgnoreCase))
                {
                    bool notLastLine = i < (linewiseCode.Length - 2);
                    if (notLastLine &&  (!Regex.IsMatch(linewiseCode[i + 1], ElseRegex,
                        RegexOptions.IgnoreCase)))
                    {
                        Console.WriteLine("end");
                        if (nestingLevel == 0)
                        {
                            conditionalDepth--;
                            
                        }
                        else
                        {
                            nestingLevel--;
                        }
                        i++;
                    }
                    else
                    {
                        i += 2;
                    }
                }
                else
                {
                    if (isImplicit)
                    {
                        bool notLastLine = i < (linewiseCode.Length - 2);
                        if (notLastLine && (! Regex.IsMatch(linewiseCode[i + 1], ElseRegex,
                            RegexOptions.IgnoreCase)))
                        {
                            Console.WriteLine("{0} end implicit", conditionalDepth);
                            conditionalDepth--;
                            i++;
                        }
                        else
                        {
                            i += 2;
                        }

                    }
                    else
                    {
                        i++;
                    }
                }

                
            }

            
            Console.WriteLine("{0} end cond, ret {1}", conditionalDepth, i);

            return i;
        }

        private void UpdateConditionalNestingDepth(int nestingLevel)
        {
            if (nestingLevel > ConditionalNestingDepth)
            {
                ConditionalNestingDepth = nestingLevel;
            }
        }

    }
}
