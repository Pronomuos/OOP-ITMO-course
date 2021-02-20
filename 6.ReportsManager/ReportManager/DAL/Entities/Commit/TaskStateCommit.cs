using System;

namespace ReportManager.DAL.Entities.Commit
{
    public class TaskStateCommit : ICommit
    {
        public DateTime CommitDate { get; }
        public Guid CommitId { get; }
        public Guid TaskId { get; }
        public Guid EmployeeInCharge { get; }
        public TasksStates PreviousState { get; }
        public TasksStates NewState { get; }
        
        public TaskStateCommit(Guid taskId, Guid employeeId, TasksStates prev, TasksStates update, DateTime time)
        {
            CommitId = Guid.NewGuid();
            CommitDate = time;
            TaskId = taskId;
            EmployeeInCharge = employeeId;
            PreviousState = prev;
            NewState = update;
        }
    }
}