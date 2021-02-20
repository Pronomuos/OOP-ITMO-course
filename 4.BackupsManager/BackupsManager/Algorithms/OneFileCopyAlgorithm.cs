using System;
using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Algorithms
{
    public  class OneFileCopyAlgorithm : IFileCopyCreateAlgorithm
    {
        public void Copy(Storage directory, IRestorePoint point)
        {
            var memory = 0;
            if (point is IncrementRestorePoint incrementPoint)
            {
                var delta = incrementPoint.Delta;
                memory = incrementPoint.Files.Sum(file => file.Length * (delta / 100));
            }
            else
                foreach (var file in point.Files)
                    memory += file.Length;

            var name = String.Format("Arch {0}", directory.FilesList.Count);
            var ifile = new File(name, memory);
                    directory.FilesList.Add(ifile);
                    
        }
    }
}