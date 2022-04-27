using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacersDB.Data.Models;

namespace RacersDB.NewRepo
{
    public class RacerRepository : IRepository<Racer>
    {
        protected IList<Racer> racers;

        public RacerRepository()
        {
            racers = new List<Racer>()
            {
                new Racer() { Id = 1, Rname = "Pilot One", Age = 21, Nationality = "Albanian", Rserie = "F1", Sumwin = 11 },
                new Racer() { Id = 2, Rname = "Pilot Two", Age = 22, Nationality = "Belgian", Rserie = "F2", Sumwin = 22 },
                new Racer() { Id = 3, Rname = "Pilot Three", Age = 23, Nationality = "Croatian", Rserie = "F3", Sumwin = 33 },
            };
        }

        public void AddNew(Racer newInstance)
        {
            if (newInstance != null)
                racers.Add(newInstance);
        }

        public void DeleteOld(Racer oldInstance)
        {
            if (oldInstance != null)
                racers.Remove(oldInstance);
        }

        public IQueryable<Racer> GetAll()
        {
            return racers.AsQueryable();
        }

        public Racer GetById(int id)
        {
            return racers.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateEntity(Racer newRacer)
        {
            if (newRacer != null)
            {
                Racer copy = GetById((int)newRacer.Id);

                if (copy != null)
                {
                    copy.Age = newRacer.Age;
                    copy.Races.Clear();
                    newRacer.Races.ToList().ForEach(item => copy.Races.Add(item));
                    copy.Rserie = newRacer.Rserie;
                    copy.Sumwin = newRacer.Sumwin;
                    copy.Nationality = newRacer.Nationality;
                    copy.Rname = newRacer.Rname;
                }
            }
        }
    }
}
