using System;

namespace ReportManager.UL.Controllers.Interfaces
{
    public interface IEmployeeController
    {
        public void AddEmployee(string name);
        public void UpdateSuperior(string employeeName, string subordinateName);
        public void AddSubordinate(string employeeName, string subordinateName);
        public void RemoveSubordinate(string employeeName, string subordinateName);
        public void SetTeamLeader(string name);
        public Guid GetId(string name);
        public void ShowHierarchy();

    }
}