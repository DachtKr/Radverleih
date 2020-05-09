
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2020 12:34:25
-- Generated from EDMX file: C:\Users\I2CM Developer\Source\Repos\Radverleih\Radverleih\RadverleihLib\RadverleihModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Radverleih];
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

-- Creating table 'Kundes'
CREATE TABLE [dbo].[Kundes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Vorname] nvarchar(max)  NOT NULL,
    [Strasse] nvarchar(max)  NOT NULL,
    [Stadt] nvarchar(max)  NOT NULL,
    [Postleitzahl] nvarchar(max)  NOT NULL,
    [eMail] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Fortbewegungsmittels'
CREATE TABLE [dbo].[Fortbewegungsmittels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nummer] nvarchar(max)  NOT NULL,
    [Alter] int  NOT NULL,
    [Rückgabedatum] datetime  NOT NULL,
    [KundeId] int  NOT NULL,
    [ModellId] int  NOT NULL,
    [AblageId] int  NULL
);
GO

-- Creating table 'Modells'
CREATE TABLE [dbo].[Modells] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL,
    [Beschreibung] nvarchar(max)  NOT NULL,
    [Preis] decimal(18,0)  NOT NULL,
    [Größe] int  NOT NULL
);
GO

-- Creating table 'Ablages'
CREATE TABLE [dbo].[Ablages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Kundes'
ALTER TABLE [dbo].[Kundes]
ADD CONSTRAINT [PK_Kundes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fortbewegungsmittels'
ALTER TABLE [dbo].[Fortbewegungsmittels]
ADD CONSTRAINT [PK_Fortbewegungsmittels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Modells'
ALTER TABLE [dbo].[Modells]
ADD CONSTRAINT [PK_Modells]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ablages'
ALTER TABLE [dbo].[Ablages]
ADD CONSTRAINT [PK_Ablages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KundeId] in table 'Fortbewegungsmittels'
ALTER TABLE [dbo].[Fortbewegungsmittels]
ADD CONSTRAINT [FK_KundeFortbewegungsmittel]
    FOREIGN KEY ([KundeId])
    REFERENCES [dbo].[Kundes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeFortbewegungsmittel'
CREATE INDEX [IX_FK_KundeFortbewegungsmittel]
ON [dbo].[Fortbewegungsmittels]
    ([KundeId]);
GO

-- Creating foreign key on [ModellId] in table 'Fortbewegungsmittels'
ALTER TABLE [dbo].[Fortbewegungsmittels]
ADD CONSTRAINT [FK_FortbewegungsmittelModell]
    FOREIGN KEY ([ModellId])
    REFERENCES [dbo].[Modells]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FortbewegungsmittelModell'
CREATE INDEX [IX_FK_FortbewegungsmittelModell]
ON [dbo].[Fortbewegungsmittels]
    ([ModellId]);
GO

-- Creating foreign key on [AblageId] in table 'Fortbewegungsmittels'
ALTER TABLE [dbo].[Fortbewegungsmittels]
ADD CONSTRAINT [FK_FortbewegungsmittelAblage]
    FOREIGN KEY ([AblageId])
    REFERENCES [dbo].[Ablages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FortbewegungsmittelAblage'
CREATE INDEX [IX_FK_FortbewegungsmittelAblage]
ON [dbo].[Fortbewegungsmittels]
    ([AblageId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------