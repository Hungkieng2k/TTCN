using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TourCore.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}