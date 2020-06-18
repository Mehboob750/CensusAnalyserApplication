namespace CensusAnalyserApplication
{
    using System;

    /// <summary>
    /// This Class used to Define Custom Exceptions
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CensusAnalyserException() 
        {
        }

        /// <summary>
        /// Parameterized constructor used to Initialize type of Exception
        /// </summary>
        /// <param name="type">It contains the type of Exception</param>
        /// <param name="message">It contains the message</param>
        public CensusAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// It is used when file is not readable
            /// </summary>
            CensusFileProblem,

            /// <summary>
            /// It is used when file contains incorrect header
            /// </summary>
            IncorrectHeader,

            /// <summary>
            /// It is used when file is not able to parse
            /// </summary>
            UnableToParse,

            /// <summary>
            /// It is used when file contains null value
            /// </summary>
            ValueCanNotBeNull,

            /// <summary>
            /// It is used when country name is invalid
            /// </summary>
            InvalidCountry
        }

        /// <summary>
        /// It creates the Reference of Exception Type
        /// </summary>
        public ExceptionType type { get; set; }
    }
}