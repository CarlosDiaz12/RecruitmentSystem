using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecruitmentSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompetenciaRepository _competenciaRepository;
        public HomeController(ICompetenciaRepository competenciaRepository)
        {
            _competenciaRepository = competenciaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
