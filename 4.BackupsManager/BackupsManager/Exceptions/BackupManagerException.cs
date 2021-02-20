using System;
namespace BackupsManager.Exceptions
{
    public class BackupManagerException : Exception
    {
        public BackupManagerException() {}
        public BackupManagerException(string message) :
            base(message) {}
        public BackupManagerException(string message, Exception inner) :
            base(message, inner) {}
    }
}