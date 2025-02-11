﻿IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QuerySummaryLogDTOsByParentFlocList')
    BEGIN
        DROP  Procedure  QuerySummaryLogDTOsByParentFlocList
    END
GO

CREATE Procedure [dbo].QuerySummaryLogDTOsByParentFlocList
    (        
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,      
		@CsvFLOCIds varchar(max),
		@CsvVisibilityGroupIds varchar(max),
		@RoleId bigint=Null 
    )
AS
-- Logic to Get Allowview WOrkassigmnet based on rolepermission

DECLARE @listStrWorkAssigmnet VARCHAR(MAX)
if(@RoleId IS NOT NULL)
Begin
(select @listStrWorkAssigmnet = COALESCE(@listStrWorkAssigmnet+',' ,'') + CAST(Id AS VARCHAR) from WorkAssignment where (RoleId IN(select CreatedByRoleId from RolePermission where RoleElementId=114 and RoleId =@RoleId)))-- OR Roleid=@RoleId);
--SELECT @listStrWorkAssigmnet
ENd;
------END------

WITH SummaryLog_Id_Cte (SummaryLogId)
AS
(
select distinct l.id
  from 
    dbo.SummaryLog l
	inner join SummaryLogFunctionalLocation lfl on lfl.SummaryLogId = l.Id
  WHERE 
    l.Deleted = 0 AND       
    l.CreatedDateTime <= @EndOfDateRange AND
    l.CreatedDateTime >= @StartOfDateRange AND
    (
	  l.WorkAssignmentId is null or
	  @CsvVisibilityGroupIds is null or
	  EXISTS (
		select wavg.Id
		from WorkAssignmentVisibilityGroup wavg
		inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
		where wavg.WorkAssignmentId = l.WorkAssignmentId and
			  wavg.VisibilityType = 2
	  )
    ) AND
    (
		EXISTS
		(
        -- Floc of Summary Log matches one of the passed in flocs
        select lfl.SummaryLogId From IDSplitter(@CsvFLOCIds) ids
        WHERE ids.Id = lfl.FunctionalLocationId
		)
        OR EXISTS
		(
        -- Floc of Summary Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)
        select lfl.SummaryLogId from FunctionalLocationAncestor a
        INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid
        WHERE a.Id = lfl.FunctionalLocationId
		)
    )
)
SELECT
    l.Id as SummaryLogId,        
    l.EHSFollowup,
    l.InspectionFollowUp,
    l.OperationsFollowUp,
    l.ProcessControlFollowUp,
    l.SupervisionFollowUp,
    l.OtherFollowUp,
    l.LogDateTime,
	l.CreatedDateTime,
	l.CreatedByUserId,
	l.CreatedByRoleId,
	l.RootLogId,
    l.ReplyToLogId,
	l.HasChildren,
	l.DataSourceId,

    lastModifiedUser.LastName AS LastModifiedByLastName,
    lastModifiedUser.FirstName AS LastModifiedByFirstName,
    lastModifiedUser.UserName AS LastModifiedByUserName,
	
    createdByUser.LastName AS CreatedByLastName,
    createdByUser.Firstname AS CreatedByFirstName,
    createdByUser.Username AS CreatedByUsername,

    s.StartTime AS CreatedShiftStartDateTime,
    s.EndTime AS CreatedShiftEndDateTime,
    s.[id] AS CreatedShiftId,
    s.[Name] AS CreatedShiftName,

   	siteconfig.PreShiftPaddingInMinutes,
	siteconfig.PostShiftPaddingInMinutes,

	a.[Name] AS WorkAssignmentName,

	slfll.FunctionalLocationList as FullHierarchy,
	
	l.PlainTextComments as Comments,
	
	vg.Name as VisibilityGroupName
FROM	
    [SummaryLog] l
    INNER JOIN SummaryLog_Id_Cte ON SummaryLog_Id_Cte.SummaryLogId = l.Id
	inner join [User] createdByUser on l.CreatedByUserId = createdByUser.Id
    INNER JOIN [User] lastModifiedUser ON l.LastModifiedUserId = lastModifiedUser.Id
    INNER JOIN [Shift] s ON l.CreationUserShiftPatternId = s.Id
	INNER JOIN [SiteConfiguration] siteconfig on s.SiteId = siteconfig.SiteId
	INNER JOIN SummaryLogFunctionalLocationList slfll on slfll.SummaryLogId = l.Id
    LEFT OUTER JOIN [WorkAssignment] a ON a.id = l.WorkAssignmentId
	LEFT OUTER JOIN WorkAssignmentVisibilityGroup wavg ON wavg.WorkAssignmentId = l.WorkAssignmentId and wavg.VisibilityType = 2
	LEFT OUTER JOIN VisibilityGroup vg ON vg.Id = wavg.VisibilityGroupId
	WHERE @listStrWorkAssigmnet IS NULL OR a.id in (select * From IDSplitter(@listStrWorkAssigmnet))
OPTION (OPTIMIZE FOR UNKNOWN)	
GO

GRANT EXEC ON QuerySummaryLogDTOsByParentFlocList TO PUBLIC