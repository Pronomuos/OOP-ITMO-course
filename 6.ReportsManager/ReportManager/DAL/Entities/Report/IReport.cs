using System;
using System.Collections.Generic;

namespace ReportManager.DAL.Entities.Report
{
    public interface IReport
    {
        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public ReportSates State { get; set; }
        public List<Task> CompletedTasks { get; }

        
    }
}