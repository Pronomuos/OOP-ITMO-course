using System;

namespace ReportManager.DAL.Entities.Commit
{
    public class TaskCommentCommit : ICommit
    {
        public DateTime CommitDate { get; }
        public Guid CommitId { get; }
        public Guid TaskId { get; }
        public Guid EmployeeInCharge { get; }
        public string PreviousComment { get; }
        public string NewComment { get; }

        public TaskCommentCommit(Guid taskId, Guid employeeId, string prev, string update, DateTime time)
        {
            CommitId = Guid.NewGuid();
            CommitDate = time;
            TaskId = taskId;
            EmployeeInCharge = employeeId;
            PreviousComment = prev;
            NewComment = update;
        }
    }
}