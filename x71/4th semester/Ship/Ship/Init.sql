insert into dbo.[Runs] ([ShipId], [ShipName], [DeparturePort], [DepartureTime], [ArrivalPort], [ArrivalTime]) values
(11131,  N'Одесса', N'Титаник', N'2005/05/01 10:20', N'Одесса', N'2005/05/01 10:21'),
(3325, N'Крым наш', N'Титаник11',N'2005/05/01 10:21', N'Нью-Йорк', N'2005/05/01 10:22')

go

insert into dbo.[CustomersInfo] ([Name], [Adress], [Email], [Fax], [Phone]) values
(N'Петя', N'Ботаническая', N'petya@ibm.com', N'927467183', N'8293746173'),
(N'Вася', N'Невский', N'vasya@ibm.com', N'927467133', N'8293734173'),
(N'Иванова', N'Гостилицкое', N'ivanova@ivanova.ru', N'92384832', N'23489873')

go

insert into dbo.[Orders] ([Name], [Cost], [CustomerId], [Seal], [Weight]) values
(N'asdlf', 10, 1, N'332119', 25),
(N'sdfdfff', 11, 2, N'2ss2', 26),
(N'sdfdfhhhf', 4, 3, N'2ds2', 11)

go

insert into dbo.[Containers] ([Weight], [Сapacity], [Type], [OrderId], [RunId]) values
(100, 59, N'Обычный', 1, 2),
(301, 65, N'Необычный', 2, 1),
(101, 43, N'обычный', 3, 2)

go


