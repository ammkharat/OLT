
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryPermitRequestMudsDTOsByFlocUnitAndBelow')
	BEGIN
		DROP Procedure [dbo].QueryPermitRequestMudsDTOsByFlocUnitAndBelow
	END
GO

--- TODO: get rid of the 'UnitAndBelow' in this query name as the query can work on any floc level now  
CREATE Procedure [dbo].[QueryPermitRequestMudsDTOsByFlocUnitAndBelow]  
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
 --wpmg.Name as RequestedByGroup  
 PermitRequest.RequestedByGroupId as RequestedByGroup  ,
 
-- PermitRequest.StartDateTime, -- commented after issue from 5.08 release 
 --PermitRequest.EndDateTime,

    DATEADD(day, 0, DATEDIFF(day, 0, PermitRequest.StartDate)) +    DATEADD(day, 0 - DATEDIFF(day, 0, PermitRequest.StartDateTime), PermitRequest.StartDateTime) as StartDateTime,
	DATEADD(day, 0, DATEDIFF(day, 0, PermitRequest.EndDate)) +    DATEADD(day, 0 - DATEDIFF(day, 0, PermitRequest.EndDateTime), PermitRequest.EndDateTime) as EndDateTime,
	
 PermitRequest.Analyse_Attribute_CheckBox,
 PermitRequest.Cadenassage_multiple_Attribute_CheckBox,
 PermitRequest.Cadenassage_simple_Attribute_CheckBox,
 PermitRequest.Procédure_Attribute_CheckBox,
 PermitRequest.Espace_clos_Attribute_CheckBox
FROM  
    PermitRequestMuds PermitRequest  
 INNER JOIN PermitRequestMudsFunctionalLocation prmfl ON prmfl.PermitRequestMudsId = PermitRequest.Id  
 INNER JOIN FunctionalLocation FunctionalLocation ON prmfl.FunctionalLocationId = FunctionalLocation.Id  
 INNER JOIN [User] LastModifiedByUser ON PermitRequest.LastModifiedByUserId = LastModifiedByUser.Id  
 LEFT JOIN [User] LastImportedByUser ON PermitRequest.LastImportedByUserId = LastImportedByUser.Id  
 LEFT JOIN [User] LastSubmittedByUser ON PermitRequest.LastSubmittedByUserId = LastSubmittedByUser.Id  
 --left outer join WorkPermitMudsGroup wpmg on wpmg.Id = PermitRequest.RequestedByGroupId  
WHERE  
 PermitRequest.StartDate <= @ToDate AND   
 PermitRequest.EndDate >= @FromDate AND  
 EXISTS  
 (  
  -- Floc of permit request matches one of the passed in flocs  
  select ids.Id  
  from IDSplitter(@FlocIds) ids  
  inner join PermitRequestMudsFunctionalLocation prmfl on prmfl.FunctionalLocationId = ids.Id  
  where prmfl.PermitRequestMudsId = PermitRequest.Id  
    
  UNION ALL  
    
  -- Floc of permit request is child of one of the passed in flocs (look down the floc tree from my selected flocs)  
  select ids.Id  
  from FunctionalLocationAncestor a  
  inner join IDSplitter(@FlocIds) ids on ids.Id = a.AncestorId  
  inner join PermitRequestMudsFunctionalLocation prmfl on prmfl.FunctionalLocationId = a.Id  
  where prmfl.PermitRequestMudsId = PermitRequest.Id  
 ) AND  
 PermitRequest.Deleted = 0  
order by PermitRequest.StartDate desc  
OPTION (OPTIMIZE FOR UNKNOWN)
GO


GRANT EXEC ON QueryPermitRequestMudsDTOsByFlocUnitAndBelow TO PUBLIC
GO
