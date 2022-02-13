﻿using Microsoft.AspNetCore.Http;
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
        private readonly INivelAcademicoRepository _nivelAcademicoRepository;
        public CandidatoController(
            ICandidatoRepository repository, 
            IPuestoRepository puestoRepository, 
            IIdiomaRepository idiomaRepository, 
            INivelAcademicoRepository nivelAcademicoRepository)
        {
            _repository = repository;
            _puestoRepository = puestoRepository;
            _idiomaRepository = idiomaRepository;
            _nivelAcademicoRepository = nivelAcademicoRepository;
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
            ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
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
                    // mapear datos
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
                        PrincipalesCapacitaciones = _object.Capacitaciones,
                        Idiomas = _object.Idiomas.Select(x => new CandidatoIdioma { IdiomaId = int.Parse(x) }).ToList()
                    };

                    _repository.Create(newCandidato);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
                return View();
            }
        }

        // GET: CandidatoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var _object = _repository.GetById(id);
                if (_object == null)
                    throw new Exception("Registro no encontrado");
                // mapear datos
                var viewModelData = new CandidatoViewModel()
                {
                    Id = _object.Id,
                    Nombre = _object.Nombre,
                    Cedula = _object.Cedula,
                    Departamento = _object.Departamento,
                    PuestoAspiraId = _object.PuestoAspiraId,
                    SalarioAspira = _object.SalarioAspira,
                    RecomendadoPor = _object.RecomendadoPor,
                    ExperienciasLaborales = _object.ExperienciasLaborales.ToList(),
                    Competencias = _object.PrincipalesCompetencias.ToList(),
                    Idiomas = _object.Idiomas.Select(m => m.IdiomaId.ToString()).ToArray(),
                    Capacitaciones = _object.PrincipalesCapacitaciones.ToList()
                    
                };

                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
                return View(viewModelData);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
                return View();
            }
        }

        // POST: CandidatoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CandidatoViewModel _object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_repository.CheckIfExists(id))
                        throw new Exception("Registro no encontrado");

                    // mapear datos
                    var candidatoUpdated = new Candidato()
                    {
                        Nombre = _object.Nombre,
                        Cedula = _object.Cedula,
                        Departamento = _object.Departamento,
                        PuestoAspiraId = _object.PuestoAspiraId,
                        SalarioAspira = _object.SalarioAspira,
                        RecomendadoPor = _object.RecomendadoPor,
                        ExperienciasLaborales = _object.ExperienciasLaborales,
                        PrincipalesCompetencias = _object.Competencias,
                        PrincipalesCapacitaciones = _object.Capacitaciones,
                        Idiomas = _object.Idiomas.Select(x => new CandidatoIdioma { IdiomaId = int.Parse(x) }).ToList()
                    };
                    _repository.Update(candidatoUpdated);
                }
                else
                {
                    ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                    ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
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
