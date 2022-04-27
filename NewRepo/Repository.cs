using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacersDB.NewRepo
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        public void AddNew(T newInstance)
        {
            throw new NotImplementedException();
        }

        public void DeleteOld(T oldInstance)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(T newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
