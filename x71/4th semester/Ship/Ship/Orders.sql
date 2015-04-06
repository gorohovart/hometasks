CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [Seal] NCHAR(50) NULL, 
    [Weight] NCHAR(10) NULL,
	[Cost] INT NULL, 
    [Time] DATETIME NULL, 
    CONSTRAINT [FK_Orders_CustomersInfo] FOREIGN KEY ([CustomerId]) REFERENCES [CustomersInfo]([Id])
)
