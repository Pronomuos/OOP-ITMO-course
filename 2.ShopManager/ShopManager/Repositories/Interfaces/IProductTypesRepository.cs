using System;
using System.Collections.Generic;
using ShopManager.Models;

namespace ShopManager.Repositories.Interfaces
{
    public interface IProductTypesRepository
    {
        public IEnumerable<ProductType> GetTypes();
        public void Insert(Guid id, string name);
        public void Delete(Guid id);
        public void UpdateName (Guid id, string name);
        public string GetName(Guid id);
        public Guid GetId(string name);
    }
}