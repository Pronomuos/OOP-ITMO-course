using System;
using System.Collections.Generic;
using System.Linq;
using ReportManager.BLL.Interfaces;
using ReportManager.DAL.Entities;
using ReportManager.DAL.Interfaces;
using ReportManager.DAL.Repositories;

namespace ReportManager.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _dataBase;

        public EmployeeService(IUnitOfWork database)
            => _dataBase = database;

        public void AddEmployee(string name)
            => _dataBase.EmployeeRepo.Create(new Employee(name));

        public void UpdateSuperior(Guid employeeId, Guid superiorId)
        {
            if (_dataBase.EmployeeRepo.GetById(employeeId) is Employee employee)
            {
                if (employee.SuperiorId != null)
                    _dataBase.EmployeeRepo.GetById((Guid) employee.SuperiorId).Subordinates.Remove(employee);
                employee.SuperiorId = superiorId;
                var superior =  _dataBase.EmployeeRepo.GetById(superiorId);
                superior.Subordinates.Add(employee);

            }
        }

        public void AddSubordinate(Guid employeeId, Guid subordinateId)
            => _dataBase.EmployeeRepo.GetById(employeeId).Subordinates.
                Add((Employee) _dataBase.EmployeeRepo.GetById(subordinateId));

        public void RemoveSubordinate(Guid employeeId, Guid subordinateId)
            => _dataBase.EmployeeRepo.GetById(employeeId).Subordinates.
                Remove((Employee) _dataBase.EmployeeRepo.GetById(subordinateId));

        public void SetTeamLeader(string name)
        => _dataBase.EmployeeRepo.Create(new TeamLeader(name));
        
        
        public Guid GetId (string name)
            => _dataBase.EmployeeRepo.GetId(name);

        public TeamLeader GetEmployees()
        {
            var employees = _dataBase.EmployeeRepo.GetAll();
            return (TeamLeader) employees.Single(x => x is TeamLeader);
        }
        
        public string GetNameById (Guid id)
            => _dataBase.EmployeeRepo.GetById(id).Name;
    }

}
