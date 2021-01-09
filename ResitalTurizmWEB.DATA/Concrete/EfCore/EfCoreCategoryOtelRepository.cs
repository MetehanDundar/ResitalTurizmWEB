using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.DATA.Concrete.EfCore
{
    public class EfCoreCategoryOtelRepository : EfCoreGenericRepository<CategoryOtel, ResitalContext>,ICategoryOtelRepository
    {
        
    }
}
