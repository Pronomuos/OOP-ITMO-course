using System.Collections.Generic;
using System.Linq;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;
using Microsoft.Extensions.Logging;

namespace BackupsManager.Algorithms.Interfaces
{
    public interface IPointsDeleteAlgorithm
    {
        List<IRestorePoint> DeletePoints(Backup backup);

        public static List<IRestorePoint> Delete(Backup backup, int count)
        {
            var temp = new List<IRestorePoint>(backup.RestorePoints);
            if (temp.Count <= count)
                return temp.ToList();
            if (temp.TakeLast(count).First() is IncrementRestorePoint point)
            {
                count += point.CountForParent;
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                ILogger logger = loggerFactory.CreateLogger<IPointsDeleteAlgorithm>();
                logger.LogWarning("There were less points deleted because of increment points.");
            }


            return temp.TakeLast(count).ToList();
        }
    }
}