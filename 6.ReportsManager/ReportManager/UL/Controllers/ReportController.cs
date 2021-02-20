using System;
using System.Collections.Generic;
using ReportManager.BLL.Interfaces;
using ReportManager.BLL.Services;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Entities.Report;
using ReportManager.UL.Controllers.Interfaces;

namespace ReportManager.UL.Controllers
{
    public class ReportController : IReportController
    {
        private IReportService _reportServ;

        public ReportController(IReportService reportServ)
            => _reportServ = reportServ;
        

        public void CreateDailyReport(Guid employee)
            => _reportServ.CreateDailyReport(employee);

        public void AddDailyTasks(Guid employeeId, List<Task> tasks)
            => _reportServ.AddDailyTasks(employeeId, tasks);

        public void AddDailyChanges(Guid employeeId, List<ICommit> changes)
            => _reportServ.AddDailyChanges(employeeId, changes);

        public Guid GetLastDailyReportIdOfEmployee(Guid employee)
            => _reportServ.GetLastDailyReportIdOfEmployee(employee);

        public DailyReport GetLastDailyReportOfEmployee(Guid employee)
            => _reportServ.GetLastDailyReportOfEmployee(employee);


        public List<DailyReport> GetReportsOfPeriod(int days)
            => _reportServ.GetReportsOfPeriod(days);


        public void CreateSprintReport(int numberOfSprintDays)
            => _reportServ.CreateSprintReport(numberOfSprintDays);

        public Guid GetLastSprintId()
            => _reportServ.GetLastSprintId();

        public SprintReport GetLastSprint()
            => _reportServ.GetLastSprint();

        public void AddReportsToSprint(SprintReport sprint, List<DailyReport> reports)
            => _reportServ.AddReportsToSprint(sprint, reports);

        public void CompleteSprint(Guid reportId)
            => _reportServ.CompleteSprint(reportId);

        public void CompleteReport(Guid reportId)
            => _reportServ.CompleteReport(reportId);

        public void CompleteTeamLeaderReport(Guid reportId)
            => _reportServ.CompleteTeamLeaderReport(reportId);


        public void CreateTeamLeaderReport(Guid teamLeaderId)
            => _reportServ.CreateTeamLeaderReport(teamLeaderId);

        public Guid GetLastTeamLeaderReportId()
            => _reportServ.GetLastTeamLeaderReportId();

        public TeamLeaderReport GetLastTeamLeaderReport()
            => _reportServ.GetLastTeamLeaderReport();

        public void AddSprintsToTeamLeaderReport(TeamLeaderReport sprint, SprintReport report)
            => _reportServ.AddSprintsToTeamLeaderReport(sprint, report);
    }
}