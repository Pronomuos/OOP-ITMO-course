using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities.Report;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Repositories.ReportRepository
{
    public class TeamLeaderReportRepo : ITeamLeaderRepo
    {
        private List<TeamLeaderReport> ReportRepo = new List<TeamLeaderReport>();

        public void Create(TeamLeaderReport report)
            => ReportRepo.Add(report);

        public TeamLeaderReport GetById(Guid id)
            => ReportRepo.Single(x => x.Id == id);

        public List<TeamLeaderReport> GetAll()
            => ReportRepo;
    }
}
