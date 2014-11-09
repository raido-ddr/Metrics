using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Metrics
{
    class SourceCodePreprocessor
    {
        private readonly string unanalyzableRegionRegex =
            "\\(\\*[^(\\(\\*)(\\*\\))]*\\*\\)|\"[^\"]*\"|'[^']*'|\\{[^\\{\\}]*\\}";

        private readonly string RedundantWhitespaceRegex = "\\s+\\n\\s+";

        private readonly string SplittingRegex =
            "[ \\t]+(?=\\bbegin\\b|\\bend\\b|;|{|\\belse\\b|:(?!=))" +
            "|(?<=\\bbegin\\b|\\bend\\b|;|}|\\belse\\b|\\bthen\\b|" +
            "\\bof\\b|\\bdo\\b|:(?<!=))[ \\t]";

        public static SourceCodePreprocessor Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SourceCodePreprocessor();
                }
                return instance;
            }
        }

        private static SourceCodePreprocessor instance;

        private SourceCodePreprocessor()
        { }

        public string[] SplitNormalizedSource(string normalizedCodeString)
        {
            string splittableCode = Regex.Replace(normalizedCodeString,
                SplittingRegex, Environment.NewLine);

            string[] linewiseRepresentation =
                splittableCode.Split(new string[] { Environment.NewLine },
                StringSplitOptions.None);

            for (int i = 0; i < linewiseRepresentation.Length; i++)
            {
                linewiseRepresentation[i] = linewiseRepresentation[i].Trim();
            }

            return linewiseRepresentation;
        }


        public string NormalizeSourceString(string sourceCodeString)
        {
            RemoveUnanalizableRegions(ref sourceCodeString);
            RemoveRedundantWhitespaces(ref sourceCodeString);

            return sourceCodeString;
        }


        private void RemoveUnanalizableRegions(ref string sourceCodeString)
        {
            sourceCodeString =
                Regex.Replace(sourceCodeString, unanalyzableRegionRegex, " ");
        }

        private void RemoveRedundantWhitespaces(ref string sourceCodeString)
        {
            sourceCodeString =
                Regex.Replace(sourceCodeString, RedundantWhitespaceRegex,
                Environment.NewLine);
        }

      
        

    }
}
