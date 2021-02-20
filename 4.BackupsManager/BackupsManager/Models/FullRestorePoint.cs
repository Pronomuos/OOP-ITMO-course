using System;
using System.Collections.Generic;
using System.Linq;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Models
{
    public class FullRestorePoint : IRestorePoint
    {
        public DateTime CreateTime { get; }
        public  IEnumerable<File> Files { get; }
        
        public int Size { get; }

        public FullRestorePoint(IEnumerable<File> files, DateTime time)
        {
            CreateTime = time;
            Files = files;
            Size = Files.Sum(file => file.Length);
        }
        
    }
}