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
        private void FillDropdownLists()
        {
            ViewBag.CandidatoId = new SelectList(_candidatoRepository.GetAll().ToList(), "Id", "Nombre");
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
            FillDropdownLists();
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
                    FillDropdownLists();
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropdownLists();
                return View();
            }
        }

        // GET: ExperienciaLaboralController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                    throw new Exception("Registro no encontrado");

                FillDropdownLists();
                return View(data);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropdownLists();
                return View();
            }
        }

        // POST: ExperienciaLaboralController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExperienciaLaboral _object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_repository.CheckIfExists(id))
                        throw new Exception("Registro no encontrado");
                    _repository.Update(_object);
                }
                else
                {
                    FillDropdownLists();
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropdownLists();
                return View();
            }
        }

        // GET: ExperienciaLaboralController/Delete/5
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

        // POST: ExperienciaLaboralController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ExperienciaLaboral _object)
        {
            try
            {
                if (!_repository.CheckIfExists(id))
                    throw new Exception("Registro no encontrado");
                _repository.Delete(id);
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
