using System;

namespace BanksManager.Models.Accounts.Factory
{
    public class DebitAccountFactory : IFactory
    {
        public IAccount CreateAccount(Guid bankId, Guid clientId, Bank bank, decimal money = 0)
        {
            var account = new DebitAccount();
            account.BankId = bankId;
            account.ClientId = clientId;
            account.Money = money;
            account.Interest = new Interest(Convert.ToDecimal(bank.Interest / 365.0));
            account.AccId = Guid.NewGuid();

            return account;
        }

    }
}