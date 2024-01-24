insert into RoleElement(Id, Name, FunctionalArea) values (240, 'View Navigation - On Premise Personnel', 'On Premise Personnel')

insert into RoleElementTemplate (RoleElementId, RoleId) SELECT 240, r.Id FROM Role r where r.SiteId = 8 and r.[Name] IN ('Contractor / Tradesperson', 'Supervisor', 'Scheduler', 'Support Coordinator', 'Administrator')


GO

