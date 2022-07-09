using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Parkgin.Server.Api.Controllers
{
    public class MVCDevelopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}