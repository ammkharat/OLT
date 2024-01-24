INSERT INTO dbo.WorkAssignment ([Name],[Description],SiteId,Deleted,RoleId,Category,UseWorkAssignmentForActionItemHandoverDisplay,CopyTargetAlertResponseToLog) 
  (SELECT 'TDS Reliability Engineer', 'TDS Reliability Engineer',6, 0, r.Id, 'General', 1, 1 from [Role] r where r.SiteId = 6 and r.[Name]='TDS Engineer');     


insert into [WorkAssignmentFunctionalLocation]([WorkAssignmentId],[FunctionalLocationId]) 
select a.id, f.id from functionallocation f, workassignment a where f.siteid = 6 and f.fullhierarchy = 'OS1' and a.[name] = 'TDS Reliability Engineer' and a.siteId = 6;  

INSERT INTO WorkAssignmentVisibilityGroup (
   VisibilityGroupId
  ,WorkAssignmentId
  ,VisibilityType
) SELECT vg.Id, wa.Id, 1 from VisibilityGroup vg, WorkAssignment wa where vg.SiteId = 6 and wa.SiteId = 6 and wa.[Name] = 'TDS Reliability Engineer'

INSERT INTO WorkAssignmentVisibilityGroup (
   VisibilityGroupId
  ,WorkAssignmentId
  ,VisibilityType
) SELECT vg.Id, wa.Id, 2 from VisibilityGroup vg, WorkAssignment wa where vg.SiteId = 6 and wa.SiteId = 6 and wa.[Name] = 'TDS Reliability Engineer'



GO

