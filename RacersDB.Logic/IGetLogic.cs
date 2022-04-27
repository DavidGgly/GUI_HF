// <copyright file="IGetLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RacersDB.Data.Models;

    /// <summary>
    /// This interface collect all the methods, which are just reading data from the DB.
    /// </summary>
    public interface IGetLogic
    {
        /// <summary>
        /// Searches in the DB for that Race instance, which id equals with parameter.
        /// </summary>
        /// <param name="id">The ID, which method is searching for.</param>
        /// <returns>A Race instance, which ID equals with parameter.</returns>
        Race GetOneRace(int id);

        /// <summary>
        /// Puts all Races in an IList.
        /// </summary>
        /// <returns>Returns an IList, which contains all Races in the DB.</returns>
        IList<Race> GetAllRaces();

        /// <summary>
        /// Searches in the DB for that Racer instance, which ID equals with parameter.
        /// </summary>
        /// <param name="id">The ID, which method is searching for.</param>
        /// <returns>A Racer instance, which ID equals with parameter.</returns>
        Racer GetOneRacer(int id);

        /// <summary>
        /// Puts all Racers in an IList.
        /// </summary>
        /// <returns>Returns an IList, which contains all Racers in the DB.</returns>
        IList<Racer> GetAllRacers();

        /// <summary>
        /// Searches in the DB for that Racetrack instance, which id equals with parameter.
        /// </summary>
        /// <param name="id">The ID, which method is searching for.</param>
        /// <returns>A Racetrack instance, which ID equals with parameter.</returns>
        Racetrack GetOneRacetrack(int id);

        /// <summary>
        /// Puts all Racetracks in an IList.
        /// </summary>
        /// <returns>Returns an IList, which contains all Racetracks in the DB.</returns>
        IList<Racetrack> GetAllRacetracks();

        /// <summary>
        /// This method collects all data of all Racetracks and sorts descending
        /// based on the amount of Races organized on each Racetracks.
        /// </summary>
        /// <returns>An IList filled with these Racetracks.</returns>
        IList<RacetrackQuery> GetRacetrackQuery();

        /// <summary>
        /// This method is the ASync version of GetRacetrackQuery method.
        /// </summary>
        /// <returns>The same IList, as GetRacetrackQuery, but packed in a task.</returns>
        Task<IList<RacetrackQuery>> GetRacetrackQueryASync();

        /// <summary>
        /// This method returns all data of the Racers, who was born the same year as a Racetrack was built.
        /// This list is ordered by the name of Racetracks.
        /// </summary>
        /// <returns>An IList filled with these Racers.</returns>
        IList<RacerQuery> GetRacerQuery();

        /// <summary>
        /// This method is the ASync version of GetRacerQuery method.
        /// </summary>
        /// <returns>The same IList, as GetRacerQuery, but packed in a task.</returns>
        Task<IList<RacerQuery>> GetRacerQueryASync();

        /// <summary>
        /// This method returns some data about the Races, where the venue of the Race and the winner's
        /// nationality equals.
        /// </summary>
        /// <returns>An IList filled with these Races.</returns>
        IList<RaceQuery> GetRaceQuery();

        /// <summary>
        /// This method is the ASync version of GetRaceQuery method.
        /// </summary>
        /// <returns>The same IList, as GetRaceQuery, but packed in a task.</returns>
        Task<IList<RaceQuery>> GetRaceQueryASync();
    }
}
