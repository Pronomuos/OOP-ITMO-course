using System;

namespace ReportManager.DAL.Entities.Commit
{
    public class TaskEmployeeCommit : ICommit
    {
        public DateTime CommitDate { get; }
        public Guid CommitId { get; }
        public Guid TaskId { get; }
        public Guid EmployeeInCharge { get; }
        public Guid PreviousEmployeeId { get; }
        public Guid NewEmployeeId { get; }
        
        public TaskEmployeeCommit(Guid taskId, Guid employeeId, Guid prev, Guid update, DateTime time)
        {
            CommitId = Guid.NewGuid();
            CommitDate = time;
            TaskId = taskId;
            EmployeeInCharge = employeeId;
            PreviousEmployeeId = prev;
            NewEmployeeId = update;
        }
    }
}