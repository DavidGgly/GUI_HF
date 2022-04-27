IF OBJECT_ID('Racetrack', 'U') IS NOT NULL DROP TABLE Racetrack;
IF OBJECT_ID('Race', 'U') IS NOT NULL DROP TABLE Race;
IF OBJECT_ID('Racer', 'U') IS NOT NULL DROP TABLE Racer;

CREATE TABLE Racetrack
	(ID NUMERIC(3) NOT NULL PRIMARY KEY,
	 TRACKNAME	VARCHAR(30),
	 BUILTYEAR	NUMERIC(4),
	 TLENGTH	NUMERIC(5),
	 TVENUE		VARCHAR(30),
	 ISF1		VARCHAR(3),
	 CONSTRAINT IS_FORMULA1 CHECK (ISF1 = 'Yes' OR ISF1 = 'No') );

INSERT INTO Racetrack VALUES (1, 'Österreichring', 1969, 4318, 'Austria', 'No');
INSERT INTO Racetrack VALUES (2, 'Brno', 1930, 5403, 'Czech Republic', 'No');
INSERT INTO Racetrack VALUES (3, 'Hungaroring', 1986, 4381, 'Hungary', 'Yes');
INSERT INTO Racetrack VALUES (4, 'Slovakiaring', 2009, 3737, 'Slovakia', 'No');
INSERT INTO Racetrack VALUES (5, 'Jerez', 1985, 4429, 'Spain', 'No');
INSERT INTO Racetrack VALUES (6, 'Pau', 1933, 2760, 'France', 'Yes');
INSERT INTO Racetrack VALUES (7, 'Silverstone', 1943, 5890, 'United Kingdom', 'Yes');
INSERT INTO Racetrack VALUES (8, 'Nürburgring', 1927, 25947, 'Germany', 'No');

CREATE TABLE Racer
	(ID NUMERIC(3) NOT NULL PRIMARY KEY,
	 RNAME		VARCHAR(40),
	 AGE		NUMERIC(2),
	 NATIONALITY	VARCHAR(25),
	 RSERIE		VARCHAR(20),
	 SUMWIN		NUMERIC(3) );

INSERT INTO Racer VALUES (1, 'Michael Schumacher', 51, 'Germany', 'Formula 1', 91);
INSERT INTO Racer VALUES (2, 'Michelisz Norbert', 36, 'Hungary', 'WTCR', 16);
INSERT INTO Racer VALUES (3, 'Lewis Hamilton', 35, 'United Kingdom', 'Formula 1', 92);
INSERT INTO Racer VALUES (4, 'Talmácsi Gábor', 39, 'Hungary', 'Superbike', 9);
INSERT INTO Racer VALUES (5, 'Keszthelyi Vivien', 19, 'Hungary', 'WTCR', 2);
INSERT INTO Racer VALUES (6, 'Stefano Daste', 46, 'Italy', 'WTCC', 0);
INSERT INTO Racer VALUES (7, 'Nico Müller', 28, 'Switzerland', 'DTM', 6);
INSERT INTO Racer VALUES (8, 'Augusto Farfus', 37, 'Brazil', 'WTCC', 6);


CREATE TABLE Race
	(ID NUMERIC(3) NOT NULL PRIMARY KEY,
	 RTRACK		NUMERIC(3) NOT NULL,
	 CONSTRAINT RTRACK_FOREIGN FOREIGN KEY (RTRACK) REFERENCES Racetrack (ID),
	 RYEAR		NUMERIC(4),
	 SERIE		VARCHAR(20),
	 SUMRACERS	NUMERIC(2),
	 SUMLAPS	NUMERIC(3),
	 WINNERID	NUMERIC(3) NOT NULL,
	 CONSTRAINT WINNER_FOREIGN FOREIGN KEY (WINNERID) REFERENCES Racer (ID) );

INSERT INTO Race VALUES (1, 6, 2015, 'Formula 1', 24, 57, 3);
INSERT INTO Race VALUES (2, 4, 2020, 'WTCR', 22, 16, 6);
INSERT INTO Race VALUES (3, 8, 2000, 'DTM', 35, 12, 1);
INSERT INTO Race VALUES (4, 3, 2016, 'Formula 1', 23, 62, 5);
INSERT INTO Race VALUES (5, 2, 2008, 'WTCC', 19, 19, 8);
INSERT INTO Race VALUES (6, 5, 2011, 'Superbike', 22, 49, 4);
INSERT INTO Race VALUES (7, 6, 2012, 'Formula 1', 23, 59, 3);
INSERT INTO Race VALUES (8, 3, 2018, 'Superbike', 26, 44, 2);