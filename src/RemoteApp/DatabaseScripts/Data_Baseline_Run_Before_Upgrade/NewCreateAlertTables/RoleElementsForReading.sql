
IF not EXISTS (
select * from RoleElement where  Name like N'View Reading' and FunctionalArea = N'Reading'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (400, N'View Reading', N'Reading')
End

IF not EXISTS (
select * from RoleElement where  Name like N'View Priorities - Reading' and FunctionalArea = N'Reading'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (401, N'View Priorities - Reading', N'Reading')
End

IF not EXISTS (
select * from RoleElement where  Name like N'View Navigation - Reading' and FunctionalArea = N'Reading'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (402, N'View Navigation - Reading', N'Reading')
End

IF not EXISTS (
select * from RoleElement where  Name like N'View Reading Definition' and FunctionalArea = N'Reading'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (403, N'View Reading Definition', N'Reading')
End

