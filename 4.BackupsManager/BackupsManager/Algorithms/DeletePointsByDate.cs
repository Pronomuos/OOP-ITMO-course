using System;
using System.Collections.Generic;
using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;


namespace BackupsManager.Algorithms
{
    public class DeletePointsByDate : IPointsDeleteAlgorithm
    {
        private DateTime Time { get; set; }

        public DeletePointsByDate(DateTime time)
            => Time = time;

        public List<IRestorePoint> DeletePoints(Backup backup)
        {
            var temp = backup.RestorePoints.Where(point => point.CreateTime.CompareTo(Time) >= 0).ToList();
            return IPointsDeleteAlgorithm.Delete(backup, temp.Count);
        }
    }
}