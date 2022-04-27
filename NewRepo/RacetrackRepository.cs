using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacersDB.Data.Models;

namespace RacersDB.NewRepo
{
    public class RacetrackRepository : IRepository<Racetrack>
    {
        protected IList<Racetrack> racetracks;

        public RacetrackRepository()
        {
            racetracks = new List<Racetrack>()
            {
                new Racetrack() { Id = 1, Trackname = "Track A", Builtyear = 1991, Tlength = 5311, Tvenue = "Algheria", Isf1 = "1" },
                new Racetrack() { Id = 2, Trackname = "Track B", Builtyear = 2002, Tlength = 5322, Tvenue = "Belarus", Isf1 = "0" },
                new Racetrack() { Id = 3, Trackname = "Track C", Builtyear = 2013, Tlength = 5233, Tvenue = "Canada", Isf1 = "0" },
            };
        }

        public void AddNew(Racetrack newInstance)
        {
            if (newInstance != null)
                racetracks.Add(newInstance);
        }

        public void DeleteOld(Racetrack oldInstance)
        {
            if (oldInstance != null)
                racetracks.Remove(oldInstance);
        }

        public IQueryable<Racetrack> GetAll()
        {
            return racetracks.AsQueryable();
        }

        public Racetrack GetById(int id)
        {
            return racetracks.SingleOrDefault(x => x.Id == id);
        }

        public void UpdateEntity(Racetrack newRacetrack)
        {
            if (newRacetrack != null)
            {
                Racetrack copy = GetById((int)newRacetrack.Id);

                if (copy != null)
                {
                    copy.Trackname = newRacetrack.Trackname;
                    copy.Builtyear = newRacetrack.Builtyear;
                    copy.Races.Clear();
                    newRacetrack.Races.ToList().ForEach(item => copy.Races.Add(item));
                    copy.Tvenue = newRacetrack.Tvenue;
                    copy.Isf1 = newRacetrack.Isf1;
                    copy.Tlength = newRacetrack.Tlength;
                }
            }
        }
    }
}
