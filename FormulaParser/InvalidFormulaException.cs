using System;
using System.Runtime.Serialization;

namespace FormulaParser
{
    [Serializable]
    internal class InvalidFormulaException : Exception
    {
        public InvalidFormulaException()
        {
        }

        public InvalidFormulaException(string message) : base(message)
        {
        }

        public InvalidFormulaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFormulaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}