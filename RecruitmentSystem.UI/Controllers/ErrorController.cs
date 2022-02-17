using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorAlert(string errorMessage)
        {
            return PartialView(errorMessage);
        }

        public IActionResult Unathorized()
        {
            return View();
        }
    }
}
