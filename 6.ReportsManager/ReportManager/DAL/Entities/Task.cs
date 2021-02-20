using System;
using System.Collections.Generic;
using ReportManager.DAL.Entities.Commit;

namespace ReportManager.DAL.Entities
{
    public class Task
    {
        public DateTime CreationDate { get;}
        public DateTime? TaskDoneDate { get; set; }
        public Guid Id { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public Guid EmployeeInChargeId  { get; set;}
        public string Comment { get; set;}
        public TasksStates State { get; set;}
        public List<ICommit> Commits { get; set;}

        public Task (string name, Guid employeeId, DateTime time, 
            string description = null, string comment = null)
        {
            Name = name;
            Description = description;
            EmployeeInChargeId = employeeId;
            Comment = comment;
            State = TasksStates.Open;
            Id = Guid.NewGuid();
            Commits = new List<ICommit>();
            CreationDate = time;
            TaskDoneDate = null;
        }
        
        public Task(Task task)
        { 
            CreationDate = task.CreationDate;
            TaskDoneDate = task.TaskDoneDate;
            Id = task.Id; 
            Name = task.Name; 
            Description = task.Description;
            EmployeeInChargeId = task.EmployeeInChargeId; 
            Comment = task.Comment;
            State = task.State;
        }

        public void Commit(ICommit commit)
            => Commits.Add(commit);

        public bool Edited()
            => Commits.Count != 0;

    }
}