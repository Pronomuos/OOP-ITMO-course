using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities;

namespace ReportManager.UL.Controllers.Interfaces
{
    public interface ITasksController
    {
        public void Create(string name, Guid employeeId,
            string description = null, string comment = null);

        public void UpdateComment(string name, string comment);
        public void UpdateEmployee(string name, Guid newEmployeeId);
        public void UpdateState(string name, TasksStates state);
        public Task GetTaskById(Guid id);
        public Task GetTaskByLastCommit();
        public Task GetLastCreatedTask();
        public List<Task> GetTasksOfEmployee(Guid employeeId);
        public List<Task> GetEditedTasks();
        public List<Task> GetTasksOfSubordinates(Guid superiorId);
        public List<Task> GetTasksOfPeriod(int days);
        public void CompleteTask(string name);
        public Task GetLastTaskOfEmployee(Guid employeeId);
        public Guid GetIdByName(string name);
        public List<Task> GetDailyTaskOfEmployee(Guid employeeId);
    }
}