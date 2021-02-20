using System;
using System.Collections.Generic;
using System.Linq;
using BackupsManager.Algorithms.Interfaces;
using BackupsManager.Models;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Services
{
    public class BackupService
    {
        private Backup _backup;
        private Storage _directory;
        public IFileCopyCreateAlgorithm FileCopyAlgo { get; set; }
        public IPointCreateAlgorithm PointCreateAlgo { get; set; }
        public IPointsDeleteAlgorithm PointsDeleteAlgo { get; set; }

        public BackupService(Backup backup, Storage directory, IFileCopyCreateAlgorithm fileCopyAlgo,
            IPointCreateAlgorithm pointCreateAlgo, IPointsDeleteAlgorithm pointsDeleteAlgo)
        {
            _backup = backup;
            _directory = directory;
            FileCopyAlgo = fileCopyAlgo;
            PointCreateAlgo = pointCreateAlgo;
            PointsDeleteAlgo = pointsDeleteAlgo;
        }

        public void CreateRestorePoint(DateTime time)
        {
            _backup.RestorePoints.Add(PointCreateAlgo.CreateRestore(_backup, time));
            FileCopyAlgo.Copy(_directory, _backup.RestorePoints.Last());
        }

        public void CleanRestorePoints()
            => _backup.RestorePoints = PointsDeleteAlgo.DeletePoints(_backup);

        public IEnumerable<IRestorePoint> GetRestorePoints()
            => _backup.RestorePoints;




    }
}