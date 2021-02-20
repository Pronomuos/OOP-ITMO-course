using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities.Commit;

namespace ReportManager.UL.Controllers.Interfaces
{
    public interface ICommitController
    {
        public List<ICommit> GetCommitsOfPeriod(int days);
        public List<ICommit> GetDailyCommitsOfEmployee(Guid employeeId);
    }
}