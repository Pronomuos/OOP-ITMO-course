using System;

namespace BackupsManager.Exceptions
{
    public class FirstIncrementRestorePointException : BackupManagerException
    {
        public FirstIncrementRestorePointException()
            : base("Increment restore point cannot be without a parent restore point.") {}
        
        public FirstIncrementRestorePointException(Exception inner)
            : base("Increment restore point cannot be without a parent restore point.", inner) {}
        public FirstIncrementRestorePointException(string message)
            : base($"Increment restore point cannot be without a parent restore point: {message}.") {}
        
        public FirstIncrementRestorePointException(string message, Exception inner)
            : base($"Increment restore point cannot be without a parent restore point: {message}.", inner) {}
    }
}