using ShopManager.Models;
using System.Collections.Generic;
using ShopManager.Repositories.Interfaces;
using System.Linq;
using System;

namespace ShopManager.Repositories
{
    public class ShopProductsRepository : IShopProductsRepository
    {
        protected List<ShopProduct> shopProductsList;

        public ShopProductsRepository()
        {
            shopProductsList = new List<ShopProduct>();
        }

        public IEnumerable<ShopProduct> GetProducts()
        {
            return shopProductsList;
        }
        
        public void Insert(Guid productId, Guid shopId, int quantity, decimal price = default)
        {
            var products = shopProductsList.
                Find(x => x.ProductId == productId && x.ShopId == shopId);
            if (products == null)
                shopProductsList.Add(new ShopProduct(productId, quantity, price, shopId));
            else
            {
                var index = shopProductsList.FindIndex(x => x.ProductId == productId && x.ShopId == shopId);
                shopProductsList[index].Quantity += quantity;
                if (price != default)
                    shopProductsList[index].SalePrice = price;
            }
        }

        public void Delete(Guid productId, Guid shopId)
        {
            shopProductsList.Remove(shopProductsList.
                Find(x => x.ProductId == productId && x.ShopId == shopId));
        }

        public void UpdatePrice(Guid productId, Guid shopId, decimal price)
        {
            var index = shopProductsList.
                FindIndex(x => x.ProductId == productId && x.ShopId == shopId);
            if (index != -1)
                shopProductsList[index].SalePrice = price;
        }

        public void UpdateQuantity(Guid productId, Guid shopId, int quantity)
        {
            var index = shopProductsList.
                FindIndex(x => x.ProductId == productId && x.ShopId == shopId);
            if (index != -1)
                shopProductsList[index].Quantity -= quantity;
        }

        public int GetQuantity(Guid productId, Guid shopId)
        {
            var index = shopProductsList.
                FindIndex(x => x.ProductId == productId && x.ShopId == shopId);
            return (index != -1) ? shopProductsList[index].Quantity : default;
        }

        public void ChangeShop(Guid productId, Guid shopId, Guid newShopId)
        {
            var index = shopProductsList.
                FindIndex(x => x.ProductId == productId && x.ShopId == shopId);
            if (index != -1)
                shopProductsList[index].ShopId = newShopId;
        }
        
    }
}