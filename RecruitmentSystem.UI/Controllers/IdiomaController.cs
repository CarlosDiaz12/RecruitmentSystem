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
    public class IdiomaController : Controller
    {
        private readonly IIdiomaRepository _repository;
        public IdiomaController(IIdiomaRepository repository)
        {
            _repository = repository;
        }
        // GET: IdiomaController
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: IdiomaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IdiomaController/Create
        public ActionResult Create()
        {
            return View(new Idioma() { Estado = true });
        }

        // POST: IdiomaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Idioma _object)
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
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: IdiomaController/Edit/5
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

        // POST: IdiomaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Idioma _object)
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

        // GET: IdiomaController/Delete/5
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

        // POST: IdiomaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Idioma _object)
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
