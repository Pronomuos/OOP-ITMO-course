using System;
using System.Linq;
using System.Collections.Generic;
using ShopManager.Exceptions;
using ShopManager.Services.Interfaces;



namespace ShopManager.Services
{
    public class ShopManagerService : IShopManagerService
    {
        private ProductsService _productsServ;
        private ShopsService _shopsServ;
        private ProductTypesService _typesServ;

        public ShopManagerService()
        {
            _productsServ = new ProductsService();
            _shopsServ = new ShopsService();
            _typesServ = new ProductTypesService();
        }

        public void CreateShop(string name, string address)
        {
            var id = Guid.NewGuid();
            _shopsServ.Insert(id, name, address);
        }

        public void DeleteShop(Guid id)
        {
            _shopsServ.Delete(id);
        }

        public void CreateProduct(string name)
        {
            var id = Guid.NewGuid();
            _typesServ.Insert(id, name);
        }

        public void DeleteProduct(Guid id)
        {
            _typesServ.Delete(id);
        }

        public void PutProductsIntoShop(string shopName, string productName, int quantity, decimal price = default)
        {
            var shopId = _shopsServ.GetId(shopName);
            var productId = _typesServ.GetId(productName);
            _productsServ.Insert(productId, shopId, quantity, price);
        }

        public void PrintShopWithCheapestProduct(string productName)
        {
            var productId = _typesServ.GetId(productName);
            var shopid = _productsServ.FindShopWithCheapestProduct(productId);
            Console.WriteLine("The shop that has the cheapest product {0} is {1} : {2}.",
                productName, _shopsServ.GetName(shopid), shopid);
        }

        public void PrintQuantityBuy(string shopName, decimal payment)
        {
            var shopId = _shopsServ.GetId(shopName);
            var list = _productsServ.QuantityToBuy(shopId, payment);
            Console.WriteLine("In the shop {0} having {1}$ one can purchase:", shopName, payment);
            if (!list.Any())
                Console.WriteLine("None.");
            else
                foreach (var pair in list)
                {
                    Console.WriteLine("{0} of {1}", pair.Value, _typesServ.GetName(pair.Key));
                }
        }

        public void BuyProducts(string shopName, string productName, int number)
        {
            var shopId = _shopsServ.GetId(shopName);
            var productId = _typesServ.GetId(productName);
            var cost = _productsServ.FindCost(shopId, productId, number);
            if (cost == Decimal.MinValue)
                throw new InvalidProductsQuantityException();
            var quantity = _productsServ.GetQuantity(productId, shopId);
            _productsServ.UpdateQuantity(productId, shopId, quantity - number);
            Console.WriteLine("To buy {0} of product {1} in shop {2} one needs {3}",
                number, productName, shopName, cost);
        }

        public void PrintShopWithCheapestSet(List<KeyValuePair<string, int>> set)
        {
            var list = new List<KeyValuePair<Guid, int>>();
            foreach (var pair in set)
                list.Add(new KeyValuePair<Guid, int>(_typesServ.GetId(pair.Key), pair.Value));

            var shopId = _productsServ.FindShopWithCheapestSet(list);
            if (shopId == Guid.Empty)
                throw new InvalidProductsQuantityException();
            Console.WriteLine("The shop where one can purchase those products " +
                              "using the least amount of money is {0} : {1}.", _shopsServ.GetName(shopId), shopId);

        }
    }
}