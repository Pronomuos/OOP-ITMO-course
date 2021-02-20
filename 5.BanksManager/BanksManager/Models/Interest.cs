using System;
using BanksManager.Models.MyTimer;

namespace BanksManager.Models
{
    public class Interest
    {
        private decimal Value { get; set; }
        private DateTime _lastTime;
        private DateTime _putMoneyDate;
        private decimal _sum;

        public Interest(decimal value)
        {
            Value = value;
            _lastTime = DateTime.Today;
            _putMoneyDate = DateTime.Today;
            _sum = 0;
        }
        

        public decimal Calculate (IMyTimer time, decimal amount)
        {
            decimal cash = 0;
            
            if (time.Time >= _lastTime.AddDays(1))
            {
                _sum += amount * Value;
                _lastTime = time.Time;
            }
            
            if (time.Time >= _putMoneyDate.AddMonths(1))
            {
                cash = _sum;
                _sum = 0;
                _putMoneyDate = time.Time;
            }

            return cash;

        }
    }
}