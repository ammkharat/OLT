insert into ShiftHandoverConfigurationWorkAssignment (ShiftHandoverConfigurationId, WorkAssignmentId)
select distinct shqfl.ShiftHandoverConfigurationId, wa.Id
from ShiftHandoverConfigurationFunctionalLocation shqfl
inner join FunctionalLocation fl1 on shqfl.FunctionalLocationId = fl1.Id
inner join FunctionalLocation fl2 on fl1.Division = fl2.Division
inner join ShiftHandoverConfigurationRole shcr on shqfl.ShiftHandoverConfigurationId = shcr.ShiftHandoverConfigurationId
inner join WorkAssignmentFunctionalLocation wafl on wafl.FunctionalLocationId = fl2.Id
inner join WorkAssignment wa on (wafl.WorkAssignmentId = wa.Id and wa.RoleId = shcr.RoleId)
where wa.Deleted = 0

GO

drop table ShiftHandoverConfigurationRole;
drop table ShiftHandoverConfigurationFunctionalLocation;

GO

GO
