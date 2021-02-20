using System; 

namespace MyIniParser.Exceptions
{
    public class InvalidFileFormatException : ParserException
    {
        public InvalidFileFormatException()
            : base("File format is not ini.") {}
        
        public InvalidFileFormatException(Exception inner)
            : base("File format is not ini.", inner) {}
        public InvalidFileFormatException(string message)
            : base("File format is not ini.") {}
        
        public InvalidFileFormatException(string message, Exception inner)
            : base("File format is not ini.", inner) {}
    }
}