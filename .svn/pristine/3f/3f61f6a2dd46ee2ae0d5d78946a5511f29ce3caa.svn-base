IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryDirectiveDTOsByParentFlocListAndMarkedAsRead')
    BEGIN
        DROP PROCEDURE [dbo].QueryDirectiveDTOsByParentFlocListAndMarkedAsRead
    END
GO

CREATE Procedure [dbo].QueryDirectiveDTOsByParentFlocListAndMarkedAsRead
    (
        @StartOfDateRange DateTime,
        @EndOfDateRange DateTime,
		@CsvFlocIds varchar(max)
	)
AS
WITH Directive_Id_CTE (DirectiveId)
AS 
(
SELECT 
  DISTINCT d.Id
FROM
  [Directive] d
  INNER JOIN DirectiveFunctionalLocation dfl ON dfl.DirectiveId = d.Id
WHERE
    d.Deleted = 0 AND
	d.ActiveFromDateTime <= @EndOfDateRange and
    d.ActiveToDateTime >= @StartOfDateRange and
	( 
		EXISTS
		(
		-- Floc of Directive matches one of the passed in flocs
		select * From IDSplitter(@CsvFlocIds) ids
		WHERE dfl.FunctionalLocationId = ids.Id
		)
		OR EXISTS
		(
		  -- Floc of Directive is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		  select a.Id from FunctionalLocationAncestor a
		  INNER JOIN IDSplitter(@CsvFlocIds) ids ON ids.Id = a.ancestorid
		  WHERE dfl.FunctionalLocationId = a.Id
		)
	)
)
SELECT
    d.Id as DirectiveId,
    fl.FullHierarchy as FunctionalLocation,
	wa.Name as WorkAssignment,
    d.ActiveFromDateTime,
	d.ActiveToDateTime,
	d.PlainTextContent,
	
	createdByUser.Firstname as CreatedByFirstName,
	createdByUser.Lastname as CreatedByLastName,
	createdByUser.Username as CreatedByUsername,

    lastModifiedUser.LastName AS LastModifiedByLastName,
    lastModifiedUser.FirstName AS LastModifiedByFirstName,
    lastModifiedUser.UserName AS LastModifiedByUsername,
	
	readUser.LastName as ReadByLastName,
	readUser.FirstName as ReadByFirstName,
	readUser.UserName as ReadByUserName,
	
	r.[DateTime] as ReadByDateTime

FROM
    [Directive] d
    inner join Directive_Id_CTE on Directive_Id_CTE.DirectiveId = d.Id
	inner join DirectiveRead r on r.DirectiveId = d.id
	inner join DirectiveFunctionalLocation dfl on dfl.DirectiveId = d.Id
	inner join FunctionalLocation fl on fl.Id = dfl.FunctionalLocationId
	inner join [User] readUser on readUser.Id = r.Userid
	inner join [User] createdByUser on createdByUser.Id = d.CreatedByUserId
	INNER JOIN [User] lastModifiedUser on lastModifiedUser.Id = d.LastModifiedByUserId
	left outer join DirectiveWorkAssignment dwa on dwa.DirectiveId = d.Id
	left outer join WorkAssignment wa on wa.Id = dwa.WorkAssignmentId
GO  

GRANT EXEC ON [QueryDirectiveDTOsByParentFlocListAndMarkedAsRead] TO PUBLIC
GO