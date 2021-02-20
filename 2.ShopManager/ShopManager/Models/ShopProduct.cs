using System;
using System.ComponentModel;

namespace ShopManager.Models
{
    public class ShopProduct
    {
        public Guid ProductId { get; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public Guid ShopId { get; set; }

        public ShopProduct(Guid productId, int quantity, decimal price, Guid shopId)
        {
            ProductId = productId;
            SalePrice = price;
            Quantity = quantity;
            ShopId = shopId;
        }
    }
}