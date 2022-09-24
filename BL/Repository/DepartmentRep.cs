using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;

namespace WebApplication7.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public DepartmentRep(DbContainer db , IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;
        }


        public DepartmentVM GetById(int id)
        {
            DepartmentVM data = GetDepartmentByID(id);
            return data;
        }


        public void Add(DepartmentVM dpt)
        {
            // Mapping
            var data = mapper.Map<Department>(dpt);

            db.Department.Add(data);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        {
            // Mapping
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Department.Find(id);
            db.Department.Remove(DeletedObject);
            db.SaveChanges();
        }



        // Refactor
        private DepartmentVM GetDepartmentByID(int id)
        {
            return db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
        }

        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Department
                       .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

    }

   
}
