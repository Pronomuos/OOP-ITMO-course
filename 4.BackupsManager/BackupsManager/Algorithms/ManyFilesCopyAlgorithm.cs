using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Algorithms
{
    public class ManyFilesCopyAlgorithm : IFileCopyCreateAlgorithm
    {
        public void Copy(Storage directory, IRestorePoint point)
        {
            if (point is IncrementRestorePoint incrementPoint)
            {
                var delta = incrementPoint.Delta;
                var files = incrementPoint.Files.Select(file =>
                    new File(file.Name, file.Length * (delta / 100))).ToList();
                foreach (var file in files)
                    directory.FilesList.Add(file);
            }
            else
                foreach (var file in point.Files)
                    directory.FilesList.Add(file);
        }
    }
}
