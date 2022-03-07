create database ProjectAtADOWithCrud

use ProjectAtADOWithCrud


create table Student(
Id int primary key identity,
Course varchar(30)
)

create proc Sp_Students
@action varchar(max)=null,
@Id int=0,
@Course varchar(30)=null
as
begin
if(@action='CREATE')
begin
insert into Student(Course)values(@Course)
Select 'Ok' as result
end
else if(@action='SELECT')
begin
Select*from Student
end
else if(@action='DELETE')
begin
DELETE from Student where Id=@Id
Select 'Ok' as result
end
else if(@action='UPDATE')
begin
Update Student set Course=@Course where Id=@Id
Select 'OK' as result
end
end

create table StudentCourse
(Id int primary key identity,
StudName varchar(30),
Email varchar(30),
Contact varchar(20),
Course int foreign key references Student(id))

alter Proc  Sp_StudentCourses
@action varchar(max)=null,
@Id int=0,
@StudName varchar(30)=null,
@Email varchar(30)=null,
@Contact varchar(20)=null,
@Course int =0
as 
begin
if(@action='CREATE')
begin
insert into StudentCourse(StudName,Email,Contact,Course)values(@StudName,@Email,@Contact,@Course)
select 'Ok' as result
end
else if(@action='SELECT')
begin
Select*from StudentCourse
end
else if(@action='SELECT_JOIN')
begin
select c.Id,c.StudName,c.Email,c.Contact,s.Course from StudentCourse c 
inner join Student s
on c.Course = s.Id
end
else if(@action='DELETE')
begin
delete from StudentCourse where id=@id
Select 'Ok' as result
end
else if(@action='UPDATE')
begin
Update StudentCourse Set StudName=@StudName,Email=@Email,Contact=@Contact,Course=@Course where id=@id
Select'Ok' as result 
end
end


exec Sp_Students 'CREATE',0,'BSC'
exec Sp_Students 'SELECT',2
exec Sp_Students 'UPDATE',4,'BCOM'
EXEC Sp_Students 'DELETE',3

exec Sp_StudentCourses 'SELECT'
exec Sp_StudentCourses 'CREATE',0,'Sourav','gk@gmail.com','9884387575',1
exec Sp_StudentCourses 'DELETE',2
exec Sp_StudentCourses 'SELECT_JOIN'


