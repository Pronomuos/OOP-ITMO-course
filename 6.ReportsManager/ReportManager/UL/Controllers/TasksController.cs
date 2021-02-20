using System;
using System.Collections.Generic;
using ReportManager.BLL.Interfaces;
using ReportManager.BLL.Services;
using ReportManager.DAL.Entities;
using ReportManager.UL.Controllers.Interfaces;

namespace ReportManager.UL.Controllers
{
    public class TasksController : ITasksController
    {
        private ITasksService _service;

        public TasksController(ITasksService service)
            => _service = service;

        public void Create(string name, Guid employeeId,
            string description = null, string comment = null)
            => _service.Create(name, employeeId, description, comment);

        public void UpdateComment(string name, string comment)
            => _service.UpdateComment(name, comment);

        public void UpdateEmployee(string name, Guid newEmployeeId)
            => _service.UpdateEmployee(name, newEmployeeId);

        public void UpdateState(string name, TasksStates state)
            => _service.UpdateState(name, state);

        public Task GetTaskById(Guid id)
            => _service.GetTaskById(id);

        public Task GetTaskByLastCommit()
            => _service.GetTaskByLastCommit();
        
        public Task GetLastCreatedTask()
            => _service.GetLastCreatedTask();

        public List<Task> GetTasksOfEmployee(Guid employeeId)
            => _service.GetTasksOfEmployee(employeeId);

        public List<Task> GetEditedTasks()
            => _service.GetEditedTasks();

        public List<Task> GetTasksOfSubordinates(Guid superiorId)
            => _service.GetTasksOfSubordinates(superiorId);

        public List<Task> GetTasksOfPeriod(int days)
            => _service.GetTasksOfPeriod(days);

        public void CompleteTask(string name)
            => _service.CompleteTask(name);

        public Task GetLastTaskOfEmployee(Guid employeeId)
            => _service.GetLastTaskOfEmployee(employeeId);
        
        public Guid GetIdByName(string name)
            => _service.GetIdByName(name);

        public List<Task> GetDailyTaskOfEmployee(Guid employeeId)
            => _service.GetDailyTaskOfEmployee(employeeId);
    }
}