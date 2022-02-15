
using RecruitmentSystem.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Abstract.Base
{
    public interface IRepository<T> where T: class
    {
        public T Create(T _object);
        public void Update(T _object);
        public IQueryable<T> GetAll(IList<FilterModel> filters = null);
        public void Delete(int Id);
        public T GetById(int Id);
        public bool CheckIfExists(int id);
    }
}
