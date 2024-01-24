-- Since Montreal refers to templates by specific numbers we need a column to hold this static value.
-- When templates are modified a new "Id" will be given but the TemplateNumber will remain the same.
ALTER TABLE [dbo].[WorkPermitMontrealTemplate]
ADD TemplateNumber int NOT NULL
GO
GO
