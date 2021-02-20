
using System;

namespace MyIniParser.Exceptions
{
    public class InvalidFieldException : ParserException
    {
        public InvalidFieldException()
            : base("Invalid field exception.") {}
        
        public InvalidFieldException(Exception inner)
            : base("Invalid field exception.", inner) {}
        public InvalidFieldException(string message)
            : base($"Invalid field exception: {message}.") {}
        
        public InvalidFieldException(string message, Exception inner)
            : base($"Invalid field exception: {message}.", inner) {}
    }
}