use SubhasishPracticeDB
go

Create Table tbEmployee
(
	Id int,
	Name nvarchar(50),
	Gender nvarchar(50),
	DateOfBirth datetime
)
go
insert into tbEmployee values (1,'Subhasish','Male',getdate())
insert into tbEmployee values (1,'Debasish','Male',getdate())
insert into tbEmployee values (1,'Asmita','Female',getdate())
go
Create procedure spGetEmployee
@Id int
as
Begin
select Id,Name,Gender,DateOfBirth from tbEmployee where Id=@Id
End

go

Create procedure spSaveEmployee 
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50),
@DateOfBirth Datetime
As
Begin insert into tbEmployee values (@Id,@Name,@Gender,@DateOfBirth)
End


select * from tbEmployee
go

Alter table tbEmployee Add 
EmployeeType int, AnnualSalary int, HourlyPay int, HoursWorked int
go

delete from tbEmployee;

go

Alter procedure spGetEmployee
@Id int
as
Begin
select Id,Name,Gender,DateOfBirth,EmployeeType,AnnualSalary,HourlyPay,HoursWorked from tbEmployee where Id=@Id
End

Alter procedure spSaveEmployee 
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50),
@DateOfBirth Datetime,
@EmployeeType int,
@AnnualSalary int=null,
@HourlyPay int=null,
@HoursWorked int=null
As
Begin insert into tbEmployee values (@Id,@Name,@Gender,@DateOfBirth,@EmployeeType,@AnnualSalary,@HourlyPay,@HoursWorked)
End


Alter table tbEmployee Add 
City nvarchar(50)

go

Alter procedure spGetEmployee
@Id int
as
Begin
select Id,Name,Gender,DateOfBirth,EmployeeType,AnnualSalary,HourlyPay,HoursWorked,City from tbEmployee where Id=@Id
End

sp_helptext spSaveEmployee 

Alter procedure spSaveEmployee   
@Id int,  
@Name nvarchar(50),  
@Gender nvarchar(50)=null,  
@DateOfBirth Datetime,  
@EmployeeType int,  
@AnnualSalary int=null,  
@HourlyPay int=null,  
@HoursWorked int=null,
@City nvarchar(50)=null  
As  
Begin insert into tbEmployee values (@Id,@Name,@Gender,@DateOfBirth,@EmployeeType,@AnnualSalary,@HourlyPay,@HoursWorked,@City)  
End

Alter procedure spGetEmployee
@Id int
as
Begin
select Id,Name,DateOfBirth,EmployeeType,AnnualSalary,HourlyPay,HoursWorked,City from tbEmployee where Id=@Id
End