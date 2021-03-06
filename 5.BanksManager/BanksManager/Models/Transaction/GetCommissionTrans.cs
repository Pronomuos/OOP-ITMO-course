using System;
using BanksManager.Models.MyTimer;
using BanksManager.Services;

namespace BanksManager.Models.Transaction
{
    public class GetCommissionTrans : ITransaction
    {
        public BankingSystem.Backup Backup { get; set; }
        public Guid TransId { get; }
        public IMyTimer Timer { get; }
        private readonly AccountsService _receiver;
        private readonly Guid _creditId;

        public GetCommissionTrans(ref AccountsService receiver, Guid creditId,
            IMyTimer timer)
        {
            _receiver = receiver;
            _creditId = creditId;
            Timer = timer;
            TransId = Guid.NewGuid();
        }
        public bool Execute()
         => _receiver.GetAccountById(_creditId).GetCommission(Timer);
    }
}