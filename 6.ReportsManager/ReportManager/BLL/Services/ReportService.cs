using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.BLL.Interfaces;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Entities.Report;
using ReportManager.DAL.Interfaces;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class ReportService : IReportService
    {
        private IUnitOfWork _dataBase;

        public ReportService(IUnitOfWork database)
            => _dataBase = database;

        public void CreateDailyReport (Guid employee)
            => _dataBase.DailyReportRepo.Create(new DailyReport(employee, _dataBase.Timer.Time));

        public void AddDailyTasks(Guid employeeId, List<Task> tasks)
        {
            var reportId = GetLastDailyReportIdOfEmployee(employeeId);
            if (CheckDailyState(reportId))
                foreach (var task in tasks)
                    _dataBase.DailyReportRepo.GetById(reportId).CompletedTasks.Add(task);
        }

        public void AddDailyChanges(Guid employeeId, List<ICommit> changes)
        {
            var reportId = GetLastDailyReportIdOfEmployee(employeeId);
            if (CheckDailyState(reportId))
                foreach (var change in changes)
                    _dataBase.DailyReportRepo.GetById(reportId).Changes.Add(change);
        }

        public Guid GetLastDailyReportIdOfEmployee(Guid employee)
            =>  _dataBase.DailyReportRepo.GetAll(). Where(x => x.EmployeeInChargeId == employee).
                OrderBy(x => x.CreationDate).
                Last().Id;
        
        public DailyReport GetLastDailyReportOfEmployee(Guid employee)
            =>  _dataBase.DailyReportRepo.GetAll().OrderBy(x => x.CreationDate).Last();
        

        private bool CheckDailyState (Guid reportId)
        {
            if (_dataBase.DailyReportRepo.GetById(reportId).CreationDate.AddDays(1) > _dataBase.Timer.Time)
                return true;
            
            _dataBase.DailyReportRepo.GetById(reportId).State = ReportSates.Closed;
            return false;
        }
        
        public List<DailyReport> GetReportsOfPeriod (int days)
            => _dataBase.DailyReportRepo.GetAll().
                Where(x => x.CreationDate >= _dataBase.Timer.Time.AddDays(-days)).
                ToList();



        public void CreateSprintReport (int numberOfSprintDays)
            => _dataBase.SprintReportRepo.Create(new SprintReport(numberOfSprintDays, _dataBase.Timer.Time));

        public Guid GetLastSprintId()
            => _dataBase.SprintReportRepo.GetAll().OrderBy(x => x.CreationDate).Last().Id;
        
        public SprintReport GetLastSprint()
            => _dataBase.SprintReportRepo.GetAll().OrderBy(x => x.CreationDate).Last();

        public void AddReportsToSprint(SprintReport sprint, List<DailyReport> reports)
        {
            foreach (var report in reports)
                sprint.Reports.Add(report);
        }

        public void CompleteSprint(Guid reportId)
            => _dataBase.SprintReportRepo.GetById(reportId).State = ReportSates.Closed;
        
        public void CompleteReport(Guid reportId)
            => _dataBase.DailyReportRepo.GetById(reportId).State = ReportSates.Closed;
        
        public void CompleteTeamLeaderReport(Guid reportId)
            => _dataBase.TeamLeaderReportRepo.GetById(reportId).State = ReportSates.Closed;

        public void CreateTeamLeaderReport (Guid teamLeaderId)
            => _dataBase.TeamLeaderReportRepo.Create(new TeamLeaderReport(teamLeaderId));

        public Guid GetLastTeamLeaderReportId()
            => _dataBase.TeamLeaderReportRepo.GetAll().OrderBy(x => x.CreationDate).Last().Id;
        
        public TeamLeaderReport GetLastTeamLeaderReport()
            => _dataBase.TeamLeaderReportRepo.GetAll().OrderBy(x => x.CreationDate).Last();

        public void AddSprintsToTeamLeaderReport(TeamLeaderReport sprint, SprintReport report)
        {
            if (report.State == ReportSates.Closed)
                sprint.SprintReports.Add(report);
        }

    }
}