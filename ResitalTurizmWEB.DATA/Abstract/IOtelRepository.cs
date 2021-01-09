using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.DATA.Abstract
{
    public interface IOtelRepository : IRepository<Otel>
    {
        Otel GetOtelDetails(int id);
        List<Otel> GetOtelsByCategoryOtel(string name,int page, int pageSize);
        List<Otel> GetSearchResult(string searchString,DateTime startDate, DateTime endDate);
        int GetCountByCategory(string categoryotel);
    }
}
