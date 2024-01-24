IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDirectiveDTOByDateRangeAndFlocIds')
    BEGIN
        DROP PROCEDURE [dbo].QueryDirectiveDTOByDateRangeAndFlocIds
    END
GO

CREATE Procedure [dbo].QueryDirectiveDTOByDateRangeAndFlocIds
    (
		@CsvFlocIds varchar(MAX),
		@StartOfDateRange DateTime,
		@EndOfDateRange DateTime,
		@CsvVisibilityGroupIds varchar(max),
		@ReadByUserId bigint = NULL
    )
AS

WITH Directive_Id_Cte (DirectiveId)
AS
(
select distinct d.id
  from 
    dbo.Directive d
  WHERE 
    d.ActiveFromDateTime <= @EndOfDateRange and
    d.ActiveToDateTime >= @StartOfDateRange and
    d.Deleted = 0 AND
	(
		EXISTS
		(
		-- Floc of Directive matches one of the passed in flocs
		select dfl.DirectiveId 
		from IDSplitter(@CsvFlocIds) ids
		INNER JOIN DirectiveFunctionalLocation dfl ON ids.Id = dfl.FunctionalLocationId
		WHERE dfl.DirectiveId = d.Id
		)
		OR EXISTS
		(
		  -- Floc of Directive is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select dfl.DirectiveId
		  from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.AncestorId
		  INNER JOIN DirectiveFunctionalLocation dfl ON a.Id = dfl.FunctionalLocationId
		  WHERE dfl.DirectiveId = d.Id
		)
		OR EXISTS
	    (
	      -- Floc of Directive is parent of one of the passed in flocs (look up the floc tree from my selected flocs)
		  select dfl.DirectiveId
		  from FunctionalLocationAncestor a
		  inner join IDSplitter(@CsvFlocIds) ids on ids.Id = a.Id
		  inner join DirectiveFunctionalLocation dfl on a.AncestorId = dfl.FunctionalLocationId
		  where dfl.DirectiveId = d.Id
	    )
	) AND
	(
	@CsvVisibilityGroupIds is null or
	EXISTS (
		select wavg.Id
		from WorkAssignmentVisibilityGroup wavg
		inner join IDSplitter(@CsvVisibilityGroupIds) vgIds on vgIds.Id = wavg.VisibilityGroupId
		inner join DirectiveWorkAssignment dwa on dwa.DirectiveId = d.Id
		where wavg.WorkAssignmentId = dwa.WorkAssignmentId and
		      wavg.VisibilityType = 2
	    )
	or ((select count(*) from DirectiveWorkAssignment dwa where dwa.DirectiveId = d.Id) = 0)
    )
)

SELECT
	d.Id,	
	d.ActiveFromDateTime,
	d.ActiveToDateTime,
	d.PlainTextContent,
	fl.FullHierarchy as FunctionalLocation,
	wa.Name as WorkAssignment,
	d.CreatedByUserId,
	d.CreatedByRoleId,
	d.CreatedByWorkAssignmentName,
	d.LastModifiedByUserId,
	d.CreatedDateTime,
	createdByUser.Firstname as CreatedByFirstName,
	createdByUser.Lastname as CreatedByLastName,
	createdByUser.Username as CreatedByUsername,
	lastModifiedByUser.Firstname as LastModifiedByFirstName,
	lastModifiedByUser.Lastname as LastModifiedByLastName,
	lastModifiedByUser.Username as LastModifiedByUsername,
	dr.UserId as ReadByUserId
FROM
	Directive d
	INNER JOIN Directive_Id_Cte ON Directive_Id_Cte.DirectiveId = d.Id
	inner join DirectiveFunctionalLocation dfl on dfl.DirectiveId = d.Id
	inner join FunctionalLocation fl on fl.Id = dfl.FunctionalLocationId
	left outer join DirectiveWorkAssignment dwa on dwa.DirectiveId = d.Id
	left outer join WorkAssignment wa on wa.Id = dwa.WorkAssignmentId
	inner join [User] createdByUser on createdByUser.Id = d.CreatedByUserId
	inner join [User] lastModifiedByUser on lastModifiedByUser.Id = d.LastModifiedByUserId
	left outer join DirectiveRead dr ON dr.DirectiveId = d.Id and dr.UserId = @ReadByUserId
GO

GRANT EXEC ON QueryDirectiveDTOByDateRangeAndFlocIds TO PUBLIC
GO