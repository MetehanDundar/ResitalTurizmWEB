using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.DATA.Abstract
{
    public interface IBookingRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(int id);
    }
}
