using System;

namespace BanksManager.Models.Accounts.Factory
{
    public class DepositAccountFactory : IFactory
    {
        public IAccount CreateAccount(Guid bankId, Guid clientId, Bank bank, decimal money = 0)
        {
            var account = new Deposit();
            account.BankId = bankId;
            account.ClientId = clientId;
            var interest = money switch
            {
                _ when money <= 50000 => 3.0 / 365,
                _ when money > 50000 && money <= 100000 => 3.5 / 365,
                _ => 4.0 /365
            };
            account.Interest = new Interest(Convert.ToDecimal(interest));
            account.Money = money;
            account.CeasingDate = DateTime.Today.AddDays(bank.DepositCeasingDays);
            account.AccId = Guid.NewGuid();
            
            return account;
        }

    }
}