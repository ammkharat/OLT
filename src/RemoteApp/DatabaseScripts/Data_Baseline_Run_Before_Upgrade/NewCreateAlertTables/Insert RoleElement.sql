--//Fort Hill's forms Role element

IF not EXISTS (
select * from RoleElement where  Name like N'View 980E- AT 250HR Oil Sample/ inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (341, N'View 980E- AT 250HR Oil Sample/ inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Approve/Close 980E- AT 250HR Oil Sample/ inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (342, N'Approve/Close 980E- AT 250HR Oil Sample/ inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create 980E- AT 250HR Oil Sample/ inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (343, N'Create 980E- AT 250HR Oil Sample/ inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Edit 980E- AT 250HR Oil Sample/ inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (344, N'Edit 980E- AT 250HR Oil Sample/ inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Delete 980E- AT 250HR Oil Sample/ inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (345, N'Delete 980E- AT 250HR Oil Sample/ inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'View 980E- AT Daily Inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (346, N'View 980E- AT Daily Inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Approve/Close 980E- AT Daily Inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (347, N'Approve/Close 980E- AT Daily Inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create 980E- AT Daily Inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (348, N'Create 980E- AT Daily Inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Edit 980E- AT Daily Inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (349, N'Edit 980E- AT Daily Inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Delete 980E- AT Daily Inspection' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (350, N'Delete 980E- AT Daily Inspection', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------


-- Edmonton

IF not EXISTS (
select * from RoleElement where  Name like N'View Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (406, N'View Non-Emergency Water System Approval', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Approve/Close Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (407, N'Approve/Close Non-Emergency Water System Approval', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (408, N'Create Non-Emergency Water System Approval', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Edit Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (409, N'Edit Non-Emergency Water System Approval', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Delete Non-Emergency Water System Approval' and FunctionalArea = N'Forms'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (410, N'Delete Non-Emergency Water System Approval', N'Forms')
End
-----------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create Global Template' and FunctionalArea = N'Work Permits'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (411, N'Create Global Template', N'Work Permits')
End
-----------------------------------------------------------------------------------------------------------------------


-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Create CSD Log' and FunctionalArea = N'Shift Handovers'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (412, N'Create CSD Log', N'Shift Handovers')
End
-----------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------------
IF not EXISTS (
select * from RoleElement where  Name like N'Clone Action Item Definition' and FunctionalArea = N'Action Items'
)
Begin
INSERT [dbo].[RoleElement] ([Id], [Name], [FunctionalArea]) VALUES (413, N'Clone Action Item Definition', N'Action Items')
End
-----------------------------------------------------------------------------------------------------------------------




