using System;

namespace MyIniParser.Exceptions
{
    public class InvalidTypeConversion : ParserException
    {
        public InvalidTypeConversion()
            : base("Error in conversion.") {}
        
        public InvalidTypeConversion(Exception inner)
            : base("Error in conversion.", inner) {}
        public InvalidTypeConversion(AvailableTypes from, AvailableTypes to)
            : base($"Error while converting from {from} to {to}.") {}
        
        public InvalidTypeConversion(AvailableTypes from, AvailableTypes to, Exception inner)
            : base($"Error while converting from {from} to {to}.", inner) {}
    }
}