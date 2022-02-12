using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class CompetenciaController : Controller
    {
        private readonly ICompetenciaRepository _repository;
        public CompetenciaController(ICompetenciaRepository repository)
        {
            _repository = repository;
        }
        // GET: Competencia
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: Competencia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Competencia/Create
        public ActionResult Create()
        {
            return View(new Competencia() { Estado = true});
        }

        // POST: Competencia/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competencia _object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Create(_object);
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: Competencia/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                    throw new Exception("Registro no encontrado");
                
                return View(data);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // POST: Competencia/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Competencia _object)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = _repository.GetById(id);
                    if (data == null)
                        throw new Exception("Registro no encontrado");
                    _repository.Update(_object);
                } else
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: Competencia/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                    throw new Exception("Registro no encontrado");

                return View(data);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // POST: Competencia/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                    throw new Exception("Registro no encontrado");
                _repository.Delete(data.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }
    }
}
