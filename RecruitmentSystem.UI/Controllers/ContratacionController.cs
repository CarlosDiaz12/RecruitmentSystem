using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Controllers
{
    public class ContratacionController : Controller
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IPuestoRepository _puestoRepository;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IDepartamentoRepository _departamentoRepository;
        public ContratacionController(
            IEmpleadoRepository repository, 
            IPuestoRepository puestoRepository,
            ICandidatoRepository candidatoRepository,
            IDepartamentoRepository departamentoRepository)
        {
            _repository = repository;
            _puestoRepository = puestoRepository;
            _candidatoRepository = candidatoRepository;
            _departamentoRepository = departamentoRepository;
        }
        // GET: ContratacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContratacionController/Details/5
        public ActionResult IniciarContratacion(int id)
        {
            try
            {
                var data = _candidatoRepository.GetById(id);
                if (data == null)
                    throw new Exception("Registro no encontrado");

                var dataEmpleado = new ContratacionViewModel()
                {
                    Cedula = data.Cedula,
                    Nombre = data.Nombre,
                    FechaIngreso = DateTime.Now,
                    Departamento = data.DepartamentoPertenece,
                    Puesto = data.PuestoAspira,
                    SalarioMensual = data.SalarioAspira,
                    IdCandidato = id,
                    Estado = true
                };

                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.DepartamentoId = new SelectList(_departamentoRepository.GetAll().ToList(), "Id", "Descripcion");
                return View(dataEmpleado);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                ViewBag.DepartamentoId = new SelectList(_departamentoRepository.GetAll().ToList(), "Id", "Descripcion");
                return View();
            }
        }
        [HttpPost]
        public ActionResult IniciarContratacion(ContratacionViewModel _object)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevoEmpleado = new Empleado()
                    {
                        Cedula = _object.Cedula,
                        Nombre = _object.Nombre,
                        FechaIngreso = _object.FechaIngreso,
                        Departamento = _object.Departamento,
                        PuestoId = _object.PuestoId,
                        SalarioMensual = _object.SalarioMensual,
                        Estado = _object.Estado
                    };
                    _repository.Create(nuevoEmpleado);
                    _candidatoRepository.Delete(_object.IdCandidato);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                ViewBag.PuestoAspiraId = new SelectList(_puestoRepository.GetAll().ToList(), "Id", "Nombre");
                return View();
            }
        }

    }
}
