using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BanksManager.Models.Accounts.Factory;
using BanksManager.Models.MyTimer;
using BanksManager.Models.Transaction;
using BanksManager.Services;

namespace BanksManager.Models
{
    public class BankingSystem
    {
        private BanksService _banksServ;
        private ClientsService _clientsServ;
        private AccountsService _accountsServ;
        private TransactionsService _transServ;

        public BanksService BanksServ
        {
            get => _banksServ;
        }

        public ClientsService ClientsServ
        {
            get => _clientsServ;
        }

        public AccountsService AccountsServ
        {
            get => _accountsServ;
            set => _accountsServ = value;
        }

        public TransactionsService TransServ
        {
            get => _transServ;
            set => _transServ = value;
        }

        public FutureTimer Timer { get; }

        public BankingSystem(BanksService banksServ, ClientsService clientsServ,
            AccountsService accountsServ, TransactionsService transServ, FutureTimer timer)
        {
            _banksServ = banksServ;
            _clientsServ = clientsServ;
            _accountsServ = accountsServ;
            _transServ = transServ;
            Timer = timer;
        }

        public void CreateBank(string name, int interest,
            int commission, int limit, int depositDays)
        {
            var builder = new BankBuilder();
            builder.SetName(name);
            builder.SetInterest(interest);
            builder.SetCommission(commission);
            builder.SetLimit(limit);
            builder.SetCeasingTime(depositDays);
            BanksServ.AddBank(builder.Build());
        }

        public void CreateClient(string name, string surname,
            PassportData data = null, string address = null)
        {
            var builder = new ClientBuilder();
            builder.SetName(name);
            builder.SetSurname(surname);
            builder.SetPassportData(data);
            builder.SetAddress(address);
            ClientsServ.AddClient(builder.Build());
        }

        public void UpdatePassportData(string name, string surname, PassportData data)
            => ClientsServ.GetObject(ClientsServ.GetId(name, surname)).PassportData = data;

        public void UpdateClientsAddress(string name, string surname, string address)
            => ClientsServ.GetObject(ClientsServ.GetId(name, surname)).Address = address;


        public void CreateAccount(string bankName, string clientName,
            string clientSurname, AccountFactoryTypes type, int money = 0)
        {
            IFactory accountFactory;

            switch (type)
            {
                case AccountFactoryTypes.Credit:
                    accountFactory = new CreditAccountFactory();
                    break;
                case AccountFactoryTypes.Debit:
                    accountFactory = new DebitAccountFactory();
                    break;
                case AccountFactoryTypes.Deposit:
                    accountFactory = new DepositAccountFactory();
                    break;
                default:
                    accountFactory = new CreditAccountFactory();
                    break;

            }

            var bankId = BanksServ.GetId(bankName);
            var clientId = ClientsServ.GetId(clientName, clientSurname);
            var bank = BanksServ.GetObject(bankName);

            AccountsServ.AddAccount(accountFactory.CreateAccount(bankId, clientId, bank, money));
        }

        private void Execute(ITransaction command)
        {
            if (command.Execute())
            {
                command.Backup = new Backup(this);
                TransServ.AddTrans(command);
            }
            else
                Restore(TransServ.GetEnumerator().Last().Backup);
        }

        public Guid GetAccId(string clientName, string surname, string bankName)
        {
            var clientId = ClientsServ.GetId(clientName, surname);
            var bankId = BanksServ.GetId(bankName);
            return AccountsServ.GetId(clientId, bankId);
        }

        public decimal CheckBalance(Guid accId)
        {
            return AccountsServ.GetObject(accId).Money;
        }

        public void PutMoney(Guid creditId, int money)
        {
            var command = new PutMoneyTrans(ref _accountsServ, creditId, money, Timer);
            Execute(command);
        }

        public void WithdrawMoney(Guid creditId, int money)
        {
            var bank = BanksServ.GetObject(AccountsServ.GetEnumerator().Single(x => x.AccId == creditId).BankId);
            var client = ClientsServ.GetObject(AccountsServ.GetEnumerator().Single(x => x.AccId == creditId).ClientId);
            var command = new WithdrawMoneyTrans(ref _accountsServ, client, bank, creditId, money, Timer);
            Execute(command);
        }

        public void TransferMoney(Guid fromCreditId, Guid toCreditId, int money)
        {
            var bank = BanksServ.GetObject(AccountsServ.GetEnumerator().Single(x => x.AccId == fromCreditId).BankId);
            var client =
                ClientsServ.GetObject(AccountsServ.GetEnumerator().Single(x => x.AccId == fromCreditId).ClientId);
            var command =
                new TransferMoneyTrans(ref _accountsServ, client, bank, fromCreditId, toCreditId, money, Timer);
            Execute(command);
        }

        public void CancelTrans(Guid transId)
        {
            var list = TransServ.GetEnumerator().ToList();
            var tran = list.Single(x => x.TransId == transId);
            var index = list.IndexOf(tran) + 1;
            if (index != list.Count)
            {
                var size = list.Count - index;
                var temp = new ITransaction[size];
                list.CopyTo(temp, index);
                Restore(list.ElementAt(index - 2).Backup);
                list.RemoveRange(index - 1, size);
                TransServ.Update(list);
                for (var i = 0; i < size; i++)
                    Execute(temp[i]);
            }
            else
            {
                Restore(list.ElementAt(index - 2).Backup);
                list.RemoveAt(list.Count - 1);
                _transServ.Update(list);
            }

        }

        public void PutInterestMoney(Guid creditId)
        {
            var command = new PutInterestTrans(ref _accountsServ, creditId, Timer);
            Execute(command);
        }

        public void GetCommission(Guid creditId)
        {
            var command = new GetCommissionTrans(ref _accountsServ, creditId, Timer);
            Execute(command);
        }


        public class Backup
        {
            public AccountsService AccountsServ { get; }

            public Backup(BankingSystem system)
                => AccountsServ = system.AccountsServ;


        }

        private void Restore(Backup backup)
            => AccountsServ = backup.AccountsServ.Clone();
        

    }
}
