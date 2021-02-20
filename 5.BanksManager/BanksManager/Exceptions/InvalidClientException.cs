using System;

namespace BanksManager.Exceptions
{
    public class InvalidClientException : BanksManagerException
    {
        public InvalidClientException()
            : base("Client should be with a name and a surname.") {}
        
        public InvalidClientException(Exception inner)
            : base("Client should be with a name and a surname.", inner) {}
        public InvalidClientException(string message)
            : base($"Client should be with a name and a surname.: {message}.") {}
        
        public InvalidClientException(string message, Exception inner)
            : base($"Client should be with a name and a surname.: {message}.", inner) {}
    }
}