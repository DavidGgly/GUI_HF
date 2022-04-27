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
        /// By calling this method, user is going to be able to change the name of a specific Racetrack.
        /// </summary>
        /// <param name="id">The ID of Racetrack, user wants to modify.</param>
        /// <param name="newName">The new name of the specific Racetrack.</param>
        void ChangeName(int id, string newName);
    }
}
