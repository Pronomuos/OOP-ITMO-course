using System;
using System.Collections.Generic;

namespace ReportManager.DAL.Entities
{
    public interface IWorker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public List<Employee> Subordinates {get; set;}
    }
}