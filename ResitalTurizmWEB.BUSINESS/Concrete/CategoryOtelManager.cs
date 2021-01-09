using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Concrete
{
    public class CategoryOtelManager : ICategoryOtelService
    {
        private ICategoryOtelRepository _categoryRepository;
        public CategoryOtelManager(ICategoryOtelRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(CategoryOtel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoryOtel entity)
        {
            throw new NotImplementedException();
        }

        public List<CategoryOtel> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public CategoryOtel GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryOtel entity)
        {
            throw new NotImplementedException();
        }
    }
}
