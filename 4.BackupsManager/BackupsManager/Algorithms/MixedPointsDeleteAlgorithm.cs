using BackupsManager.Algorithms.Interfaces;
using System.Collections.Generic;
using BackupsManager.Models;
using System.Linq;
using BackupsManager.Models.Interfaces;

namespace BackupsManager.Algorithms
{
    public class MixedPointsDeleteAlgorithm : IPointsDeleteAlgorithm
    {
        private List<IPointsDeleteAlgorithm> _algos;
        private Limits _mode;

        public MixedPointsDeleteAlgorithm(List<IPointsDeleteAlgorithm> algos, Limits mode)
        {
            _algos = algos;
            _mode = mode;
        }

        public List<IRestorePoint> DeletePoints(Backup backup)
        {
            var count = (_mode == Limits.OneLimitPass)
                ? _algos.Select(algo => algo.DeletePoints(backup).Count).Max()
                : _algos.Select(algo => algo.DeletePoints(backup).Count).Min();
            
            return IPointsDeleteAlgorithm.Delete(backup, count);
        }
    }

    public enum Limits
    {
        AllLimitsPass,
        OneLimitPass
    }
}