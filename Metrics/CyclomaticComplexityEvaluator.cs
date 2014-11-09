using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    class CyclomaticComplexityEvaluator
    {
        public static CyclomaticComplexityEvaluator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CyclomaticComplexityEvaluator();
                }
                return instance;
            }
        }

        private static CyclomaticComplexityEvaluator instance;

        private CyclomaticComplexityHandler FirstHandler { get; set; }

        public int EvaluateCyclomaticComplexity(AnalyzableSource sourceCode)
        {
            string[] codeLines = sourceCode.LinewiseRepresentation;
            int cyclomaticComplexity = 0;

            for (int i = 0; i < codeLines.Length; i++)
            {
                cyclomaticComplexity +=
                    FirstHandler
                .EvaluateCyclomaticComplexity(codeLines, i);
            }

            return cyclomaticComplexity;
        }

        private CyclomaticComplexityEvaluator()
        {
            BuildHandlerChain();
        }

        private void BuildHandlerChain()
        {
            FirstHandler = new ConditionalHandler();
            CyclomaticComplexityHandler loopHandler = new LoopHandler();
            CyclomaticComplexityHandler caseHandler = new CaseHandler();
            CyclomaticComplexityHandler generalHandler = new DefaultStatementHandler();

            FirstHandler.SetSuccessor(loopHandler);
            loopHandler.SetSuccessor(caseHandler);
            caseHandler.SetSuccessor(generalHandler);
            generalHandler.SetSuccessor(null);

        }

        
    }
}
