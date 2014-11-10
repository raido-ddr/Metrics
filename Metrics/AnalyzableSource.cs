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
        public string NormalizedRepresentation { get; set; }

        public string RawRepresentation { get; set; }

        public string[] LinewiseRepresentation { get; set; }


        public AnalyzableSource(string fileName)
        {
            SourceCodePreprocessor preprocessor =
                SourceCodePreprocessor.Instance;

            RawRepresentation = ReadSourceFromFile(fileName).ToLower();
            NormalizedRepresentation = 
                preprocessor.NormalizeSourceString(RawRepresentation);
            LinewiseRepresentation =
                preprocessor.SplitNormalizedSource(NormalizedRepresentation);

            //For debug purposes only
            File.WriteAllLines("lines.txt", LinewiseRepresentation);

        }

        private string ReadSourceFromFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        
    }
}
