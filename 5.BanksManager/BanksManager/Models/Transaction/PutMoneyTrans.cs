using System;
using BanksManager.Models.MyTimer;
using BanksManager.Services;

namespace BanksManager.Models.Transaction
{
    public class PutMoneyTrans : ITransaction
    {
        public BankingSystem.Backup Backup { get; set; }
        public Guid TransId { get; }
        public IMyTimer Timer { get; }
        private readonly AccountsService _receiver;
        private readonly Guid _creditId;
        private readonly int _money;

        public PutMoneyTrans(ref AccountsService receiver, Guid creditId, int money,
            IMyTimer timer)
        {
            _receiver = receiver;
            _creditId = creditId;
            _money = money;
            Timer = timer;
            TransId = Guid.NewGuid();
        }

        public bool Execute()
        => _receiver.GetAccountById(_creditId).PutMoney(_money);
        
    }
}