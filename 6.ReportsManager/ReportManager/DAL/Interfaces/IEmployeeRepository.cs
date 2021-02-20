using System;
using ReportManager.DAL.Entities;

namespace ReportManager.DAL.Interfaces
{
    public interface IEmployeeRepository : IRepository<IWorker>
    {
        public Guid GetId(string name);
    }
}