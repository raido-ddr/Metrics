using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrics
{
    abstract class CyclomaticComplexityHandler
    {
        protected CyclomaticComplexityHandler successor;
        public void SetSuccessor(CyclomaticComplexityHandler successor)
        {
            this.successor = successor;
        }

        public abstract int EvaluateCyclomaticComplexity(string[] codeLines,
            int position);

    }
}
