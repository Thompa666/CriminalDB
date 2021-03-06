USE [master]
GO

CREATE DATABASE [NationalCriminalDB]
GO

USE [NationalCriminalDB]
GO

CREATE TABLE [dbo].[Offense](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OffenserID] [int] NOT NULL,
	[CrimeDate] [date] NULL,
	[CrimeCountry] [nvarchar](50) NULL,
	[CaseNumber] [nchar](12) NULL,
	[OffenseCode] [nchar](12) NULL,
	[Category] [nvarchar](50) NULL,
	[Degree] [nvarchar](50) NULL,
	[Disposition] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Offense] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
)
GO

INSERT [dbo].[Offense] ([OffenseID],[OffenderID], [CrimeDate], [CrimeCountry], [CaseNumber], [OffenseCode], [Category], [Degree], [Disposition], [Description]) VALUES (1, 2, CAST('2004-2-17' AS Date), 'ALACHUA', '012012CF0123', '7840412A    ', 'CRIMINAL', 'FT', 'GUILTY', 'AGGRAVATED BATTERY WITH DEADLY WEAPON')
INSERT [dbo].[Offense] ([OffenseID],[OffenderID], [CrimeDate], [CrimeCountry], [CaseNumber], [OffenseCode], [Category], [Degree], [Disposition], [Description]) VALUES (2, 1, CAST('1996-12-4' AS Date), 'ALACHUA', '012004111CF0', '89313       ', 'FELONY', 'FF', 'GUILTY', 'POSSESSION OF CONTROLLED SUBSTANCE: COCAINE')

CREATE TABLE [dbo].[Offender](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [nchar](1) NULL,
	[Nationality] [nvarchar](50) NULL,
	[Height] [int] NULL,
	[Weight] [int] NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Offender] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
)
GO

INSERT [dbo].[Offender] ([OffenderID], [FirstName], [LastName], [DateOfBirth], [Gender], [Nationality], [Height], [Weight], [Country], [City], [Address]) VALUES (1, 'ANTHONY', 'PARK', CAST('1972-1-17' AS Date), 'M', 'American', 187, 89, 'America ', 'Florida', '263 W 32nd PLACE APT. A, GAINESVILLE, FL 32608')
INSERT [dbo].[Offender] ([OffenderID], [FirstName], [LastName], [DateOfBirth], [Gender], [Nationality], [Height], [Weight], [Country], [City], [Address]) VALUES (2, 'JONATHEN', 'KIM', CAST('1968-6-10' AS Date), 'M', 'British', 156, 59, 'America', 'Washington', '2430 Nouakchott Place,Washington, DC 20521-2430')

