// <copyright file="IRaceRepository.cs" company="PlaceholderCompany">
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
    public interface IRaceRepository : IRepository<Race>
    {
        /// <summary>
        /// By calling this method, user is going to be able to update a specific Race.
        /// </summary>
        /// <param name="newWinner">The updated Winner.</param>
        void UpdateRace(Race newWinner);
    }
}
