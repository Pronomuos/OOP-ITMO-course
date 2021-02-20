using System;

namespace BanksManager.Models.Accounts.Factory
{
    public interface  IFactory
    {
        public  IAccount CreateAccount(Guid bankId, Guid clientId, Bank bank, decimal money = 0);
    }

    public enum AccountFactoryTypes
    {
        Credit,
        Debit,
        Deposit
    }
}