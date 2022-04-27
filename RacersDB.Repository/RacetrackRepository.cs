// <copyright file="RacetrackRepository.cs" company="PlaceholderCompany">
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
    /// RacetrackRepository class.
    /// </summary>
    public class RacetrackRepository : MainRepository<Racetrack>, IRacetrackRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RacetrackRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type parameter.</param>
        public RacetrackRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            var copy = this.GetById(id);

            if (copy != null)
            {
                copy.Trackname = newName;
            }

            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Racetrack GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
