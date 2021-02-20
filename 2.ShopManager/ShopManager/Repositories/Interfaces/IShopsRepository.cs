using System;
using System.Collections.Generic;
using ShopManager.Models;

namespace ShopManager.Repositories.Interfaces
{
    public interface IShopsRepository
    {
        public IEnumerable<Shop> GetShops();
        public void Insert(Guid id, string name, string address);
        public void Delete(Guid id);
        public void UpdateName(Guid id, string name);
        public void UpdateAddress(Guid id, string address);
        public string GetName(Guid id);
        public Guid GetId(string name);
        public Guid GetId(string name, string address);


    }
}