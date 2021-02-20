using ReportManager.BLL.Interfaces;
using ReportManager.DAL.Interfaces;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class TimerService : ITimerService
    {
        private IUnitOfWork _dataBase;

        public TimerService (IUnitOfWork database)
            => _dataBase = database;

        public void NextDay()
            => _dataBase.Timer.NextDay();

        public void NextMonth()
            => _dataBase.Timer.NextMonth();
    }    
}