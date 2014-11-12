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

        private string BlockStartRegex = "\\bbegin\\b";

        private string BlockEndRegex = "\\bend\\b";

        private AnalyzableSource SourceCode { get; set; }

        private string[] LinewiseCode { get; set; }

        private int ConditionalNestingDepth = 0;

        public SourceCodeAnalyzer(AnalyzableSource sourceCode)
        {
            SourceCode = sourceCode;
            LinewiseCode = sourceCode.LinewiseRepresentation;
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
            int i = position;

            while ((i < LinewiseCode.Length) && (conditionalDepth >= baseLevel))
            {
                Console.WriteLine("{0}: {1}", conditionalDepth, i + 1);
                UpdateConditionalNestingDepth(conditionalDepth);

                
                if (Regex.IsMatch(LinewiseCode[i], ConditionalRegex, RegexOptions.IgnoreCase))
                {
                    //Conditional statement encountered
                    i = ProcessConditionalStatement(i, baseLevel, isImplicit, ref conditionalDepth);

                }
                else if (Regex.IsMatch(LinewiseCode[i], BlockStartRegex,
                    RegexOptions.IgnoreCase))
                {
                    //'Begin' keyword encountered
                    ProcessBlockStart(i, ref nestingLevel);
                    i++;
                    
                }
                else if (Regex.IsMatch(LinewiseCode[i], BlockEndRegex,
                RegexOptions.IgnoreCase))
                {
                    //'End' keyword encountered
                    i = ProcessBlockEnd(i, ref nestingLevel, ref conditionalDepth);
                }
                else
                {
                    //Non-conditional statement encountered
                    i = ProcessDefaultStatement(i, ref conditionalDepth, isImplicit);
                }
                
            }

            Console.WriteLine("{0} end cond, ret {1}", conditionalDepth, i);
            return i;
        }

        private int ProcessConditionalStatement(int position, int baseLevel, 
            bool isImplicit, ref int conditionalDepth)
        {
            int i = position;
            bool notLastLine = i < (LinewiseCode.Length - 2);

            Console.WriteLine("cond: {0}", LinewiseCode[i]);

            
            if (notLastLine && (!Regex.IsMatch(LinewiseCode[i + 1], BlockStartRegex,
                RegexOptions.IgnoreCase)) && (!Regex.IsMatch(LinewiseCode[i], CaseRegex,
                RegexOptions.IgnoreCase)))
            {
                //'If' statement with implicit block encountered 
                Console.WriteLine("to implicit");
                i = ProcessConditionalNestingLevel(i + 1, baseLevel + 1, true);
            }
            else
            {
                //'If' statement with explicit block encountered 
                i = ProcessConditionalNestingLevel(i + 2, baseLevel + 1, false);
            }

            if (isImplicit)
            {
                //Implicit block ends
                Console.WriteLine("{0}: end implicit", conditionalDepth);
                conditionalDepth--;
            }

            return i;
        }

        private void ProcessBlockStart(int position, ref int nestingLevel)
        {
            if (!Regex.IsMatch(LinewiseCode[position - 1], ElseRegex,
                        RegexOptions.IgnoreCase))
            {
                //Skip 'begin' preceded by 'else'
                Console.WriteLine("begin");
                nestingLevel++;

            }
        }

        private int ProcessBlockEnd(int position, ref int nestingLevel,
            ref int conditionalDepth)
        {
            int i = position;
            bool notLastLine = i < (LinewiseCode.Length - 2);
            if (notLastLine && (!Regex.IsMatch(LinewiseCode[i + 1], ElseRegex,
                RegexOptions.IgnoreCase)))
            {
                //'End' is not followed by 'else'
                Console.WriteLine("end");
                if (nestingLevel == 0)
                {
                    //Non-coditional statement block is being processed
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
                //Skip 'end' followed by 'else'
                i += 2;
            }

            return i;
        }

        private int ProcessDefaultStatement(int position, ref int conditionalDepth,
            bool isImplicit)
        {
            int i = position;

            //Non-conditional statement encountered
            if (isImplicit)
            {
                bool notLastLine = i < (LinewiseCode.Length - 2);
                if (notLastLine && (!Regex.IsMatch(LinewiseCode[i + 1], ElseRegex,
                    RegexOptions.IgnoreCase)))
                {
                    //Statement represents the body of the implicit conditional block
                    Console.WriteLine("{0} end implicit", conditionalDepth);
                    conditionalDepth--;
                    i++;
                }
                else
                {
                    //Skip 'else' keyword
                    i += 2;
                }

            }
            else
            {
                i++;
            }

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
