CREATE TABLE [dbo].[OrderedContainers]
(
    [OrderId] INT NOT NULL, 
    [RunId] INT NOT NULL, 
    [Seal] NCHAR(50) NOT NULL, 
    [Weight] INT NOT NULL, 
    [ContainerId] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_OrderedContainers_Order] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_OrderedContainers_Run] FOREIGN KEY ([RunId]) REFERENCES [Runs]([Id]), 
    CONSTRAINT [FK_OrderedContainers_Containers] FOREIGN KEY ([ContainerId]) REFERENCES [Containers]([Id])
)