using System;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;
using BackupsManager.Algorithms.Interfaces;

namespace BackupsManager.Algorithms.Interfaces
{
    public interface IPointCreateAlgorithm
    {
        public IRestorePoint CreateRestore (Backup backup, DateTime time);
    }
}