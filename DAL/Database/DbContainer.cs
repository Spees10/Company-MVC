using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace WebApplication7.DAL.Database
{
    public class DbContainer : IdentityDbContext // Context
    {
        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts) {}
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = . ; database = SharpDb ; integrated security = true");
        //}

    }
}
