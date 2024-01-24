IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VReportingFormOP14')
BEGIN
	DROP VIEW VReportingFormOP14
END
GO

CREATE VIEW dbo.[VReportingFormOP14] WITH SCHEMABINDING
AS

select 
	f.Id as FormId,
	CASE 
      WHEN f.FormStatusId = 2 and GETDATE() > f.ValidToDateTime THEN 5
      WHEN f.FormStatusId = 1 and GETDATE() > f.ValidToDateTime THEN 5
		ELSE f.FormStatusId
    END as FormStatusId,	
	f.PlainTextContent,
	f.ValidFromDateTime,
	f.ValidToDateTime,
	f.ApprovedDateTime,
	f.ClosedDateTime,
	f.DepartmentId,
	f.IsTheCSDForAPressureSafetyValve,
	f.CreatedDateTime,
	f.LastModifiedDateTime,
	cu.Username as CreatedByUserName,
	cu.Firstname as CreatedByFirstName,
	cu.Lastname as CreatedByLastName,
	lu.Username as LastModifiedByUserName,
	lu.Firstname as LastModifiedByFirstName,
	lu.Lastname as LastModifiedByLastName,
	fl.Id as FunctionalLocationId,
	fl.FullHierarchy as FunctionalLocation,
	s.Id as SiteId,
	s.Name as Site	
from 
	dbo.FormOP14 f
	inner join dbo.[User] cu on cu.Id = f.CreatedByUserId
	inner join dbo.[User] lu on lu.Id = f.LastModifiedByUserId	
	inner join dbo.FormOP14FunctionalLocation ffl on ffl.FormOP14Id = f.Id
	inner join dbo.FunctionalLocation fl on fl.Id = ffl.FunctionalLocationId
	inner join dbo.[Site] s on s.Id = fl.SiteId
where f.Deleted = 0

GO
