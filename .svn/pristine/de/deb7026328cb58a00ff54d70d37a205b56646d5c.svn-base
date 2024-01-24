
CREATE TABLE [dbo].[SAPImportPriorityWorkPermitEdmontonGroup](
	[SAPImportPriority] [int] NOT NULL,
	[WorkPermitEdmontonGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SAPImportPriorityWorkPermitEdmontonGroup] PRIMARY KEY CLUSTERED 
(
	[SAPImportPriority] ASC,
	[WorkPermitEdmontonGroupId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SAPImportPriorityWorkPermitEdmontonGroup]  WITH CHECK ADD  CONSTRAINT [FK_SAPImportPriorityWorkPermitEdmontonGroup_WorkPermitEdmontonGroup] FOREIGN KEY([WorkPermitEdmontonGroupId])
REFERENCES [dbo].[WorkPermitEdmontonGroup] ([Id])
GO




insert into SAPImportPriorityWorkPermitEdmontonGroup (SAPImportPriority, WorkPermitEdmontonGroupId)
select 0, wpeg.Id
from WorkPermitEdmontonGroup wpeg
where wpeg.Name = 'Maintenance'

insert into SAPImportPriorityWorkPermitEdmontonGroup (SAPImportPriority, WorkPermitEdmontonGroupId)
select 1, wpeg.Id
from WorkPermitEdmontonGroup wpeg
where wpeg.Name = 'Maintenance'

insert into SAPImportPriorityWorkPermitEdmontonGroup (SAPImportPriority, WorkPermitEdmontonGroupId)
select 2, wpeg.Id
from WorkPermitEdmontonGroup wpeg
where wpeg.Name = 'Maintenance'

insert into SAPImportPriorityWorkPermitEdmontonGroup (SAPImportPriority, WorkPermitEdmontonGroupId)
select 3, wpeg.Id
from WorkPermitEdmontonGroup wpeg
where wpeg.Name = 'Turnaround'

insert into SAPImportPriorityWorkPermitEdmontonGroup (SAPImportPriority, WorkPermitEdmontonGroupId)
select 4, wpeg.Id
from WorkPermitEdmontonGroup wpeg
where wpeg.Name = 'Outage'

insert into SAPImportPriorityWorkPermitEdmontonGroup (SAPImportPriority, WorkPermitEdmontonGroupId)
select 999, wpeg.Id
from WorkPermitEdmontonGroup wpeg
where wpeg.Name = '(Not Set)'

go


alter table WorkPermitEdmontonGroup drop column SAPImportPriorityList







GO

