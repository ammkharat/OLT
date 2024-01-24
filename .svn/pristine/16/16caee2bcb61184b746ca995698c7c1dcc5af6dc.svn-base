CREATE TABLE [dbo].[SAPImportPriorityWorkPermitLubesGroup](
	SAPImportPriority int NULL,
	SAPPlannerGroup varchar(25) NULL,
	WorkPermitLubesGroupId bigint NOT NULL
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SAPImportPriorityWorkPermitLubesGroup]
WITH CHECK ADD  CONSTRAINT [FK_SAPImportPriorityWorkPermitLubesGroup_WorkPermitLubesGroup] 
FOREIGN KEY([WorkPermitLubesGroupId])
REFERENCES [dbo].[WorkPermitLubesGroup] ([Id])

insert into SAPImportPriorityWorkPermitLubesGroup (SAPImportPriority, SAPPlannerGroup, WorkPermitLubesGroupId)
select 1, null, wplg.Id
from WorkPermitLubesGroup wplg
where wplg.Name = 'Maintenance';

insert into SAPImportPriorityWorkPermitLubesGroup (SAPImportPriority, SAPPlannerGroup, WorkPermitLubesGroupId)
select 2, null, wplg.Id
from WorkPermitLubesGroup wplg
where wplg.Name = 'Maintenance';

insert into SAPImportPriorityWorkPermitLubesGroup (SAPImportPriority, SAPPlannerGroup, WorkPermitLubesGroupId)
select 3, null, wplg.Id
from WorkPermitLubesGroup wplg
where wplg.Name = 'Turnaround';

insert into SAPImportPriorityWorkPermitLubesGroup (SAPImportPriority, SAPPlannerGroup, WorkPermitLubesGroupId)
select 4, null, wplg.Id
from WorkPermitLubesGroup wplg
where wplg.Name = 'Outage';

insert into SAPImportPriorityWorkPermitLubesGroup (SAPImportPriority, SAPPlannerGroup, WorkPermitLubesGroupId)
select null, 'PE1', wplg.Id
from WorkPermitLubesGroup wplg
where wplg.Name = 'Construction';







GO

