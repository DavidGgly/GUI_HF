// <copyright file="Race.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the 'Race' table of .mdf file.
    /// </summary>
    public partial class Race
    {
        /// <summary>
        /// Gets or sets the ID of the Race. This is the primary key.
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of track, where this Race was organized.
        /// </summary>
        public decimal Rtrack { get; set; }

        /// <summary>
        /// Gets or sets the year of this Race.
        /// </summary>
        public decimal? Ryear { get; set; }

        /// <summary>
        /// Gets or sets the serie, in which this Race was organized.
        /// </summary>
        public string Serie { get; set; }

        /// <summary>
        /// Gets or sets the amount of Racers participated to this event.
        /// </summary>
        public decimal? Sumracers { get; set; }

        /// <summary>
        /// Gets or sets the amount of laps.
        /// </summary>
        public decimal? Sumlaps { get; set; }

        /// <summary>
        /// Gets or sets the ID of the winner.
        /// </summary>
        public decimal Winnerid { get; set; }

        /// <summary>
        /// Gets the track, where this race was organized.
        /// </summary>
        public virtual Racetrack RtrackNavigation { get; }

        /// <summary>
        /// Gets the Winner of this Race.
        /// </summary>
        public virtual Racer Winner { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Race)
            {
                Race other = obj as Race;
                return this.Id == other.Id &&
                    this.Rtrack == other.Rtrack &&
                    this.Ryear == other.Ryear &&
                    this.Serie == other.Serie &&
                    this.Sumracers == other.Sumracers &&
                    this.Sumlaps == other.Sumlaps &&
                    this.Winnerid == other.Winnerid;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (int)this.Id;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "ID:\t\t\t" + this.Id + "\nRacetrack:\t\t" + this.Rtrack + "\nYear:\t\t\t" + this.Ryear + "\nSerie:\t\t\t" +
                this.Serie + "\nNumber of racers:\t" + this.Sumracers + "\nNumber of laps:\t\t" + this.Sumlaps +
                "\nWinner's ID:\t\t" + this.Winnerid + "\n\n";
        }
    }
}
