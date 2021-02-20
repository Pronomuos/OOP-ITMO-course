using System;
using System.Linq;
using BanksManager.Exceptions;
using BanksManager.Models;
using BanksManager.Models.Accounts.Factory;
using BanksManager.Models.MyTimer;
using BanksManager.Services;

namespace BanksManager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var accServ = new AccountsService();
                var banksServ = new BanksService();
                var clientsServ = new ClientsService();
                var transServ = new TransactionsService();
                var timer = new FutureTimer();

                var system = new BankingSystem(banksServ, clientsServ, accServ, transServ, timer);
                system.CreateBank("MyBank", 5, 500, 1000, 12);
                system.CreateBank("AnotherBank", 3, 100, 500, 6);
                system.CreateBank("TheLastButTheBest", 10, 50, 1200, 5);
                system.CreateClient("Max", "Reshetnikov", new PassportData(), "address");
                system.CreateAccount("MyBank", "Max", "Reshetnikov",
                    AccountFactoryTypes.Credit, 1000);
                system.CreateAccount("AnotherBank", "Max", "Reshetnikov",
                    AccountFactoryTypes.Deposit, 500);
                system.CreateAccount("TheLastButTheBest", "Max", "Reshetnikov",
                    AccountFactoryTypes.Debit, 2000);

                var accId1 = system.GetAccId("Max", "Reshetnikov", "MyBank");
                system.PutMoney(accId1, 5000);
                Console.WriteLine(system.CheckBalance(accId1) == 6000);
                system.WithdrawMoney(accId1, 6500);
                Console.WriteLine(system.CheckBalance(accId1) == -500);
                system.GetCommission(accId1);
                Console.WriteLine(system.CheckBalance(accId1) == -1000);
                system.GetCommission(accId1);
                Console.WriteLine(system.CheckBalance(accId1) == -1000);
                var accId2 = system.GetAccId("Max", "Reshetnikov", "AnotherBank");
                system.PutMoney(accId1, 5000);
                system.TransferMoney(accId1, accId2, 2000);
                Console.WriteLine(system.CheckBalance(accId2) == 2500);

                for (var i = 0; i <= 31; ++i)
                {
                    system.PutInterestMoney(accId2);
                    system.Timer.NextDay();
                }

                Console.WriteLine(system.CheckBalance(accId2));
                var accId3 = system.GetAccId("Max", "Reshetnikov", "TheLastButTheBest");

                for (var i = 0; i <= 31; ++i)
                {
                    system.PutInterestMoney(accId3);
                    system.Timer.NextDay();
                }

                Console.WriteLine(system.CheckBalance(accId3));

                system.CreateClient("Tany", "Kolobova");
                system.CreateAccount("MyBank", "Tany", "Kolobova", AccountFactoryTypes.Credit, 2500);
                var accId4 = system.GetAccId("Tany", "Kolobova", "MyBank");
                system.WithdrawMoney(accId4, 2000);
                Console.WriteLine(system.CheckBalance(accId4) == 2500);
                system.UpdateClientsAddress("Tany", "Kolobova", "address");
                system.UpdatePassportData("Tany", "Kolobova", new PassportData());
                system.WithdrawMoney(accId4, 2000);
                Console.WriteLine(system.CheckBalance(accId4) == 500);
                system.CancelTrans(system.TransServ.GetEnumerator().Last().TransId);
                Console.WriteLine(system.CheckBalance(accId4) == 2500);
            }
            catch (BanksManagerException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}