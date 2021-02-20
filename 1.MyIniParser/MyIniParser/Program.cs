using System;
using System.IO;
using System.Linq;
using MyIniParser.Parser;
using MyIniParser.Exceptions;

namespace MyIniParser
{
    internal static class Program {
       
        public static void Main(string[] args) {
            if (args.Length < 1 && args.Length > 4) {
                Console.Error.WriteLine("Invalid number of args");
                return;
            }

            ParsedIniFile parser = null;
            try {
                parser = IniParser.Parse(args[0]);
            }
            catch (ParserException e) {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.InnerException.Message);
                Console.Error.WriteLine(e.StackTrace);
                return;
            }
            
            var section = args[1];
            var key = args[2];
            var type = args[3];

            if (!Enum.GetNames(typeof(AvailableTypes)).Any(x => x.ToLower() == type.ToLower()))
            {
                Console.Error.WriteLine("Incorrect type.");
                return;
            }
            try
            {
                switch (type.ToLower())
                {
                    case "int":
                        Console.WriteLine(parser.TryGetInt(section, key));
                        break;
                    case "float":
                        Console.WriteLine(parser.TryGetFloat(section, key));
                        break;
                    case "string":
                        Console.WriteLine(parser.TryGetString(section, key));
                        break;
                    default:
                        Console.Error.WriteLine("Incorrect type.");
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("File not found");
            }
            catch (ParserException e) {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.InnerException.Message);
                Console.Error.WriteLine(e.StackTrace);
            }
        }
    }
}