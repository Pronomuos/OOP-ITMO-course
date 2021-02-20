using System;

namespace ShopManager.Exceptions
{
    public class InvalidProductException : ShopManagerException
    {
        public InvalidProductException()
            : base("There is no such a product in the shop.") {}
        
        public InvalidProductException(Exception inner)
            : base("There is no such a product in the shop.", inner) {}
        public InvalidProductException(string message)
            : base($"There is no such a product in the shop: {message}.") {}
        
        public InvalidProductException(string message, Exception inner)
            : base($"There is no such a product in the shop: {message}.", inner) {}
    }
}