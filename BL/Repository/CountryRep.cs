using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.Models;

namespace WebApplication7.BL.Repository
{
    public class CountryRep : ICountryRep
    {

        private readonly DbContainer db;


        public CountryRep(DbContainer db)
        {
            this.db = db;
        }

        public IQueryable<CountryVM> Get()
        {
            IQueryable<CountryVM> data = GetAllCountries();
            return data;
        }


        public CountryVM GetById(int id)
        {
            CountryVM data = GetCountryByID(id);
            return data;
        }



        // Refactor
        private CountryVM GetCountryByID(int id)
        {
            return db.Country.Where(a => a.Id == id)
                                    .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName})
                                    .FirstOrDefault();
        }

        private IQueryable<CountryVM> GetAllCountries()
        {
            return db.Country
                       .Select(a => new CountryVM { Id = a.Id, CountryName = a.CountryName });
        }

    }
}
