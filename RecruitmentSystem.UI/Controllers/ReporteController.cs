using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IEmpleadoRepository _empleadoRepository;
        public ReporteController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }
        // GET: ReporteController
        public ActionResult ListaEmpleados(EmpleadoFilterViewModel viewModel)
        {
            try
            {
                if((viewModel.FechaDesde == null && viewModel.FechaHasta != null) 
                    || (viewModel.FechaHasta == null && viewModel.FechaDesde != null))
                {
                    ModelState.AddModelError("", "Rango De Fechas Incorrecto");
                }

                if(ModelState.ErrorCount == 0)
                {
                    if((viewModel.FechaDesde != null && viewModel.FechaHasta != null) 
                        && DateTime.Compare(viewModel.FechaDesde.Value.Date, viewModel.FechaHasta.Value.Date) > 0)
                    {
                        ModelState.AddModelError("", "Rango De Fechas Incorrecto");
                    }
                }
                var filters = new List<FilterModel>
                {
                    //new FilterModel() { Operation = FilterModel.Op.GreaterThanOrEqual, PropertyName = "FechaIngreso", Value = viewModel.FechaDesde },
                    //new FilterModel() { Operation = FilterModel.Op.LessThanOrEqual, PropertyName = "FechaIngreso", Value = viewModel.FechaHasta }
                };

                if(ModelState.IsValid)
                {
                    var data = _empleadoRepository.GetAll();
                    if (viewModel.FechaDesde != null && viewModel.FechaHasta != null)
                    {
                        data = data.
                            Where(x => DateTime.Compare(x.FechaIngreso, viewModel.FechaDesde.Value.Date) >= 0 
                            && DateTime.Compare(x.FechaIngreso, viewModel.FechaHasta.Value.Date) <= 0);
                    }
                    viewModel.Empleados = data.ToList();
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                viewModel.Empleados ??= new List<Empleado>();
                return View(viewModel);
            }
        }

        // GET: ReporteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReporteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteController/Create
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

        // GET: ReporteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReporteController/Edit/5
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

        // GET: ReporteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReporteController/Delete/5
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
