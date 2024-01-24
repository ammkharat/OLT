INSERT INTO FunctionalLocationOperationalMode
( UnitId, OperationalModeId, AvailabilityReasonId, LastModifiedDateTime)
(
    Select
        FunctionalLocation.Id,
        0,
        0,
        GETDATE()
    FROM
        FunctionalLocation
    WHERE
		[Level] = 3
		AND NOT EXISTS(SELECT UnitID FROM FunctionalLocationOperationalMode WHERE UnitId = FunctionalLocation.Id)
)
GO

-- missing roleelementtemplates for rolepermissions
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) VALUES (
   99   -- RoleElementId - bigint
  ,196   -- RoleId - bigint
) 

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) VALUES (
   177   -- RoleElementId - bigint
  ,196   -- RoleId - bigint
) 


INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) VALUES (
   98   -- RoleElementId - bigint
  ,197   -- RoleId - bigint
) 

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) VALUES (
   99   -- RoleElementId - bigint
  ,197   -- RoleId - bigint
) 

INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) VALUES (
   177   -- RoleElementId - bigint
  ,197   -- RoleId - bigint
) 
GO



GO

