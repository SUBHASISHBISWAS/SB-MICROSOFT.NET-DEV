create database SubhasishPracticeDB
go


use SubhasishPracticeDB
go

create table Customers (
	CustomerId int identity primary key,
	CustomerName nvarchar(50),
	Address national character varying(255),
	CreditLimit int,
	ActiveStatus bit
	)

	insert into Customers values
	(N'Northwind Traders','Bangalore',12000,1),
	(N'SouthWind Traders','Bangalore',42000,1),
	(N'WestWind Traders','Mysore',22000,0),
	(N'Westin Traders','Bangalore',12000,1),
	(N'Novotel Traders','Chenni',32000,1),
	(N'Ibis Traders','Mangalore',12000,1),
	(N'Country Inn Traders','Bangalore',12000,0),
	(N'The Park Traders','Bangalore',12000,1);


	select * from Customers;

	create table Orders (
	OrderId int identity primary key,
	OrderDate datetime,
	CustomerId int references Customers(CustomerId),
	Units int,
	amount int
	)
	go

	create procedure dbo.uspGetCustomers(@customerName nvarchar(50))
	as
	begin
	select * from Customers where CustomerName like '%'+@customerName+'%'
	end;
	go

	insert into Orders values
	(getdate(),1,120,12000),
	(getdate(),2,120,13000),
	(getdate(),1,120,42000),
	(getdate(),4,120,12000),
	(getdate(),3,120,12000),
	(getdate(),6,120,52000),
	(getdate(),5,120,12000),
	(getdate(),5,120,12000),
	(getdate(),6,120,12000),
	(getdate(),1,120,52000),
	(getdate(),1,120,12000),
	(getdate(),7,120,12000),
	(getdate(),7,120,12000),
	(getdate(),8,120,72000),
	(getdate(),8,120,12000),
	(getdate(),1,120,12000),
	(getdate(),1,120,12000),
	(getdate(),8,120,72000),
	(getdate(),4,120,12000),
	(getdate(),3,120,82000),
	(getdate(),2,120,12000),
	(getdate(),5,120,32000),
	(getdate(),1,120,22000),
	(getdate(),5,120,12000),
	(getdate(),6,120,12000),
	(getdate(),7,120,72000),
	(getdate(),7,120,12000),
	(getdate(),1,120,32000),
	(getdate(),1,120,12000),
	(getdate(),8,120,52000),
	(getdate(),8,120,62000),
	(getdate(),3,120,82000),
	(getdate(),1,120,12000);

	select * from Orders;
	go


	create procedure dbo.uspGetOrder(@customerId int)
	as
	begin
	select * from Orders where CustomerId =@customerId
	end;