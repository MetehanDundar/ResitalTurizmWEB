using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete.EfCore;
using ResitalTurizmWEB.ENTITY;
using ResitalTurizmWEB.ENTITY.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResitalTurizmWEB.BUSINESS.Concrete
{
    //iş katmanında filtreleme yani belli kontroller yapıyorum.
    public class OtelManager : IOtelService
    {
        private IOtelRepository _otelRepository;
        public OtelManager(IOtelRepository otelRepository)
        {
            _otelRepository = otelRepository;
        }
        public void Create(Otel entity)
        {
            //iş kuralları uygula
            
            _otelRepository.Create(entity);
        }

        public void Delete(Otel entity)
        {
            //iş kuralları uygula
            _otelRepository.Delete(entity);
        }

        public List<Otel> GetAll()
        {
            return _otelRepository.GetAll();
        }

        public Otel GetByID(int id)
        {
            return _otelRepository.GetByID(id);
        }

        public int GetCountByCategory(string categoryotel)
        {
            return _otelRepository.GetCountByCategory(categoryotel);
        }

        public Otel GetOtelDetails(int id)
        {
            return _otelRepository.GetOtelDetails(id);
        }

        public List<Otel> GetOtelsByCategoryOtel(string name, int page, int pageSize)
        {
            return _otelRepository.GetOtelsByCategoryOtel(name, page, pageSize);
        }

        public List<Otel> GetSearchResult(string searchString,DateTime startDate, DateTime endDate)
        {
            return _otelRepository.GetSearchResult(searchString, startDate, endDate);
        }

        public void Update(Otel entity)
        {
            _otelRepository.Update(entity);
        }
    }
}
