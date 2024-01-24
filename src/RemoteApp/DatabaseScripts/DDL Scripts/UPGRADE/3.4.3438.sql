CREATE TABLE [dbo].[LogTemplateWorkAssignment](
	[LogTemplateId] [bigint] NOT NULL,
	[WorkAssignmentId] [bigint] NOT NULL
)
GO

ALTER TABLE [dbo].[LogTemplateWorkAssignment]
ADD CONSTRAINT [FK_LogTemplateWorkAssignment_LogTemplate] 
FOREIGN KEY([LogTemplateId])
REFERENCES [dbo].[LogTemplate] ([Id])
GO

ALTER TABLE [dbo].[LogTemplateWorkAssignment]
ADD CONSTRAINT [FK_LogTemplateWorkAssignment_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO

insert into LogTemplateWorkAssignment (LogTemplateId, WorkAssignmentId)
select distinct ltfl.LogTemplateId, wa.Id
from LogTemplateFunctionalLocation ltfl
inner join FunctionalLocation fl1 on ltfl.FunctionalLocationId = fl1.Id
inner join FunctionalLocation fl2 on fl1.Division = fl2.Division
inner join WorkAssignmentFunctionalLocation wafl on wafl.FunctionalLocationId = fl2.Id
inner join WorkAssignment wa on wafl.WorkAssignmentId = wa.Id
where wa.Deleted = 0 and fl1.Deleted = 0;

GO

drop table LogTemplateFunctionalLocation

GO

GO
