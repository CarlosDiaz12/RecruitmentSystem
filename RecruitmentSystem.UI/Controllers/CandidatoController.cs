using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.ViewModel;
using RecruitmentSystem.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RecruitmentSystem.Domain.Util.FilterModel;

namespace RecruitmentSystem.UI.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ICandidatoRepository _repository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly IIdiomaRepository _idiomaRepository;
        private readonly INivelAcademicoRepository _nivelAcademicoRepository;
        private readonly ICompetenciaRepository _competenciaRepository;
        private readonly ICapacitacionRepository _capacitacionRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        public CandidatoController(
            ICandidatoRepository repository, 
            IPuestoRepository puestoRepository, 
            IIdiomaRepository idiomaRepository, 
            INivelAcademicoRepository nivelAcademicoRepository,
            ICompetenciaRepository competenciaRepository,
            ICapacitacionRepository capacitacionRepository,
            IDepartamentoRepository departamentoRepository)
        {
            _repository = repository;
            _puestoRepository = puestoRepository;
            _idiomaRepository = idiomaRepository;
            _nivelAcademicoRepository = nivelAcademicoRepository;
            _competenciaRepository = competenciaRepository;
            _capacitacionRepository = capacitacionRepository;
            _departamentoRepository = departamentoRepository;
        }
        private IEnumerable<string> GetCompetenciasDdl()
        {
            return _competenciaRepository.GetAll().Select(x => x.Descripcion).Distinct();
        }

        private IEnumerable<string> GetPuestosDdl()
        {
            return _puestoRepository.GetAll().Select(x => x.Nombre).Distinct();
        }

        private IEnumerable<string> GetCapacitacionesDdl()
        {
            return _capacitacionRepository.GetAll().Select(x => x.Descripcion).Distinct();
        }

        private void FillDropdownLists()
        {
            ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
            ViewBag.Idiomas = new SelectList(_idiomaRepository.GetAll().ToList(), "Id", "Nombre");
            ViewBag.NivelesCapacitacion = new SelectList(_nivelAcademicoRepository.GetAll().ToList(), "Id", "Descripcion");
            ViewBag.DepartamentoId = new SelectList(_departamentoRepository.GetAll().ToList(), "Id", "Descripcion");
        }
        // GET: CandidatoController
        public ActionResult Index(CandidatoFilterViewModel viewModel)
        {
            try
            {
                var data = _repository.GetAll().ToList();

                // filtros
                if (viewModel != null)
                {
                    // filtrar 
                    data = _repository
                        .Filter(viewModel.Nombre, viewModel.Competencias, viewModel.Puestos, viewModel.Capacitaciones)
                        .ToList();
                }

                ViewBag.Puestos = new SelectList(GetPuestosDdl());
                ViewBag.Competencias = new SelectList(GetCompetenciasDdl());
                ViewBag.Capacitaciones = new SelectList(GetCapacitacionesDdl());
                return View(
                    new CandidatoFilterViewModel()
                    {
                        Candidatos = data,
                        Competencias = viewModel.Competencias,
                        Puestos = viewModel.Puestos,
                        Capacitaciones = viewModel.Capacitaciones,
                        Nombre = viewModel.Nombre
                    });
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(new CandidatoFilterViewModel());
            }
        }
        // GET: CandidatoController/Details/5
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

        // GET: CandidatoController/Create
        public ActionResult Create()
        {
            FillDropdownLists();
            return View();
        }

        // POST: CandidatoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidatoViewModel _object)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(_object.Cedula) 
                    && _repository.ExisteCandidatoCedula(_object.Cedula))
                {
                    ModelState.AddModelError("", "La cedula ingresada ya existe");
                }
                if (ModelState.IsValid)
                {
                    // mapear datos
                    _object.Cedula = _object.Cedula.Replace('-', ' ');
                    var newCandidato = new Candidato()
                    {
                        Nombre = _object.Nombre,
                        Cedula = _object.Cedula,
                        DepartamentoPerteneceId = _object.DepartamentoId,
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
                    DepartamentoId = _object.DepartamentoPerteneceId,
                    PuestoAspiraId = _object.PuestoAspiraId,
                    SalarioAspira = _object.SalarioAspira,
                    RecomendadoPor = _object.RecomendadoPor,
                    ExperienciasLaborales = _object.ExperienciasLaborales.ToList(),
                    Competencias = _object.PrincipalesCompetencias.ToList(),
                    Idiomas = _object.Idiomas.Select(m => m.IdiomaId.ToString()).ToArray(),
                    Capacitaciones = _object.PrincipalesCapacitaciones.ToList() 
                };

                FillDropdownLists();
                return View(viewModelData);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropdownLists();
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
                if (!string.IsNullOrWhiteSpace(_object.Cedula)
                    && _repository.ExisteCandidatoCedula(_object.Cedula))
                {
                    ModelState.AddModelError("", "La cedula ingresada ya existe");
                }
                if (ModelState.IsValid)
                {
                    var data = _repository.GetByIdNoTracking(id);
                    if (data == null)
                        throw new Exception("Registro no encontrado");
                    // mapear idiomas 
                    var selectedIdiomas = _idiomaRepository
                        .GetAll()
                        .Where(x => _object.Idiomas.Contains(x.Id.ToString()))
                        .ToList()
                        .Select(x => new CandidatoIdioma { 
                            CandidatoId = _object.Id,
                            IdiomaId = x.Id
                        });

                    data.Idiomas = selectedIdiomas.ToList();
                    // mapear datos
                    _object.Cedula = _object.Cedula.Replace('-', ' ');
                    var candidatoUpdated = new Candidato()
                    {
                        Id = _object.Id,
                        Nombre = _object.Nombre,
                        Cedula = _object.Cedula,
                        DepartamentoPerteneceId = _object.DepartamentoId,
                        PuestoAspiraId = _object.PuestoAspiraId,
                        SalarioAspira = _object.SalarioAspira,
                        RecomendadoPor = _object.RecomendadoPor,
                        ExperienciasLaborales = _object.ExperienciasLaborales,
                        PrincipalesCompetencias = _object.Competencias,
                        PrincipalesCapacitaciones = _object.Capacitaciones,
                        Idiomas = data.Idiomas,
                    };
                    _repository.Update(candidatoUpdated);
                }
                else
                {
                    FillDropdownLists();
                    return View(_object);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                FillDropdownLists();
                return View(_object);
            }
        }

        // GET: CandidatoController/Delete/5
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

        // POST: CandidatoController/Delete/5
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
