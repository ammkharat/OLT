IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VSummaryLogCustomFields')
BEGIN
	DROP VIEW VSummaryLogCustomFields
END
GO

CREATE VIEW [dbo].[VSummaryLogCustomFields] WITH SCHEMABINDING
AS

select 
	SummaryLogId, 
	SummaryLogCustomFieldName as FieldName, 
	FieldEntry as FieldValue, 
	DisplayOrder
from 
	dbo.summarylogcustomfieldentry 
GO
