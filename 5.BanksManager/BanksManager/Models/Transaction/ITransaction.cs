using System;
using BanksManager.Models.MyTimer;

namespace BanksManager.Models.Transaction
{
    public interface ITransaction
    {
        public BankingSystem.Backup Backup { get; set; }
        public Guid TransId { get; }
        public IMyTimer Timer { get; }
        public bool Execute();
    }
}