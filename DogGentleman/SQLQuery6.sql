
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/19/2020 18:36:41
-- Generated from EDMX file: C:\MeuProjetoWeb\DogGentleman\DogGentleman\Models\EDM-DogGentleman.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BD-DogGentleman];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CadastroProduto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_CadastroProduto];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdutoCarrinho]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdutoSet] DROP CONSTRAINT [FK_ProdutoCarrinho];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RaçãoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RaçãoSet];
GO
IF OBJECT_ID(N'[dbo].[ProdutoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdutoSet];
GO
IF OBJECT_ID(N'[dbo].[CarrinhoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarrinhoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RacaoSet'
CREATE TABLE [dbo].[RacaoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Peso] int  NOT NULL
);
GO

-- Creating table 'ProdutoSet'
CREATE TABLE [dbo].[ProdutoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Preço] float  NOT NULL,
    [Racao_Id] int  NOT NULL,
    [Carrinho_Id] int  NOT NULL
);
GO

-- Creating table 'CarrinhoSet'
CREATE TABLE [dbo].[CarrinhoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Quantidade] int  NOT NULL,
    [Preço] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RacaoSet'
ALTER TABLE [dbo].[RacaoSet]
ADD CONSTRAINT [PK_RacaoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [PK_ProdutoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarrinhoSet'
ALTER TABLE [dbo].[CarrinhoSet]
ADD CONSTRAINT [PK_CarrinhoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Racao_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_CadastroProduto]
    FOREIGN KEY ([Racao_Id])
    REFERENCES [dbo].[RacaoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CadastroProduto'
CREATE INDEX [IX_FK_CadastroProduto]
ON [dbo].[ProdutoSet]
    ([Racao_Id]);
GO

-- Creating foreign key on [Carrinho_Id] in table 'ProdutoSet'
ALTER TABLE [dbo].[ProdutoSet]
ADD CONSTRAINT [FK_ProdutoCarrinho]
    FOREIGN KEY ([Carrinho_Id])
    REFERENCES [dbo].[CarrinhoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdutoCarrinho'
CREATE INDEX [IX_FK_ProdutoCarrinho]
ON [dbo].[ProdutoSet]
    ([Carrinho_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------