ALTER TABLE [dbo].[LogDefinition] 
ADD  CONSTRAINT [FK_LogDefinition_Schedule]
FOREIGN KEY ([ScheduleId])
REFERENCES [dbo].[Schedule] ( [Id] )
GO

ALTER TABLE [dbo].[ShiftHandoverQuestionnaire] 
ADD  CONSTRAINT [FK_ShiftHandoverQuestionnaire_User]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] )
GO

ALTER TABLE [dbo].[LogCustomFieldEntry] 
ADD  CONSTRAINT [FL_LogCustomFieldEntry_CustomField]
FOREIGN KEY ([CustomFieldId])
REFERENCES [dbo].[CustomField] ( [Id] )
GO

ALTER TABLE [dbo].[SummaryLogCustomFieldEntry] 
ADD  CONSTRAINT [FK_SummaryLogCustomFieldEntry_CustomField]
FOREIGN KEY ([CustomFieldId])
REFERENCES [dbo].[CustomField] ( [Id] )
GO



GO

