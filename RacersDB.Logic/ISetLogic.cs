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
        /// Changes the Winner's ID in a chosen Race.
        /// </summary>
        /// <param name="raceID">The ID of the Race, we would like to modify.</param>
        /// <param name="newWinnerID">The ID of the new Winner.</param>
        void ChangeRaceWinnersID(int raceID, int newWinnerID);

        /// <summary>
        /// Changes the Racer's summary of winnings based on it's ID.
        /// </summary>
        /// <param name="racerID">The ID of the Racer, we would like to modify.</param>
        /// <param name="newSumWin">The new value of the chosen Racers SumWin property.</param>
        void ChangeSumWin(int racerID, int newSumWin);

        /// <summary>
        /// Changes the name of a chosen Racetrack.
        /// </summary>
        /// <param name="racetrackID">The ID of the Racetrack, we would like to modify.</param>
        /// <param name="newName">The new name of the chosen Racetrack.</param>
        void ChangeRacetracksName(int racetrackID, string newName);
    }
}
