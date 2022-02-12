using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class PuestoController : Controller
    {
        private readonly IPuestoRepository _repository;
        public PuestoController(IPuestoRepository repository)
        {
            _repository = repository;
        }
        // GET: PuestoController
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: PuestoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PuestoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PuestoController/Create
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

        // GET: PuestoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PuestoController/Edit/5
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

        // GET: PuestoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PuestoController/Delete/5
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
