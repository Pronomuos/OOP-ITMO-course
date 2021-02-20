using System;
using BanksManager.Models.Accounts.Factory;
using BanksManager.Models.MyTimer;

namespace BanksManager.Models.Accounts
{
    public class CreditAccount : IAccount
    {
        public Guid AccId { get; set; }
        public Guid BankId { get; set; }
        public Guid ClientId { get; set; }
        public decimal Money { get; set; }
        
        public int MinLimit { get; set; }
        public int MaxLimit { get; set; }
        public int Commission { get; set; }
        
        public DateTime CommissionWriteOffDate { get; private set; }

        public bool WithdrawMoney(decimal amount)
        {
            Money -= amount;
            return true;
        }

        public bool PutMoney(decimal amount)
        {
            Money += amount;
            return true;
        }

        public bool GetCommission(IMyTimer timer)
        {
            if (Money < MinLimit && CommissionWriteOffDate.AddDays(1) < timer.Time)
            {
                Money -= Commission;
                CommissionWriteOffDate = timer.Time;
                return true;
            }

            return false;
        }

        public bool PutInterest(IMyTimer timer)
            => false;

        public IAccount Clone()
        {
            var acc = new CreditAccount();
            acc.AccId = AccId;
            acc.BankId = BankId;
            acc.ClientId = ClientId;
            acc.Commission = Commission;
            acc.Money = Money;
            acc.MinLimit = MinLimit;
            acc.MaxLimit = MaxLimit;
            acc.CommissionWriteOffDate = CommissionWriteOffDate;

            return acc;
        }

        
    }
}