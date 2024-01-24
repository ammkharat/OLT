-- Copy all the assignments that are used for work permit auto assignment
insert into WorkPermitAutoAssignmentConfigurationFunctionalLocation (WorkAssignmentId, FunctionalLocationId)
select wafl.WorkAssignmentId, wafl.FunctionalLocationId
from WorkAssignmentFunctionalLocation wafl
inner join WorkAssignment wa on wafl.WorkAssignmentId = wa.Id
where wa.UseForWorkPermitAutoAssignment = 1;

GO

-- Insert unit level where needed (note that Sarnia has assigned 4th and 5th level FLOCs that aren't 
-- for work permit auto-assignment)
insert into WorkAssignmentFunctionalLocation (FunctionalLocationId, WorkAssignmentId)
select distinct fl.UnitId, wa.Id from WorkAssignmentFunctionalLocation wafl
inner join WorkAssignment wa on wafl.WorkAssignmentId = wa.Id
inner join FunctionalLocation fl on wafl.FunctionalLocationId = fl.Id
where fl.Equipment1 is not null
and fl.UnitId not in (
  select wafl2.FunctionalLocationId from WorkAssignmentFunctionalLocation wafl2 
    where wafl2.WorkAssignmentId = wafl.WorkAssignmentId);

GO

-- Remove work assignment associations that aren't unit level or higher
delete from WorkAssignmentFunctionalLocation
where FunctionalLocationId in (
  select fl.Id from FunctionalLocation fl where fl.Equipment1 is not null)

GO

-- Remove the UseForWorkPermitAutoAssignment column
alter table WorkAssignment drop column UseForWorkPermitAutoAssignment

GO

GO
