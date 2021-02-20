using System;

namespace ShopManager.Exceptions
{
    public class ShopManagerException : Exception
    {
        public ShopManagerException() {}
        public ShopManagerException(string message) :
            base(message) {}
        public ShopManagerException(string message, Exception inner) :
            base(message, inner) {}
    }
}
