// <copyright file="MainProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Program
{
    using System;
    using ConsoleTools;
    using RacersDB.Data.Models;
    using RacersDB.Logic;
    using RacersDB.Repository;

    /// <summary>
    /// The main program.
    /// </summary>
    public static class MainProgram
    {
        /// <summary>
        /// The main method.
        /// </summary>
        public static void Main()
        {
            Factory fact = new Factory();
            Functionality fun = new Functionality();
            Menu menu = new Menu(fun, fact.GetLogic, fact.SetLogic);

            menu.ConsoleMainMenu();
        }
    }
}
