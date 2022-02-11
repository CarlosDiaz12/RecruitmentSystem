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
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        public Repository(AppDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }
        public bool CheckIfExists(int id)
        {
            try
            {
                return _dbSet.Find(id) != null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Create(T _object)
        {
            try
            {
                var entity = _dbSet.Add(_object);
                _context.SaveChanges();
                return entity.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var entity = GetById(Id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _dbSet.AsNoTracking();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(int Id)
        {
            try
            {
                return _dbSet.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T _object)
        {
            try
            {
                var entity = _dbSet.Update(_object);
                _context.SaveChanges();
                return entity.Entity;
            }
            catch (Exception e)
            {
                var message = (e.Message.Contains("data may have been modified or deleted", StringComparison.InvariantCultureIgnoreCase)) ? "Entity was not found" : e.Message;
                throw new Exception(message);
            }
        }
    }
}
