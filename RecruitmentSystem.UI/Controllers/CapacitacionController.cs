using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class CapacitacionController : Controller
    {
        private readonly ICapacitacionRepository _repository;
        private readonly INivelAcademicoRepository _nivelAcademicoRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        public CapacitacionController(
            ICapacitacionRepository repository, 
            INivelAcademicoRepository nivelAcademicoRepository, 
            ICandidatoRepository candidatoRepository)
        {
            _repository = repository;
            _nivelAcademicoRepository = nivelAcademicoRepository;
            _candidatoRepository = candidatoRepository;
        }

        private void FillDropDownLists()
        {
            ViewBag.NivelId = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
            ViewBag.CandidatoId = new SelectList(_candidatoRepository.GetAll().ToList(), "Id", "Nombre");
        }
        // GET: CapacitacionController
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: CapacitacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CapacitacionController/Create
        public ActionResult Create()
        {
            FillDropDownLists();
            return View();
        }

        // POST: CapacitacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Capacitacion _object)
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
                    FillDropDownLists();
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropDownLists();
                return View();
            }
        }

        // GET: CapacitacionController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                if (data == null)
                    throw new Exception("Registro no encontrado");

                FillDropDownLists();
                return View(data);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropDownLists();
                return View();
            }
        }

        // POST: CapacitacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Capacitacion _object)
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
                    FillDropDownLists();
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropDownLists();
                return View();
            }
        }

        // GET: CapacitacionController/Delete/5
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

        // POST: CapacitacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Capacitacion _object)
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
