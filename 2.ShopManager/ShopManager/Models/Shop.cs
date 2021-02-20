using System.Data.Common;
using System.Collections.Generic;
using System;

namespace ShopManager.Models
{
    public class Shop
    {
        public Guid ShopId { get;}
        public string ShopName { get; set; }
        public string UrlAddress { get; set; }

        public Shop(Guid id, string name, string address)
        {
            ShopId = id;
            ShopName = name;
            UrlAddress = address;
        }
    }
    
    
}