// <copyright file="GetLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RacersDB.Data.Models;
    using RacersDB.Repository;

    /// <summary>
    /// This class implements IGetLogic interface.
    /// </summary>
    public class GetLogic : IGetLogic
    {
        private readonly IRaceRepository raceRepo;
        private readonly IRacerRepository racerRepo;
        private readonly IRacetrackRepository racetrackRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLogic"/> class.
        /// </summary>
        /// <param name="raceRepo">Interface raceRepo typed parameter because of dependency injection.</param>
        /// <param name="racerRepo">Interface racerRepo typed parameter because of dependency injection.</param>
        /// <param name="racetrackRepo">Interface racetrackRepo typed parameter because of dependency injection.</param>
        public GetLogic(IRaceRepository raceRepo, IRacerRepository racerRepo, IRacetrackRepository racetrackRepo)
        {
            this.raceRepo = raceRepo;
            this.racerRepo = racerRepo;
            this.racetrackRepo = racetrackRepo;
        }

        /// <inheritdoc/>
        public IList<Racer> GetAllRacers()
        {
            return this.racerRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public IList<Race> GetAllRaces()
        {
            return this.raceRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public IList<Racetrack> GetAllRacetracks()
        {
            return this.racetrackRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Race GetOneRace(int id)
        {
            return this.raceRepo.GetById(id);
        }

        /// <inheritdoc/>
        public Racer GetOneRacer(int id)
        {
            return this.racerRepo.GetById(id);
        }

        /// <inheritdoc/>
        public Racetrack GetOneRacetrack(int id)
        {
            return this.racetrackRepo.GetById(id);
        }

        /// <inheritdoc/>
        public IList<RaceQuery> GetRaceQuery()
        {
            var queryHelp = from racetrack in this.racetrackRepo.GetAll()
                         join racer in this.racerRepo.GetAll() on racetrack.Tvenue equals racer.Nationality
                         select new
                         {
                             RacetrackID = racetrack.Id,
                             RacetrackName = racetrack.Trackname,
                             RacerID = racer.Id,
                             RacerName = racer.Rname,
                             RacerAge = racer.Age,
                             Country = racer.Nationality,
                         };

            var query = from race in this.raceRepo.GetAll()
                        join countries in queryHelp
                        on new { TrackID = race.Rtrack, WinnerID = race.Winnerid }
                        equals new { TrackID = countries.RacetrackID, WinnerID = countries.RacerID }
                        orderby countries.Country
                        select new RaceQuery()
                        {
                            Country = countries.Country,
                            RacerName = countries.RacerName,
                            RacerAgeThen = countries.RacerAge - (DateTime.Today.Year - race.Ryear),
                            RacetrackName = countries.RacetrackName,
                            RaceID = race.Id,
                            RaceYear = race.Ryear,
                        };

            return query.ToList();
        }

        /// <inheritdoc/>
        public Task<IList<RaceQuery>> GetRaceQueryASync()
        {
            return Task.Run(() => this.GetRaceQuery());
        }

        /// <inheritdoc/>
        public IList<RacerQuery> GetRacerQuery()
        {
            var query = from racer in this.racerRepo.GetAll()
                        join racetrack in this.racetrackRepo.GetAll()
                        on DateTime.Today.Year - (int)racer.Age equals racetrack.Builtyear
                        orderby racetrack.Trackname
                        select new RacerQuery()
                        {
                            RacerName = racer.Rname,
                            RacerAge = racer.Age,
                            RacerNationality = racer.Nationality,
                            RacetrackName = racetrack.Trackname,
                            RacetrackBuiltYear = racetrack.Builtyear,
                        };

            return query.ToList();
        }

        /// <inheritdoc/>
        public Task<IList<RacerQuery>> GetRacerQueryASync()
        {
            return Task.Run(() => this.GetRacerQuery());
        }

        /// <inheritdoc/>
        public IList<RacetrackQuery> GetRacetrackQuery()
        {
            var queryHelp = from race in this.raceRepo.GetAll()
                            group race by race.Rtrack into grp
                            select new
                            {
                                TrackID = grp.Key,
                                TrackCount = grp.Count(),
                            };

            var query = from rt in this.racetrackRepo.GetAll()
                        join race in queryHelp on rt.Id equals race.TrackID into grj
                        from subRace in grj
                        orderby subRace.TrackCount descending
                        select new RacetrackQuery()
                        {
                            TrackName = rt.Trackname,
                            SumRaces = subRace.TrackCount,
                            BuiltYear = rt.Builtyear,
                            TrackLength = rt.Tlength,
                            TrackVenue = rt.Tvenue,
                            IsFormula = rt.Isf1,
                        };

            return query.ToList();
        }

        /// <inheritdoc/>
        public Task<IList<RacetrackQuery>> GetRacetrackQueryASync()
        {
            return Task.Run(() => this.GetRacetrackQuery());
        }
    }
}
