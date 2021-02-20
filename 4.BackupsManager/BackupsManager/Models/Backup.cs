using System;
using System.Collections.Generic;
using System.IO;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Models
{
    public class Backup
    {
        public Guid Id { get; }
        public DateTime CreationTime { get; }
        public long BackupSize { get;}
        public List<IRestorePoint> RestorePoints { get; set; }
        public List<File> Files { get; set; }
        
        public Backup(List<File> files)
        {
            Files = files;
            Id = Guid.NewGuid();
            CreationTime = DateTime.Today;
            BackupSize = 0;
            foreach (var file in Files)
                BackupSize += file.Length;
            RestorePoints = new List<IRestorePoint>();
        }

        void UpdateFiles(List<File> newFiles)
            => Files = newFiles;

    }
}