IF not EXISTS (
select * from PermitAttribute where  Name like N'Amiante' and SiteId = 16 and Deleted = 0
)
Begin
INSERT [dbo].[PermitAttribute] ([SiteId], [Name], [Deleted]) VALUES (16, N'Amiante', 0)
End


IF not EXISTS (
select * from PermitAttribute where  Name like N'Analyse critique de la tâche (ACT)' and SiteId = 16 and Deleted = 0
)
Begin
INSERT [dbo].[PermitAttribute] ([SiteId], [Name], [Deleted]) VALUES (16, N'Analyse critique de la tâche (ACT)', 0)
End

IF not EXISTS (
select * from PermitAttribute where  Name like N'Procédure' and SiteId = 16 and Deleted = 0
)
Begin
INSERT [dbo].[PermitAttribute] ([SiteId], [Name], [Deleted]) VALUES (16, N'Procédure', 0)
End

IF not EXISTS (
select * from PermitAttribute where  Name like N'Silice' and SiteId = 16 and Deleted = 0
)
Begin
INSERT [dbo].[PermitAttribute] ([SiteId], [Name], [Deleted]) VALUES (16, N'Silice', 0)
End

IF not EXISTS (
select * from PermitAttribute where  Name like N'Chariot élévateur' and SiteId = 16 and Deleted = 0
)
Begin
INSERT [dbo].[PermitAttribute] ([SiteId], [Name], [Deleted]) VALUES (16, N'Chariot élévateur', 0)
End
-------------------------------------------------------------------------------------------------------

