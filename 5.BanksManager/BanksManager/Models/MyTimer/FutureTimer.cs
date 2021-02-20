using System;

namespace BanksManager.Models.MyTimer
{
    public class FutureTimer : IMyTimer
    {
        public DateTime Time { get; private set; }

        public FutureTimer()
            => Time = DateTime.Today;

        public void NextDay()
            => Time = Time.AddDays(1);

        public void NextMonth()
            => Time = Time.AddMonths(1);
        

    }
}