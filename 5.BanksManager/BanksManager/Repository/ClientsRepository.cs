using System;
using System.Collections.Generic;
using System.Linq;
using BanksManager.Models;

namespace BanksManager.Repository
{
    public class ClientsRepository : IRepository
    {
        protected List<Client> ClientsRepo = new List<Client>();

        public Guid GetId(string name, string surname)
            => ClientsRepo.
                Single(x => x.FirstName == name && x.Surname == surname).Id;
        
        public void AddClient(Client client)
            => ClientsRepo.Add(client);
        
        public Client GetObject (Guid id)
            => ClientsRepo.Single(x => x.Id == id);

    }
}