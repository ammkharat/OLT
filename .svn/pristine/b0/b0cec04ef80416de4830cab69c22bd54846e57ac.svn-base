-- Add "Clone Permit Request" security role element to the following Montreal roles: Administrateur des Permis, Coordonnateur de l'Entretien, Coordonnateur des Op�rations, Entrepreneur de l'Entretien, Superviseur de l'Entretien
INSERT INTO RoleElementTemplate (
   RoleElementId
  ,RoleId
) SELECT 
  197, r.Id FROM [Role] r
WHERE 
  r.SiteId = 9 and r.[ActiveDirectoryKey] IN ('PermitAdministrator', 'MaintenanceCoordinator', 'OperationsCoordinator', 'MaintenanceContractor', 'MaintenanceSupervisor')
GO




GO

