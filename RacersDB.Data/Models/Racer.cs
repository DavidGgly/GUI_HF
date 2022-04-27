// <copyright file="Racer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// This class represents the 'Racer' table of .mdf file.
    /// </summary>
    public partial class Racer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Racer"/> class.
        /// </summary>
        public Racer()
        {
            this.Races = new HashSet<Race>();
        }

        /// <summary>
        /// Gets or sets the ID of the Racer. This is the primary key.
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the Racer.
        /// </summary>
        public string Rname { get; set; }

        /// <summary>
        /// Gets or sets the age of the Racer.
        /// </summary>
        public decimal? Age { get; set; }

        /// <summary>
        /// Gets or sets the Racer's country.
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the Racer's race series.
        /// </summary>
        public string Rserie { get; set; }

        /// <summary>
        /// Gets or sets the Racer's amount of wins.
        /// </summary>
        public decimal? Sumwin { get; set; }

        /// <summary>
        /// Gets an ICollection of a bunch of Race type Races.
        /// </summary>
        public virtual ICollection<Race> Races { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Racer)
            {
                Racer other = obj as Racer;
                return this.Id == other.Id &&
                    this.Rname == other.Rname &&
                    this.Age == other.Age &&
                    this.Nationality == other.Nationality &&
                    this.Rserie == other.Rserie &&
                    this.Sumwin == other.Sumwin;
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
            return "ID:\t\t" + this.Id + "\nRacer's name:\t" + this.Rname.ToUpper(new CultureInfo("hu-HU", false)) + "\nRacer's age:\t" + this.Age +
                "\nNationality:\t" + this.Nationality + "\nSerie:\t\t" + this.Rserie + "\nSumWin:\t\t" + this.Sumwin + " wins\n\n";
        }
    }
}
