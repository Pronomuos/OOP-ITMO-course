using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackupsManager.Models.Interfaces
{
    public interface IRestorePoint
    {
        public DateTime CreateTime { get; }
        public  IEnumerable<File> Files { get; }
        
        public int Size { get; }
        
        public IEnumerable<string> GetFilePaths()
            => Files.Select(file => file.Name);
           
        
    }
}