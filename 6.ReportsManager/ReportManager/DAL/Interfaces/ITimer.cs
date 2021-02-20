using System;

namespace ReportManager.DAL.Interfaces
{
    public interface ITimer
    {
        public DateTime Time { get; set; }
        public void NextDay();
        public void NextMonth();
    }
}