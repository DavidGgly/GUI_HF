// <copyright file="Functionality.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RacersDB.Data.Models;
    using RacersDB.Logic;

    /// <summary>
    /// This class contains all methods, which user can call by ConsoleMenu.
    /// </summary>
    public class Functionality
    {
        /// <summary>
        /// Adding new Race instance to the database.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void AddNewRace(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("ADDING A NEW RACE");
            if (gLogic != null && sLogic != null)
            {
                foreach (var item in gLogic.GetAllRacetracks())
                {
                    this.ConsoleWrite(item.Id + " - " + item.Trackname);
                }

                this.ConsoleWrite("\n");

                foreach (var item in gLogic.GetAllRacers())
                {
                    this.ConsoleWrite(item.Id + " - " + item.Rname);
                }

                this.ConsoleWrite("New Race's Racetrack's ID (help above): ", false);
                decimal newRacetrackID = decimal.Parse(Console.ReadLine());
                this.ConsoleWrite("\nNew Race's year: ", false);
                int newRaceYear = int.Parse(Console.ReadLine());
                this.ConsoleWrite("\nNew Race's serie: ", false);
                string newRaceSerie = Console.ReadLine();
                this.ConsoleWrite("\nAmount of racers: ", false);
                int newRaceSumRacers = int.Parse(Console.ReadLine());
                this.ConsoleWrite("\nNumber of laps: ", false);
                int newRaceSumLaps = int.Parse(Console.ReadLine());
                this.ConsoleWrite("\nWinner's ID: ", false);
                decimal newRaceWinnerID = decimal.Parse(Console.ReadLine());

                Race newRace = new Race();

                int generateID = gLogic.GetAllRaces().Count + 1;

                newRace.Id = generateID;
                newRace.Rtrack = newRacetrackID;
                newRace.Ryear = newRaceYear;
                newRace.Serie = newRaceSerie;
                newRace.Sumracers = newRaceSumRacers;
                newRace.Sumlaps = newRaceSumLaps;
                newRace.Winnerid = newRaceWinnerID;

                sLogic.AddNewRace(newRace);
            }
            else
            {
                this.ConsoleWrite("Failed to add the new Race!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Adding new Racer instance to the database.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void AddNewRacer(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("ADDING A NEW RACER");
            if (gLogic != null && sLogic != null)
            {
                this.ConsoleWrite("\nNew Racer's full name: ", false);
                string newRacerName = Console.ReadLine();
                this.ConsoleWrite("\nNew Racer's age: ", false);
                int newRacerAge = int.Parse(Console.ReadLine());
                this.ConsoleWrite("\nNew Racer's nationality: ", false);
                string newRacerNationality = Console.ReadLine();
                this.ConsoleWrite("\nNew Racer's main racing serie: ", false);
                string newRacerSerie = Console.ReadLine();
                this.ConsoleWrite("\nAmount of won races: ", false);
                int newRacerSumWin = int.Parse(Console.ReadLine());

                Racer newRacer = new Racer();

                int generateID = gLogic.GetAllRacers().Count + 1;

                newRacer.Id = generateID;
                newRacer.Rname = newRacerName;
                newRacer.Age = newRacerAge;
                newRacer.Nationality = newRacerNationality;
                newRacer.Rserie = newRacerSerie;
                newRacer.Sumwin = newRacerSumWin;

                sLogic.AddNewRacer(newRacer);
            }
            else
            {
                this.ConsoleWrite("Failed to add the new Racer!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Adding new Racetrack instance to the database.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void AddNewRacetrack(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("ADDING A NEW RACETRACK");
            if (gLogic != null && sLogic != null)
            {
                this.ConsoleWrite("\nNew Racetrack's name: ", false);
                string newRacetrackName = Console.ReadLine();
                this.ConsoleWrite("\nNew Racetrack's built year: ", false);
                int newRacetrackBuiltYear = int.Parse(Console.ReadLine());
                this.ConsoleWrite("\nNew Racetrack's length (m): ", false);
                int newRacetrackLength = int.Parse(Console.ReadLine());
                this.ConsoleWrite("\nNew Racetrack's country: ", false);
                string newRacetrackVenue = Console.ReadLine();
                this.ConsoleWrite("\nIs it actively used to organize F1 races (Yes/No)?: ", false);
                string newRacetrackIsF1 = Console.ReadLine();

                Racetrack newRacetrack = new Racetrack();

                int generateID = gLogic.GetAllRacetracks().Count + 1;

                newRacetrack.Id = generateID;
                newRacetrack.Trackname = newRacetrackName;
                newRacetrack.Builtyear = newRacetrackBuiltYear;
                newRacetrack.Tlength = newRacetrackLength;
                newRacetrack.Tvenue = newRacetrackVenue;
                newRacetrack.Isf1 = newRacetrackIsF1;

                sLogic.AddNewRacetrack(newRacetrack);
            }
            else
            {
                this.ConsoleWrite("Failed to add the new Racetrack!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Deleting old Race instance from the database.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void DeleteOldRace(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("Which Race would you like to delete? ", false);
            int raceIDtoDel = int.Parse(Console.ReadLine());

            if (gLogic != null)
            {
                Race instanceToDel = gLogic.GetOneRace(raceIDtoDel);

                if (sLogic != null && instanceToDel != null)
                {
                    sLogic.DeleteOldRace(instanceToDel);

                    this.ConsoleWrite("Race with ID: " + raceIDtoDel + " has been successfully deleted!");

                    foreach (var item in gLogic.GetAllRaces())
                    {
                        if (item.Id > raceIDtoDel)
                        {
                            item.Id--;
                        }
                    }
                }
                else
                {
                    this.ConsoleWrite("Failed to delete Race, with ID: " + raceIDtoDel + ".");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Deleting old Racer instance from the database.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void DeleteOldRacer(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("Which Racer would you like to delete? ", false);
            int racerIDtoDel = int.Parse(Console.ReadLine());

            if (gLogic != null)
            {
                Racer instanceToDel = gLogic.GetOneRacer(racerIDtoDel);

                if (sLogic != null && instanceToDel != null)
                {
                    sLogic.DeleteOldRacer(instanceToDel);

                    this.ConsoleWrite("Racer with ID: " + racerIDtoDel + " has been successfully deleted!");

                    foreach (var item in gLogic.GetAllRacers())
                    {
                        if (item.Id > racerIDtoDel)
                        {
                            item.Id--;
                        }
                    }
                }
                else
                {
                    this.ConsoleWrite("Failed to delete Racer, with ID: " + racerIDtoDel + ".");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Deleting old Racetrack instance from the database.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void DeleteOldRacetrack(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("Which Racetrack would you like to delete? ", false);
            int racetrackIDtoDel = int.Parse(Console.ReadLine());

            if (gLogic != null)
            {
                Racetrack instanceToDel = gLogic.GetOneRacetrack(racetrackIDtoDel);

                if (sLogic != null && instanceToDel != null)
                {
                    sLogic.DeleteOldRacetrack(instanceToDel);

                    this.ConsoleWrite("Racetrack with ID: " + racetrackIDtoDel + " has been successfully deleted!");

                    foreach (var item in gLogic.GetAllRacetracks())
                    {
                        if (item.Id > racetrackIDtoDel)
                        {
                            item.Id--;
                        }
                    }
                }
                else
                {
                    this.ConsoleWrite("Failed to delete Racetrack, with ID: " + racetrackIDtoDel + ".");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Returns that Race instance, which id is equal to what user types in.
        /// </summary>
        /// <param name="logic">This parameter represents the GetLogic class.</param>
        public void GetOneRace(GetLogic logic)
        {
            this.ConsoleWrite("Which Race would you like to see? ", false);
            int id = int.Parse(Console.ReadLine());

            if (logic != null)
            {
                var result = logic.GetOneRace(id);

                if (result != null)
                {
                    this.ConsoleWrite("Race successfully found!");
                    this.ConsoleWrite(result.ToString());
                }
                else
                {
                    this.ConsoleWrite("Race not found!");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Returns that Racer instance, which id is equal to what user types in.
        /// </summary>
        /// <param name="logic">This parameter represents the GetLogic class.</param>
        public void GetOneRacer(GetLogic logic)
        {
            this.ConsoleWrite("Which Racer would you like to see? ", false);
            int id = int.Parse(Console.ReadLine());

            if (logic != null)
            {
                var result = logic.GetOneRacer(id);

                if (result != null)
                {
                    this.ConsoleWrite("Racer successfully found!");
                    this.ConsoleWrite(result.ToString());
                }
                else
                {
                    this.ConsoleWrite("Racer not found!");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Returns that Racetrack instance, which id is equal to what user types in.
        /// </summary>
        /// <param name="logic">This parameter represents the GetLogic class.</param>
        public void GetOneRacetrack(GetLogic logic)
        {
            this.ConsoleWrite("Which Racetrack would you like to see? ", false);
            int id = int.Parse(Console.ReadLine());

            if (logic != null)
            {
                var result = logic.GetOneRacetrack(id);

                if (result != null)
                {
                    this.ConsoleWrite("Racetrack successfully found!");
                    this.ConsoleWrite(result.ToString());
                }
                else
                {
                    this.ConsoleWrite("Racetrack not found!");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Returns all Race instances and all it's properties, in order.
        /// </summary>
        /// <param name="logic">This parameter represents the GetLogic class.</param>
        public void GetAllRaces(GetLogic logic)
        {
            if (logic != null)
            {
                IList<Race> result = logic.GetAllRaces();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        this.ConsoleWrite(item.ToString());
                    }
                }
                else
                {
                    this.ConsoleWrite("No Race found!");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Returns all Racer instances and all it's properties, in order.
        /// </summary>
        /// <param name="logic">This parameter represents the GetLogic class.</param>
        public void GetAllRacers(GetLogic logic)
        {
            if (logic != null)
            {
                IList<Racer> result = logic.GetAllRacers();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        this.ConsoleWrite(item.ToString());
                    }
                }
                else
                {
                    this.ConsoleWrite("No Racer found!");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Returns all Racetrack instances and all it's properties, in order.
        /// </summary>
        /// <param name="logic">This parameter represents the GetLogic class.</param>
        public void GetAllRacetracks(GetLogic logic)
        {
            if (logic != null)
            {
                IList<Racetrack> result = logic.GetAllRacetracks();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        this.ConsoleWrite(item.ToString());
                    }
                }
                else
                {
                    this.ConsoleWrite("No Racetrack found!");
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Changes the Winner's ID in a chosen Race.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void ChangeRaceWinnersID(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("Which Race's winner would you like to modify? ", false);
            int raceID = int.Parse(Console.ReadLine());
            this.ConsoleWrite("Who should be the new winner?", false);
            int newWinnerID = int.Parse(Console.ReadLine());

            if (gLogic != null && sLogic != null && newWinnerID <= gLogic.GetAllRacers().Count)
            {
                sLogic.ChangeRaceWinnersID(raceID, newWinnerID);

                this.ConsoleWrite("Successfully updated the WinnerID!");
            }
            else
            {
                this.ConsoleWrite("Failed to update the WinnerID!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Changes the Racer's summary of winnings based on it's ID.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void ChangeSumWin(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("Which Racer's amount of winnings would you like to modify? ", false);
            int racerID = int.Parse(Console.ReadLine());
            this.ConsoleWrite("What should be the new value?", false);
            int newSumWin = int.Parse(Console.ReadLine());

            if (gLogic != null && sLogic != null && gLogic.GetOneRacer(racerID) != null)
            {
                sLogic.ChangeSumWin(racerID, newSumWin);

                this.ConsoleWrite("Successfully updated the winner's amount of winnings!");
            }
            else
            {
                this.ConsoleWrite("Failed to update the amount of winnings!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Changes the name of a chosen Racetrack.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        /// <param name="sLogic">This parameter represents the SetLogic class.</param>
        public void ChangeRacetracksName(GetLogic gLogic, SetLogic sLogic)
        {
            this.ConsoleWrite("Which Racetrack's name would you like to modify? ", false);
            int racetrackID = int.Parse(Console.ReadLine());
            this.ConsoleWrite("What should be the new name?", false);
            string newName = Console.ReadLine();

            if (gLogic != null && sLogic != null && gLogic.GetOneRacetrack(racetrackID) != null)
            {
                sLogic.ChangeRacetracksName(racetrackID, newName);

                this.ConsoleWrite("Successfully updated the Racetrack's name!");
            }
            else
            {
                this.ConsoleWrite("Failed to update the Racetrack's name!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method returns some data about the Races, where the venue of the Race and the winner's
        /// nationality equals.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        public void RaceQuery(GetLogic gLogic)
        {
            this.ConsoleWrite("This query returns some data about the Races, where the venue of the Race and the winner's nationality equals.");

            if (gLogic != null)
            {
                foreach (var item in gLogic.GetRaceQuery())
                {
                    this.ConsoleWrite(item.ToString());
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method is the ASync version of GetRaceQuery method.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        public void RaceQueryASync(GetLogic gLogic)
        {
            this.ConsoleWrite("This query returns some data about the Races, where the venue of the Race and the winner's nationality equals.");

            if (gLogic != null)
            {
                foreach (var item in gLogic.GetRaceQueryASync().Result)
                {
                    this.ConsoleWrite(item.ToString());
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method returns all data of the Racers, who was born the same year as a Racetrack was built.
        /// This list is ordered by the name of Racetracks.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        public void RacerQuery(GetLogic gLogic)
        {
            this.ConsoleWrite("This method returns all data of the Racers, who was born the same year as a Racetrack was built. This list is ordered by the name of Racetracks.");

            if (gLogic != null)
            {
                foreach (var item in gLogic.GetRacerQuery())
                {
                    this.ConsoleWrite(item.ToString());
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method is the ASync version of GetRacerQuery method.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        public void RacerQueryASync(GetLogic gLogic)
        {
            this.ConsoleWrite("This method returns all data of the Racers, who was born the same year as a Racetrack was built. This list is ordered by the name of Racetracks.");

            if (gLogic != null)
            {
                foreach (var item in gLogic.GetRacerQueryASync().Result)
                {
                    this.ConsoleWrite(item.ToString());
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method collects all data of all Racetracks and sorts descending
        /// based on the amount of Races organized on each Racetracks.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        public void RacetrackQuery(GetLogic gLogic)
        {
            this.ConsoleWrite("This method collects all data of all Racetracks and sorts descending based on the amount of Races organized on each Racetracks.");

            if (gLogic != null)
            {
                foreach (var item in gLogic.GetRacetrackQuery())
                {
                    this.ConsoleWrite(item.ToString());
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method is the ASync version of GetRacetrackQuery method.
        /// </summary>
        /// <param name="gLogic">This parameter represents the GetLogic class.</param>
        public void RacetrackQueryASync(GetLogic gLogic)
        {
            this.ConsoleWrite("This method collects all data of all Racetracks and sorts descending based on the amount of Races organized on each Racetracks.");

            if (gLogic != null)
            {
                foreach (var item in gLogic.GetRacetrackQueryASync().Result)
                {
                    this.ConsoleWrite(item.ToString());
                }
            }
            else
            {
                this.ConsoleWrite("Empty logic parameter!");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// This method is the default WriteLine() method, used by all of this methods, inside class.
        /// </summary>
        /// <param name="stringToWrite">This is the string, which will be wrote to the screen.</param>
        /// <param name="breakLine">If this bool is true, the method breaks the line after WriteLine, if it's false, then not.</param>
        protected void ConsoleWrite(string stringToWrite, bool breakLine = true)
        {
            Console.Write(stringToWrite);
            if (breakLine)
            {
                Console.WriteLine();
            }
        }
    }
}
