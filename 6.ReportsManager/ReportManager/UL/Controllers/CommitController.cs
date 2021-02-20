using System;
using System.Collections.Generic;
using ReportManager.BLL.Interfaces;
using ReportManager.DAL.Entities.Commit;
using ReportManager.UL.Controllers.Interfaces;

namespace ReportManager.UL.Controllers
{
    public class CommitController : ICommitController
    {
        private ICommitService _service;

        public CommitController(ICommitService service)
            => _service = service;

        public List<ICommit> GetCommitsOfPeriod(int days)
            => _service.GetCommitsOfPeriod(days);

        public List<ICommit> GetDailyCommitsOfEmployee(Guid employeeId)
            => _service.GetDailyCommitsOfEmployee(employeeId);
    }
}