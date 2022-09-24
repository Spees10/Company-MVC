using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;


namespace WebApplication7.BL.Interface
{
    public interface ICityRep
    {
        IQueryable<CityVM> Get();
        CityVM GetById(int id);
    }
}
