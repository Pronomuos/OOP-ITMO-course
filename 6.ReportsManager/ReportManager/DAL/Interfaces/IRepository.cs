using System;
using System.Collections.Generic;

namespace ReportManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Create(T entity);
        public T GetById(Guid id);
        public List<T> GetAll();

    }
}