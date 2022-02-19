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
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        public EmpleadoController(
            IEmpleadoRepository repository, 
            IPuestoRepository puestoRepository,
            IDepartamentoRepository departamentoRepository)
        {
            _puestoRepository = puestoRepository;
            _repository = repository;
            _departamentoRepository = departamentoRepository;
        }

        private void FillDropdownLists()
        {
            ViewBag.PuestoId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
            ViewBag.DepartamentoId = new SelectList(_departamentoRepository.GetAll().ToList(), "Id", "Descripcion");
        }
        // GET: EmpleadoController
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
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

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
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

        // GET: EmpleadoController/Edit/5
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

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Empleado _object)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(_object.Cedula)
                    && _repository.ExisteEmpleadoCedula(_object.Cedula))
                {
                    ModelState.AddModelError("", "La cedula ingresada ya existe");
                }

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

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoController/Delete/5
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
