using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities.Report;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Repositories.ReportRepository
{
    public class DailyReportRepo : IDailyRepo
    {
        private List<DailyReport> ReportRepo = new List<DailyReport>();
        
        public void Create(DailyReport report)
            => ReportRepo.Add(report);
        
        public DailyReport GetById(Guid id)
            => ReportRepo.Single(x => x.Id == id);

        public List<DailyReport> GetAll()
            => ReportRepo;
    }
}