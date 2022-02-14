using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.Helper;
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
        [HttpPost]
        public ActionResult GenerateExcelReport()
        {
            try
            {
                var columnNames = new string[] { "Cedula", "Nombre", "FechaIngreso", "Departamento", "Puesto", "SalarioMensual", "Estado" };
                var empleados = _empleadoRepository.GetAll().ToList();

                DataTable dtEmpleados = new DataTable("Empleados");
                var columns = new DataColumn[columnNames.Length];
                foreach (var item in columnNames)
                {
                    dtEmpleados.Columns.Add(new DataColumn(item));
                }

                foreach (var empleado in empleados)
                {
                    dtEmpleados.Rows.Add(
                        empleado.Cedula,
                        empleado.Nombre,
                        empleado.FechaIngreso.ToShortDateString(),
                        empleado.Departamento,
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
                return View("ListaEmpleados", new EmpleadoFilterViewModel());
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
