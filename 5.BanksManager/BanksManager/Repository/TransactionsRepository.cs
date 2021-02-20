using System.Collections.Generic;
using BanksManager.Models.Transaction;

namespace BanksManager.Repository
{
    public class TransactionsRepository : IRepository
    {
        protected List<ITransaction> TransactionsRepo = new List<ITransaction>();
        
        public void AddTrans (ITransaction transaction)
            => TransactionsRepo.Add(transaction);

        public IEnumerable<ITransaction> GetEnumerator()
            => TransactionsRepo;

        public void Update(List<ITransaction> newList)
            => TransactionsRepo = newList;
    }
}