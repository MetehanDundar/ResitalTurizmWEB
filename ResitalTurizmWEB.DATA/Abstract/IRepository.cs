using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.DATA.Abstract
{
    public interface IRepository<T>
    {
        T GetByID(int id);
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
