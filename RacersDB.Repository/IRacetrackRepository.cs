// <copyright file="IRacetrackRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RacersDB.Data.Models;

    /// <summary>
    /// Extending the generic IRepository interface to a specific interface.
    /// </summary>
    public interface IRacetrackRepository : IRepository<Racetrack>
    {
        /// <summary>
        /// By calling this method, user is going to be able to update a specific Racetrack.
        /// </summary>
        /// <param name="newRacetrack">The new Racetrack.</param>
        void UpdateRacetrack(Racetrack newRacetrack);
    }
}
