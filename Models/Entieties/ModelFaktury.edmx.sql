
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/01/2023 18:53:46
-- Generated from EDMX file: C:\Users\48728\Desktop\ERPNaviProject\Firma\Firma\Firma\Models\Entieties\ModelFaktury.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Projekt_Prog_Aplik_Destop];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Faktura_Kontrahent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Faktura] DROP CONSTRAINT [FK_Faktura_Kontrahent];
GO
IF OBJECT_ID(N'[dbo].[FK_Faktura_SposobPlatnosci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Faktura] DROP CONSTRAINT [FK_Faktura_SposobPlatnosci];
GO
IF OBJECT_ID(N'[dbo].[FK_Kontrahent_Adres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kontrahent] DROP CONSTRAINT [FK_Kontrahent_Adres];
GO
IF OBJECT_ID(N'[dbo].[FK_Kontrahent_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kontrahent] DROP CONSTRAINT [FK_Kontrahent_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_Kontrahent_Status1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kontrahent] DROP CONSTRAINT [FK_Kontrahent_Status1];
GO
IF OBJECT_ID(N'[dbo].[FK_KorektaFakturySprzedazy_Faktura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KorektaFakturySprzedazy] DROP CONSTRAINT [FK_KorektaFakturySprzedazy_Faktura];
GO
IF OBJECT_ID(N'[dbo].[FK_PozycjaFaktury_Faktura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PozycjaFaktury] DROP CONSTRAINT [FK_PozycjaFaktury_Faktura];
GO
IF OBJECT_ID(N'[dbo].[FK_PozycjaFaktury_Towar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PozycjaFaktury] DROP CONSTRAINT [FK_PozycjaFaktury_Towar];
GO
IF OBJECT_ID(N'[dbo].[FK_StanyMagazynowe_Towar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StanyMagazynowe] DROP CONSTRAINT [FK_StanyMagazynowe_Towar];
GO
IF OBJECT_ID(N'[dbo].[FK_StratyMagazynoweIZwroty_Towar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StratyMagazynoweIZwroty] DROP CONSTRAINT [FK_StratyMagazynoweIZwroty_Towar];
GO
IF OBJECT_ID(N'[dbo].[FK_Towar_StanyMagazynowe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Towar] DROP CONSTRAINT [FK_Towar_StanyMagazynowe];
GO
IF OBJECT_ID(N'[dbo].[FK_Towar_Status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Towar] DROP CONSTRAINT [FK_Towar_Status];
GO
IF OBJECT_ID(N'[dbo].[FK_UzytkowicyERP_Kadry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UzytkowicyERP] DROP CONSTRAINT [FK_UzytkowicyERP_Kadry];
GO
IF OBJECT_ID(N'[dbo].[FK_ZamowieniaOdKlientow_Kontrahent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaOdKlientow] DROP CONSTRAINT [FK_ZamowieniaOdKlientow_Kontrahent];
GO
IF OBJECT_ID(N'[dbo].[FK_ZamowieniaOdKlientow_Towar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaOdKlientow] DROP CONSTRAINT [FK_ZamowieniaOdKlientow_Towar];
GO
IF OBJECT_ID(N'[dbo].[FK_ZamowieniaWMS_ZamowieniaOdKlientow]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaWMS] DROP CONSTRAINT [FK_ZamowieniaWMS_ZamowieniaOdKlientow];
GO
IF OBJECT_ID(N'[dbo].[FK_ZamowieniaWMS_ZamowieniaOdKlientow1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZamowieniaWMS] DROP CONSTRAINT [FK_ZamowieniaWMS_ZamowieniaOdKlientow1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Adres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adres];
GO
IF OBJECT_ID(N'[dbo].[BibliotekaDokumentow]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BibliotekaDokumentow];
GO
IF OBJECT_ID(N'[dbo].[Faktura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faktura];
GO
IF OBJECT_ID(N'[dbo].[InformatorTowaru]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InformatorTowaru];
GO
IF OBJECT_ID(N'[dbo].[JednostkiMiary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JednostkiMiary];
GO
IF OBJECT_ID(N'[dbo].[Kadry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kadry];
GO
IF OBJECT_ID(N'[dbo].[Kontrahent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kontrahent];
GO
IF OBJECT_ID(N'[dbo].[KorektaFakturySprzedazy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KorektaFakturySprzedazy];
GO
IF OBJECT_ID(N'[dbo].[PozycjaFaktury]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PozycjaFaktury];
GO
IF OBJECT_ID(N'[dbo].[Przetargi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Przetargi];
GO
IF OBJECT_ID(N'[dbo].[Rodzaj]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rodzaj];
GO
IF OBJECT_ID(N'[dbo].[SposobPlatnosci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SposobPlatnosci];
GO
IF OBJECT_ID(N'[dbo].[StanyMagazynowe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StanyMagazynowe];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[StratyMagazynoweIZwroty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StratyMagazynoweIZwroty];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Towar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Towar];
GO
IF OBJECT_ID(N'[dbo].[UzytkowicyERP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UzytkowicyERP];
GO
IF OBJECT_ID(N'[dbo].[ZamowieniaOdKlientow]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZamowieniaOdKlientow];
GO
IF OBJECT_ID(N'[dbo].[ZamowieniaWMS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZamowieniaWMS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Adres'
CREATE TABLE [dbo].[Adres] (
    [IdAdresu] int IDENTITY(1,1) NOT NULL,
    [Ulica] nvarchar(50)  NULL,
    [Miejscowosc] nvarchar(50)  NULL,
    [NrDomu] nchar(10)  NULL,
    [NrLokalu] nchar(10)  NULL,
    [KodPocztowy] nchar(10)  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'BibliotekaDokumentow'
CREATE TABLE [dbo].[BibliotekaDokumentow] (
    [IdDokumentuBiblioteki] int IDENTITY(1,1) NOT NULL,
    [Odbiorca] nvarchar(50)  NULL,
    [NrDok] nchar(10)  NULL,
    [Opis] nvarchar(50)  NULL,
    [CzyAktywny] bit  NULL,
    [Numer] nvarchar(50)  NULL
);
GO

-- Creating table 'Faktura'
CREATE TABLE [dbo].[Faktura] (
    [IdFaktury] int IDENTITY(1,1) NOT NULL,
    [Numer] nchar(10)  NULL,
    [DataWystawienia] datetime  NULL,
    [IdKontrahenta] int  NULL,
    [TerminPłatnosci] datetime  NULL,
    [IdSposobuPlatnosci] int  NULL,
    [CzyZatwierdzono] bit  NULL,
    [CzyAktywna] bit  NULL
);
GO

-- Creating table 'InformatorTowaru'
CREATE TABLE [dbo].[InformatorTowaru] (
    [IdInformatoraTowaru] int IDENTITY(1,1) NOT NULL,
    [Data_utworzenie_zlecenia] datetime  NULL,
    [IdFaktury] int  NULL,
    [IdKontrahenta] int  NULL,
    [IdZamowieniaOdKlientow] int  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'JednostkiMiary'
CREATE TABLE [dbo].[JednostkiMiary] (
    [Opakowanie] nvarchar(50)  NOT NULL,
    [IDJednostkiMiary] int IDENTITY(1,1) NOT NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'Kadry'
CREATE TABLE [dbo].[Kadry] (
    [IdPracownika] int IDENTITY(1,1) NOT NULL,
    [ImiePracownika] nvarchar(50)  NULL,
    [NazwiskoPracownika] nvarchar(50)  NULL,
    [DataZatrudnieniaPracownika] datetime  NULL,
    [MiastoZamieszkaniaPracownika] nvarchar(50)  NULL,
    [KodPocztowyPracownika] nvarchar(50)  NULL,
    [UlicaPracownika] nvarchar(50)  NULL,
    [NrDomu_mieszkaniaPracownika] nvarchar(50)  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'Kontrahent'
CREATE TABLE [dbo].[Kontrahent] (
    [IdKontrahenta] int IDENTITY(1,1) NOT NULL,
    [Kod] nvarchar(50)  NOT NULL,
    [NIP] nvarchar(50)  NOT NULL,
    [Nazwa] nvarchar(50)  NOT NULL,
    [IdRodzaju] int  NOT NULL,
    [IdStatusu] int  NOT NULL,
    [IdAdresu] int  NOT NULL,
    [DataPrzystapienia] datetime  NOT NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'KorektaFakturySprzedazy'
CREATE TABLE [dbo].[KorektaFakturySprzedazy] (
    [IdKorektyFaktury] int IDENTITY(1,1) NOT NULL,
    [IdFaktury] int  NULL,
    [DataWystawieniaKorekty] datetime  NULL,
    [CzyZatwierdzono] bit  NULL,
    [CzyAktywny] bit  NULL,
    [Numer] nvarchar(50)  NULL
);
GO

-- Creating table 'PozycjaFaktury'
CREATE TABLE [dbo].[PozycjaFaktury] (
    [IdPozycjiFaktury] int  NOT NULL,
    [IdFaktury] int  NOT NULL,
    [IdTowaru] int  NOT NULL,
    [CenaNetto] decimal(19,4)  NOT NULL,
    [Ilosc] decimal(18,0)  NOT NULL,
    [Rabat] decimal(18,0)  NOT NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'Przetargi'
CREATE TABLE [dbo].[Przetargi] (
    [IDPrzetargu] int IDENTITY(1,1) NOT NULL,
    [NrPrzetargu] nchar(10)  NULL,
    [NazwaPrzetargu] nvarchar(50)  NULL,
    [DataOgloszenia] datetime  NULL,
    [DataZakonczenia] datetime  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'Rodzaj'
CREATE TABLE [dbo].[Rodzaj] (
    [IdRodzaju] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(50)  NULL,
    [Opis] nvarchar(50)  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'SposobPlatnosci'
CREATE TABLE [dbo].[SposobPlatnosci] (
    [IdSposobuPlatnosci] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(50)  NULL,
    [Opis] nvarchar(max)  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'StanyMagazynowe'
CREATE TABLE [dbo].[StanyMagazynowe] (
    [IdStanuMagazynowego] int IDENTITY(1,1) NOT NULL,
    [IdTowaru] int  NULL,
    [DataPrzyjecia] datetime  NULL,
    [DataPrzydatnosciDoUzycia] datetime  NULL,
    [IloscPrzyjeta] int  NULL,
    [CzyAktywny] bit  NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [IdStatusu] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(50)  NULL,
    [CzyAktywny] nchar(10)  NULL
);
GO

-- Creating table 'StratyMagazynoweIZwroty'
CREATE TABLE [dbo].[StratyMagazynoweIZwroty] (
    [IdStratMagazynowychIZwrotow] int IDENTITY(1,1) NOT NULL,
    [IdTowaru] int  NULL,
    [DataZgloszenia] datetime  NULL,
    [Opis] varchar(50)  NULL,
    [CzyAktywny] bit  NULL,
    [Numer] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Towar'
CREATE TABLE [dbo].[Towar] (
    [IdTowaru] int IDENTITY(1,1) NOT NULL,
    [Kod] nvarchar(50)  NOT NULL,
    [NazwaTowaru] nvarchar(50)  NOT NULL,
    [StawkaVatSprzedazy] decimal(18,0)  NOT NULL,
    [CenaNetto] decimal(19,4)  NOT NULL,
    [Marza] decimal(18,0)  NOT NULL,
    [CzyAktywny] bit  NULL,
    [IdStanuMagazynowego] int  NULL,
    [IdStatusu] int  NULL
);
GO

-- Creating table 'UzytkowicyERP'
CREATE TABLE [dbo].[UzytkowicyERP] (
    [IDUzytkownikaERP] int IDENTITY(1,1) NOT NULL,
    [Stanowisko] nvarchar(50)  NULL,
    [Dzial] nvarchar(50)  NULL,
    [CzyAktywny] bit  NULL,
    [IDPracownika] int  NULL
);
GO

-- Creating table 'ZamowieniaOdKlientow'
CREATE TABLE [dbo].[ZamowieniaOdKlientow] (
    [IdZamowieniaOdKlientow] int IDENTITY(1,1) NOT NULL,
    [IdTowaru] int  NULL,
    [IloscZamowiona] int  NULL,
    [Opis] nvarchar(50)  NULL,
    [Data_utworzenia_zlecenia] datetime  NULL,
    [CzyAktywny] bit  NULL,
    [IdKontrahenta] int  NULL,
    [IdStanuMagazynowego] int  NULL,
    [Numer] nvarchar(50)  NULL
);
GO

-- Creating table 'ZamowieniaWMS'
CREATE TABLE [dbo].[ZamowieniaWMS] (
    [IdZamowieniaWMS] int IDENTITY(1,1) NOT NULL,
    [Data_utworzenia_zlecenia] datetime  NULL,
    [IdZamowieniaOdKlienta] int  NULL,
    [IloscWydana] int  NULL,
    [IdTowaru] int  NULL,
    [CzyAktywny] bit  NULL,
    [IdKontrahenta] int  NULL,
    [Numer] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAdresu] in table 'Adres'
ALTER TABLE [dbo].[Adres]
ADD CONSTRAINT [PK_Adres]
    PRIMARY KEY CLUSTERED ([IdAdresu] ASC);
GO

-- Creating primary key on [IdDokumentuBiblioteki] in table 'BibliotekaDokumentow'
ALTER TABLE [dbo].[BibliotekaDokumentow]
ADD CONSTRAINT [PK_BibliotekaDokumentow]
    PRIMARY KEY CLUSTERED ([IdDokumentuBiblioteki] ASC);
GO

-- Creating primary key on [IdFaktury] in table 'Faktura'
ALTER TABLE [dbo].[Faktura]
ADD CONSTRAINT [PK_Faktura]
    PRIMARY KEY CLUSTERED ([IdFaktury] ASC);
GO

-- Creating primary key on [IdInformatoraTowaru] in table 'InformatorTowaru'
ALTER TABLE [dbo].[InformatorTowaru]
ADD CONSTRAINT [PK_InformatorTowaru]
    PRIMARY KEY CLUSTERED ([IdInformatoraTowaru] ASC);
GO

-- Creating primary key on [IDJednostkiMiary] in table 'JednostkiMiary'
ALTER TABLE [dbo].[JednostkiMiary]
ADD CONSTRAINT [PK_JednostkiMiary]
    PRIMARY KEY CLUSTERED ([IDJednostkiMiary] ASC);
GO

-- Creating primary key on [IdPracownika] in table 'Kadry'
ALTER TABLE [dbo].[Kadry]
ADD CONSTRAINT [PK_Kadry]
    PRIMARY KEY CLUSTERED ([IdPracownika] ASC);
GO

-- Creating primary key on [IdKontrahenta] in table 'Kontrahent'
ALTER TABLE [dbo].[Kontrahent]
ADD CONSTRAINT [PK_Kontrahent]
    PRIMARY KEY CLUSTERED ([IdKontrahenta] ASC);
GO

-- Creating primary key on [IdKorektyFaktury] in table 'KorektaFakturySprzedazy'
ALTER TABLE [dbo].[KorektaFakturySprzedazy]
ADD CONSTRAINT [PK_KorektaFakturySprzedazy]
    PRIMARY KEY CLUSTERED ([IdKorektyFaktury] ASC);
GO

-- Creating primary key on [IdPozycjiFaktury] in table 'PozycjaFaktury'
ALTER TABLE [dbo].[PozycjaFaktury]
ADD CONSTRAINT [PK_PozycjaFaktury]
    PRIMARY KEY CLUSTERED ([IdPozycjiFaktury] ASC);
GO

-- Creating primary key on [IDPrzetargu] in table 'Przetargi'
ALTER TABLE [dbo].[Przetargi]
ADD CONSTRAINT [PK_Przetargi]
    PRIMARY KEY CLUSTERED ([IDPrzetargu] ASC);
GO

-- Creating primary key on [IdRodzaju] in table 'Rodzaj'
ALTER TABLE [dbo].[Rodzaj]
ADD CONSTRAINT [PK_Rodzaj]
    PRIMARY KEY CLUSTERED ([IdRodzaju] ASC);
GO

-- Creating primary key on [IdSposobuPlatnosci] in table 'SposobPlatnosci'
ALTER TABLE [dbo].[SposobPlatnosci]
ADD CONSTRAINT [PK_SposobPlatnosci]
    PRIMARY KEY CLUSTERED ([IdSposobuPlatnosci] ASC);
GO

-- Creating primary key on [IdStanuMagazynowego] in table 'StanyMagazynowe'
ALTER TABLE [dbo].[StanyMagazynowe]
ADD CONSTRAINT [PK_StanyMagazynowe]
    PRIMARY KEY CLUSTERED ([IdStanuMagazynowego] ASC);
GO

-- Creating primary key on [IdStatusu] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([IdStatusu] ASC);
GO

-- Creating primary key on [IdStratMagazynowychIZwrotow] in table 'StratyMagazynoweIZwroty'
ALTER TABLE [dbo].[StratyMagazynoweIZwroty]
ADD CONSTRAINT [PK_StratyMagazynoweIZwroty]
    PRIMARY KEY CLUSTERED ([IdStratMagazynowychIZwrotow] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [IdTowaru] in table 'Towar'
ALTER TABLE [dbo].[Towar]
ADD CONSTRAINT [PK_Towar]
    PRIMARY KEY CLUSTERED ([IdTowaru] ASC);
GO

-- Creating primary key on [IDUzytkownikaERP] in table 'UzytkowicyERP'
ALTER TABLE [dbo].[UzytkowicyERP]
ADD CONSTRAINT [PK_UzytkowicyERP]
    PRIMARY KEY CLUSTERED ([IDUzytkownikaERP] ASC);
GO

-- Creating primary key on [IdZamowieniaOdKlientow] in table 'ZamowieniaOdKlientow'
ALTER TABLE [dbo].[ZamowieniaOdKlientow]
ADD CONSTRAINT [PK_ZamowieniaOdKlientow]
    PRIMARY KEY CLUSTERED ([IdZamowieniaOdKlientow] ASC);
GO

-- Creating primary key on [IdZamowieniaWMS] in table 'ZamowieniaWMS'
ALTER TABLE [dbo].[ZamowieniaWMS]
ADD CONSTRAINT [PK_ZamowieniaWMS]
    PRIMARY KEY CLUSTERED ([IdZamowieniaWMS] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdAdresu] in table 'Kontrahent'
ALTER TABLE [dbo].[Kontrahent]
ADD CONSTRAINT [FK_Kontrahent_Adres]
    FOREIGN KEY ([IdAdresu])
    REFERENCES [dbo].[Adres]
        ([IdAdresu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kontrahent_Adres'
CREATE INDEX [IX_FK_Kontrahent_Adres]
ON [dbo].[Kontrahent]
    ([IdAdresu]);
GO

-- Creating foreign key on [IdKontrahenta] in table 'Faktura'
ALTER TABLE [dbo].[Faktura]
ADD CONSTRAINT [FK_Faktura_Kontrahent]
    FOREIGN KEY ([IdKontrahenta])
    REFERENCES [dbo].[Kontrahent]
        ([IdKontrahenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Faktura_Kontrahent'
CREATE INDEX [IX_FK_Faktura_Kontrahent]
ON [dbo].[Faktura]
    ([IdKontrahenta]);
GO

-- Creating foreign key on [IdSposobuPlatnosci] in table 'Faktura'
ALTER TABLE [dbo].[Faktura]
ADD CONSTRAINT [FK_Faktura_SposobPlatnosci]
    FOREIGN KEY ([IdSposobuPlatnosci])
    REFERENCES [dbo].[SposobPlatnosci]
        ([IdSposobuPlatnosci])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Faktura_SposobPlatnosci'
CREATE INDEX [IX_FK_Faktura_SposobPlatnosci]
ON [dbo].[Faktura]
    ([IdSposobuPlatnosci]);
GO

-- Creating foreign key on [IdFaktury] in table 'KorektaFakturySprzedazy'
ALTER TABLE [dbo].[KorektaFakturySprzedazy]
ADD CONSTRAINT [FK_KorektaFakturySprzedazy_Faktura]
    FOREIGN KEY ([IdFaktury])
    REFERENCES [dbo].[Faktura]
        ([IdFaktury])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KorektaFakturySprzedazy_Faktura'
CREATE INDEX [IX_FK_KorektaFakturySprzedazy_Faktura]
ON [dbo].[KorektaFakturySprzedazy]
    ([IdFaktury]);
GO

-- Creating foreign key on [IdFaktury] in table 'PozycjaFaktury'
ALTER TABLE [dbo].[PozycjaFaktury]
ADD CONSTRAINT [FK_PozycjaFaktury_Faktura]
    FOREIGN KEY ([IdFaktury])
    REFERENCES [dbo].[Faktura]
        ([IdFaktury])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PozycjaFaktury_Faktura'
CREATE INDEX [IX_FK_PozycjaFaktury_Faktura]
ON [dbo].[PozycjaFaktury]
    ([IdFaktury]);
GO

-- Creating foreign key on [IDPracownika] in table 'UzytkowicyERP'
ALTER TABLE [dbo].[UzytkowicyERP]
ADD CONSTRAINT [FK_UzytkowicyERP_Kadry]
    FOREIGN KEY ([IDPracownika])
    REFERENCES [dbo].[Kadry]
        ([IdPracownika])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UzytkowicyERP_Kadry'
CREATE INDEX [IX_FK_UzytkowicyERP_Kadry]
ON [dbo].[UzytkowicyERP]
    ([IDPracownika]);
GO

-- Creating foreign key on [IdStatusu] in table 'Kontrahent'
ALTER TABLE [dbo].[Kontrahent]
ADD CONSTRAINT [FK_Kontrahent_Status]
    FOREIGN KEY ([IdStatusu])
    REFERENCES [dbo].[Status]
        ([IdStatusu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kontrahent_Status'
CREATE INDEX [IX_FK_Kontrahent_Status]
ON [dbo].[Kontrahent]
    ([IdStatusu]);
GO

-- Creating foreign key on [IdRodzaju] in table 'Kontrahent'
ALTER TABLE [dbo].[Kontrahent]
ADD CONSTRAINT [FK_Kontrahent_Status1]
    FOREIGN KEY ([IdRodzaju])
    REFERENCES [dbo].[Rodzaj]
        ([IdRodzaju])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Kontrahent_Status1'
CREATE INDEX [IX_FK_Kontrahent_Status1]
ON [dbo].[Kontrahent]
    ([IdRodzaju]);
GO

-- Creating foreign key on [IdKontrahenta] in table 'ZamowieniaOdKlientow'
ALTER TABLE [dbo].[ZamowieniaOdKlientow]
ADD CONSTRAINT [FK_ZamowieniaOdKlientow_Kontrahent]
    FOREIGN KEY ([IdKontrahenta])
    REFERENCES [dbo].[Kontrahent]
        ([IdKontrahenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZamowieniaOdKlientow_Kontrahent'
CREATE INDEX [IX_FK_ZamowieniaOdKlientow_Kontrahent]
ON [dbo].[ZamowieniaOdKlientow]
    ([IdKontrahenta]);
GO

-- Creating foreign key on [IdTowaru] in table 'PozycjaFaktury'
ALTER TABLE [dbo].[PozycjaFaktury]
ADD CONSTRAINT [FK_PozycjaFaktury_Towar]
    FOREIGN KEY ([IdTowaru])
    REFERENCES [dbo].[Towar]
        ([IdTowaru])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PozycjaFaktury_Towar'
CREATE INDEX [IX_FK_PozycjaFaktury_Towar]
ON [dbo].[PozycjaFaktury]
    ([IdTowaru]);
GO

-- Creating foreign key on [IdTowaru] in table 'StanyMagazynowe'
ALTER TABLE [dbo].[StanyMagazynowe]
ADD CONSTRAINT [FK_StanyMagazynowe_Towar]
    FOREIGN KEY ([IdTowaru])
    REFERENCES [dbo].[Towar]
        ([IdTowaru])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StanyMagazynowe_Towar'
CREATE INDEX [IX_FK_StanyMagazynowe_Towar]
ON [dbo].[StanyMagazynowe]
    ([IdTowaru]);
GO

-- Creating foreign key on [IdStanuMagazynowego] in table 'Towar'
ALTER TABLE [dbo].[Towar]
ADD CONSTRAINT [FK_Towar_StanyMagazynowe]
    FOREIGN KEY ([IdStanuMagazynowego])
    REFERENCES [dbo].[StanyMagazynowe]
        ([IdStanuMagazynowego])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Towar_StanyMagazynowe'
CREATE INDEX [IX_FK_Towar_StanyMagazynowe]
ON [dbo].[Towar]
    ([IdStanuMagazynowego]);
GO

-- Creating foreign key on [IdStatusu] in table 'Towar'
ALTER TABLE [dbo].[Towar]
ADD CONSTRAINT [FK_Towar_Status]
    FOREIGN KEY ([IdStatusu])
    REFERENCES [dbo].[Status]
        ([IdStatusu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Towar_Status'
CREATE INDEX [IX_FK_Towar_Status]
ON [dbo].[Towar]
    ([IdStatusu]);
GO

-- Creating foreign key on [IdTowaru] in table 'StratyMagazynoweIZwroty'
ALTER TABLE [dbo].[StratyMagazynoweIZwroty]
ADD CONSTRAINT [FK_StratyMagazynoweIZwroty_Towar]
    FOREIGN KEY ([IdTowaru])
    REFERENCES [dbo].[Towar]
        ([IdTowaru])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StratyMagazynoweIZwroty_Towar'
CREATE INDEX [IX_FK_StratyMagazynoweIZwroty_Towar]
ON [dbo].[StratyMagazynoweIZwroty]
    ([IdTowaru]);
GO

-- Creating foreign key on [IdTowaru] in table 'ZamowieniaOdKlientow'
ALTER TABLE [dbo].[ZamowieniaOdKlientow]
ADD CONSTRAINT [FK_ZamowieniaOdKlientow_Towar]
    FOREIGN KEY ([IdTowaru])
    REFERENCES [dbo].[Towar]
        ([IdTowaru])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZamowieniaOdKlientow_Towar'
CREATE INDEX [IX_FK_ZamowieniaOdKlientow_Towar]
ON [dbo].[ZamowieniaOdKlientow]
    ([IdTowaru]);
GO

-- Creating foreign key on [IdZamowieniaOdKlienta] in table 'ZamowieniaWMS'
ALTER TABLE [dbo].[ZamowieniaWMS]
ADD CONSTRAINT [FK_ZamowieniaWMS_ZamowieniaOdKlientow]
    FOREIGN KEY ([IdZamowieniaOdKlienta])
    REFERENCES [dbo].[ZamowieniaOdKlientow]
        ([IdZamowieniaOdKlientow])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZamowieniaWMS_ZamowieniaOdKlientow'
CREATE INDEX [IX_FK_ZamowieniaWMS_ZamowieniaOdKlientow]
ON [dbo].[ZamowieniaWMS]
    ([IdZamowieniaOdKlienta]);
GO

-- Creating foreign key on [IdZamowieniaOdKlienta] in table 'ZamowieniaWMS'
ALTER TABLE [dbo].[ZamowieniaWMS]
ADD CONSTRAINT [FK_ZamowieniaWMS_ZamowieniaOdKlientow1]
    FOREIGN KEY ([IdZamowieniaOdKlienta])
    REFERENCES [dbo].[ZamowieniaOdKlientow]
        ([IdZamowieniaOdKlientow])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZamowieniaWMS_ZamowieniaOdKlientow1'
CREATE INDEX [IX_FK_ZamowieniaWMS_ZamowieniaOdKlientow1]
ON [dbo].[ZamowieniaWMS]
    ([IdZamowieniaOdKlienta]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------