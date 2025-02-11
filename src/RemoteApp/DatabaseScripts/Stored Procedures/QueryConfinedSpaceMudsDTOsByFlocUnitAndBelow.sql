
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryConfinedSpaceMudsDTOsByFlocUnitAndBelow')
	BEGIN
		DROP Procedure [dbo].QueryConfinedSpaceMudsDTOsByFlocUnitAndBelow
	END
GO

Create Procedure [dbo].[QueryConfinedSpaceMudsDTOsByFlocUnitAndBelow]
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
    ConfinedSpaceMuds ConfinedSpace
	INNER JOIN FunctionalLocation FunctionalLocation ON ConfinedSpace.FunctionalLocationId = FunctionalLocation.Id
	INNER JOIN [User] LastModifiedByUser ON ConfinedSpace.LastModifiedByUserId = LastModifiedByUser.Id
WHERE
	ConfinedSpace.StartDateTime <= @ToDate AND 
	ConfinedSpace.Deleted = 0	
order by ConfinedSpace.StartDateTime desc
OPTION (OPTIMIZE FOR UNKNOWN)
GO

GRANT EXEC ON QueryConfinedSpaceMudsDTOsByFlocUnitAndBelow TO PUBLIC
GO
