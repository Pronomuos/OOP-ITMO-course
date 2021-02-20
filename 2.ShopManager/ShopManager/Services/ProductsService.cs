using System.Linq;
using System.Collections.Generic;
using ShopManager.Repositories;
using ShopManager.Services.Interfaces;
using System;
using ShopManager.Exceptions;

namespace ShopManager.Services
{
    public class ProductsService : ShopProductsRepository, IProductsService
    {

        public Guid FindShopWithCheapestProduct(Guid productId)
        {
             return shopProductsList.
                Where(x => x.ProductId == productId).
                OrderBy(x => x.SalePrice).
                First().ShopId;
        }

        public List<KeyValuePair<Guid, int>> QuantityToBuy(Guid shopId, decimal payment)
        {
            var result = new List<KeyValuePair<Guid, int>>();
            var query = shopProductsList.
                Where(x => x.ShopId == shopId).
                Select(x => new
                {
                    id = x.ProductId, 
                    quantity = Convert.ToInt32(Math.Floor(payment / x.SalePrice))
                });
            
            foreach (var product in query)
                result.Add( new KeyValuePair<Guid, int>(product.id, product.quantity));

            return result;
        }

        public decimal FindCost(Guid shopId, Guid productId, int number)
        {
            var index = shopProductsList.FindIndex(x => x.ProductId == productId && x.ShopId == shopId);
            return (index != -1 && shopProductsList[index].Quantity >= number) ?
                 shopProductsList[index].SalePrice * number: Decimal.MinValue;
        }

        public Guid FindShopWithCheapestSet(List<KeyValuePair<Guid, int>> set)
        {
            var shops = shopProductsList.
                Select(x => new {x.ShopId, Total = decimal.Zero});
            foreach (var pair in  set)
            {
                shops = shops.Select(x => new
                {
                    x.ShopId,
                    Total =  x.Total + FindCost(x.ShopId, pair.Key, pair.Value)
                }).Where(x => x.Total >= 0);
            }

            return (!shops.Any()) ? 
                Guid.Empty: 
                shops.OrderBy(x => x.Total).First().ShopId;
        }
    }
}