using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Infrastructure.Concrete.Base;
using RecruitmentSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Concrete
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        private readonly AppDbContext _dbContext;
        public EmpleadoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ExisteEmpleadoCedula(string cedula)
        {
            try
            {
                cedula = cedula.Replace('-', ' ').Trim();
                var cedulaExiste = _dbContext.Empleados.Any(x => x.Cedula == cedula);
                return cedulaExiste;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IQueryable<Empleado> GetEmpleadosByRange(DateTime start, DateTime end)
        {
            try
            {
                return _dbContext.Empleados.Where(x => DateTime.Compare(x.FechaIngreso, start.Date) >= 0
                        && DateTime.Compare(x.FechaIngreso, end.Date) <= 0);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
