using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class ExperienciaLaboralController : Controller
    {
        private readonly IExperienciaLaboralRepository _repository;
        private readonly ICandidatoRepository _candidatoRepository;
        public ExperienciaLaboralController(IExperienciaLaboralRepository repository, ICandidatoRepository candidatoRepository)
        {
            _repository = repository;
            _candidatoRepository = candidatoRepository;
        }
        // GET: ExperienciaLaboralController
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: ExperienciaLaboralController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExperienciaLaboralController/Create
        public ActionResult Create()
        {
            ViewBag.CandidatoId = new SelectList(_candidatoRepository.GetAll().ToList(), "Id", "Nombre");
            return View();
        }

        // POST: ExperienciaLaboralController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExperienciaLaboral _object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Create(_object);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.CandidatoId = new SelectList(_candidatoRepository.GetAll().ToList(), "Id", "Nombre");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.CandidatoId = new SelectList(_candidatoRepository.GetAll().ToList(), "Id", "Nombre");
                return View();
            }
        }

        // GET: ExperienciaLaboralController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExperienciaLaboralController/Edit/5
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

        // GET: ExperienciaLaboralController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExperienciaLaboralController/Delete/5
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
