using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Domain.Abstract.Base;
using RecruitmentSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Concrete.Base
{
    public abstract class Repository<T>: IRepository<T> where T: class
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
    }
}
