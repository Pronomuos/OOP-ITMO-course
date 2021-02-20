using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Models
{
    public class IncrementRestorePoint : IRestorePoint
    {
        
        public int Delta { get; }
        public int CountForParent { get;}
        public DateTime CreateTime { get; }
        public  IEnumerable<File> Files { get; }
        
        public int Size { get; }
        

        public IncrementRestorePoint(IEnumerable<File> files, DateTime time, int delta, int count)
        {
            Files = files;
            CreateTime = time;
            Delta = delta;
            CountForParent = count;
            Size = files.Sum(file => file.Length * delta);
        }
        
    }
}