using System;
using ReportManager.DAL.Entities;

namespace ReportManager.DAL.Interfaces
{
    public interface ITasksRepository : IRepository<Task>
    {
        public Guid GetId(string name);
        public Task GetByName(string name);
    }
}