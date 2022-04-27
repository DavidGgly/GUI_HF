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
        /// By calling this method, user is going to be able to change the winner of a specific Race.
        /// </summary>
        /// <param name="id">The ID of Race, user wants to modify.</param>
        /// <param name="newWinner">The ID of the new Winner.</param>
        void ChangeWinnerId(int id, int newWinner);
    }
}
