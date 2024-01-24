delete from roleelementtemplate where roleelementid = '198' and roleid in (121,122,129,130)
GO

delete from roleelementtemplate where roleelementid = '250'
GO

delete from roleelement where name = 'Show Active CSDs on Shift Handover Report'
GO

INSERT INTO RoleElement (
   Id
  ,[Name]
  ,FunctionalArea
) VALUES (
   250   -- Id - bigint
  ,'Delete Form - Lubes CSD'  -- Name - varchar(60)
  ,'Forms'  -- FunctionalArea - varchar(100)
)
GO
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  250, r.Id FROM [Role] r
WHERE 
  r.SiteId = 10 and r.[Name] IN ('Operator', 'Lead Technician', 'Supervisor', 'Operations Coordinator')
GO


GO

