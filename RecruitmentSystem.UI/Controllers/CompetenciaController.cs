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
    public class CompetenciaController : Controller
    {
        private readonly ICompetenciaRepository _repository;
        private readonly ICandidatoRepository _candidatoRepository;
        public CompetenciaController(ICompetenciaRepository repository, ICandidatoRepository candidatoRepository)
        {
            _repository = repository;
            _candidatoRepository = candidatoRepository;
        }

        private void FillDropdownLists()
        {
            ViewBag.CandidatoId = new SelectList(_candidatoRepository.GetAll().ToList(), "Id", "Nombre");
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
            FillDropdownLists();
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

        // GET: Competencia/Edit/5
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

        // POST: Competencia/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Competencia _object)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (!_repository.CheckIfExists(id))
                        throw new Exception("Registro no encontrado");
                    _repository.Update(_object);
                } else
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
