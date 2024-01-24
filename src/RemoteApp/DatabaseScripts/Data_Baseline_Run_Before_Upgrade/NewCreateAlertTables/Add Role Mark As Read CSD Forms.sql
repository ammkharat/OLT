
IF not EXISTS (
select * from RoleElement where  Name like N'Mark As Read CSD Forms' and FunctionalArea = N'Forms'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (340, 'Mark As Read CSD Forms', 'Forms')
End


