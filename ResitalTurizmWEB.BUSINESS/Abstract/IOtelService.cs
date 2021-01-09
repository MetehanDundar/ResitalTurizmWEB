using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Abstract
{
    public interface IOtelService
    {
        Otel GetByID(int id);
        Otel GetOtelDetails(int id);
        List<Otel> GetOtelsByCategoryOtel(string name, int page, int pageSize);
        List<Otel> GetAll();
        void Create(Otel entity);
        void Update(Otel entity);
        void Delete(Otel entity);
        int GetCountByCategory(string categoryotel);
        List<Otel> GetSearchResult(string searchString,DateTime startDate,DateTime endDate);
    }
}
