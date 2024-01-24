IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[SAPImportPriorityWorkPermitFortHillsGroup]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[SAPImportPriorityWorkPermitFortHillsGroup](
	[SAPImportPriority] [int] NOT NULL,
	[WorkPermitFortHillsGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SAPImportPriorityWorkPermitFortHillsGroup] PRIMARY KEY CLUSTERED 
(
	[SAPImportPriority] ASC,
	[WorkPermitFortHillsGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

END

--ALTER TABLE [dbo].[SAPImportPriorityWorkPermitFortHillsGroup]  WITH CHECK ADD  CONSTRAINT [FK_SAPImportPriorityWorkPermitFortHillsGroup_WorkPermitFortHillsGroup] FOREIGN KEY([WorkPermitFortHillsGroupId])
--REFERENCES [dbo].[WorkPermitFortHillsGroup] ([Id])
--GO

--ALTER TABLE [dbo].[SAPImportPriorityWorkPermitFortHillsGroup] CHECK CONSTRAINT [FK_SAPImportPriorityWorkPermitFortHillsGroup_WorkPermitFortHillsGroup]
--GO



IF NOT (SELECT COUNT(*) FROM SAPImportPriorityWorkPermitFortHillsGroup)>0
BEGIN
Insert INTO SAPImportPriorityWorkPermitFortHillsGroup (SAPImportPriority, WorkPermitFortHillsGroupId)VALUES (0,1),(1,1),(2,1),(3,3),(4,4),(999,5)
END