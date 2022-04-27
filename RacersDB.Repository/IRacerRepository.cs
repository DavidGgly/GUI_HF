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
        /// By calling this method, user is going to be able to change the sumwin property of a specific Racer.
        /// </summary>
        /// <param name="id">The ID of Racer, user wants to modify.</param>
        /// <param name="newSumWin">The new value of Racers number of winnings.</param>
        void ChangeSumWin(int id, int newSumWin);
    }
}
