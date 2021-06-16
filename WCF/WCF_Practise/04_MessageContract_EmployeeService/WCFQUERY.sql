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