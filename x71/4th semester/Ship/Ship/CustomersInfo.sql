CREATE TABLE [dbo].[CustomersInfo]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Company] NCHAR(50) NULL,
	[Name] NCHAR(50) NOT NULL,
	[Phone] NCHAR(20) NULL, 
    [Fax] NCHAR(20) NULL, 
    [Email] NCHAR(20) NULL, 
    [Adress] NCHAR(50) NULL,
    [Other] NCHAR(100) NULL, 
    [IsInBlackList] BIT NULL
)
