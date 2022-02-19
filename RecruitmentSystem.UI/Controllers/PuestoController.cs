using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Enums;
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
        private void FillDropdownLists()
        {
            ViewBag.NivelRiesgo = new SelectList(Enum.GetValues(typeof(NivelRiesgo)));
        }

        // GET: PuestoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PuestoController/Create
        public ActionResult Create()
        {
            FillDropdownLists();
            return View(new Puesto() { Estado = true});
        }

        // POST: PuestoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Puesto _object)
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

        // GET: PuestoController/Edit/5
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

        // POST: PuestoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Puesto _object)
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

        // GET: PuestoController/Delete/5
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

        // POST: PuestoController/Delete/5
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
