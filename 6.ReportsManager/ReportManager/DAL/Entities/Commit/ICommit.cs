using System;

namespace ReportManager.DAL.Entities.Commit
{
    public interface ICommit
    {
        public DateTime CommitDate { get; }
        public Guid CommitId { get; }
        public Guid TaskId { get; }
        
        public Guid EmployeeInCharge { get; }
        
    }
}