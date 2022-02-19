using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.ViewModel;
using RecruitmentSystem.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Data;
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

                if(ModelState.IsValid)
                {
                    var data = _empleadoRepository.GetAll();
                    if (viewModel.FechaDesde != null && viewModel.FechaHasta != null)
                    {
                        data = _empleadoRepository.GetEmpleadosByRange(viewModel.FechaDesde.Value, viewModel.FechaHasta.Value);
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
        [HttpPost]
        public ActionResult GenerateExcelReport(DateTime? fechaDesde, DateTime? fechaHasta)
        {
            try
            {
                var empleados = _empleadoRepository.GetAll();
                if(fechaDesde != null && fechaHasta != null 
                    && DateTime.Compare(fechaDesde.Value.Date, fechaHasta.Value.Date) < 0)
                {
                    empleados = _empleadoRepository.GetEmpleadosByRange(fechaDesde.Value, fechaHasta.Value);
                }

                var columnNames = new string[] { "Cedula", "Nombre", "FechaIngreso", "Departamento", "Puesto", "SalarioMensual", "Estado" };
                DataTable dtEmpleados = new DataTable("Empleados");
                var columns = new DataColumn[columnNames.Length];
                foreach (var item in columnNames)
                {
                    dtEmpleados.Columns.Add(new DataColumn(item));
                }

                foreach (var empleado in empleados.ToList())
                {
                    dtEmpleados.Rows.Add(
                        empleado.Cedula,
                        empleado.Nombre,
                        empleado.FechaIngreso.ToShortDateString(),
                        empleado.Departamento.Descripcion,
                        empleado.Puesto.Nombre,
                        empleado.SalarioMensual,
                        empleado.Estado ? "Activo" : "Inactivo"
                        );
                }

                var content = ReportGenerator.GenerateExcel("Empleados", dtEmpleados, columnNames);
                Response.Clear();
                Response.Headers.Clear();
                Response.ContentType = "application/excel";
                Response.Headers.Add("content-disposition", $"attachment;filename=ReporteEmpleados_{DateTime.Now.ToShortDateString()}.xls");
                Response.Headers.Add("content-length", content.File.Length.ToString()); //Here is the additional header which is required for Chrome.
                Response.Body.WriteAsync(content.File);
                Response.Body.Flush();
                Response.Body.Close();
                return null;
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("ListaEmpleados", new EmpleadoFilterViewModel() { FechaDesde = fechaDesde, FechaHasta = fechaHasta });
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
