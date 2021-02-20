using System;
using BanksManager.Models.MyTimer;
using BanksManager.Services;

namespace BanksManager.Models.Transaction
{
    public class WithdrawMoneyTrans : ITransaction
    {
        public BankingSystem.Backup Backup { get; set; }
        public Guid TransId { get; }
        public IMyTimer Timer { get; }
        private readonly AccountsService _receiver;
        private readonly Client _client;
        private readonly Bank _bank;
        private readonly Guid _creditId;
        private readonly int _money;

        public WithdrawMoneyTrans(ref AccountsService receiver, Client client, Bank bank,
            Guid creditId, int money, IMyTimer timer)
        {
            _receiver = receiver;
            _client = client;
            _bank = bank;
            _creditId = creditId;
            _money = money;
            Timer = timer;
            TransId = Guid.NewGuid();
        }

        public bool Execute()
        {
            if (_client.IsDoubtful() && _bank.LimForDoubtfulAcc < _money)
                return false;
            
            return _receiver.GetAccountById(_creditId).WithdrawMoney(_money);
        }
    }
}