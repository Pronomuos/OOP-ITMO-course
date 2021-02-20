using System;

namespace BanksManager.Models.MyTimer
{
    public class CurrentTimer : IMyTimer
    {
        public DateTime Time { get; private set; }

        public CurrentTimer()
            => Time = DateTime.Today;

        public void Update()
            => Time = DateTime.Today;


    }
}