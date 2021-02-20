using System;
using System.Collections.Generic;
using System.Linq;
using BanksManager.Models.Accounts;
using BanksManager.Services;

namespace BanksManager.Repository
{
    public class AccountsRepository : IRepository
    {
        protected List<IAccount> AccountsRepo = new List<IAccount>();

        public void AddAccount (IAccount account)
            => AccountsRepo.Add(account);

        public IAccount GetAccountById(Guid id)
            => AccountsRepo.Single(x => x.AccId == id);
        
        public IEnumerable<IAccount> GetEnumerator()
            => AccountsRepo;
        
        public IAccount GetObject (Guid accId)
            => AccountsRepo.Single(x => x.AccId == accId);


        public Guid GetId(Guid clientId, Guid bankId)
            => AccountsRepo.Single(x =>
                x.ClientId == clientId && x.BankId == bankId).AccId;

        public AccountsService Clone()
        {
           var service = new AccountsService();
           foreach (var acc in AccountsRepo) 
               service.AccountsRepo.Add(acc.Clone());

           return service;

        }
    }
}