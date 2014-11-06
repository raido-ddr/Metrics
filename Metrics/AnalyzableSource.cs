using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Metrics
{
    class AnalyzableSource
    {
        public string StringRepresentation { get; set; }

        public AnalyzableSource(string fileName)
        {
            StringRepresentation = ReadSourceFromFile(fileName);
        }

        private string ReadSourceFromFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}
