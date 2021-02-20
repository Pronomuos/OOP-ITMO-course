using System;
using BanksManager.Models.MyTimer;

namespace BanksManager.Models.Accounts
{
    public interface IAccount
    {
        public Guid AccId { get; set; }
        public Guid BankId { get; }
        public Guid ClientId { get; set; }
        public decimal Money { get; set; }

        public bool WithdrawMoney(decimal amount);
        public bool PutMoney(decimal amount);
        public bool GetCommission(IMyTimer timer);
        public bool PutInterest(IMyTimer timer);

        public IAccount Clone();

        public decimal CheckBalance()
            => Money;
    }
}