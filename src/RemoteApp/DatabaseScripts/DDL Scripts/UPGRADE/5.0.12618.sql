
IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'DocumentLink' AND COLUMN_NAME = 'PermitRequestFortHillsId')
BEGIN
    ALTER TABLE DocumentLink ADD PermitRequestFortHillsId bigint NULL;  
END



GO


IF  EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='SAPImportPriorityWorkPermitFortHillsGroup' AND XTYPE='U')
    BEGIN
    DROP Table SAPImportPriorityWorkPermitFortHillsGroup
    END
GO


CREATE TABLE [dbo].[SAPImportPriorityWorkPermitFortHillsGroup](
	[SAPImportPriority] [int] NOT NULL,
	[WorkPermitFortHillsGroupId] [bigint] NOT NULL,
 CONSTRAINT [PK_SAPImportPriorityWorkPermitFortHillsGroup] PRIMARY KEY CLUSTERED 
(
	[SAPImportPriority] ASC,
	[WorkPermitFortHillsGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--ALTER TABLE [dbo].[SAPImportPriorityWorkPermitFortHillsGroup]  WITH CHECK ADD  CONSTRAINT [FK_SAPImportPriorityWorkPermitFortHillsGroup_WorkPermitFortHillsGroup] FOREIGN KEY([WorkPermitFortHillsGroupId])
--REFERENCES [dbo].[WorkPermitFortHillsGroup] ([Id])
--GO

--ALTER TABLE [dbo].[SAPImportPriorityWorkPermitFortHillsGroup] CHECK CONSTRAINT [FK_SAPImportPriorityWorkPermitFortHillsGroup_WorkPermitFortHillsGroup]
--GO



IF NOT (SELECT COUNT(*) FROM SAPImportPriorityWorkPermitFortHillsGroup)>0
BEGIN
Insert INTO SAPImportPriorityWorkPermitFortHillsGroup (SAPImportPriority, WorkPermitFortHillsGroupId)VALUES (0,1),(1,1),(2,1),(3,3),(4,4),(999,5)
END


GO


IF  EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME='WorkPermitFortHillsGroup' AND XTYPE='U')
    BEGIN
    DROP Table WorkPermitFortHillsGroup
    END
GO

CREATE TABLE [dbo].[WorkPermitFortHillsGroup](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DefaultToDayShiftOnSapImport] [bit] NOT NULL,
 CONSTRAINT [PK_WorkPermitFortHillsGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


IF NOT (SELECT COUNT(*) FROM WORKPERMITFORTHILLSGROUP)>0
BEGIN
INSERT INTO WORKPERMITFORTHILLSGROUP (NAME,DISPLAYORDER,DELETED,DEFAULTTODAYSHIFTONSAPIMPORT) VALUES ('Maintenance FH',0,0,1),('Construction FH',1,0,1),('Turnaround FH',2,0,0),('Outage FH',3,0,0),('(Not Set) FH',4,1,0)
END



GO

