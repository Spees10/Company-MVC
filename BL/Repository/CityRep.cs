using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.Models;

namespace WebApplication7.BL.Repository
{
    public class CityRep : ICityRep
    {
        private readonly DbContainer db;


       
        public CityRep(DbContainer db)
        {
            this.db = db;
        }

        
        public IQueryable<CityVM> Get()
        {
            IQueryable<CityVM> data = GetAllCities();
            return data;
        }


        public CityVM GetById(int id)
        {
            CityVM data = GetCityByID(id);
            return data;
        }



        // Refactor
        private CityVM GetCityByID(int id)
        {
            return db.City.Where(a => a.Id == id)
                                    .Select(a => new CityVM { Id = a.Id, CityName = a.CityName , CountryId = a.CountryId})
                                    .FirstOrDefault();
        }

        private IQueryable<CityVM> GetAllCities()
        {
            return db.City
                       .Select(a => new CityVM { Id = a.Id, CityName = a.CityName , CountryId = a.CountryId });
        }



    }
}
