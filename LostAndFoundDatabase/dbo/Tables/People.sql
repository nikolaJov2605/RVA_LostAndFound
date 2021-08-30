CREATE TABLE [dbo].[People] (
    [Username]  NVARCHAR (128) NOT NULL,
    [Password]  NVARCHAR (MAX) NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [BirthDate] NVARCHAR (MAX) NULL,
    [Role]      INT            NOT NULL,
    CONSTRAINT [PK_dbo.People] PRIMARY KEY CLUSTERED ([Username] ASC)
);

