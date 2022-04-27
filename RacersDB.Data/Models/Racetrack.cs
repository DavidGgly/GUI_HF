// <copyright file="Racetrack.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// This class represents the 'Racetrack' table of .mdf file.
    /// </summary>
    public partial class Racetrack
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Racetrack"/> class.
        /// </summary>
        public Racetrack()
        {
            this.Races = new HashSet<Race>();
        }

        /// <summary>
        /// Gets or sets a decimal value. This is the primary key.
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the track.
        /// </summary>
        public string Trackname { get; set; }

        /// <summary>
        /// Gets or sets the year, this track has been built.
        /// </summary>
        public decimal? Builtyear { get; set; }

        /// <summary>
        /// Gets or sets the length of the track in metres.
        /// </summary>
        public decimal? Tlength { get; set; }

        /// <summary>
        /// Gets or sets the country of the track.
        /// </summary>
        public string Tvenue { get; set; }

        /// <summary>
        /// Gets or sets only 0 or 1, depending on the fact, that is this track used by F1 series or not.
        /// </summary>
        public string Isf1 { get; set; }

        /// <summary>
        /// Gets an ICollection of a bunch of Race type Races.
        /// </summary>
        public virtual ICollection<Race> Races { get; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Racetrack)
            {
                Racetrack other = obj as Racetrack;
                return this.Id == other.Id &&
                    this.Trackname == other.Trackname &&
                    this.Builtyear == other.Builtyear &&
                    this.Tlength == other.Tlength &&
                    this.Tvenue == other.Tvenue &&
                    this.Isf1 == other.Isf1;
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
            return "ID:\t\t" + this.Id + "\nTrackname:\t" + this.Trackname.ToUpper(new CultureInfo("hu-HU", false)) + "\nBuilt year:\t" + this.Builtyear +
                "\nTrack length:\t" + this.Tlength + "m\nCountry:\t" + this.Tvenue + "\nIs it F1 track?\t" + this.Isf1 + "\n\n";
        }
    }
}
