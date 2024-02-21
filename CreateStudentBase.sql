CREATE DATABASE StudentBase


USE StudentBase
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (MAX) NOT NULL,
    [MiddleName]   NVARCHAR (MAX) NOT NULL,
    [Lastname]     NVARCHAR (MAX) NOT NULL,
    [Group]        NVARCHAR (MAX) NOT NULL,
    [AverageGrade] FLOAT (53)     NOT NULL,
    [BestSubject]  NVARCHAR (MAX) NOT NULL,
    [WorstSubject] NVARCHAR (MAX) NOT NULL
);


