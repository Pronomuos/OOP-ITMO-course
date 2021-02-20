using System;
using System.Linq;
using System.Collections.Generic;
using ShopManager.Models;

namespace ShopManager.Repositories.Interfaces
{
    public interface IShopProductsRepository
    {
        public IEnumerable<ShopProduct> GetProducts();
        public void Insert(Guid productId, Guid shopId, int quantity, decimal price);
        public void Delete(Guid productId, Guid shopId);
        public void UpdatePrice(Guid productId, Guid shopId, decimal price);
        public void UpdateQuantity(Guid productId, Guid shopId, int quantity);
        public void ChangeShop(Guid productId, Guid shopId, Guid newShopId);
    }
}