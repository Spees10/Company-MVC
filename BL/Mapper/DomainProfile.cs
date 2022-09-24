using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;

namespace WebApplication7.BL.Mapper
{
    public class DomainProfile : Profile
    {
     
        
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

        }

    }
}
