using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacersDB.NewRepo
{
    public interface IRepository<T> where T : class
    {
        public void AddNew(T newInstance);
        public void DeleteOld(T oldInstance);
        public IQueryable<T> GetAll();
        public abstract T GetById(int id);
        public void UpdateEntity(T newEntity);
    }
}
