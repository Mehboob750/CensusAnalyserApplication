
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserApplication
{
    /// <summary>
    /// CensusAnalyserException Class used to Define Custom Exceptions
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        public CensusAnalyserException() { }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            CensusFileProblem, IncorrectHeader, UnableToParse, ValueCanNotBeNull, INVALID_COUNTRY
        }

        public ExceptionType type { get; set; }

        public CensusAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}