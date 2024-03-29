﻿using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Domain.Abstract.Base;
using RecruitmentSystem.Domain.Util;
using RecruitmentSystem.Infrastructure.Data;
using RecruitmentSystem.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Concrete.Base
{
    public abstract class Repository<T>: IRepository<T> where T: class
    {
        private readonly DbContext _context;
        private DbSet<T> _dbSet;
        public Repository(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }
        public virtual bool CheckIfExists(int id)
        {
            try
            {
                var data = _dbSet.Find(id);
                if (data == null)
                    return false;

                _context.Entry(data).State = EntityState.Detached;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual T Create(T _object)
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

        public virtual void Delete(int Id)
        {
            try
            {
                var entity = GetById(Id);
                if (entity != null)
                {
                    _context.Entry(entity).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IQueryable<T> GetAll(IList<FilterModel> filters = null)
        {
            try
            {
                if (filters == null || filters.Count == 0) return _dbSet.AsQueryable();
                var deleg = ExpressionBuilderUtil.GetExpression<T>(filters).Compile();
                var filteredCollection = _dbSet.Where(deleg).AsQueryable();
                return filteredCollection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T GetById(int Id)
        {
            try
            {

                return _dbSet.Find(Id); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(T _object)
        {
            try
            {
                _dbSet.Update(_object);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var message = (e.Message.Contains("data may have been modified or deleted", StringComparison.InvariantCultureIgnoreCase)) ? "Entity was not found" : e.Message;
                throw new Exception(message);
            }
        }
    }
}
