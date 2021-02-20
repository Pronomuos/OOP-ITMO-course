using System;
using ReportManager.DAL.Entities;

namespace ReportManager.BLL.Interfaces
{
    public interface IEmployeeService
    {
        public void AddEmployee(string name);
        public void UpdateSuperior(Guid employeeId, Guid superiorId);
        public void AddSubordinate(Guid employeeId, Guid subordinateId);
        public void RemoveSubordinate(Guid employeeId, Guid subordinateId);
        public void SetTeamLeader(string name);
        public Guid GetId(string name);
        public TeamLeader GetEmployees();
        public string GetNameById(Guid id);
    }

}