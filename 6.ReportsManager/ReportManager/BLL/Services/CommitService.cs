using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.BLL.Interfaces;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Interfaces;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class CommitService : ICommitService
    {
        private IUnitOfWork _dataBase;

        public CommitService (IUnitOfWork database)
            => _dataBase = database;
        
        public List<ICommit> GetCommitsOfPeriod (int days)
            => _dataBase.CommitsRepo.GetAll().
                Where(x => x.CommitDate >= _dataBase.Timer.Time.AddDays(-days)).
                ToList();
        
        public List<ICommit> GetDailyCommitsOfEmployee (Guid employeeId)
            => _dataBase.CommitsRepo.GetAll().
                Where(x => x.CommitDate >= _dataBase.Timer.Time && x.EmployeeInCharge == employeeId).
                ToList();
    }
}