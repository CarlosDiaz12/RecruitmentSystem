using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Util;
using RecruitmentSystem.Infrastructure.Concrete.Base;
using RecruitmentSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RecruitmentSystem.Domain.Util.FilterModel;

namespace RecruitmentSystem.Infrastructure.Concrete
{
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        private readonly AppDbContext _context; 
        public CandidatoRepository(AppDbContext dbContext) 
            : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Candidato> Filter(string nombre, string[] competenciasIds, string[] puestos, string[] capacitacionesIds)
        {
            try
            {
                var filters = new List<FilterModel>{
                    new FilterModel() { Operation = Op.Contains, PropertyName = nameof(Candidato.Nombre), Value = nombre ?? "" }
                };

                var data = GetAll(filters);
                if (competenciasIds != null && competenciasIds.Length > 0)
                {
                    var competenciasData = _context.Competencias.AsQueryable()
                        .Where(x => competenciasIds.Contains(x.Descripcion))
                        .Select(x => x.CandidatoId.ToString());
                    data = data.Where(x => competenciasData.Contains(x.Id.ToString()));
                }

                // filtrar por nombre puesto
                if (puestos != null && puestos.Length > 0)
                {
                    data = data.Where(x => puestos.Contains(x.PuestoAspira.Nombre));
                }

                // filtrar por capacitaciones
                if (capacitacionesIds != null && capacitacionesIds.Length > 0)
                {
                    var capacitacionesData = _context.Capacitaciones.AsQueryable()
                        .Where(x => capacitacionesIds.Contains(x.Descripcion))
                        .Select(x => x.CandidatoId.ToString());
                    data = data.Where(x => capacitacionesData.Contains(x.Id.ToString()));
                }
                return data.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteCandidatoCedula(string cedula)
        {
            try
            {
                cedula = cedula.Replace('-', ' ').Trim();
                var cedulaExiste = _context.Candidatos.Any(x => x.Cedula == cedula);
                return cedulaExiste;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Candidato GetByIdNoTracking(int Id)
        {
            try
            {
                var data = _context.Candidatos.Find(Id);
                if (data == null)
                {
                    return data;
                }
                _context.Entry(data).State = EntityState.Detached;
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
