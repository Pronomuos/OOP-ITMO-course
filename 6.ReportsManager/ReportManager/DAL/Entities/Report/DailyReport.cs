using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities.Commit;

namespace ReportManager.DAL.Entities.Report
{
    public class DailyReport : IReport
    {
        public Guid EmployeeInChargeId  { get;}
        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public ReportSates State { get; set; }
        public List<ICommit> Changes { get; }
        public List<Task> CompletedTasks { get; }

        public DailyReport(Guid employeeInChargeId, DateTime time)
        {
            EmployeeInChargeId = employeeInChargeId;
            CreationDate = time;
            State = ReportSates.Open;
            Id = Guid.NewGuid(); 
            Changes = new List<ICommit>();
        }
        
        public DailyReport(Guid employeeInChargeId, 
            List<ICommit> changes, List<Task> completedTasks, DateTime time)
        {
            EmployeeInChargeId = employeeInChargeId;
            CreationDate = time;
            State = ReportSates.Open;
            Changes = changes;
            CompletedTasks = completedTasks;
            Id = Guid.NewGuid(); 
        }
    }
}