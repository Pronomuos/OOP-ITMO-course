using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.BLL.Interfaces;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Entities.Commit;
using ReportManager.DAL.Interfaces;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class TasksService : ITasksService
    {
        private IUnitOfWork _dataBase;

        public TasksService(IUnitOfWork database)
            => _dataBase = database;

        public void Create(string name, Guid employeeId,
            string description = null, string comment = null)
        => _dataBase.TasksRepo.Create(new Task(name, employeeId, _dataBase.Timer.Time,
                description, comment));
        

        public void UpdateComment(string name, string comment)
        {
            var taskId = _dataBase.TasksRepo.GetByName(name).Id;
            var employeeId = _dataBase.TasksRepo.GetByName(name).EmployeeInChargeId;
            if (_dataBase.TasksRepo.GetByName(name).State != TasksStates.Active)
                UpdateState(name, TasksStates.Active);
            var commit = new TaskCommentCommit(taskId, employeeId,
                _dataBase.TasksRepo.GetById(taskId).Comment, comment, _dataBase.Timer.Time);
            _dataBase.TasksRepo.GetById(taskId).Comment = comment;
            _dataBase.TasksRepo.GetById(taskId).Commit(commit);
            _dataBase.CommitsRepo.Create(commit);
        }

        public void UpdateState(string name, TasksStates state)
        {
            var taskId = _dataBase.TasksRepo.GetByName(name).Id;
            var employeeId = _dataBase.TasksRepo.GetByName(name).EmployeeInChargeId;
            var commit = new TaskStateCommit(taskId, employeeId,
                _dataBase.TasksRepo.GetById(taskId).State, state, _dataBase.Timer.Time);
            _dataBase.TasksRepo.GetById(taskId).State = state;
            _dataBase.TasksRepo.GetById(taskId).Commit(commit);
            _dataBase.CommitsRepo.Create(commit);
        }

        public void UpdateEmployee(string name,  Guid newEmployeeId)
        {
            var taskId = _dataBase.TasksRepo.GetByName(name).Id;
            var employeeId = _dataBase.TasksRepo.GetByName(name).EmployeeInChargeId;
            if (_dataBase.TasksRepo.GetById(taskId).State != TasksStates.Active)
                UpdateState(name, TasksStates.Active);
            var commit = new TaskEmployeeCommit(taskId, employeeId,
                _dataBase.TasksRepo.GetById(taskId).EmployeeInChargeId, newEmployeeId, _dataBase.Timer.Time);
            _dataBase.TasksRepo.GetById(taskId).EmployeeInChargeId = newEmployeeId;
            _dataBase.TasksRepo.GetById(taskId).Commit(commit);
            _dataBase.CommitsRepo.Create(commit);
        }

        public Task GetTaskById(Guid id)
            => _dataBase.TasksRepo.GetById(id);

        public Task GetTaskByLastCommit()
            => _dataBase.TasksRepo.GetAll().Where(x => x.Commits.Count != 0).
                OrderBy(x => x.Commits.Last().CommitDate).Last();
        
        public Task GetLastCreatedTask()
            => _dataBase.TasksRepo.GetAll().OrderBy(x => x.CreationDate).Last();

        public List<Task> GetTasksOfEmployee(Guid employeeId)
            => _dataBase.TasksRepo.GetAll().Where(x => x.EmployeeInChargeId == employeeId).ToList();

        public List<Task> GetEditedTasks()
            => _dataBase.TasksRepo.GetAll().Where(x => x.Commits.Count != 0).ToList();

        public List<Task> GetTasksOfSubordinates(Guid superiorId)
        {
            var tasks = new List<Task>();
            foreach (var task in _dataBase.TasksRepo.GetAll())
            {
                if (_dataBase.EmployeeRepo.GetById(task.EmployeeInChargeId) is Employee employee
                    && employee.SuperiorId == superiorId)
                    tasks.Add(task);

            }
            return tasks;
        }
        
        public List<Task> GetTasksOfPeriod (int days)
            => _dataBase.TasksRepo.GetAll().
                Where(x => x.TaskDoneDate >= _dataBase.Timer.Time.AddDays(-days)).
                ToList();
        
        public List<Task> GetDailyTaskOfEmployee (Guid employeeId)
            => _dataBase.TasksRepo.GetAll().
                Where(x => x.TaskDoneDate >= _dataBase.Timer.Time && x.EmployeeInChargeId == employeeId).
                ToList();

        public void CompleteTask(string name)
        {
            var taskId = _dataBase.TasksRepo.GetByName(name).Id;
            if (_dataBase.TasksRepo.GetById(taskId).State != TasksStates.Resolved)
            {
                UpdateState(name, TasksStates.Resolved);
                _dataBase.TasksRepo.GetById(taskId).TaskDoneDate = _dataBase.Timer.Time;
            }
        }
        
        public Task GetLastTaskOfEmployee (Guid employeeId)
            => _dataBase.TasksRepo.GetAll().Where(x => x.EmployeeInChargeId == employeeId ).
                OrderBy(x => x.CreationDate).Last();

        public Guid GetIdByName(string name)
            => _dataBase.TasksRepo.GetByName(name).Id;
    }
}