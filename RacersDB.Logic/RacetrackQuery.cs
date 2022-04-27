// <copyright file="RacetrackQuery.cs" company="PlaceholderCompany">
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
    public class RacetrackQuery
    {
        /// <summary>
        /// Gets or sets the name of the Racetrack.
        /// </summary>
        public string TrackName { get; set; }

        /// <summary>
        /// Gets or sets, how much Races were organized on that exact Racetrack already.
        /// </summary>
        public decimal? SumRaces { get; set; }

        /// <summary>
        /// Gets or sets, when that exact Racetrack was built.
        /// </summary>
        public decimal? BuiltYear { get; set; }

        /// <summary>
        /// Gets or sets the Racetrack's exact length in metres.
        /// </summary>
        public decimal? TrackLength { get; set; }

        /// <summary>
        /// Gets or sets the country of the Racetrack.
        /// </summary>
        public string TrackVenue { get; set; }

        /// <summary>
        /// Gets or sets a 'Yes' if the Racetrack is actively used to organize Formula 1 races, 'No' otherwise.
        /// </summary>
        public string IsFormula { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is RacetrackQuery)
            {
                RacetrackQuery other = obj as RacetrackQuery;

                return this.TrackName == other.TrackName &&
                    this.SumRaces == other.SumRaces &&
                    this.BuiltYear == other.BuiltYear &&
                    this.TrackLength == other.TrackLength &&
                    this.TrackVenue == other.TrackVenue &&
                    this.IsFormula == other.IsFormula;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.TrackName.GetHashCode(StringComparison.Ordinal) + (int)this.BuiltYear;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Trackname:\t" + this.TrackName.ToUpper(new CultureInfo("hu-HU", false)) + "\nSumraces:\t" + (this.SumRaces == null ? 0 : (int)this.SumRaces) + "\nBuiltyear:\t" + this.BuiltYear +
                "\nTrackLength:\t" + this.TrackLength + "\nTrackVenue:\t" + this.TrackVenue + "\nIsFormula:\t" + this.IsFormula + "\n\n";
        }
    }
}
