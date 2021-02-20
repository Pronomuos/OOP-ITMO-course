using System;
using BanksManager.Models.MyTimer;
using BanksManager.Services;

namespace BanksManager.Models.Transaction
{
    public class TransferMoneyTrans : ITransaction
    {
        public BankingSystem.Backup Backup { get; set; }
        public Guid TransId { get; }
        public IMyTimer Timer { get; }
        private readonly AccountsService _receiver;
        private readonly Client _fromClient;
        private readonly Bank _fromBank;
        private readonly Guid _fromCreditId;
        private readonly Guid _toCreditId;
        private readonly int _money;

        public TransferMoneyTrans (ref AccountsService receiver, Client fromClient, Bank fromBank,
            Guid fromCreditId, Guid toCreditId,  int money, IMyTimer timer)
        {
            _receiver = receiver;
            _fromClient = fromClient;
            _fromBank = fromBank;
            _fromCreditId = fromCreditId;
            _toCreditId = toCreditId;
            _money = money;
            Timer = timer;
            TransId = Guid.NewGuid();
        }

        public bool Execute()
        {
            if (_fromClient.IsDoubtful() && _fromBank.LimForDoubtfulAcc < _money)
                return false;
            
            if (_receiver.GetAccountById(_fromCreditId).WithdrawMoney(_money))
                _receiver.GetAccountById(_toCreditId).PutMoney(_money);

            return false;
        }
    }
}