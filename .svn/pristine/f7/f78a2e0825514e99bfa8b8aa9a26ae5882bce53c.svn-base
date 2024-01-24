CREATE TABLE [dbo].[SummaryLogCustomFieldGroupWorkAssignment](
	[SummaryLogCustomFieldGroupId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL);

GO

ALTER TABLE [dbo].[SummaryLogCustomFieldGroupWorkAssignment] 
ADD CONSTRAINT [FK_SummaryLogCustomFieldGroupWorkAssignment_SummaryLogCustomFieldGroup] 
FOREIGN KEY([SummaryLogCustomFieldGroupId])
REFERENCES [dbo].[SummaryLogCustomFieldGroup] ([Id])
GO

ALTER TABLE [dbo].[SummaryLogCustomFieldGroupWorkAssignment] 
ADD CONSTRAINT [FK_SummaryLogCustomFieldGroupWorkAssignment_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO
/*
insert into SummaryLogCustomFieldGroupWorkAssignment (SummaryLogCustomFieldGroupId, WorkAssignmentId)
select distinct cfgfl.SummaryLogCustomFieldGroupId, wa.Id from SummaryLogCustomFieldGroupFunctionalLocation cfgfl
inner join FunctionalLocation fl1 on cfgfl.FunctionalLocationId = fl1.Id
inner join FunctionalLocation fl2 on fl1.Division = fl2.Division and fl1.Section = fl2.Section
inner join WorkAssignmentFunctionalLocation wafl on wafl.FunctionalLocationId = fl2.Id
inner join WorkAssignment wa on wafl.WorkAssignmentId = wa.Id
where wa.RoleId = 1
*/
insert into SummaryLogCustomFieldGroupWorkAssignment (SummaryLogCustomFieldGroupId, WorkAssignmentId)
select distinct cfgfl.SummaryLogCustomFieldGroupId, wa.Id from SummaryLogCustomFieldGroupFunctionalLocation cfgfl
inner join FunctionalLocation fl1 on cfgfl.FunctionalLocationId = fl1.Id
inner join FunctionalLocation fl2 on 
  (fl1.Division = fl2.Division and fl1.Section = fl2.Section and fl2.Section is not null) 
  or (fl1.Division = fl2.Division and fl2.Section is null)
inner join WorkAssignmentFunctionalLocation wafl on wafl.FunctionalLocationId = fl2.Id
inner join WorkAssignment wa on wafl.WorkAssignmentId = wa.Id
where wa.RoleId = 1

GO

drop table SummaryLogCustomFieldGroupFunctionalLocation

GO
GO
