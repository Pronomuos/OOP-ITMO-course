using System;

namespace BanksManager.Models.Accounts.Factory
{
    public class CreditAccountFactory : IFactory
    {
        public IAccount CreateAccount (Guid bankId, Guid clientId, Bank bank, decimal money = 0)
        {
            var account = new CreditAccount();
            account.BankId = bankId;
            account.ClientId = clientId;
            account.Money = money;
            account.MinLimit = 0;
            account.MaxLimit = bank.CreditLimit;
            account.Commission = bank.Commission;
            account.AccId = Guid.NewGuid();

            return account;
        }

    }
}