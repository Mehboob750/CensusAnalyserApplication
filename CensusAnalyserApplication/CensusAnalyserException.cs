using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserApplication
{
    public class CensusAnalyserException : Exception
    {
        public CensusAnalyserException() { }

        public enum ExceptionType
        {
            CensusFileProblem,DelimeterIncorrectException
        }

        public ExceptionType type { get; set; }

        public CensusAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
