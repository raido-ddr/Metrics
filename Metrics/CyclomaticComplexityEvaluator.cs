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

        public int EvaluateCyclomaticComplexity(string[] codeLines, int position)
        {
            return FirstHandler.EvaluateCyclomaticComplexity(codeLines, position);
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
            CyclomaticComplexityHandler generalHandler = new GeneralStatementHandler();

            FirstHandler.SetSuccessor(loopHandler);
            loopHandler.SetSuccessor(caseHandler);
            caseHandler.SetSuccessor(generalHandler);
            generalHandler.SetSuccessor(null);

        }

        
    }
}
