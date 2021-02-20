using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Repositories
{
    public class CommitsRepository : ICommitsRepository
    {
        private List<ICommit> CommitsRepo = new List<ICommit>();

        public void Create(ICommit employee)
            => CommitsRepo.Add(employee);
        
        public ICommit GetById(Guid id)
            => CommitsRepo.Single(x => x.CommitId == id);

        public List<ICommit> GetAll()
            => CommitsRepo;
    }
}