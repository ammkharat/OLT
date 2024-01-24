
IF not EXISTS (
select * from RoleElement where  Name like N'View Reading' and FunctionalArea = N'Reading'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (400, 'View Reading', 'Reading')
End


IF not EXISTS (
select * from RoleElement where  Name like N'View Priorities - Reading' and FunctionalArea = N'Reading'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (401, 'View Priorities - Reading', 'Reading')
End

IF not EXISTS (
select * from RoleElement where  Name like N'View Navigation - Reading' and FunctionalArea = N'Reading'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (402, 'View Navigation - Reading', 'Reading')
End

IF not EXISTS (
select * from RoleElement where  Name like N'View Reading Definition' and FunctionalArea = N'Reading'
)
Begin
Insert into RoleElement (Id, Name,FunctionalArea) VALUES (403, 'View Reading Definition', 'Reading')
End




