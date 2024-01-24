 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetLastReading')
	BEGIN
		DROP  Procedure  [dbo].[GetLastReading]
	END

GO

create procedure [dbo].[GetLastReading]

@ActionItemDefinitionId bigint

as

	select CustomFieldId,case when DisplayField = 'Unavailable' then null else  DisplayField end as [DisplayField] from ActionItemResponseTracker where actionitemdefinitionid = @ActionItemDefinitionId and
	 BatchNumber = (select max(batchnumber) from ActionItemResponseTracker where actionitemdefinitionid = @ActionItemDefinitionId) order by DisplayOrder 


