using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.BL.Service
{
    public class EmployeeServiceController : Controller
    {

        [Route("/EmployeeService/GetCity")]
        public JsonResult GetCity()
        {
            return Json("");
        }




    }
}
