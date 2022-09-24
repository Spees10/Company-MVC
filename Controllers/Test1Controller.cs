using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;

namespace WebApplication7.Controllers
{
    public class Test1Controller : Controller
    {

        private readonly IEmployeeRep employee;
        public Test1Controller(IEmployeeRep employee)
        {
            this.employee = employee;

        }

        public IActionResult Index()
        {
            var data = employee.Get();
            return View(data);
        }




        // --------------------- Ajax Call -------------

        [HttpPost]
        public JsonResult Display(string name)
        {
            var data = "Welcome : " + name;
            return Json(data);
        }


    }
}
