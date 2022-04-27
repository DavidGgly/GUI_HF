// <copyright file="RacerQuery.cs" company="PlaceholderCompany">
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
    public class RacerQuery
    {
        /// <summary>
        /// Gets or sets the Racer's full name.
        /// </summary>
        public string RacerName { get; set; }

        /// <summary>
        /// Gets or sets the Racer's age.
        /// </summary>
        public decimal? RacerAge { get; set; }

        /// <summary>
        /// Gets or sets the Racer's nationality.
        /// </summary>
        public string RacerNationality { get; set; }

        /// <summary>
        /// Gets or sets the name of the Racetrack.
        /// </summary>
        public string RacetrackName { get; set; }

        /// <summary>
        /// Gets or sets the year, when that exact Racetrack was built.
        /// </summary>
        public decimal? RacetrackBuiltYear { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is RacerQuery)
            {
                RacerQuery other = obj as RacerQuery;

                return this.RacerName == other.RacerName &&
                    this.RacerAge == other.RacerAge &&
                    this.RacerNationality == other.RacerNationality &&
                    this.RacetrackName == other.RacetrackName &&
                    this.RacetrackBuiltYear == other.RacetrackBuiltYear;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.RacerName.GetHashCode(StringComparison.Ordinal) + (int)this.RacerAge;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "RacerName:\t\t" + this.RacerName.ToUpper(new CultureInfo("hu-HU", false)) + "\nRacerAge:\t\t" + this.RacerAge +
                "\nRacerNationality:\t" + this.RacerNationality + "\nRacetrackName:\t\t" +
                this.RacetrackName.ToUpper(new CultureInfo("hu-HU", false)) + "\nRacetrackBuiltYear:\t" + this.RacetrackBuiltYear + "\n\n";
        }
    }
}
