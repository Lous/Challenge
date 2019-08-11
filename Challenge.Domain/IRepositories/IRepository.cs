using Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void Commit();
    }
}
