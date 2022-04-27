// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ConsoleTools;
    using RacersDB.Logic;

    /// <summary>
    /// This class contains the exact ConsoleMenu, which is visible to user.
    /// </summary>
    public class Menu
    {
        private readonly Functionality func;
        private readonly GetLogic gLogic;
        private readonly SetLogic sLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="func">This parameter contains the methods, which can be called by the ConsoleMenu.</param>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public Menu(Functionality func, GetLogic gLogic, SetLogic sLogic)
        {
            this.func = func;
            this.gLogic = gLogic;
            this.sLogic = sLogic;
        }

        /// <summary>
        /// This method contains the exact ConsoleMenu, which is visible to the user.
        /// </summary>
        public void ConsoleMainMenu()
        {
            var menu = new ConsoleMenu()
                .Add("Get one Race", () => this.func.GetOneRace(this.gLogic))
                .Add("Get one Racer", () => this.func.GetOneRacer(this.gLogic))
                .Add("Get one Racetrack", () => this.func.GetOneRacetrack(this.gLogic))
                .Add("Get all Races", () => this.func.GetAllRaces(this.gLogic))
                .Add("Get all Racers", () => this.func.GetAllRacers(this.gLogic))
                .Add("Get all Racetracks", () => this.func.GetAllRacetracks(this.gLogic))
                .Add("Add new Race", () => this.func.AddNewRace(this.gLogic, this.sLogic))
                .Add("Add new Racer", () => this.func.AddNewRacer(this.gLogic, this.sLogic))
                .Add("Add new Racetrack", () => this.func.AddNewRacetrack(this.gLogic, this.sLogic))
                .Add("Update Race winner's ID", () => this.func.ChangeRaceWinnersID(this.gLogic, this.sLogic))
                .Add("Update Racer's amount of winnings", () => this.func.ChangeSumWin(this.gLogic, this.sLogic))
                .Add("Update Racetrack's name", () => this.func.ChangeRacetracksName(this.gLogic, this.sLogic))
                .Add("Delete old Race", () => this.func.DeleteOldRace(this.gLogic, this.sLogic))
                .Add("Delete old Racer", () => this.func.DeleteOldRacer(this.gLogic, this.sLogic))
                .Add("Delete old Racetrack", () => this.func.DeleteOldRacetrack(this.gLogic, this.sLogic))
                .Add("RaceQuery", () => this.func.RaceQuery(this.gLogic))
                .Add("RaceQueryASync", () => this.func.RaceQueryASync(this.gLogic))
                .Add("RacerQuery", () => this.func.RacerQuery(this.gLogic))
                .Add("RacerQueryASync", () => this.func.RacerQueryASync(this.gLogic))
                .Add("RacetrackQuery", () => this.func.RacetrackQuery(this.gLogic))
                .Add("RacetrackQueryASync", () => this.func.RacetrackQueryASync(this.gLogic))
                .Add("CLOSE", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
