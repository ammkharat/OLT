IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'temp_role')
	BEGIN
		DROP PROCEDURE [dbo].temp_role
	END
GO

CREATE Procedure [dbo].temp_role
  (
    @old_role VARCHAR(100), 
    @new_role VARCHAR(100), 
    @new_role_ad VARCHAR(200), 
    @new_role_alias VARCHAR(100)
  )
AS

INSERT INTO [Role] (
   [Name]
  ,deleted
  ,ActiveDirectoryKey
  ,IsAdministratorRole
  ,IsReadOnlyRole
  ,IsWorkPermitNonOperationsRole
  ,SiteId
  ,WarnIfWorkAssignmentNotSelected
  ,Alias
  ,IsDefaultReadOnlyRoleForSite
) SELECT 
   @new_role  -- Name - varchar(40)
  ,0   -- deleted - bit
  ,@new_role_ad  -- ActiveDirectoryKey - varchar(255)
  ,IsAdministratorRole-- IsAdministratorRole - bit
  ,IsReadOnlyRole-- IsReadOnlyRole - bit
  ,IsWorkPermitNonOperationsRole -- IsWorkPermitNonOperationsRole - bit
  ,SiteId -- SiteId - bigint
  ,WarnIfWorkAssignmentNotSelected -- WarnIfWorkAssignmentNotSelected - bit
  ,@new_role_alias -- Alias - varchar(10)
  ,0 -- IsDefaultReadOnlyRoleForSite - bit
FROM
  dbo.[Role]
WHERE
  SiteId = 3
  and [Name] = @old_role
  
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
   RoleElementId       
  ,new_role.Id
FROM
  Role new_role,
  Role old_role,
  RoleElementTemplate t
WHERE
  old_role.SiteId = 3
  and old_role.SiteId = new_role.SiteId
  and t.RoleId = old_role.Id
  and old_role.[Name] = @old_role
  and new_role.[Name] = @new_role
GO

EXEC dbo.temp_role 'Area Manager', 'Upgrading Area Manager', 'UpgradingAreaManager', 'upgareamgr'
EXEC dbo.temp_role 'Area Manager', 'Extraction Area Manager', 'ExtractionAreaManager', 'extareamgr'

EXEC dbo.temp_role 'Operator', 'Upgrading Operator', 'UpgradingOperator', 'upgoper'
EXEC dbo.temp_role 'Operator', 'Extraction Operator', 'ExtractionOperator', 'extoper'

EXEC dbo.temp_role 'Supervisor', 'Upgrading Supervisor', 'UpgradingSupervisor', 'upgsuper'
EXEC dbo.temp_role 'Supervisor', 'Extraction Supervisor', 'ExtractionSupervisor', 'extsuper'

EXEC dbo.temp_role 'Unit Leader', 'Upgrading Unit Leader', 'UpgradingUnitLeader', 'upgulead'
EXEC dbo.temp_role 'Unit Leader', 'Extraction Unit Leader', 'ExtractionUnitLeader', 'extulead'

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'temp_role')
	BEGIN
		DROP PROCEDURE [dbo].temp_role
	END
GO

INSERT INTO RolePermission (
   RoleId
  ,RoleElementId
  ,CreatedByRoleId
) SELECT 
   new_role.Id   AS RoleId                  -- RoleId - bigint
  ,rp.RoleelementId   AS RoleElementId           -- RoleElementId - bigint
  ,rp.CreatedByRoleId   AS CreatedByRoleId         -- CreatedByRoleId - bigint
FROM  
  RolePermission rp,
  Role new_role,
  Role old_role
WHERE
  old_role.SiteId = 3
  and new_role.SiteId = old_role.SiteId
  and old_role.Id = rp.RoleId
  and new_role.[Name] != 'Upgrading Student'
  and new_role.[Name] LIKE 'Upgrading %'
  and REPLACE(new_role.[Name], 'Upgrading ', '') = old_role.[Name]
GO

INSERT INTO RolePermission (
   RoleId
  ,RoleElementId
  ,CreatedByRoleId
) SELECT 
   rp.RoleId   AS RoleId                  -- RoleId - bigint
  ,rp.RoleelementId   AS RoleElementId           -- RoleElementId - bigint
  ,new_role.Id   AS CreatedByRoleId         -- CreatedByRoleId - bigint
FROM  
  Role new_role,
  RolePermission rp
  INNER JOIN Role old_role1 on rp.RoleId = old_role1.Id
  INNER JOIN Role old_role2 on rp.CreatedByRoleId = old_role2.Id
WHERE
  new_role.SiteId = 3
  and old_role1.SiteId = new_role.SiteId
  and new_role.[Name] != 'Upgrading Student'
  and new_role.[Name] LIKE 'Upgrading %'
  and REPLACE(new_role.[Name], 'Upgrading ', '') = old_role2.[Name]
GO
  
INSERT INTO RolePermission (
   RoleId
  ,RoleElementId
  ,CreatedByRoleId
) SELECT 
   new_role.Id   AS RoleId                  -- RoleId - bigint
  ,rp.RoleelementId   AS RoleElementId           -- RoleElementId - bigint
  ,rp.CreatedByRoleId   AS CreatedByRoleId         -- CreatedByRoleId - bigint
FROM  
  RolePermission rp,
  Role new_role,
  Role old_role
WHERE
  old_role.SiteId = 3
  and new_role.SiteId = old_role.SiteId
  and old_role.Id = rp.RoleId
  and new_role.[Name] LIKE 'Extraction %'
  and REPLACE(new_role.[Name], 'Extraction ', '') = old_role.[Name]
GO

INSERT INTO RolePermission (
   RoleId
  ,RoleElementId
  ,CreatedByRoleId
) SELECT 
   rp.RoleId   AS RoleId                  -- RoleId - bigint
  ,rp.RoleelementId   AS RoleElementId           -- RoleElementId - bigint
  ,new_role.Id   AS CreatedByRoleId         -- CreatedByRoleId - bigint
FROM  
  Role new_role,
  RolePermission rp
  INNER JOIN Role old_role1 on rp.RoleId = old_role1.Id
  INNER JOIN Role old_role2 on rp.CreatedByRoleId = old_role2.Id
WHERE
  new_role.SiteId = 3
  and old_role1.SiteId = new_role.SiteId
  and new_role.[Name] LIKE 'Extraction %'
  and REPLACE(new_role.[Name], 'Extraction ', '') = old_role2.[Name]
GO
  
DELETE rp
FROM
  RolePermission rp
  INNER JOIN Role r1 on rp.RoleId = r1.Id
  INNER JOIN Role r2 ON rp.CreatedByRoleId = r2.Id
WHERE
  r1.SiteId = 3 and r2.SiteId = 3
  and r1.[Name] LIKE 'Extraction %' and r2.[Name] LIKE 'Upgrading %'
GO

DELETE rp
FROM
  RolePermission rp
  INNER JOIN Role r1 on rp.RoleId = r1.Id
  INNER JOIN Role r2 ON rp.CreatedByRoleId = r2.Id
WHERE
  r1.SiteId = 3 and r2.SiteId = 3
  and r1.[Name] LIKE 'Upgrading %' and r2.[Name] LIKE 'Extraction %'
GO



GO

