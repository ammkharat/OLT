IF not EXISTS (
select * from RoleElement where  Name like N'View Temporary Installations - MUDS' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (331, N'View Temporary Installations - MUDS', N'Forms')
End
---------------------------------------------------------------------------------------------
--------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Approve/Close Temporary Installations - MUDS' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (332, N'Approve/Close Temporary Installations - MUDS', N'Forms')
End
---------------------------------------------------------------------------------------------
--------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create Temporary Installations - MUDS' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (333, N'Create Temporary Installations - MUDS', N'Forms')
End
---------------------------------------------------------------------------------------------
--------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Edit Temporary Installations - MUDS' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (334, N'Edit Temporary Installations - MUDS', N'Forms')
End
---------------------------------------------------------------------------------------------
--------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Delete Temporary Installations - MUDS' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (335, N'Delete Temporary Installations - MUDS', N'Forms')
End





GO

