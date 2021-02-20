using System;

namespace BanksManager.Exceptions
{
    public class BanksManagerException : Exception
    {
        public BanksManagerException() {}
        public BanksManagerException(string message) :
            base(message) {}
        public BanksManagerException(string message, Exception inner) :
            base(message, inner) {}
    }
}