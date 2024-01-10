CREATE TABLE [dbo].[Authors] (
    [AuthorId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (450) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([AuthorId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Authors_Name]
    ON [dbo].[Authors]([Name] ASC) WHERE ([Name] IS NOT NULL);

INSERT INTO Authors (AuthorId, Name)
VALUES (1,"Cemal Süreya");