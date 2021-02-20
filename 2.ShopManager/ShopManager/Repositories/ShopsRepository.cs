using ShopManager.Models;
using System.Collections.Generic;
using System;
using ShopManager.Repositories.Interfaces;


namespace ShopManager.Repositories
{
    public class ShopsRepository : IShopsRepository
    {
        protected List<Shop> shopsList;

        public ShopsRepository()
        {
            shopsList = new List<Shop>();
        }


        public IEnumerable<Shop> GetShops()
        {
            return shopsList;
        }

        public void Insert(Guid id, string name, string address)
        {
            var index = shopsList.FindIndex(x => x.ShopId == id);
            if (index == -1)
                shopsList.Add(new Shop (id, name, address));
        }

        public void Delete(Guid id)
        {
            var index = shopsList.FindIndex(x => x.ShopId == id);
            if (index != -1)
                shopsList.RemoveAt(index);
        }

        public void UpdateName(Guid id, string name)
        {
            var index = shopsList.FindIndex(x => x.ShopId == id);
            if (index != -1)
                shopsList[index].ShopName = name;
        }

        public void UpdateAddress(Guid id, string address)
        {
            var index = shopsList.FindIndex(x => x.ShopId == id);
            if (index != -1)
                shopsList[index].UrlAddress = address;
        }

        public string GetName(Guid id)
        {
            var index = shopsList.FindIndex(x => x.ShopId == id);
            return (index != -1) ? 
                shopsList[index].ShopName :
                default;
        }

        public Guid GetId(string name)
        {
            var index = shopsList.FindIndex(x => x.ShopName == name);
            return (index != -1) ? 
                shopsList[index].ShopId :
                default;
        }
        public Guid GetId(string name, string address)
        {
            var index = shopsList.
                FindIndex(x => x.ShopName == name && x.UrlAddress == address);
            return (index != -1) ? 
                shopsList[index].ShopId :
                default;
        }
    }
}