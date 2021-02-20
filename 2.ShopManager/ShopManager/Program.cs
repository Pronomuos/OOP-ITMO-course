using System;
using System.Collections.Generic;
using System.Linq;
using ShopManager.Exceptions;
using ShopManager.Services;
using ShopManager.Models;

namespace ShopManager
{
    class Program
    {
        private static void Main(string[] args)
        {
            var shopManager = new ShopManagerService();

            try
            {
                shopManager.CreateShop("LetoMall", "https://letomall.ru");
                shopManager.CreateShop("Piterland", "http://piterland.ru");
                shopManager.CreateShop("Ecopolis", "https://ecopolis-spb.ru");

                shopManager.CreateProduct("Bread");
                shopManager.CreateProduct("Cereals");
                shopManager.CreateProduct("Mints");
                shopManager.CreateProduct("Chocolate bar");
                shopManager.CreateProduct("Ice cream");
                shopManager.CreateProduct("Eggs");
                shopManager.CreateProduct("Nuts");
                shopManager.CreateProduct("Pork");
                shopManager.CreateProduct("Fish");
                shopManager.CreateProduct("Potato");

                shopManager.PutProductsIntoShop("LetoMall", "Cereals", 11, 10);
                shopManager.PutProductsIntoShop("LetoMall", "Chocolate bar", 7, 15);
                shopManager.PutProductsIntoShop("LetoMall", "Eggs", 18, 8);
                shopManager.PutProductsIntoShop("LetoMall", "Pork", 13, 15);
                shopManager.PutProductsIntoShop("LetoMall", "Potato", 8, 18);
                shopManager.PutProductsIntoShop("Piterland", "Mints", 22, 6);
                shopManager.PutProductsIntoShop("Piterland", "Chocolate bar", 12, 10);
                shopManager.PutProductsIntoShop("Piterland", "Nuts", 4, 13);
                shopManager.PutProductsIntoShop("Piterland", "Pork", 6, 30);
                shopManager.PutProductsIntoShop("Piterland", "Cereals", 11, 20);
                shopManager.PutProductsIntoShop("Ecopolis", "Bread", 9, 8);
                shopManager.PutProductsIntoShop("Ecopolis", "Cereals", 3, 25);
                shopManager.PutProductsIntoShop("Ecopolis", "Chocolate bar", 15, 12);
                shopManager.PutProductsIntoShop("Ecopolis", "Pork", 18, 11);
                shopManager.PutProductsIntoShop("Ecopolis", "Fish", 14, 14);

                shopManager.PrintShopWithCheapestProduct("Chocolate bar");
                shopManager.PrintQuantityBuy("Piterland", 100);
                shopManager.BuyProducts("LetoMall", "Potato", 5);
                var set = new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>("Cereals", 3),
                    new KeyValuePair<string, int>("Chocolate bar", 3),
                    new KeyValuePair<string, int>("Pork", 3)
                };
                shopManager.PrintShopWithCheapestSet(set);
            }
            catch (ShopManagerException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}