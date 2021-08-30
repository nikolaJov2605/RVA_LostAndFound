CREATE TABLE [dbo].[Items] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Date]            NVARCHAR (MAX) NULL,
    [Title]           NVARCHAR (MAX) NULL,
    [Location]        NVARCHAR (MAX) NULL,
    [Description]     NVARCHAR (MAX) NULL,
    [IsFound]         BIT            NOT NULL,
    [ItemCommandID]   INT            NOT NULL,
    [Finder_Username] NVARCHAR (128) NULL,
    [Owner_Username]  NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Items_dbo.People_Finder_Username] FOREIGN KEY ([Finder_Username]) REFERENCES [dbo].[People] ([Username]),
    CONSTRAINT [FK_dbo.Items_dbo.People_Owner_Username] FOREIGN KEY ([Owner_Username]) REFERENCES [dbo].[People] ([Username])
);


GO
CREATE NONCLUSTERED INDEX [IX_Finder_Username]
    ON [dbo].[Items]([Finder_Username] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Owner_Username]
    ON [dbo].[Items]([Owner_Username] ASC);

