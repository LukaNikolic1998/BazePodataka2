
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/20/2021 10:40:32
-- Generated from EDMX file: D:\F\S8\BP2\Projekat\BpProjekat\BpProjekat\BpProjekatModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BpProjekatModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StripStamparija]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Strips] DROP CONSTRAINT [FK_StripStamparija];
GO
IF OBJECT_ID(N'[dbo].[FK_IzdajeIzdavac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdajes] DROP CONSTRAINT [FK_IzdajeIzdavac];
GO
IF OBJECT_ID(N'[dbo].[FK_StripIzdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdajes] DROP CONSTRAINT [FK_StripIzdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdajeStriparnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prodajes] DROP CONSTRAINT [FK_ProdajeStriparnica];
GO
IF OBJECT_ID(N'[dbo].[FK_StripUcestvuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucestvujes] DROP CONSTRAINT [FK_StripUcestvuje];
GO
IF OBJECT_ID(N'[dbo].[FK_UcestvujeFestival]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucestvujes] DROP CONSTRAINT [FK_UcestvujeFestival];
GO
IF OBJECT_ID(N'[dbo].[FK_FestivalDodeljuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dodeljujes] DROP CONSTRAINT [FK_FestivalDodeljuje];
GO
IF OBJECT_ID(N'[dbo].[FK_DodeljujeNagrada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dodeljujes] DROP CONSTRAINT [FK_DodeljujeNagrada];
GO
IF OBJECT_ID(N'[dbo].[FK_UcestvujeDodeljuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dodeljujes] DROP CONSTRAINT [FK_UcestvujeDodeljuje];
GO
IF OBJECT_ID(N'[dbo].[FK_StripProdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prodajes] DROP CONSTRAINT [FK_StripProdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_CrtacCrta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Crtas] DROP CONSTRAINT [FK_CrtacCrta];
GO
IF OBJECT_ID(N'[dbo].[FK_CrtaStrip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Crtas] DROP CONSTRAINT [FK_CrtaStrip];
GO
IF OBJECT_ID(N'[dbo].[FK_ScenaristaPise]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pises] DROP CONSTRAINT [FK_ScenaristaPise];
GO
IF OBJECT_ID(N'[dbo].[FK_PiseStrip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pises] DROP CONSTRAINT [FK_PiseStrip];
GO
IF OBJECT_ID(N'[dbo].[FK_KategorijaStrip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Strips] DROP CONSTRAINT [FK_KategorijaStrip];
GO
IF OBJECT_ID(N'[dbo].[FK_Crtac_inherits_Autor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autors_Crtac] DROP CONSTRAINT [FK_Crtac_inherits_Autor];
GO
IF OBJECT_ID(N'[dbo].[FK_Scenarista_inherits_Autor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autors_Scenarista] DROP CONSTRAINT [FK_Scenarista_inherits_Autor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Stamparijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stamparijas];
GO
IF OBJECT_ID(N'[dbo].[Izdavacs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Izdavacs];
GO
IF OBJECT_ID(N'[dbo].[Striparnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Striparnicas];
GO
IF OBJECT_ID(N'[dbo].[Nagradas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nagradas];
GO
IF OBJECT_ID(N'[dbo].[Kategorijas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategorijas];
GO
IF OBJECT_ID(N'[dbo].[Autors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autors];
GO
IF OBJECT_ID(N'[dbo].[Strips]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Strips];
GO
IF OBJECT_ID(N'[dbo].[Festivals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Festivals];
GO
IF OBJECT_ID(N'[dbo].[Izdajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Izdajes];
GO
IF OBJECT_ID(N'[dbo].[Prodajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prodajes];
GO
IF OBJECT_ID(N'[dbo].[Ucestvujes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ucestvujes];
GO
IF OBJECT_ID(N'[dbo].[Dodeljujes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dodeljujes];
GO
IF OBJECT_ID(N'[dbo].[Crtas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Crtas];
GO
IF OBJECT_ID(N'[dbo].[Pises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pises];
GO
IF OBJECT_ID(N'[dbo].[Autors_Crtac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autors_Crtac];
GO
IF OBJECT_ID(N'[dbo].[Autors_Scenarista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autors_Scenarista];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Stamparijas'
CREATE TABLE [dbo].[Stamparijas] (
    [idsta] int IDENTITY(1,1) NOT NULL,
    [imesta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Izdavacs'
CREATE TABLE [dbo].[Izdavacs] (
    [idi] int IDENTITY(1,1) NOT NULL,
    [imei] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Striparnicas'
CREATE TABLE [dbo].[Striparnicas] (
    [ids] int IDENTITY(1,1) NOT NULL,
    [imes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Nagradas'
CREATE TABLE [dbo].[Nagradas] (
    [idn] int IDENTITY(1,1) NOT NULL,
    [imen] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Kategorijas'
CREATE TABLE [dbo].[Kategorijas] (
    [idk] int NOT NULL,
    [imek] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Autors'
CREATE TABLE [dbo].[Autors] (
    [ida] int IDENTITY(1,1) NOT NULL,
    [tipaut] nvarchar(max)  NOT NULL,
    [imea] nvarchar(max)  NOT NULL,
    [prza] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Strips'
CREATE TABLE [dbo].[Strips] (
    [idstr] int IDENTITY(1,1) NOT NULL,
    [imestr] nvarchar(max)  NOT NULL,
    [Stamparija_idsta] int  NOT NULL,
    [Kategorija_idk] int  NOT NULL
);
GO

-- Creating table 'Festivals'
CREATE TABLE [dbo].[Festivals] (
    [idf] int IDENTITY(1,1) NOT NULL,
    [imef] nvarchar(max)  NOT NULL,
    [gododr] int  NOT NULL
);
GO

-- Creating table 'Izdajes'
CREATE TABLE [dbo].[Izdajes] (
    [Izdavac_idi] int  NOT NULL,
    [Strip_idstr3] int  NOT NULL
);
GO

-- Creating table 'Prodajes'
CREATE TABLE [dbo].[Prodajes] (
    [Striparnica_ids] int  NOT NULL,
    [Strip_idstr4] int  NOT NULL,
    [Strip_idstr] int  NOT NULL
);
GO

-- Creating table 'Ucestvujes'
CREATE TABLE [dbo].[Ucestvujes] (
    [Strip_idstr5] int  NOT NULL,
    [Festival_idf] int  NOT NULL
);
GO

-- Creating table 'Dodeljujes'
CREATE TABLE [dbo].[Dodeljujes] (
    [Festival_idf] int  NOT NULL,
    [Nagrada_idn] int  NOT NULL,
    [UcestvujeStrip_idstr] int  NOT NULL,
    [UcestvujeFestival_idf] int  NOT NULL
);
GO

-- Creating table 'Crtas'
CREATE TABLE [dbo].[Crtas] (
    [Crtac_ida] int  NOT NULL,
    [Strip_idstr2] int  NOT NULL
);
GO

-- Creating table 'Pises'
CREATE TABLE [dbo].[Pises] (
    [Scenarista_ida] int  NOT NULL,
    [Strip_idstr1] int  NOT NULL
);
GO

-- Creating table 'Autors_Crtac'
CREATE TABLE [dbo].[Autors_Crtac] (
    [ida] int  NOT NULL
);
GO

-- Creating table 'Autors_Scenarista'
CREATE TABLE [dbo].[Autors_Scenarista] (
    [ida] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idsta] in table 'Stamparijas'
ALTER TABLE [dbo].[Stamparijas]
ADD CONSTRAINT [PK_Stamparijas]
    PRIMARY KEY CLUSTERED ([idsta] ASC);
GO

-- Creating primary key on [idi] in table 'Izdavacs'
ALTER TABLE [dbo].[Izdavacs]
ADD CONSTRAINT [PK_Izdavacs]
    PRIMARY KEY CLUSTERED ([idi] ASC);
GO

-- Creating primary key on [ids] in table 'Striparnicas'
ALTER TABLE [dbo].[Striparnicas]
ADD CONSTRAINT [PK_Striparnicas]
    PRIMARY KEY CLUSTERED ([ids] ASC);
GO

-- Creating primary key on [idn] in table 'Nagradas'
ALTER TABLE [dbo].[Nagradas]
ADD CONSTRAINT [PK_Nagradas]
    PRIMARY KEY CLUSTERED ([idn] ASC);
GO

-- Creating primary key on [idk] in table 'Kategorijas'
ALTER TABLE [dbo].[Kategorijas]
ADD CONSTRAINT [PK_Kategorijas]
    PRIMARY KEY CLUSTERED ([idk] ASC);
GO

-- Creating primary key on [ida] in table 'Autors'
ALTER TABLE [dbo].[Autors]
ADD CONSTRAINT [PK_Autors]
    PRIMARY KEY CLUSTERED ([ida] ASC);
GO

-- Creating primary key on [idstr] in table 'Strips'
ALTER TABLE [dbo].[Strips]
ADD CONSTRAINT [PK_Strips]
    PRIMARY KEY CLUSTERED ([idstr] ASC);
GO

-- Creating primary key on [idf] in table 'Festivals'
ALTER TABLE [dbo].[Festivals]
ADD CONSTRAINT [PK_Festivals]
    PRIMARY KEY CLUSTERED ([idf] ASC);
GO

-- Creating primary key on [Izdavac_idi], [Strip_idstr3] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [PK_Izdajes]
    PRIMARY KEY CLUSTERED ([Izdavac_idi], [Strip_idstr3] ASC);
GO

-- Creating primary key on [Striparnica_ids], [Strip_idstr4] in table 'Prodajes'
ALTER TABLE [dbo].[Prodajes]
ADD CONSTRAINT [PK_Prodajes]
    PRIMARY KEY CLUSTERED ([Striparnica_ids], [Strip_idstr4] ASC);
GO

-- Creating primary key on [Strip_idstr5], [Festival_idf] in table 'Ucestvujes'
ALTER TABLE [dbo].[Ucestvujes]
ADD CONSTRAINT [PK_Ucestvujes]
    PRIMARY KEY CLUSTERED ([Strip_idstr5], [Festival_idf] ASC);
GO

-- Creating primary key on [Festival_idf], [Nagrada_idn] in table 'Dodeljujes'
ALTER TABLE [dbo].[Dodeljujes]
ADD CONSTRAINT [PK_Dodeljujes]
    PRIMARY KEY CLUSTERED ([Festival_idf], [Nagrada_idn] ASC);
GO

-- Creating primary key on [Crtac_ida], [Strip_idstr2] in table 'Crtas'
ALTER TABLE [dbo].[Crtas]
ADD CONSTRAINT [PK_Crtas]
    PRIMARY KEY CLUSTERED ([Crtac_ida], [Strip_idstr2] ASC);
GO

-- Creating primary key on [Scenarista_ida], [Strip_idstr1] in table 'Pises'
ALTER TABLE [dbo].[Pises]
ADD CONSTRAINT [PK_Pises]
    PRIMARY KEY CLUSTERED ([Scenarista_ida], [Strip_idstr1] ASC);
GO

-- Creating primary key on [ida] in table 'Autors_Crtac'
ALTER TABLE [dbo].[Autors_Crtac]
ADD CONSTRAINT [PK_Autors_Crtac]
    PRIMARY KEY CLUSTERED ([ida] ASC);
GO

-- Creating primary key on [ida] in table 'Autors_Scenarista'
ALTER TABLE [dbo].[Autors_Scenarista]
ADD CONSTRAINT [PK_Autors_Scenarista]
    PRIMARY KEY CLUSTERED ([ida] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Stamparija_idsta] in table 'Strips'
ALTER TABLE [dbo].[Strips]
ADD CONSTRAINT [FK_StripStamparija]
    FOREIGN KEY ([Stamparija_idsta])
    REFERENCES [dbo].[Stamparijas]
        ([idsta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StripStamparija'
CREATE INDEX [IX_FK_StripStamparija]
ON [dbo].[Strips]
    ([Stamparija_idsta]);
GO

-- Creating foreign key on [Izdavac_idi] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_IzdajeIzdavac]
    FOREIGN KEY ([Izdavac_idi])
    REFERENCES [dbo].[Izdavacs]
        ([idi])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Strip_idstr3] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_StripIzdaje]
    FOREIGN KEY ([Strip_idstr3])
    REFERENCES [dbo].[Strips]
        ([idstr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StripIzdaje'
CREATE INDEX [IX_FK_StripIzdaje]
ON [dbo].[Izdajes]
    ([Strip_idstr3]);
GO

-- Creating foreign key on [Striparnica_ids] in table 'Prodajes'
ALTER TABLE [dbo].[Prodajes]
ADD CONSTRAINT [FK_ProdajeStriparnica]
    FOREIGN KEY ([Striparnica_ids])
    REFERENCES [dbo].[Striparnicas]
        ([ids])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Strip_idstr5] in table 'Ucestvujes'
ALTER TABLE [dbo].[Ucestvujes]
ADD CONSTRAINT [FK_StripUcestvuje]
    FOREIGN KEY ([Strip_idstr5])
    REFERENCES [dbo].[Strips]
        ([idstr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Festival_idf] in table 'Ucestvujes'
ALTER TABLE [dbo].[Ucestvujes]
ADD CONSTRAINT [FK_UcestvujeFestival]
    FOREIGN KEY ([Festival_idf])
    REFERENCES [dbo].[Festivals]
        ([idf])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UcestvujeFestival'
CREATE INDEX [IX_FK_UcestvujeFestival]
ON [dbo].[Ucestvujes]
    ([Festival_idf]);
GO

-- Creating foreign key on [Festival_idf] in table 'Dodeljujes'
ALTER TABLE [dbo].[Dodeljujes]
ADD CONSTRAINT [FK_FestivalDodeljuje]
    FOREIGN KEY ([Festival_idf])
    REFERENCES [dbo].[Festivals]
        ([idf])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Nagrada_idn] in table 'Dodeljujes'
ALTER TABLE [dbo].[Dodeljujes]
ADD CONSTRAINT [FK_DodeljujeNagrada]
    FOREIGN KEY ([Nagrada_idn])
    REFERENCES [dbo].[Nagradas]
        ([idn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DodeljujeNagrada'
CREATE INDEX [IX_FK_DodeljujeNagrada]
ON [dbo].[Dodeljujes]
    ([Nagrada_idn]);
GO

-- Creating foreign key on [UcestvujeStrip_idstr], [UcestvujeFestival_idf] in table 'Dodeljujes'
ALTER TABLE [dbo].[Dodeljujes]
ADD CONSTRAINT [FK_UcestvujeDodeljuje]
    FOREIGN KEY ([UcestvujeStrip_idstr], [UcestvujeFestival_idf])
    REFERENCES [dbo].[Ucestvujes]
        ([Strip_idstr5], [Festival_idf])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UcestvujeDodeljuje'
CREATE INDEX [IX_FK_UcestvujeDodeljuje]
ON [dbo].[Dodeljujes]
    ([UcestvujeStrip_idstr], [UcestvujeFestival_idf]);
GO

-- Creating foreign key on [Strip_idstr] in table 'Prodajes'
ALTER TABLE [dbo].[Prodajes]
ADD CONSTRAINT [FK_StripProdaje]
    FOREIGN KEY ([Strip_idstr])
    REFERENCES [dbo].[Strips]
        ([idstr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StripProdaje'
CREATE INDEX [IX_FK_StripProdaje]
ON [dbo].[Prodajes]
    ([Strip_idstr]);
GO

-- Creating foreign key on [Crtac_ida] in table 'Crtas'
ALTER TABLE [dbo].[Crtas]
ADD CONSTRAINT [FK_CrtacCrta]
    FOREIGN KEY ([Crtac_ida])
    REFERENCES [dbo].[Autors_Crtac]
        ([ida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Strip_idstr2] in table 'Crtas'
ALTER TABLE [dbo].[Crtas]
ADD CONSTRAINT [FK_CrtaStrip]
    FOREIGN KEY ([Strip_idstr2])
    REFERENCES [dbo].[Strips]
        ([idstr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CrtaStrip'
CREATE INDEX [IX_FK_CrtaStrip]
ON [dbo].[Crtas]
    ([Strip_idstr2]);
GO

-- Creating foreign key on [Scenarista_ida] in table 'Pises'
ALTER TABLE [dbo].[Pises]
ADD CONSTRAINT [FK_ScenaristaPise]
    FOREIGN KEY ([Scenarista_ida])
    REFERENCES [dbo].[Autors_Scenarista]
        ([ida])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Strip_idstr1] in table 'Pises'
ALTER TABLE [dbo].[Pises]
ADD CONSTRAINT [FK_PiseStrip]
    FOREIGN KEY ([Strip_idstr1])
    REFERENCES [dbo].[Strips]
        ([idstr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PiseStrip'
CREATE INDEX [IX_FK_PiseStrip]
ON [dbo].[Pises]
    ([Strip_idstr1]);
GO

-- Creating foreign key on [Kategorija_idk] in table 'Strips'
ALTER TABLE [dbo].[Strips]
ADD CONSTRAINT [FK_KategorijaStrip]
    FOREIGN KEY ([Kategorija_idk])
    REFERENCES [dbo].[Kategorijas]
        ([idk])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KategorijaStrip'
CREATE INDEX [IX_FK_KategorijaStrip]
ON [dbo].[Strips]
    ([Kategorija_idk]);
GO

-- Creating foreign key on [ida] in table 'Autors_Crtac'
ALTER TABLE [dbo].[Autors_Crtac]
ADD CONSTRAINT [FK_Crtac_inherits_Autor]
    FOREIGN KEY ([ida])
    REFERENCES [dbo].[Autors]
        ([ida])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ida] in table 'Autors_Scenarista'
ALTER TABLE [dbo].[Autors_Scenarista]
ADD CONSTRAINT [FK_Scenarista_inherits_Autor]
    FOREIGN KEY ([ida])
    REFERENCES [dbo].[Autors]
        ([ida])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

CREATE OR ALTER PROCEDURE P_INS_Festival
(
@P_Ime NVARCHAR(20),
@P_God INT
)
AS
BEGIN TRY
INSERT INTO Festivals(imef,gododr)
VALUES (@P_Ime, @P_God);
END TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

CREATE OR ALTER PROCEDURE P_SEL_Ime
(@P_Id INT,
@P_Ime NVARCHAR(20) OUT)
AS
BEGIN TRY
SELECT @P_Ime = imef FROM Festivals
WHERE idf = @P_Id;
END TRY
BEGIN CATCH
SELECT
ERROR_NUMBER() AS ErrorNumber
,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
GO

CREATE OR ALTER FUNCTION F_GET_StripPoKategoriji
(
@P_idk INT
) RETURNS TABLE
AS
RETURN
SELECT imestr FROM Strips
WHERE Kategorija_idk = @P_idk;
GO

CREATE OR ALTER FUNCTION F_GET_BrojStripova
() RETURNS DECIMAL
AS
BEGIN
DECLARE
@return_value AS DECIMAL;
SELECT @return_value = count(*) FROM Strips;
RETURN @return_value;
END;
GO

CREATE OR ALTER TRIGGER TriggerCreateStrip
ON [dbo].[Strips]
FOR INSERT
AS;
declare @empname varchar(100);
select @empname=i.imestr from inserted i;
insert into AuditStrip
(ime,op,date)
values(@empname,'create',getdate());
GO

CREATE OR ALTER TRIGGER TriggerDeleteStrip
ON [dbo].[Strips]
FOR DELETE
AS
;
declare @empname varchar(100);
select @empname=i.imestr from deleted i;
insert into AuditStrip
(ime,op,date)
values(@empname,'delete',getdate());
GO

CREATE INDEX [IndexImeStripa] ON [dbo].[Strips] (idstr);
GO

CREATE OR ALTER PROCEDURE P_StripoviPoKategoriji
(@id INT,@ime VARCHAR(100) OUTPUT)
AS
DECLARE STRIP_CURSOR CURSOR
FOR SELECT imestr FROM Strips WHERE Kategorija_idk = @id;
DECLARE
@i VARCHAR(100);
BEGIN
OPEN STRIP_CURSOR;
WHILE @@FETCH_STATUS = 0
BEGIN
SET @ime = CONCAT(@ime,@i,'*');
FETCH NEXT FROM STRIP_CURSOR
INTO @i;
END;
CLOSE STRIP_CURSOR;
DEALLOCATE STRIP_CURSOR;
END;
GO

CREATE OR ALTER FUNCTION F_GET_TriTabele()
RETURNS TABLE
AS
RETURN
SELECT k.imek,s.imestr,st.imesta FROM 
Kategorijas k inner join Strips s on k.idk = s.Kategorija_idk
inner join Stamparijas st on s.Stamparija_idsta = st.idsta;
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------