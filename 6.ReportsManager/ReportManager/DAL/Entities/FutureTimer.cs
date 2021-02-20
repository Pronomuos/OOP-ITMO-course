using System;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Entities
{
    public class FutureTimer : ITimer
    {
        public DateTime Time { get; set; }
        
        public FutureTimer()
            => Time = DateTime.Now;
        
        public void NextDay()
            => Time = Time.AddDays(1);
        
        public void NextMonth()
            => Time = Time.AddMonths(1);
    }
}