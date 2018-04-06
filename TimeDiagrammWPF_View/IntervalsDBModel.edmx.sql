
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2018 14:51:22
-- Generated from EDMX file: d:\#Documents\Visual Studio 2015\Projects\TimeDiagramm\TimeDiagrammWPF_View\IntervalsDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;

GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'IntervalSet'
CREATE TABLE [dbo].[IntervalSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] time  NOT NULL,
    [Duration] time  NOT NULL,
    [SpecialLevel] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'IntervalSet'
ALTER TABLE [dbo].[IntervalSet]
ADD CONSTRAINT [PK_IntervalSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------