using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Interfaces;

namespace ReportManager.BLL.Interfaces
{
    public interface ICommitService
    {

        public List<ICommit> GetCommitsOfPeriod(int days);
        public List<ICommit> GetDailyCommitsOfEmployee(Guid employeeId);
    }
}