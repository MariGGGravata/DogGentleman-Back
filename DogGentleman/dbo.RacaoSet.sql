CREATE TABLE [dbo].[RacaoSet] (
    [Id]   INT IDENTITY (1, 1) NOT NULL,
    [Peso] INT NOT NULL,
    [Nome] TEXT NOT NULL, 
    CONSTRAINT [PK_RacaoSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

