using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Abstract
{
    public interface ICategoryOtelService
    {
        CategoryOtel GetByID(int id);
        List<CategoryOtel> GetAll();
        void Create(CategoryOtel entity);
        void Update(CategoryOtel entity);
        void Delete(CategoryOtel entity);
    }
}
