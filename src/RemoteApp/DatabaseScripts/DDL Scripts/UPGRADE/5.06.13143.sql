-- Edmonton


----------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'Non-Emergency Water System Approval' and FormTypeID = 1009 and SiteID = 8 and PlantID = 702
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1009, N'Non-Emergency Water System Approval', 8, 702)
End


----------------------------

IF not EXISTS (
select * from RoleElement where  Name like N'View Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (406, N'View Non-Emergency Water System Approval', N'Forms')
End
---------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Approve/Close Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (407, N'Approve/Close Non-Emergency Water System Approval', N'Forms')
End
---------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (408, N'Create Non-Emergency Water System Approval', N'Forms')
End
---------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Edit Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (409, N'Edit Non-Emergency Water System Approval', N'Forms')
End
---------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Delete Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (410, N'Delete Non-Emergency Water System Approval', N'Forms')
End
---------------------------------------------------------------------------------------------------------------------




GO

