using System.Dynamic;

namespace BackupsManager.Models
{
    public class File
    {
        public string Name { get; }
        public int Length { get; }
        public string Path { get; }

        public File(string name, int memory)
        {
            Name = name;
            Length = memory;
        }
    }
}