using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Util;
using RecruitmentSystem.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RecruitmentSystem.Domain.Util.FilterModel;

namespace RecruitmentSystem.UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoRepository _repository;
        public DepartamentoController(IDepartamentoRepository repository)
        {
            _repository = repository;
        }
        // GET: DepartamentoController
        public ActionResult Index(DepartamentoFilterModel viewModel)
        {
            var filters = new List<FilterModel>();
            try
            {
                if(viewModel != null && !string.IsNullOrWhiteSpace(viewModel.Descripcion))
                {
                    filters.Add(new FilterModel() { 
                            Operation = Op.Contains, 
                            PropertyName = nameof(Departamento.Descripcion), 
                            Value = viewModel.Descripcion });
                }
                viewModel.Departamentos = _repository.GetAll(filters);
                return View(viewModel);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(new DepartamentoFilterModel() { Descripcion = viewModel.Descripcion});
            }
        }

        // GET: DepartamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoController/Create
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

        // GET: DepartamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Edit/5
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

        // GET: DepartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartamentoController/Delete/5
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
