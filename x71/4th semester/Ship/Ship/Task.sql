--Выбрать всю информацию обо всех кораблях.

select r.ShipId, s.Name, r.ArrivalPort, r.ArrivalTime, r.DepartureTime, r.DeparturePort from [Runs] r, [Ships] s
	where r.ShipId = s.Id

--Выбрать контактных лиц фирмы “IBM”.

select c.Name from [CustomersInfo] c
	where c.Company = 'IBM'

--Выбрать номера контейнеров, у которых вес пустого контейнера меньше 300 и упорядочить их по этому весу.

select c.Id from [Containers] c
	where c.Weight < 300
	order by c.Weight

--Выбрать номера групп для контейнеров с общим весом груза больше 100 и номера контейнеров, у которых  номер корабля,
--на котором они будут отправлены, содержит цифру 5. Список упорядочить по номеру группы.

select o.Id, c.ContainerId from [Orders] o, [Runs] r, [OrderedContainers] c
	where o.Weight > 100 or (o.Id = c.OrderId and r.Id = c.RunId and charindex('5', r.ShipId) != 0)
	order by o.Id

--Выдать время заказа перевозки груза, имена кораблей и дату их отправления, для которых время заказа с 10:10 до 20:00 1 июля 2005 года.

select distinct o.Time, s.Name, r.DepartureTime from [Orders] o, [Runs] r, [OrderedContainers] c, [Ships] s, [Containers] z
	where o.Time between '2005/06/01 10:10' and '2005/06/01 20:00' and c.OrderId = o.Id and c.RunId = s.Id and z.Id = c.ContainerId

--Посчитать общий вес всех пустых контейнеров в первой группе контейнеров.

select sum(c.Weight) from [OrderedContainers] c
	where c.OrderId = 1

--Получить список фирм, отсортированный по количеству контактных лиц. 

select a.[Company] from [CustomersInfo] a
	group by a.Company
	order by count(a.Company)

--Выбрать постоянных клиентов корабля Титаник (не менее 2 заказов)

select c.[Name] from [CustomersInfo] c, [Runs] r, [Orders] o, [Ships] s, [OrderedContainers] oc
	where s.Name = N'Титаник' and o.CustomerId = c.Id and oc.RunId = s.Id and oc.OrderId = o.Id and s.Id = oc.ContainerId
	group by c.Name
	having count(c.[Name]) >= 2

--Удалить контакное лицо - Иванова.

delete from [CustomersInfo] where CustomersInfo.Name = N'Иванова'

--Удалить все заказы, связанные с Титаником.

delete from [Orders]
	where [Orders].[Id] in
		(select o.Id from [OrderedContainers] oc, [Runs] r, [Orders] o, [Ships] s
		where oc.RunId = r.Id and s.Name = N'Титаник' and o.Id = oc.OrderId and s.Id = r.ShipId)

 --Заменить порт приписки кораблей Севастополь на Одессу

 update [Runs]
	set [Runs].[DeparturePort] = N'Одесса'
	where [Runs].[DeparturePort] = N'Севастополь'