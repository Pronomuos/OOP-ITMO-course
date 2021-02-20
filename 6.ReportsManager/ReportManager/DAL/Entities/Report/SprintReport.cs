using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities.Commit;

namespace ReportManager.DAL.Entities.Report
{
    public class SprintReport : IReport
    {
        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public ReportSates State { get; set; }
        public List<DailyReport> Reports { get; }
        public List<Task> CompletedTasks { get; }
        
        public int NumberOfSprintDays { get; }
        
        public SprintReport (int numberOfSprintDays, DateTime time)
        {
            CreationDate = time;
            State = ReportSates.Open;
            NumberOfSprintDays = numberOfSprintDays;
            Reports = new List<DailyReport>();
        }
        
        public SprintReport(List<DailyReport> reports, List<Task> completedTasks,
            int numberOfSprintDays, DateTime time)
        {
            CreationDate = time;
            State = ReportSates.Open;
            Reports = reports;
            CompletedTasks = completedTasks;
            NumberOfSprintDays = numberOfSprintDays;
            Id = Guid.NewGuid(); 
            Reports = new List<DailyReport>();
        }
    }
}