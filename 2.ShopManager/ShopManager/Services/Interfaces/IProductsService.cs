using ShopManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ShopManager.Services.Interfaces
{
    public interface IProductsService : IShopProductsRepository
    {
        public Guid FindShopWithCheapestProduct(Guid productId);
        public List<KeyValuePair<Guid, int>> QuantityToBuy(Guid shopId, decimal payment);
        public decimal FindCost(Guid productId, Guid shopId, int number);
        public Guid FindShopWithCheapestSet(List<KeyValuePair<Guid, int>> set);



    }
}