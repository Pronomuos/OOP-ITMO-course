using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<IWorker> EmployeeRepo = new List<IWorker>();

        public void Create(IWorker employee)
            => EmployeeRepo.Add(employee);
        public Guid GetId (string name)
            => EmployeeRepo.Single(x => x.Name == name).Id;
        public IWorker GetById(Guid id)
            => EmployeeRepo.Single(x => x.Id == id);

        public List<IWorker> GetAll()
            => EmployeeRepo;
    }
}