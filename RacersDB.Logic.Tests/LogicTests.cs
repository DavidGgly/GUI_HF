// <copyright file="LogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using NUnit.Framework;
    using RacersDB.Data.Models;
    using RacersDB.Repository;

    /// <summary>
    /// This class collects all mocked Test methods.
    /// </summary>
    [TestFixture]
    public class LogicTests
    {
        private Mock<IRaceRepository> mockedRaceRepo;
        private Mock<IRacerRepository> mockedRacerRepo;
        private Mock<IRacetrackRepository> mockedRacetrackRepo;

        private List<Race> races;
        private List<Racer> racers;
        private List<Racetrack> racetracks;

        private List<RaceQuery> expectedRaces;
        private List<RacerQuery> expectedRacers;
        private List<RacetrackQuery> expectedRacetracks;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicTests"/> class.
        /// </summary>
        public LogicTests()
        {
            this.mockedRaceRepo = new Mock<IRaceRepository>(MockBehavior.Loose);
            this.mockedRacerRepo = new Mock<IRacerRepository>(MockBehavior.Loose);
            this.mockedRacetrackRepo = new Mock<IRacetrackRepository>(MockBehavior.Loose);
        }

        /// <summary>
        /// This method tests the GetAll() method, currently based on Racetrack entity.
        /// </summary>
        [Test]
        public void TestGetAllRacetracks()
        {
            this.mockedRacetrackRepo.Setup(repo => repo.GetAll()).Returns(new List<Racetrack>().AsQueryable()).Verifiable();

            GetLogic logic = new GetLogic(this.mockedRaceRepo.Object, this.mockedRacerRepo.Object, this.mockedRacetrackRepo.Object);

            logic.GetAllRacetracks();

            this.mockedRacetrackRepo.Verify(x => x.GetAll(), Times.Once);
        }

        /// <summary>
        /// This method tests the GetOne() method, currently based on Racer entity.
        /// </summary>
        [Test]
        public void TestGetOneRacer()
        {
            this.mockedRacerRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new Racer()).Verifiable();

            GetLogic logic = new GetLogic(this.mockedRaceRepo.Object, this.mockedRacerRepo.Object, this.mockedRacetrackRepo.Object);

            logic.GetOneRacer(2);

            this.mockedRacerRepo.Verify(x => x.GetById(It.Is<int>(result => result == 2)), Times.Once);
        }

        /// <summary>
        /// This method tests the Update method, currently based on Race entity.
        /// </summary>
        [Test]
        public void TestUpdateRaceWinnersID()
        {
            this.mockedRaceRepo.Setup(repo => repo.ChangeWinnerId(It.IsAny<int>(), It.IsAny<int>())).Verifiable();

            SetLogic logic = new SetLogic(this.mockedRaceRepo.Object, this.mockedRacerRepo.Object, this.mockedRacetrackRepo.Object);

            logic.ChangeRaceWinnersID(It.IsAny<int>(), It.IsAny<int>());

            this.mockedRaceRepo.Verify(x => x.ChangeWinnerId(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        /// <summary>
        /// This method tests the AddNew() method, currently based on Racer entity.
        /// </summary>
        [Test]
        public void TestAddNewRacer()
        {
            this.mockedRacerRepo.Setup(repo => repo.AddNew(It.IsAny<Racer>())).Verifiable();

            SetLogic logic = new SetLogic(this.mockedRaceRepo.Object, this.mockedRacerRepo.Object, this.mockedRacetrackRepo.Object);
            Racer racer = new Racer();

            logic.AddNewRacer(racer);

            this.mockedRacerRepo.Verify(x => x.AddNew(racer), Times.Once);
        }

        /// <summary>
        /// This method tests the DeleteOld() method, currently based on Racetrack entity.
        /// </summary>
        [Test]
        public void TestDeleteRacetrack()
        {
            this.mockedRacetrackRepo.Setup(repo => repo.DeleteOld(It.IsAny<Racetrack>())).Verifiable();

            SetLogic logic = new SetLogic(this.mockedRaceRepo.Object, this.mockedRacerRepo.Object, this.mockedRacetrackRepo.Object);

            logic.DeleteOldRacetrack(It.IsAny<Racetrack>());

            this.mockedRacetrackRepo.Verify(x => x.DeleteOld(It.IsAny<Racetrack>()), Times.Once);
        }

        /// <summary>
        /// This method tests the RaceQuery() type LINQ method.
        /// </summary>
        [Test]
        public void TestRaceQuery()
        {
            var result = this.CreateLogicWithMocks().GetRaceQuery();

            Assert.That(result, Is.EquivalentTo(this.expectedRaces));
            Assert.That(result.Count, Is.EqualTo(3));

            this.mockedRaceRepo.Verify(x => x.GetAll(), Times.Once);
            this.mockedRacerRepo.Verify(x => x.GetAll(), Times.Once);
            this.mockedRacetrackRepo.Verify(x => x.GetAll(), Times.Once);
        }

        /// <summary>
        /// This method tests the RacerQuery() type LINQ method.
        /// </summary>
        [Test]
        public void TestRacerQuery()
        {
            var result = this.CreateLogicWithMocks().GetRacerQuery();

            Assert.That(result, Is.EquivalentTo(this.expectedRacers));
            Assert.That(result.Count, Is.EqualTo(2));

            this.mockedRaceRepo.Verify(x => x.GetAll(), Times.Never);
            this.mockedRacerRepo.Verify(x => x.GetAll(), Times.Once);
            this.mockedRacetrackRepo.Verify(x => x.GetAll(), Times.Once);
        }

        /// <summary>
        /// This method tests the RacetrackQuery() type LINQ method.
        /// </summary>
        [Test]
        public void TestRacetrackQuery()
        {
            var result = this.CreateLogicWithMocks().GetRacetrackQuery();

            Assert.That(result, Is.EqualTo(this.expectedRacetracks));
            Assert.That(result.Count, Is.EqualTo(3));

            this.mockedRaceRepo.Verify(x => x.GetAll(), Times.Once);
            this.mockedRacerRepo.Verify(x => x.GetAll(), Times.Never);
            this.mockedRacetrackRepo.Verify(x => x.GetAll(), Times.Once);
        }

        private GetLogic CreateLogicWithMocks()
        {
            this.mockedRaceRepo = new Mock<IRaceRepository>(MockBehavior.Loose);
            this.mockedRacerRepo = new Mock<IRacerRepository>(MockBehavior.Loose);
            this.mockedRacetrackRepo = new Mock<IRacetrackRepository>(MockBehavior.Loose);

            this.races = new List<Race>()
            {
                new Race()
                {
                    Id = 1,
                    Rtrack = 6,
                    Ryear = 2015,
                    Winnerid = 3,
                },
                new Race()
                {
                    Id = 3,
                    Rtrack = 8,
                    Ryear = 2000,
                    Winnerid = 1,
                },
                new Race()
                {
                    Id = 4,
                    Rtrack = 3,
                    Ryear = 2016,
                    Winnerid = 5,
                },
                new Race()
                {
                    Id = 6,
                    Rtrack = 5,
                    Ryear = 2011,
                    Winnerid = 4,
                },
                new Race()
                {
                    Id = 8,
                    Rtrack = 3,
                    Ryear = 2018,
                    Winnerid = 2,
                },
            };
            this.racers = new List<Racer>()
            {
                new Racer()
                {
                    Id = 1,
                    Rname = "Michael Schumacher",
                    Age = 51,
                    Nationality = "Germany",
                },
                new Racer()
                {
                    Id = 2,
                    Rname = "Michelisz Norbert",
                    Age = 36,
                    Nationality = "Hungary",
                },
                new Racer()
                {
                    Id = 3,
                    Rname = "Lewis Hamilton",
                    Age = 35,
                    Nationality = "United Kingdom",
                },
                new Racer()
                {
                    Id = 5,
                    Rname = "Keszthelyi Vivien",
                    Age = 19,
                    Nationality = "Hungary",
                },
            };
            this.racetracks = new List<Racetrack>()
            {
                new Racetrack()
                {
                    Id = 1,
                    Trackname = "Österreichring",
                    Builtyear = 1969,
                    Tlength = 4318,
                    Tvenue = "Austria",
                    Isf1 = "No",
                },
                new Racetrack()
                {
                    Id = 3,
                    Trackname = "Hungaroring",
                    Builtyear = 1986,
                    Tlength = 4381,
                    Tvenue = "Hungary",
                    Isf1 = "Yes",
                },
                new Racetrack()
                {
                    Id = 5,
                    Trackname = "Jerez",
                    Builtyear = 1985,
                    Tlength = 4429,
                    Tvenue = "Spain",
                    Isf1 = "No",
                },
                new Racetrack()
                {
                    Id = 8,
                    Trackname = "Nürburgring",
                    Builtyear = 1927,
                    Tlength = 25947,
                    Tvenue = "Germany",
                    Isf1 = "No",
                },
            };

            this.expectedRaces = new List<RaceQuery>()
            {
                new RaceQuery()
                {
                    Country = "Germany",
                    RacerName = "Michael Schumacher",
                    RacerAgeThen = 31,
                    RacetrackName = "Nürburgring",
                    RaceID = 3,
                    RaceYear = 2000,
                },
                new RaceQuery()
                {
                    Country = "Hungary",
                    RacerName = "Michelisz Norbert",
                    RacerAgeThen = 34,
                    RacetrackName = "Hungaroring",
                    RaceID = 8,
                    RaceYear = 2018,
                },
                new RaceQuery()
                {
                    Country = "Hungary",
                    RacerName = "Keszthelyi Vivien",
                    RacerAgeThen = 15,
                    RacetrackName = "Hungaroring",
                    RaceID = 4,
                    RaceYear = 2016,
                },
            };
            this.expectedRacers = new List<RacerQuery>()
            {
                new RacerQuery()
                {
                    RacerName = "Michael Schumacher",
                    RacerAge = 51,
                    RacerNationality = "Germany",
                    RacetrackBuiltYear = 1969,
                    RacetrackName = "Österreichring",
                },
                new RacerQuery()
                {
                    RacerName = "Lewis Hamilton",
                    RacerAge = 35,
                    RacerNationality = "United Kingdom",
                    RacetrackBuiltYear = 1985,
                    RacetrackName = "Jerez",
                },
            };
            this.expectedRacetracks = new List<RacetrackQuery>()
            {
                new RacetrackQuery()
                {
                    TrackName = "Hungaroring",
                    SumRaces = 2,
                    BuiltYear = 1986,
                    TrackLength = 4381,
                    TrackVenue = "Hungary",
                    IsFormula = "Yes",
                },
                new RacetrackQuery()
                {
                    TrackName = "Jerez",
                    SumRaces = 1,
                    BuiltYear = 1985,
                    TrackLength = 4429,
                    TrackVenue = "Spain",
                    IsFormula = "No",
                },
                new RacetrackQuery()
                {
                    TrackName = "Nürburgring",
                    SumRaces = 1,
                    BuiltYear = 1927,
                    TrackLength = 25947,
                    TrackVenue = "Germany",
                    IsFormula = "No",
                },
            };

            this.mockedRaceRepo.Setup(repo => repo.GetAll()).Returns(this.races.AsQueryable());
            this.mockedRacerRepo.Setup(repo => repo.GetAll()).Returns(this.racers.AsQueryable());
            this.mockedRacetrackRepo.Setup(repo => repo.GetAll()).Returns(this.racetracks.AsQueryable());

            return new GetLogic(this.mockedRaceRepo.Object, this.mockedRacerRepo.Object, this.mockedRacetrackRepo.Object);
        }
    }
}