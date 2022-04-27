// <copyright file="RacerRepository.cs" company="PlaceholderCompany">
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
    /// RacerRepository class.
    /// </summary>
    public class RacerRepository : MainRepository<Racer>, IRacerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RacerRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type parameter.</param>
        public RacerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangeSumWin(int id, int newSumWin)
        {
            var copy = this.GetById(id);

            if (copy != null)
            {
                copy.Sumwin = newSumWin;
            }

            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Racer GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
