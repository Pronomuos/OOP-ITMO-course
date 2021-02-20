using System;
using System.Collections.Generic;
using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models.Interfaces;
using BackupsManager.Models;
using BackupsManager.Exceptions;

namespace BackupsManager.Algorithms
{
    public class IncrementPointCreateAlgorithm : IPointCreateAlgorithm
    {
        private int DefaultDelta { get; set; } = 10;

        public IRestorePoint CreateRestore(Backup backup, DateTime time)
        {
            
            return backup.RestorePoints.Last() switch
            {
                FullRestorePoint fullPoint =>
                    new IncrementRestorePoint(
                        new List<File>(fullPoint.Files), time,  DefaultDelta, 1),
                IncrementRestorePoint incrementPoint =>
                    new IncrementRestorePoint(
                        new List<File>(incrementPoint.Files), time,
                        DefaultDelta, incrementPoint.CountForParent + 1),
                _ => throw new FirstIncrementRestorePointException(),
            };
        }
    }
}