IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMontrealDTOsByFlocUnitAndBelow')
    BEGIN
        DROP PROCEDURE [dbo].QueryPermitRequestMontrealDTOsByFlocUnitAndBelow
    END
GO

--- TODO: get rid of the 'UnitAndBelow' in this query name as the query can work on any floc level now
CREATE Procedure [dbo].QueryPermitRequestMontrealDTOsByFlocUnitAndBelow
    (
        @FlocIds varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime
    )
AS

SELECT
    PermitRequest.*,
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    LastModifiedByUser.LastName AS LastModifiedByLastName,
    LastModifiedByUser.FirstName AS LastModifiedByFirstName,
    LastModifiedByUser.UserName AS LastModifiedByUserName,
    LastImportedByUser.LastName AS LastImportedByLastName,
    LastImportedByUser.FirstName AS LastImportedByFirstName,
    LastImportedByUser.UserName AS LastImportedByUserName,
    LastSubmittedByUser.LastName AS LastSubmittedByLastName,
    LastSubmittedByUser.FirstName AS LastSubmittedByFirstName,
    LastSubmittedByUser.UserName AS LastSubmittedByUserName,
	wpmg.Name as RequestedByGroup
FROM
    PermitRequestMontreal PermitRequest
	INNER JOIN PermitRequestMontrealFunctionalLocation prmfl ON prmfl.PermitRequestMontrealId = PermitRequest.Id
	INNER JOIN FunctionalLocation FunctionalLocation ON prmfl.FunctionalLocationId = FunctionalLocation.Id
	INNER JOIN [User] LastModifiedByUser ON PermitRequest.LastModifiedByUserId = LastModifiedByUser.Id
	LEFT JOIN [User] LastImportedByUser ON PermitRequest.LastImportedByUserId = LastImportedByUser.Id
	LEFT JOIN [User] LastSubmittedByUser ON PermitRequest.LastSubmittedByUserId = LastSubmittedByUser.Id
	left outer join WorkPermitMontrealGroup wpmg on wpmg.Id = PermitRequest.RequestedByGroupId
WHERE
	PermitRequest.StartDate <= @ToDate AND 
	PermitRequest.EndDate >= @FromDate AND
	EXISTS
	(
		-- Floc of permit request matches one of the passed in flocs
		select ids.Id
		from IDSplitter(@FlocIds) ids
		inner join PermitRequestMontrealFunctionalLocation prmfl on prmfl.FunctionalLocationId = ids.Id
		where prmfl.PermitRequestMontrealId = PermitRequest.Id
		
		UNION ALL
		
		-- Floc of permit request is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ids.Id
		from FunctionalLocationAncestor a
		inner join IDSplitter(@FlocIds) ids on ids.Id = a.AncestorId
		inner join PermitRequestMontrealFunctionalLocation prmfl on prmfl.FunctionalLocationId = a.Id
		where prmfl.PermitRequestMontrealId = PermitRequest.Id
	) AND
	PermitRequest.Deleted = 0
order by PermitRequest.StartDate desc
OPTION (OPTIMIZE FOR UNKNOWN)	  

GO

GRANT EXEC ON QueryPermitRequestMontrealDTOsByFlocUnitAndBelow TO PUBLIC
GO