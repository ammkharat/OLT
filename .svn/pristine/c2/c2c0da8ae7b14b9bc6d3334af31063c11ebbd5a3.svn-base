--// Insert Data for Fort Hill site - 2 Form

IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'980E- AT 250HR Oil Sample/ inspection' and FormTypeID = 1007 and SiteID = 15 and PlantID = 764
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1007, N'980E- AT 250HR Oil Sample/ inspection', 15, 764)
End
--------------------------
IF not EXISTS (
select * from GenericTemplateEFormHeader where  Name like N'980E- AT Daily Inspection' and FormTypeID = 1008 and SiteID = 15 and PlantID = 764
)
Begin
INSERT [dbo].[GenericTemplateEFormHeader] ([FormTypeID], [Name], [SiteID], [PlantID]) VALUES (1008, N'980E- AT Daily Inspection', 15, 764)
End

