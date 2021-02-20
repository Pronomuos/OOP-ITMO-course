using System;
using System.Collections.Generic;
using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models.Interfaces;
using BackupsManager.Models;

namespace BackupsManager.Algorithms
{
    public class FullPointCreateAlgorithm : IPointCreateAlgorithm
    {
        public IRestorePoint CreateRestore(Backup backup, DateTime time)
             =>   new FullRestorePoint(backup.Files, time);
        
    }
}