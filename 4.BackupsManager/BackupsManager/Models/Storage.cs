using System.Collections.Generic;

namespace BackupsManager.Models
{
    public class Storage
    {
        public string DirectoryName { get; set;}
        public string DirectoryPath { get; set;}
        public List<File> FilesList { get; set;}

        public Storage(string direcName, string direcPath)
        {
            FilesList = new List<File>();
            DirectoryPath = direcPath;
            DirectoryName = direcName;
        }
        

    }
}