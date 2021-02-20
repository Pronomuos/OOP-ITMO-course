using System;
using System.Collections.Generic;
using BanksManager.Exceptions;
using BanksManager.Models.Accounts;

namespace BanksManager.Models
{
    public class Client
    {
        public string FirstName { get;}
        public string Surname { get; }
        public PassportData PassportData { get; set; }
        public string Address { get; set; }
        public Guid Id { get; }

        public Client(string name, string surname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                throw new InvalidClientException();

            FirstName = name;
            Surname = surname;
            Id = Guid.NewGuid();
        }

        public bool IsDoubtful()
            => (PassportData == null || Address == null);


    }
    


    public class ClientBuilder
    {
        private string _name = null;
        private string _surname = null;
        private PassportData _passportData = null;
        private string _address = null;

        public ClientBuilder SetName(string name)
        {
            _name = name;
            return this;
        }
        
        public ClientBuilder SetSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public ClientBuilder SetPassportData(PassportData data)
        {
            _passportData = data;
            return this;
        }
        
        public ClientBuilder SetAddress(string address)
        {
            _address = address;
            return this;
        }

        public Client Build()
        {
            var client = new Client(_name, _surname);
            if (!string.IsNullOrEmpty(_address))
                client.Address = _address;
            if (_passportData != null)
                client.PassportData = _passportData;

            return client;
        }
        
    }

}