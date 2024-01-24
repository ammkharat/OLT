IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermitRequestFortHillsWorkOrderSource]') AND type in (N'U'))

BEGIN


CREATE TABLE [dbo].[PermitRequestFortHillsWorkOrderSource](
	[PermitRequestFortHillsId] [bigint] NOT NULL,
	[OperationNumber] [varchar](4) NULL,
	[SubOperationNumber] [varchar](4) NULL
) ON [PRIMARY]

--GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE [dbo].[PermitRequestFortHillsWorkOrderSource]  WITH CHECK ADD  CONSTRAINT [FK_PermitRequestFortHillsWorkOrderSource_PermitRequestFortHills] FOREIGN KEY([PermitRequestFortHillsId])
--REFERENCES [dbo].[PermitRequestFortHills] ([Id])
--GO

--ALTER TABLE [dbo].[PermitRequestFortHillsWorkOrderSource] CHECK CONSTRAINT [FK_PermitRequestFortHillsWorkOrderSource_PermitRequestFortHills]
--GO

END