using System;
using System.Collections.Generic;

namespace ReportManager.DAL.Entities
{
    public class TeamLeader : IWorker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Subordinates { get; set; }

        public TeamLeader(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
            Subordinates = new List<Employee>();
        }

        public class Builder
        {
            private string _name;
            private List<Employee> _subordinates = new List<Employee>();

            public Builder SetName(string name)
            {
                _name = name;
                return this;
            }


            public Builder SetSubordinates(List<Employee> list)
            {
                _subordinates = list;
                return this;
            }

            public Employee Build()
            {
                if (_name == null)
                    return null;

                var employee = new Employee(_name);
                employee.Subordinates = _subordinates;

                return employee;
            }
        }
    }
}
