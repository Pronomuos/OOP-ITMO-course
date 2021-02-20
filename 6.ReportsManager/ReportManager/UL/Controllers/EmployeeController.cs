using System;
using System.Collections;
using System.Collections.Generic;
using ReportManager.BLL.Interfaces;
using ReportManager.BLL.Services;
using ReportManager.DAL.Entities;
using ReportManager.UL.Controllers.Interfaces;

namespace ReportManager.UL.Controllers
{
    public class EmployeeController : IEmployeeController
    {
        private IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
            => _service = service;

        public void AddEmployee(string name)
            => _service.AddEmployee(name);

        public void UpdateSuperior(string employeeName, string subordinateName)
            => _service.UpdateSuperior(_service.GetId(employeeName), _service.GetId(subordinateName));

        public void AddSubordinate(string employeeName, string subordinateName)
        {
            
            _service.AddSubordinate(_service.GetId(employeeName), _service.GetId(subordinateName));
        }

        public void RemoveSubordinate(string employeeName, string subordinateName)
            => _service.RemoveSubordinate(_service.GetId(employeeName), _service.GetId(subordinateName));

        public void SetTeamLeader(string name)
            => _service.SetTeamLeader(name);
        
        public Guid GetId(string name)
            => _service.GetId(name);

        public void ShowHierarchy() 
        {
            var leader = _service.GetEmployees();
            Console.WriteLine("The team leader is - {0}.", leader.Name);
            var employees = new Queue<Employee>(leader.Subordinates);
            while (employees.Count != 0)
            {
                var next = employees.Dequeue();
                Console.WriteLine("A subordinate of {0} is {1}.", _service.GetNameById((Guid) next.SuperiorId), next.Name);
                foreach (var sub in next.Subordinates)
                    employees.Enqueue(sub);
            }
        }

    }
}