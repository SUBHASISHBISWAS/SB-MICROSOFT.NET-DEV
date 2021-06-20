--Alter Database Sample1 Modify Name=Sample2
--sp_renameDB 'Sample2', 'Sample3'

--Drop Database Sample3

--Create Database Sample
use Sample
Go

--Create Table tblGender
--( Id int NOT NULL Primary Key,
--  Gender nvarchar(50) NOT NULL
--)

--Create Table tblEmployee 
--(
--	Id int NOT NULL Primary Key,
--	Name nvarchar(50) NOT NULL,
--	Email nvarchar(50) NOT NULL,
--	GenderId int 
--)

--Alter Table tblEmployee add constraint tbPerson_GenderId_FK
--Foreign Key (GenderId) references tblGender (Id)

--Alter Table tblEmployee add constraint DF_tblEmployee_GenderId
--Default 3 For GenderId


--insert into  dbo.tblEmployee (Id,Name,Email) values (5,'SUBHASISH','subhasish@gmail.com')

--Alter Table tblEmployee add Constraint CK_tblEpmoyee_Age Check (Age >10 and Age <100)
--insert into  dbo.tblEmployee (Id,Name,Email,Age) values (6,'Asmita','Asmita@gmail.com',20)

--insert into tblPerson  Values ('Asmita')
--Select * from tblPerson
--delete  from tblPerson
--insert into tblPerson  Values ('Asmiat')

--Create Table Testl
--(
--ID int identity(1,1),
--Value nvarchar(20)
--)
--Create Table Test2
--(
--ID int identity(1,1),
--Value nvarchar(20)
--)

--Insert into Test1 Values ('Y')

--Select * from Test2



--Select SCOPE_IDENTITY()

--Select @@IDENTITY

--create Trigger trForInsert on Test1 For Insert 
--as 
--Begin 
--	Insert into Test2  Values ('Hello')
--End

--Select IDENT_CURRENT('Test1')

--Alter Table tblEmployee Add Constraint UQ_tblPerson_Email Unique (Email)

--insert into  dbo.tblEmployee (Id,Name,Email,Age) values (11,'Adrita','Adrita@gmail.com',11)

--Select * from tblEmployee

--Select DISTINCT City,Name from tblEmployee

--Select * from tblEmployee where City <> 'Bangalore'

--Select * from tblEmployee where Age IN (20,35)

--Select * from tblEmployee where Age Between 15 and 50


--Select * from tblEmployee where Email NOT LIKE '%@%'
--Select * from tblEmployee where Name LIKE '[^SA]%'

--Select * from tblEmployee where ((City ='Bangalore') or (City='Kolkata'))
--and Age <30

--Select * from tblEmployee Order by Name DESC, AGE DESC

--SELECT top 2 * from tblEmployee

--SELECT top 2 Percent *  from tblEmployee

--Find Eldest Person in Employee Table

--select top 2 * from tblEmployee order by AGE DESC,SALARY ASC
 
 --select MAX(Salary) from tblEmployee

 --Select City,SUM(Salary) as TotalSalary  from tblEmployee group by City

 --Select City,GENDER,SUM(Salary) as TotalSalary  
 --from tblEmployee group by City,GENDER

--SELECT COUNT(*) FROM tblEmployee

--Select City,GENDER,SUM(Salary) as TotalSalary, COUNT(Id) as [Total Employye]
--from tblEmployee group by City,GENDER HAVING Gender='FEMALE'

--Alter Table tblEmployee add constraint tbPerson_DepartmentId_FK
--Foreign Key (DepartmentId) references tblDepartment (Id)

Select * from tblEmployee
Select * from tblDepartment

--Select Name, Gender,Salary,DepartmentName from tblEmployee
--JOIN tblDepartment ON tblEmployee.DepartmentId=tblDepartment.Id 


--Select Name, Gender,Salary,DepartmentName from tblEmployee
--LEFT JOIN tblDepartment ON tblEmployee.DepartmentId=tblDepartment.Id



--Select Name, Gender,Salary,DepartmentName from tblEmployee
--RIGHT JOIN tblDepartment ON tblEmployee.DepartmentId=tblDepartment.Id 


--Select Name, Gender,Salary,DepartmentName from tblEmployee
--FULL JOIN tblDepartment ON tblEmployee.DepartmentId=tblDepartment.Id  


--Select Name, Gender,Salary,DepartmentName from tblEmployee
--CROSS JOIN tblDepartment

--Select Name, Gender, Salary,DepartmentName from tblEmployee 
--LEFT JOIN tblDepartment ON tblEmployee.DepartmentId=tblDepartment.Id 
--Where tblDepartment.Id IS NULL


--Select Name, Gender, Salary,DepartmentName from tblEmployee 
--FULL JOIN tblDepartment ON tblEmployee.DepartmentId=tblDepartment.Id 
--Where tblDepartment.Id IS NULL
--OR tblEmployee.DepartmentId IS NULL

--SELECT E.Name as Employee , M.Name as Manager
--from tblEmployee E
-- JOIN tblEmployee M
--ON E.ManagerId = M.Id


--Select E.Name as Employee , ISNULL(M.Name,'No Manager') as Manger 
--from tblEmployee as E
--LEFT JOIN tblEmployee as M
--ON  E.ManagerId=M.Id

--Select ISNULL(NULL,'No Manager')

--select COALESCE (NULL,'No Manager')
--COAL ESC E -->COALESCE

--Select Id, CoALESCE(NAME,EMAIL,CITY) as NAME from tblEmployee

--SELECT * from tblEmployee
--UNION
--SELECT * from tblDepartment

--CREATE PROCEDURE spGetEmployee 
--AS
--BEGIN 
-- SElect Name, Email from tblEmployee
--END

--spGetEmployee

--Create PROCEDURE spGetEmployeeByGenderAndDepartment
--@Gender nvarchar(20),
--@DepartmentId int
--AS
--BEGIN
--	SELECT Name, Gender,DepartmentId  from tblEmployee where Gender =@Gender and 
--	DepartmentId=@DepartmentId
--END

--spGetEmployeeByGenderAndDepartment 'MALE',1

--sp_helpText spGetEmployeeByGenderAndDepartment

--drop procedure spGetEmployeeByGenderAndDepartment

--ALTER PROCEDURE spGetEmployee
--WITH ENCRYPTION
--AS
--BEGIN 
--	SElect Name, Email from tblEmployee
--END

--sp_helpText spGetEmployee

--Create Procedure sp_GetEmployeeCountByGender 
--@Gender nvarchar(20),
--@EmployeeCount int output
--AS
--BEGIN 
--	Select @EmployeeCount =COUNT(Id) from tblEmployee
--	Where Gender=@Gender
--END

--Create Procedure sp_GetEmployeeCountByGender_2
--@Gender nvarchar(20)
--AS
--BEGIN 
--	return (Select COUNT(Id) from tblEmployee where Gender= @Gender)
	
--END


--Declare @Total int
--execute @Total=sp_GetEmployeeCountByGender_2 'FEMALE'
--Print @Total

--SELECT GETDATE()

--SELECT SQUARE(3)

--DECLARE @DOB DATE
--DECLARE @AGE int
--SET @DOB='10/15/1983'

--SET @AGE = DATEDIFF(YEAR,@DOB,GETDATE())
--PRINT @AGE

--CREATE FUNCTION CalculateAge(@DOB Date)
--RETURNS INT
--AS
--BEGIN

--DECLARE @AGE int
--SET @AGE = DATEDIFF(YEAR,@DOB,GETDATE())

--RETURN @AGE
--END

--SELECT dbo.CalculateAge('10/15/1985')

--insert into Test2 Values ('XXX','10/15/1983')

--SELECT Id,NAME ,dbo.CalculateAge(DateOfBirth) as Age from tblEmployee
--Where dbo.CalculateAge(DateOfBirth)>35
 
 --Create FUNCTION fn_EmployeeByGender(@Gender nvarchar(20))
 --RETURNS TABLE
 --AS
 --RETURN (select Id,Name,Gender,DateOfBirth from tblEmployee where Gender=@Gender)


 --Select * from dbo.fn_EmployeeByGender('MALE')

 --ALTER  FUNCTION fn_EmployeeByGender(@Gender nvarchar(20))
 --RETURNS TABLE
 --AS
 --RETURN (select Id,Name,Gender,DateOfBirth,DepartmentId from tblEmployee where Gender=@Gender)

 --SELECT  NAME, GENDER, DEPARTMENTNAME 
 --from dbo.fn_EmployeeByGender('MALE') E 
 --JOIN tblDepartment D
 --ON E.DepartmentId=D.Id

 --Create Function Fn_MSTVF_GetEmployee()
 --Returns @Table Table (Id int, Name nvarchar(50),DOB date)
 --AS
 --BEGIN
	--Insert into @Table select Id, Name, CAST(DateOfBirth as Date) from tblEmployee
	--Return 
 --END

 --Select * from Fn_MSTVF_GetEmployee()

 --Create Table #PersoanDetails (Id int, Name varchar(50))

 --insert into #PersoanDetails Values (1, 'SUbhasish')
 --insert into #PersoanDetails Values (2, 'Asmita')

 --Select * from #PersoanDetails

 --Select name  from tempdb..sysobjects
 --where name like '#PersoanDetails%'

 --Create Table ##PersoanDetails (Id int, Name varchar(50))


 --Create index IX_tblEmployee_Salary
 --on tblEmployee (Salary ASC)

 --sp_HelpIndex tblEmployee

 --drop index tblEmployee.IX_tblEmployee_Salary

 --sp_HelpIndex tblEmployee

-- Create CLUSTERED INDEX IX_tblEmployee_SALARY_GENDER
-- ON tblEmployee (SALARY ASC,GENDER DESC)

--drop index tblEmployee.PK__tblEmplo__3214EC07048F7D18

--select * from tblEmployee

--Create View vWEmployeeByDepartment
--as
--Select Name,Salary,Email
--from tblEmployee 
--JOIN tblDepartment
--ON tblEmployee.DepartmentId=tblDepartment.Id

--Select * from vWEmployeeByDepartment

sp_helpText  vWEmployeeByDepartment