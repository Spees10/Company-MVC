using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.BL.Interface
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetById(int id);
        void Add(EmployeeVM emp);
        void Edit(EmployeeVM emp);
        void Delete(int id);
    }
}
