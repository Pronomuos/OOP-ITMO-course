using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Interfaces;

namespace ReportManager.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private List<Task> TasksRepo = new List<Task>();

        public void Create(Task task)
            => TasksRepo.Add(task);
        
        public Guid GetId (string name)
            => TasksRepo.Single(x => x.Name == name).Id;
        
        
        public Task GetById(Guid id)
            => TasksRepo.Single(x => x.Id == id);
        
        public Task GetByName(string name)
            => TasksRepo.Single(x => x.Name == name);

        public List<Task> GetAll()
            => TasksRepo;
        


    }
}