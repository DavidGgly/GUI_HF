// <copyright file="RaceQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// This class can be used as return type of LINQ queries.
    /// </summary>
    public class RaceQuery
    {
        /// <summary>
        /// Gets or sets the country, where the Race was organized / the Racer is from.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Racer's full name.
        /// </summary>
        public string RacerName { get; set; }

        /// <summary>
        /// Gets or sets the Racer's age when the Race happened.
        /// </summary>
        public decimal? RacerAgeThen { get; set; }

        /// <summary>
        /// Gets or sets the name of the Racetrack, where the Race was organized.
        /// </summary>
        public string RacetrackName { get; set; }

        /// <summary>
        /// Gets or sets the ID in the Race table of this exact Race.
        /// </summary>
        public decimal RaceID { get; set; }

        /// <summary>
        /// Gets or sets the year, when this Race was organized.
        /// </summary>
        public decimal? RaceYear { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is RaceQuery)
            {
                RaceQuery other = obj as RaceQuery;

                return this.Country == other.Country &&
                    this.RacerName == other.RacerName &&
                    this.RacerAgeThen == other.RacerAgeThen &&
                    this.RacetrackName == other.RacetrackName &&
                    this.RaceID == other.RaceID &&
                    this.RaceYear == other.RaceYear;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Country.GetHashCode(StringComparison.Ordinal) + (int)this.RacerAgeThen;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Country:\t\t" + this.Country + "\nRacerName:\t\t" + this.RacerName.ToUpper(new CultureInfo("hu-HU", false)) + "\nRacerAgeAtTheRace:\t" + this.RacerAgeThen +
                "\nRacetrackName:\t\t" + this.RacetrackName.ToUpper(new CultureInfo("hu-HU", false)) + "\nRaceID:\t\t\t" + this.RaceID + "\nRaceYear:\t\t" + this.RaceYear + "\n\n";
        }
    }
}
