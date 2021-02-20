using System;
using System.Collections.Generic;
using System.Linq;
using BanksManager.Models;

namespace BanksManager.Repository
{
    public class BanksRepository : IRepository
    {
        protected List<Bank> BanksRepo = new List<Bank>();

        public Guid GetId(string name)
            => BanksRepo.Single(x => x.Name == name).Id;
        
        public Bank GetObject (string name)
            => BanksRepo.Single(x => x.Name == name);
        
       public Bank GetObject (Guid id)
            => BanksRepo.Single(x => x.Id == id);
        
        public void AddBank(Bank bank)
            => BanksRepo.Add(bank);


    }
}