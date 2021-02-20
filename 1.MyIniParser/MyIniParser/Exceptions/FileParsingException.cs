using System;

namespace MyIniParser.Exceptions
{
    public class FileParsingException : ParserException
    {
        public FileParsingException(string message, Exception inner)
            : base($"File parsing exception: {message}.", inner) {}
        
        public FileParsingException(string message)
            : base($"File parsing exception: {message}.") {}
        
        public FileParsingException()
            : base("File parsing exception.") {}
        public FileParsingException(Exception inner)
            : base("File parsing exception.", inner) {}
            
    }
}