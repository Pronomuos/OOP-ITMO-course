using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Entities.Report;

namespace ReportManager.UL.Controllers.Interfaces
{
    public interface IReportController
    {
        public void CreateDailyReport(Guid employee);
        public void AddDailyTasks(Guid employeeId, List<Task> tasks);
        public void AddDailyChanges(Guid employeeId, List<ICommit> changes);
        public Guid GetLastDailyReportIdOfEmployee(Guid employee);
        public DailyReport GetLastDailyReportOfEmployee(Guid employee);
        public List<DailyReport> GetReportsOfPeriod(int days);
        public void CreateSprintReport(int numberOfSprintDays);
        public Guid GetLastSprintId();
        public SprintReport GetLastSprint();
        public void AddReportsToSprint(SprintReport sprint, List<DailyReport> reports);
        public void CompleteSprint(Guid reportId);
        public void CompleteReport(Guid reportId);
        public void CompleteTeamLeaderReport(Guid reportId);
        public void CreateTeamLeaderReport(Guid teamLeaderId);
        public Guid GetLastTeamLeaderReportId();
        public TeamLeaderReport GetLastTeamLeaderReport();
        public void AddSprintsToTeamLeaderReport(TeamLeaderReport sprint, SprintReport report);
    }
}