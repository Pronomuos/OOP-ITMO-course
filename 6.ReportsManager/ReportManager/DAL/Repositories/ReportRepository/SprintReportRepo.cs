using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities.Report;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Repositories.ReportRepository
{
    public class SprintReportRepo : ISprintRepo
    {
        private List<SprintReport> ReportRepo = new List<SprintReport>();

        public void Create(SprintReport report)
            => ReportRepo.Add(report);

        public SprintReport GetById(Guid id)
            => ReportRepo.Single(x => x.Id == id);

        public List<SprintReport> GetAll()
            => ReportRepo;
    }
}
