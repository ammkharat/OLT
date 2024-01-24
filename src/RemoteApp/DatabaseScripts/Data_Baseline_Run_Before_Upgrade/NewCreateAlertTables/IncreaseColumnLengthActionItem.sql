
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VActionItem')
BEGIN
       DROP VIEW VActionItem
END

GO


--//


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingActionItems')
BEGIN
       DROP VIEW VReportingActionItems
END
GO


--//

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'ShowTimeOnly')
       BEGIN
              DROP  Function  [dbo].[ShowTimeOnly]
       END
GO


--//


ALTER TABLE  ActionItem ALTER COLUMN  Name VARCHAR (80)
Go


--//




SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'ShowTimeOnly')
       BEGIN
	   IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VActionItem')
	BEGIN
       DROP VIEW VActionItem
	END		
       DROP  Function  [dbo].[ShowTimeOnly]
       END
GO

Create Function [dbo].[ShowTimeOnly] (@dateTime datetime) 
Returns varchar(8) WITH schemabinding
AS

Begin
       declare @formattedTime varchar(8)
       select @formattedTime =  substring(convert(varchar,@dateTime,126),12,8)
       Return @formattedTime
End

GO

--//



IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingActionItems')
BEGIN
       DROP VIEW VReportingActionItems
END
GO

CREATE VIEW dbo.[VReportingActionItems] 
AS
select
       ai.Id as ActionItemId,
       ai.ResponseRequired,
       ai.ActionItemStatusId,
       ai.[Description],
       ai.StartDateTime,
       ai.EndDateTime,
       ai.ShiftAdjustedEndDateTime,
       ai.SourceId,
       ai.createdByScheduleTypeId,
       ai.Name,
       ai.PreviousActionItemStatusId,
       ai.StatusModifiedDateTime,
       ai.CreatedByActionItemDefinitionId,
       ai.PriorityId,
       bc.Name as BusinessCategory,
       wa.Id as WorkAssignmentId,
       wa.Name as WorkAssignment,
       fl.Id as FunctionalLocationId,
       fl.FullHierarchy as FunctionalLocation,
       s.Id as SiteId,
       s.Name as Site
from 
       dbo.ActionItem ai    
       inner join dbo.BusinessCategory bc on bc.Id = ai.BusinessCategoryId
       left outer join dbo.WorkAssignment wa on wa.Id = ai.WorkAssignmentId
       inner join dbo.ActionItemFunctionalLocation aifl on aifl.ActionItemId = ai.Id
       inner join dbo.FunctionalLocation fl on fl.Id = aifl.FunctionalLocationId
       inner join dbo.Site s on s.Id = fl.SiteId
where 
       ai.Deleted = 0

GO


--//





IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VActionItem')
BEGIN
       DROP VIEW VActionItem
END
GO


Create VIEW [dbo].[VActionItem] WITH schemabinding
AS
SELECT     ai.Id, ai.Name AS [Action Item Name], s.Name AS [Site Name], ai.Description AS [Action Description], l.PlainTextComments AS Comment, CONVERT(date, 
                      ai.StartDateTime) AS [Action Issue Date], dbo.ShowTimeOnly(ai.StartDateTime) AS [Action Issue Time], CONVERT(date, ai.EndDateTime) AS [Action Completion Date], 
                      dbo.ShowTimeOnly(ai.EndDateTime) AS [Action Completion Time], bc.Name AS [Business Category], ai.ActionItemStatusId AS [Action Item Status ID], 
                      ai.PriorityId AS [Priority ID], ai.SourceId AS [Source ID], s.Id AS [Site ID], 
                      CASE ai.actionitemstatusid WHEN 0 THEN 'Current' WHEN 1 THEN 'Complete' WHEN 2 THEN 'Incomplete' WHEN 3 THEN 'Cannot Complete' ELSE 'Cleared' END AS Status,
                       CASE ai.priorityid WHEN 1 THEN 'Normal' WHEN 2 THEN 'Elevated' WHEN 3 THEN 'High' ELSE 'CriticalPath' END AS Priority, 
                      CASE ai.sourceid WHEN 0 THEN 'Manual' WHEN 1 THEN 'SAP' ELSE 'Target' END AS Source, fl.FullHierarchy AS FLOC, fl.Description AS [FLOC Description]
FROM         dbo.ActionItem AS ai INNER JOIN
                      dbo.ActionItemFunctionalLocation AS af ON ai.Id = af.ActionItemId INNER JOIN
                      dbo.BusinessCategory AS bc ON bc.Id = ai.BusinessCategoryId INNER JOIN
                      dbo.FunctionalLocation AS fl ON fl.Id = af.FunctionalLocationId LEFT OUTER JOIN
                      dbo.LogActionItemAssociation AS la ON la.ActionItemId = ai.Id LEFT OUTER JOIN
                      dbo.[Log] AS l ON l.Id = la.LogId INNER JOIN
                      dbo.Site AS s ON s.Id = fl.SiteId
WHERE     (ai.Deleted = 0)




