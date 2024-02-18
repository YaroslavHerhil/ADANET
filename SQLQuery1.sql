CREATE DATABASE TheSecondBase

USE TheSecondBase

CREATE TABLE TheSecondBase(
	[ID] INT Primary key Identity(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[Group] NVARCHAR(MAX) NOT NULL,
	[Grade] FLOAT NOT NULL,
)