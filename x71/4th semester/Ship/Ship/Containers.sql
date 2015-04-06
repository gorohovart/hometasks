CREATE TABLE [dbo].[Containers]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Type] NCHAR(10) NOT NULL, 
    [Weight] INT NOT NULL, 
    [Сapacity] INT NOT NULL, 
    [OrderId] INT NULL,
	[RunId] INT NULL, 
    CONSTRAINT [FK_Containers_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]) ON UPDATE CASCADE,
	CONSTRAINT [FK_Containers_Runs] FOREIGN KEY ([RunId]) REFERENCES [Runs]([Id])
)