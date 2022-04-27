// <copyright file="RaceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using RacersDB.Data.Models;

    /// <summary>
    /// RaceRepository class.
    /// </summary>
    public class RaceRepository : MainRepository<Race>, IRaceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RaceRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type parameter.</param>
        public RaceRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangeWinnerId(int id, int newWinner)
        {
            var copy = this.GetById(id);

            if (copy != null)
            {
                copy.Winnerid = newWinner;
            }

            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Race GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
