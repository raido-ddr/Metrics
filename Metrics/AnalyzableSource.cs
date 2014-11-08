using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Metrics
{
    class AnalyzableSource
    {
        public string StringRepresentation { get; set; }

        private readonly string SplittingRegex  = 
            "[ \\t]+(?=\\bbegin\\b|\\bend\\b|;|{|else|do|:(?!=))" +
            "|(?<=\\bbegin\\b|\\bend\\b|;|}|\\belse\\b|\\bthen\\b|\\bof\\b|:(?<!=))[ \\t]";

        public AnalyzableSource(string fileName)
        {
            StringRepresentation = ReadSourceFromFile(fileName).ToLower();
        }

        private string ReadSourceFromFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        internal string[] SplitInLines()
        {
            string splittableCode = Regex.Replace(StringRepresentation, 
                SplittingRegex, Environment.NewLine);

            string[] splittedLines = splittableCode.Split(new string[]{Environment.NewLine},
                StringSplitOptions.None);

            foreach (var line in splittedLines)
            {
                line.Trim();
            }

            return splittedLines;
        }

        
    }
}
