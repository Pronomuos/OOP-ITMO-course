using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models;
using System.Collections.Generic;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Algorithms
{
    public class DeletePointsByCount : IPointsDeleteAlgorithm
    {
        public int Count { get; set; }

        public DeletePointsByCount(int count)
            => Count = count;
        
        public List<IRestorePoint> DeletePoints(Backup backup)
            => IPointsDeleteAlgorithm.Delete(backup, Count);
        
    }
}