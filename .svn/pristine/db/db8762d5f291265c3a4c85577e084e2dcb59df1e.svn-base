


If not Exists(
		Select * from FormTemplate Where siteid = 8 and FormTypeId = 1009 and Deleted = 0
)
Begin

	INSERT [dbo].[FormTemplate] ([FormTypeId], [Template], [Deleted], [CreatedByUserId], [CreatedDateTime], [TemplateKey], [Name], [siteid]) 
	VALUES (1009, N'Non-Emergency Water System Approval', 0, -1, GetDate(), NULL, NULL, 8)

End


GO

