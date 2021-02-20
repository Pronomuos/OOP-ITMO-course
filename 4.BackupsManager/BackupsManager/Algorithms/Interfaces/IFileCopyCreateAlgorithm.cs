using BackupsManager.Models;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Algorithms.Interfaces
{
    public interface IFileCopyCreateAlgorithm
    {
        void Copy(Storage directory, IRestorePoint point);
    }
}