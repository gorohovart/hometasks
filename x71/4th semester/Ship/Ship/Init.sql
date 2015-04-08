insert into dbo.[Ships] ([Name]) values
(N'Титаник'),
(N'Титаник11')

go

insert into dbo.[Runs] ([ShipId], [DeparturePort], [DepartureTime], [ArrivalPort], [ArrivalTime]) values
(1,  N'Одесса', N'2005/05/01 10:20', N'Одесса', N'2005/05/01 10:21'),
(2, N'Крым наш', N'2005/05/01 10:21', N'Нью-Йорк', N'2005/05/01 10:22')

go

insert into dbo.[CustomersInfo] ([Name], [Adress], [Email], [Fax], [Phone]) values
(N'Петя', N'Ботаническая', N'petya@ibm.com', N'927467183', N'8293746173'),
(N'Вася', N'Невский', N'vasya@ibm.com', N'927467133', N'8293734173'),
(N'Иванова', N'Гостилицкое', N'ivanova@ivanova.ru', N'92384832', N'23489873')

go

insert into dbo.[Orders] ([Name], [Cost], [CustomerId], [Weight], [Time]) values
(N'asdlf', 10, 1, 203, N'2005/05/01 10:00'),
(N'sdfdfff', 11, 2, 100, N'2005/05/01 10:20'),
(N'sdfdfhhhf', 4, 3, 100, N'2005/05/01 10:22')

go

insert into dbo.[Containers] ([Weight], [Сapacity], [Type]) values
(100, 59, N'Обычный'),
(301, 65, N'Необычный'),
(101, 43, N'обычный'),
(101, 43, N'обычный')

go

insert into dbo.[OrderedContainers] ([Weight], [Seal], [OrderId], [RunId], [ContainerId]) values
(101, N'332119', 1, 1, 1),
(102, N'2ss2', 1, 2, 3),
(100, N'2ds2', 2, 1, 2),
(100, N'2ds2', 3, 1, 4)

go





