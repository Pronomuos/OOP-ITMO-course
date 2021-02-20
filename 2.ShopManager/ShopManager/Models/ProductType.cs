using System;

namespace ShopManager.Models
{
    public class ProductType
    {
        public Guid ProductId { get;}
        public string ProductName { get; set; }

        public ProductType(Guid id, string name)
        {
            ProductId = id;
            ProductName = name;
        }
    }
}