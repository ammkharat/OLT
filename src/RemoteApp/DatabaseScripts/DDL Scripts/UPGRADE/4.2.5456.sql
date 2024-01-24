
declare @roleId as bigint

INSERT INTO dbo.[Role] (
   [Name]
  ,deleted
  ,ActiveDirectoryKey
  ,IsAdministratorRole
  ,IsReadOnlyRole
  ,IsWorkPermitNonOperationsRole
  ,SiteId
  ,WarnIfWorkAssignmentNotSelected
  ,Alias
) VALUES (
   'Entrepreneur de l''Entretien'  -- Name - varchar(40)
  ,0  -- deleted - bit
  ,'MaintenanceContractor'  -- ActiveDirectoryKey - varchar(255)
  ,0  -- IsAdministratorRole - bit
  ,0  -- IsReadOnlyRole - bit
  ,1  -- IsWorkPermitNonOperationsRole - bit
  ,9   -- SiteId - bigint
  ,0  -- WarnIfWorkAssignmentNotSelected - bit
  ,'entre'  -- Alias - varchar(10)
)

set @roleid = @@IDENTITY

INSERT INTO dbo.RoleDisplayConfiguration (
   RoleId
  ,SectionId
  ,PrimaryDefaultPageId
  ,SecondaryDefaultPageId
) VALUES (
   @roleId   -- RoleId - bigint
  ,8   -- SectionId - int
  ,26   -- PrimaryDefaultPageId - int
  ,null   -- SecondaryDefaultPageId - int
)

INSERT INTO RoleElementTemplate VALUES(24, @roleId) -- View Permit
INSERT INTO RoleElementTemplate VALUES(181, @roleId) -- View Permit Requests
INSERT INTO RoleElementTemplate VALUES(192, @roleId) -- View Confined Space Documents
INSERT INTO RoleElementTemplate VALUES(182, @roleId) -- Create Permit Request
INSERT INTO RoleElementTemplate VALUES(183, @roleId) -- Edit Permit Request
INSERT INTO RoleElementTemplate VALUES(184, @roleId) -- Delete Permit Request
INSERT INTO RoleElementTemplate VALUES(185, @roleId) -- Submit Permit Request
INSERT INTO RoleElementTemplate VALUES(186, @roleId) -- Import Permit Requests

INSERT INTO RoleElementTemplate VALUES(96, @roleId) -- View Directives
INSERT INTO RoleElementTemplate VALUES(178, @roleId) -- View Standing Orders

INSERT INTO RoleElementTemplate VALUES(1, @roleId) -- View Action Item Definition
INSERT INTO RoleElementTemplate VALUES(39, @roleId) -- View Action Item

INSERT INTO RoleElementTemplate VALUES(33, @roleId) -- View Log

INSERT INTO RoleElementTemplate VALUES(88, @roleId) -- View Summary Logs

INSERT INTO RoleElementTemplate VALUES(114, @roleId) -- View Shift Handover


GO

