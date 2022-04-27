using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacersDB.Data.Models;

namespace RacersDB.NewRepo
{
    public class RaceRepository : IRepository<Race>
    {
        protected IList<Race> races;

        public RaceRepository()
        {
            races = new List<Race>()
            {
                new Race() { Id = 1, Rtrack = 1, RtrackNavigation = null, Ryear = 2010, Serie = "F1", Sumlaps = 51, Sumracers = 24, Winner = null, Winnerid = 1 },
                new Race() { Id = 2, Rtrack = 2, RtrackNavigation = null, Ryear = 2011, Serie = "F2", Sumlaps = 52, Sumracers = 24, Winner = null, Winnerid = 2 },
                new Race() { Id = 3, Rtrack = 3, RtrackNavigation = null, Ryear = 2012, Serie = "F3", Sumlaps = 53, Sumracers = 24, Winner = null, Winnerid = 3 },
            };
        }

        public void AddNew(Race newInstance)
        {
            if (newInstance != null)
                races.Add(newInstance);
        }

        public void DeleteOld(Race oldInstance)
        {
            if (oldInstance != null)
                races.Remove(oldInstance);
        }

        public IQueryable<Race> GetAll()
        {
            return races.AsQueryable();
        }

        public Race GetById(int id)
        {
            return races.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateEntity(Race newRace)
        {
            if (newRace != null)
            {
                Race copy = this.GetById((int)newRace.Id);

                if (copy != null)
                {
                    copy.Winner = newRace.Winner;
                    copy.Winnerid = newRace.Winnerid;
                    copy.Serie = newRace.Serie;
                    copy.Rtrack = newRace.Rtrack;
                    copy.Ryear = newRace.Ryear;
                    copy.Sumlaps = newRace.Sumlaps;
                    copy.Sumracers = newRace.Sumracers;
                    copy.RtrackNavigation = newRace.RtrackNavigation;
                }
            }
        }
    }
}
