using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoRepository _repository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly IIdiomaRepository _idiomaRepository;
        public CandidatoController(ICandidatoRepository repository, IPuestoRepository puestoRepository, IIdiomaRepository idiomaRepository)
        {
            _repository = repository;
            _puestoRepository = puestoRepository;
            _idiomaRepository = idiomaRepository;
        }
        // GET: CandidatoController
        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        // GET: CandidatoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CandidatoController/Create
        public ActionResult Create()
        {
            ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
            ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
            return View();
        }

        // POST: CandidatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidatoViewModel _object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCandidato = new Candidato()
                    {
                        Nombre = _object.Nombre,
                        Cedula = _object.Cedula,
                        Departamento = _object.Departamento,
                        PuestoAspiraId = _object.PuestoAspiraId,
                        SalarioAspira = _object.SalarioAspira,
                        RecomendadoPor = _object.RecomendadoPor,
                        ExperienciasLaborales = _object.ExperienciasLaborales,
                        PrincipalesCompetencias = _object.Competencias,
                    };

                    foreach (var item in _object.Idiomas)
                    {
                        newCandidato.Idiomas.Add(new CandidatoIdioma()
                        {
                            IdiomaId = int.Parse(item)
                        });
                    }
                    _repository.Create(newCandidato);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                return View();
            }
        }

        // GET: CandidatoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidatoController/Edit/5
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

        // GET: CandidatoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidatoController/Delete/5
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
