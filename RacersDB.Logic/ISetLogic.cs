// <copyright file="ISetLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RacersDB.Data.Models;

    /// <summary>
    /// This interface collect all the methods, which are modifying data in the DB.
    /// </summary>
    public interface ISetLogic
    {
        /// <summary>
        /// Adding new Race to the database.
        /// </summary>
        /// <param name="newRace">This object is going to be added to the database.</param>
        public void AddNewRace(Race newRace);

        /// <summary>
        /// Adding new Racer to the database.
        /// </summary>
        /// <param name="newRacer">This object is going to be added to the database.</param>
        public void AddNewRacer(Racer newRacer);

        /// <summary>
        /// Adding new Racetrack to the database.
        /// </summary>
        /// <param name="newRacetrack">This object is going to be added to the database.</param>
        public void AddNewRacetrack(Racetrack newRacetrack);

        /// <summary>
        /// Deleting old Race from the database.
        /// </summary>
        /// <param name="raceToDel">This object is going to be deleted from the database.</param>
        public void DeleteOldRace(Race raceToDel);

        /// <summary>
        /// Deleting old Racer from the database.
        /// </summary>
        /// <param name="raceToDel">This object is going to be deleted from the database.</param>
        public void DeleteOldRacer(Racer raceToDel);

        /// <summary>
        /// Deleting old Racetrack from the database.
        /// </summary>
        /// <param name="raceToDel">This object is going to be deleted from the database.</param>
        public void DeleteOldRacetrack(Racetrack raceToDel);

        /// <summary>
        /// Updates a chosen Race.
        /// </summary>
        /// <param name="newRace">The updated Race.</param>
        void UpdateRace(Race newRace);

        /// <summary>
        /// Updates a chosen Racer.
        /// </summary>
        /// <param name="newRacer">The updated Racer.</param>
        void UpdateRacer(Racer newRacer);

        /// <summary>
        /// Updates a chosen Racetrack.
        /// </summary>
        /// <param name="newRacetrack">The updated Racetrack.</param>
        void UpdateRacetrack(Racetrack newRacetrack);
    }
}
