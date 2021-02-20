using System;
using System.Collections.Generic;

namespace ReportManager.DAL.Entities.Report
{
    public class TeamLeaderReport : IReport
    {
        public Guid EmployeeInChargeId  { get;}
        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public ReportSates State { get; set; }
        public List<SprintReport> SprintReports { get; }
        public List<Task> CompletedTasks { get; }
        
        public TeamLeaderReport(Guid employeeInChargeId)
        {
            EmployeeInChargeId = employeeInChargeId;
            CreationDate = DateTime.Today;
            State = ReportSates.Open;
            SprintReports = new List<SprintReport>();
        }
        
        public TeamLeaderReport(Guid employeeInChargeId,
            List<SprintReport> sprintReports, List<Task> completedTasks, DateTime time)
        {
            EmployeeInChargeId = employeeInChargeId;
            CreationDate = time;
            State = ReportSates.Open;
            SprintReports = sprintReports;
            CompletedTasks = completedTasks;
            Id = Guid.NewGuid(); 
            SprintReports = new List<SprintReport>();
        }
    }
}