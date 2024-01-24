if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryConfinedSpaceDTOsByFlocUnitAndBelow]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryConfinedSpaceDTOsByFlocUnitAndBelow]
GO

CREATE Procedure [dbo].[QueryConfinedSpaceDTOsByFlocUnitAndBelow]
    (
    @FlocIds varchar(MAX),
		@FromDate DateTime,
		@ToDate DateTime
    )
AS
	SELECT 
		ConfinedSpace.*, 
    FunctionalLocation.FullHierarchy as FunctionalLocationName,
    LastModifiedByUser.LastName AS LastModifiedByLastName,
    LastModifiedByUser.FirstName AS LastModifiedByFirstName,
    LastModifiedByUser.UserName AS LastModifiedByUserName
FROM
    ConfinedSpace ConfinedSpace
	INNER JOIN FunctionalLocation FunctionalLocation ON ConfinedSpace.FunctionalLocationId = FunctionalLocation.Id
	INNER JOIN [User] LastModifiedByUser ON ConfinedSpace.LastModifiedByUserId = LastModifiedByUser.Id
WHERE
	ConfinedSpace.StartDateTime <= @ToDate AND 
	ConfinedSpace.EndDateTime >= @FromDate AND
	EXISTS
	(
		-- Floc of confined space matches one of the passed in flocs
		select ids.Id
		from IDSplitter(@FlocIds) ids
		where ids.Id = FunctionalLocation.Id
		
		UNION ALL
		
		-- Floc of confined space is child of one of the passed in flocs (look down the floc tree from my selected flocs)
		select ids.Id
		from FunctionalLocationAncestor a
		inner join IDSplitter(@FlocIds) ids on ids.Id = a.AncestorId
		where a.Id = FunctionalLocation.Id
	)
	AND ConfinedSpace.Deleted = 0	
order by ConfinedSpace.StartDateTime desc
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC ON QueryConfinedSpaceDTOsByFlocUnitAndBelow TO PUBLIC
GO