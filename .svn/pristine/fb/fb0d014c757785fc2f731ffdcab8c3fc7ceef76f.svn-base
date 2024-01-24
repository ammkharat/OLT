
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[WorkPermitGasTestElementInfoForSELC]') AND type in (N'U'))

CREATE TABLE [dbo].[WorkPermitGasTestElementInfoForSELC](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkPermitId] [bigint] NOT NULL,
	[GasTestElementInfoId] [bigint] NOT NULL,
	[RequiredTest] [bit] DEFAULT 0 NOT NULL,
	[LegacyFirstTestResult] [varchar](50) NULL,
	[FirstTestResult] [float] NULL,
	[ConfinedSpaceTestResult] [float] NULL,
	[ConfinedSpaceTestRequired] [bit] DEFAULT 0 NOT NULL,
	[SystemEntryTestResult] [float] NULL,
	[SystemEntryTestNotApplicable] [bit]  NOT NULL,
 CONSTRAINT [PK_WorkPermitGasTestElementInfoForSELC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[WorkPermitId] ASC,
	[GasTestElementInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

IF NOT  EXISTS(SELECT * FROM SYS.OBJECTS WHERE TYPE_DESC =  'DEFAULT_CONSTRAINT' AND NAME = 'DF_WorkPermitGasTestElementInfoForSELC_SystemEntryTestNotApplicable')
BEGIN

ALTER TABLE [dbo].[WorkPermitGasTestElementInfoForSELC] ADD  CONSTRAINT [DF_WorkPermitGasTestElementInfoForSELC_SystemEntryTestNotApplicable]  DEFAULT ((0)) FOR [SystemEntryTestNotApplicable]

END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_WorkPermitGasTestElementInfoForSELC_GasTestElementId')
BEGIN
ALTER TABLE [dbo].[WorkPermitGasTestElementInfoForSELC]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitGasTestElementInfoForSELC_GasTestElementId] FOREIGN KEY([GasTestElementInfoId])
REFERENCES [dbo].[GasTestElementInfo] ([Id])

END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_WorkPermitGasTestElementInfoForSELC_GasTestElementId')
BEGIN

ALTER TABLE [dbo].[WorkPermitGasTestElementInfoForSELC] CHECK CONSTRAINT [FK_WorkPermitGasTestElementInfoForSELC_GasTestElementId]

END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_WorkPermitGasTestElementInfoForSELC_WorkPermitId')
BEGIN

ALTER TABLE [dbo].[WorkPermitGasTestElementInfoForSELC]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitGasTestElementInfoForSELC_WorkPermitId] FOREIGN KEY([WorkPermitId])
REFERENCES [dbo].[WorkPermitUSPipeline] ([Id])

END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_WorkPermitGasTestElementInfoForSELC_WorkPermitId')
BEGIN

ALTER TABLE [dbo].[WorkPermitGasTestElementInfoForSELC] CHECK CONSTRAINT [FK_WorkPermitGasTestElementInfoForSELC_WorkPermitId]

END
GO

