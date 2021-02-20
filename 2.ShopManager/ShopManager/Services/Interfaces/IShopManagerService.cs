using System;
using System.Collections.Generic;

namespace ShopManager.Services.Interfaces
{
    public interface IShopManagerService
    {
        public void CreateShop(string name, string address);
        public void DeleteShop(Guid id);
        public void CreateProduct(string name);
        public void DeleteProduct(Guid id);
        public void PutProductsIntoShop(string shopName, string productName, int quantity, decimal price = default);
        public void PrintShopWithCheapestProduct(string productName);
        public void PrintQuantityBuy(string shopName, decimal payment);
        public void BuyProducts(string shopName, string productName, int number);
        public void PrintShopWithCheapestSet(List<KeyValuePair<string, int>> set);
    }
}