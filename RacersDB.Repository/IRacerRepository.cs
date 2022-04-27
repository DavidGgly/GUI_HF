// <copyright file="IRacerRepository.cs" company="PlaceholderCompany">
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
    public interface IRacerRepository : IRepository<Racer>
    {
        /// <summary>
        /// By calling this method, user is going to be able to update a specific Racer.
        /// </summary>
        /// <param name="newRacer">The updated Racer.</param>
        void UpdateRacer(Racer newRacer);
    }
}
