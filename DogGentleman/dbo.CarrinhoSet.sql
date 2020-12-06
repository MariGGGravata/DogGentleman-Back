CREATE TABLE [dbo].[CarrinhoSet] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [Quantidade] INT NOT NULL,
    [Racao_Id] INT NOT NULL, 
    [Produto_Id] INT NOT NULL, 
    CONSTRAINT [PK_CarrinhoSet] PRIMARY KEY CLUSTERED ([Id] ASC)
);

