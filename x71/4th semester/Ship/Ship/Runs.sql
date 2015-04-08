CREATE TABLE [dbo].[Runs]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [ShipId] INT NOT NULL,
	[DeparturePort] NCHAR(20) NOT NULL,
    [DepartureTime] DATETIME NOT NULL, 
    [ArrivalPort] NCHAR(20) NOT NULL,
	[ArrivalTime] DATETIME NOT NULL,
	CONSTRAINT [FK_Runs_Ships] FOREIGN KEY ([ShipId]) REFERENCES [Ships]([Id])
)
