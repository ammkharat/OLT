-- Create the new WA & FLOC association for #1570
insert into [WorkAssignment]([Name],[Description],SiteId,Deleted,RoleId,Category) select 'Superviseur de Laboratoire', 'Superviseur de Laboratoire', 9, 0, role.id, 'Laboratoire' from role where role.name = 'Superviseur';

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) select a.id, f.id from functionallocation f, workassignment a where f.fullhierarchy = 'MT1-A004-IFST' and a.name = 'Superviseur de Laboratoire' and a.description = 'Superviseur de Laboratoire';

GO

UPDATE [WorkAssignment]
SET [Name] = 'Laboratoire - Contrôle/Procédé'
WHERE Description = 'Laboratoire - Contrôle/Procédé';

GO

insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) select a.id, f.id from functionallocation f, workassignment a where f.fullhierarchy = 'MT1-A004-IFST' and a.name = 'Laboratoire - Contrôle/Procédé' and a.description = 'Laboratoire - Contrôle/Procédé';

GO



GO

