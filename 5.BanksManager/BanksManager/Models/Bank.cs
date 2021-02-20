using System;
using System.Collections.Generic;
using BanksManager.Models.Accounts;

namespace BanksManager.Models
{
    public class Bank
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public int Interest { get; set; }
        public int Commission { get; set; }
        public int LimForDoubtfulAcc { get; set; }
        public int DepositCeasingDays { get; set; }
        public int CreditLimit { get; set; }

        public Bank(string name, int? interest, int? commission, int? limit,
            int? depositCeasingDays, int? creditLimit)
        {
            if (name == null || interest == null || commission == null || 
                limit == null || depositCeasingDays == null)
                throw new NotImplementedException();

            Name = name;
            Interest = interest.GetValueOrDefault();
            Commission = commission.GetValueOrDefault();
            LimForDoubtfulAcc = limit.GetValueOrDefault();
            DepositCeasingDays = depositCeasingDays.GetValueOrDefault();
            CreditLimit = creditLimit.GetValueOrDefault();
            Id = Guid.NewGuid();
        }
    }

    public class BankBuilder
    {
        private string _name = null;
        private int? _interest = null;
        private int? _commission = null;
        private int? _limForDoubtfulAcc = null;
        private int? _depositCeasingDays = null;
        private int? _creditLimit = null;

        public BankBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
        
        public BankBuilder SetInterest(int interest)
        {
            _interest = interest;
            return this;
        }
        
        public BankBuilder SetCommission(int commission)
        {
            _commission = commission;
            return this;
        }
        
        public BankBuilder SetLimit(int limit)
        {
            _limForDoubtfulAcc = limit;
            return this;
        }

        public BankBuilder SetCeasingTime(int days)
        {
            _depositCeasingDays = days;
            return this;
        }

        public BankBuilder SetCreditLimit(int limit)
        {
            _creditLimit = limit;
            return this;
        }

        public Bank Build()
        {
            var bank = new Bank(_name, _interest, _commission, 
                _limForDoubtfulAcc, _depositCeasingDays, _creditLimit);
            return bank;
        }
        
    }
}