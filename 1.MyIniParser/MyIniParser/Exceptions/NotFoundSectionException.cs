using System;

namespace MyIniParser.Exceptions
{
    public class NotFoundSectionException : ParserException
    {
        public NotFoundSectionException()
            : base("The specified section is not found.") {}
        
        public NotFoundSectionException(Exception inner)
            : base("The specified section is not found.", inner) {}
        public NotFoundSectionException(string message)
            : base($"The specified section is not found: {message}.") {}
        
        public NotFoundSectionException(string message, Exception inner)
            : base($"The specified section is not found: {message}.", inner) {}
    }
}