using System;

namespace ShopManager.Exceptions
{
    public class InvalidProductsQuantityException : ShopManagerException
    {
        public InvalidProductsQuantityException()
            : base("There is not enough products in the shop.") {}
        
        public InvalidProductsQuantityException(Exception inner)
            : base("There is not enough products in the shop.", inner) {}
        public InvalidProductsQuantityException(string message)
            : base($"There is not enough products in the shop: {message}.") {}
        
        public InvalidProductsQuantityException(string message, Exception inner)
            : base($"There is not enough products in the shop: {message}.", inner) {}
    }
}