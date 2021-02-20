using System;
using BanksManager.Models.MyTimer;

namespace BanksManager.Models.Accounts
{
    public class DebitAccount : IAccount
    {
        public Guid AccId { get; set; }
        public Guid BankId { get; set; }
        public Guid ClientId { get; set; }
        public decimal Money { get; set; }
        
        public Interest Interest  { get; set; }
        
        public bool WithdrawMoney(decimal amount)
        {
            if (Money <= 0)
                return false;

            Money -= amount;
            return true;

        }

        public bool PutMoney(decimal amount)
        {
            Money += amount;
            return true;
        }

        public bool GetCommission(IMyTimer timer)
            => false;

            public bool PutInterest(IMyTimer timer)
            {
                var amount = Interest.Calculate(timer, Money);
                Money += amount;
                return (amount != 0);
            }

            public IAccount Clone()
            {
                var acc = new DebitAccount();
                acc.AccId = AccId;
                acc.BankId = BankId;
                acc.ClientId = ClientId;
                acc.Money = Money;
                acc.Interest = Interest;

                return acc;
            }

    }
}