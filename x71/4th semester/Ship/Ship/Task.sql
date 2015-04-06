--Выбрать всю информацию обо всех кораблях.

select s.ShipId, s.ShipName, s.ArrivalPort, s.ArrivalTime, s.DepartureTime from [Runs] s

--Выбрать контактных лиц фирмы “IBM”.

select c.Name from [CustomersInfo] c
	where c.Company = 'IBM'

--Выбрать номера контейнеров, у которых вес пустого контейнера меньше 300 и упорядочить их по этому весу.

select c.Id from [Containers] c
	where c.Weight < 300
	order by c.Weight

--Выбрать номера групп для контейнеров с общим весом груза больше 100 и номера контейнеров, у которых  номер корабля,
--на котором они будут отправлены, содержит цифру 5. Список упорядочить по номеру группы.

select o.Id from [Orders] o, [Containers] c, [Runs] r
	where o.Weight > 100 or (o.Id = c.OrderId and r.Id = c.RunId and charindex('5', r.ShipId) != 0)
	group by o.Id
	order by o.Id

--Выдать время заказа перевозки груза, имена кораблей и дату их отправления, для которых время заказа с 10:10 до 20:00 1 июля 2005 года.

select distinct o.Time, s.ShipName, s.DepartureTime from [Orders] o, [Runs] s, [Containers] c
	where o.Time between '2005/06/01 10:10' and '2005/06/01 20:00' and c.OrderId = o.Id and c.RunId = s.Id

--Посчитать общий вес всех пустых контейнеров в первой группе контейнеров.

select sum(c.Weight) from [Containers] c
	where c.OrderId = 1

--Получить список фирм, отсортированный по количеству контактных лиц. 

select a.[Company] from [CustomersInfo] a
	group by a.Company
	order by count(a.Company)

--Выбрать постоянных клиентов корабля Титаник (не менее 2 заказов)

select c.[Name] from [CustomersInfo] c, [Runs] s, [Orders] o, [Containers] a
	where s.ShipName = N'Титаник' and o.CustomerId = c.Id and a.RunId = s.Id and a.OrderId = o.Id
	group by c.Name
	having count(c.[Name]) >= 2

--Удалить контакное лицо - Иванова.

delete from [CustomersInfo] where CustomersInfo.Name = N'Иванова'

--Удалить все заказы, связанные с Титаником.

delete from [Orders]
	where [Orders].[Id] in
		(select a.Id from [Containers] o, [Runs] s, [Orders] a
		where o.RunId = s.Id and s.ShipName = N'Титаник' and a.Id = o.OrderId)

 --Заменить порт приписки кораблей Севастополь на Одессу

 update [Runs]
	set [Runs].[DeparturePort] = N'Одесса'
	where [Runs].[DeparturePort] = N'Севастополь'