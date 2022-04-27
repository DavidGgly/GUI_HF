// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RacersDB.Data.Models;
    using RacersDB.Logic;
    using RacersDB.Repository;

    /// <summary>
    /// This class is responsible to create and share the class instances.
    /// </summary>
    public class Factory
    {
        private readonly RaceTableContext ctx;
        private readonly RaceRepository raceRepo;
        private readonly RacerRepository racerRepo;
        private readonly RacetrackRepository racetrackRepo;
        private readonly GetLogic getLogic;
        private readonly SetLogic setLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.ctx = new RaceTableContext();
            this.raceRepo = new RaceRepository(this.ctx);
            this.racerRepo = new RacerRepository(this.ctx);
            this.racetrackRepo = new RacetrackRepository(this.ctx);
            this.getLogic = new GetLogic(this.raceRepo, this.racerRepo, this.racetrackRepo);
            this.setLogic = new SetLogic(this.raceRepo, this.racerRepo, this.racetrackRepo);
        }

        /// <summary>
        /// Gets a GetLogic instance, which contains methods, which are reading from the DB.
        /// </summary>
        public GetLogic GetLogic
        {
            get { return this.getLogic; }
        }

        /// <summary>
        /// Gets a SetLogic instance, which contains methods, which are modifying data in DB.
        /// </summary>
        public SetLogic SetLogic
        {
            get { return this.setLogic; }
        }
    }
}
