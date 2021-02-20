using System.Collections.Generic;
using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Algorithms
{
    public class DeletePointsByMemory : IPointsDeleteAlgorithm
    {
        public int Memory { get; set; }

        public DeletePointsByMemory(int memory)
            => Memory = memory;

        public List<IRestorePoint> DeletePoints(Backup backup)
        {
            var count = 0;
            var memory = 0;
            for (var i = backup.RestorePoints.Count - 1; i >= 0 && Memory > memory; --i)
            {
                memory += backup.RestorePoints[i].Size;
                count = backup.RestorePoints.Count - i;
            }
            
            return IPointsDeleteAlgorithm.Delete(backup, count);
        }
    }
}