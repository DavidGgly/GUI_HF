// <copyright file="SetLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RacersDB.Data.Models;
    using RacersDB.NewRepo;

    /// <summary>
    /// This class implements ISetLogic interface.
    /// </summary>
    public class SetLogic : ISetLogic
    {
        private readonly IRepository<Race> raceRepo;
        private readonly IRepository<Racer> racerRepo;
        private readonly IRepository<Racetrack> racetrackRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetLogic"/> class.
        /// </summary>
        /// <param name="raceRepo">Interface raceRepo typed parameter because of dependency injection.</param>
        /// <param name="racerRepo">Interface racerRepo typed parameter because of dependency injection.</param>
        /// <param name="racetrackRepo">Interface racetrackRepo typed parameter because of dependency injection.</param>
        public SetLogic(IRepository<Race> raceRepo, IRepository<Racer> racerRepo, IRepository<Racetrack> racetrackRepo)
        {
            this.raceRepo = raceRepo;
            this.racerRepo = racerRepo;
            this.racetrackRepo = racetrackRepo;
        }

        /// <inheritdoc/>
        public void AddNewRace(Race newRace)
        {
            this.raceRepo.AddNew(newRace);
        }

        /// <inheritdoc/>
        public void AddNewRacer(Racer newRacer)
        {
            this.racerRepo.AddNew(newRacer);
        }

        /// <inheritdoc/>
        public void AddNewRacetrack(Racetrack newRacetrack)
        {
            this.racetrackRepo.AddNew(newRacetrack);
        }

        /// <inheritdoc/>
        public void DeleteOldRace(Race raceToDel)
        {
            this.raceRepo.DeleteOld(raceToDel);
        }

        /// <inheritdoc/>
        public void DeleteOldRacer(Racer raceToDel)
        {
            this.racerRepo.DeleteOld(raceToDel);
        }

        /// <inheritdoc/>
        public void DeleteOldRacetrack(Racetrack raceToDel)
        {
            this.racetrackRepo.DeleteOld(raceToDel);
        }

        /// <inheritdoc/>
        public void UpdateRace(Race newRace)
        {
            this.raceRepo.UpdateEntity(newRace);
        }

        /// <inheritdoc/>
        public void UpdateRacer(Racer newRacer)
        {
            this.racerRepo.UpdateEntity(newRacer);
        }

        /// <inheritdoc/>
        public void UpdateRacetrack(Racetrack newRacetrack)
        {
            this.racetrackRepo.UpdateEntity(newRacetrack);
        }
    }
}
