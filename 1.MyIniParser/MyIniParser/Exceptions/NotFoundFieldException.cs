using System;

namespace MyIniParser.Exceptions
{
    public class NotFoundFieldException : ParserException
    {
        public NotFoundFieldException()
            : base("The specified field is not found.") {}
        
        public NotFoundFieldException(Exception inner)
            : base("The specified field is not found.", inner) {}
        public NotFoundFieldException(string message)
            : base($"The specified field is not found: {message}.") {}
        
        public NotFoundFieldException(string message, Exception inner)
            : base($"The specified field is not found: {message}.", inner) {}
    }
}