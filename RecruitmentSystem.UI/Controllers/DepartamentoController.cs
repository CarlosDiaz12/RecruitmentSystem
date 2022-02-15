using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _repository;
        public DepartamentoController(IDepartamentoRepository repository)
        {
            _repository = repository;
        }
        // GET: DepartamentoController
        public ActionResult Index()
        {
            var filters = new List<FilterModel>();
            var data = _repository.GetAll();
            return View(data);
        }

        // GET: DepartamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
