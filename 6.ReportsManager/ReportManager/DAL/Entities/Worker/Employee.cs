using System;
using System.Collections.Generic;

namespace ReportManager.DAL.Entities
{
    public class Employee : IWorker
    {
        public Guid Id { get; set;}
        public string Name { get; set;}
        public Guid? SuperiorId { get; set; }
        public List<Employee> Subordinates {get; set;}
        
        public Employee(string name)                        
        {                                                      
            Name = name;
            Id = Guid.NewGuid(); 
            Subordinates = new List<Employee>();
        }                                                      
                                                               
        public class Builder                                   
        {                                                      
            private string _name;                               
            private Guid? _superiorId = null;                           
            private List<Employee> _subordinates;                 
                                                               
            public Builder SetName(string name)               
            {                                                  
                _name = name;                             
                return this;                                   
            }                                                  
                                                               
            public Builder SetSuperior (Guid superiorId)            
            {                                                  
                _superiorId = superiorId;                              
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
                employee.SuperiorId = _superiorId;              
                employee.Subordinates = _subordinates;      
                                                               
                return employee;                               
            }
        }                                                      
    }
}