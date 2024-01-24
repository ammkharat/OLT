if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FormOvertimeFormHistory]') and OBJECTPROPERTY(id, N'IsTable') = 1)
DROP TABLE FormOvertimeFormHistory;
GO

CREATE TABLE [dbo].[FormOvertimeFormHistory](
	[Id] [bigint] NOT NULL,
	[FormStatusId] [int] NOT NULL,
	[FromDateTime] [datetime] NOT NULL,
	[ToDateTime] [datetime] NOT NULL,	
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[FunctionalLocation] varchar(max) NOT NULL,
	[TradeOccupation] varchar(50) NOT NULL,
	[OnSitePersonnel] varchar(max) NOT NULL,	
	[Approvals] varchar(max) NULL,
	[DocumentLinks] varchar(max) NULL,
	[ApprovedDateTime] [datetime] NULL,
	[CancelledDateTime] [datetime] NULL	
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FormOvertimeFormHistory]  WITH CHECK ADD  CONSTRAINT [FK_FormOvertimeFormHistory_LastModifiedByUser] FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[FormOvertimeFormHistory] CHECK CONSTRAINT [FK_FormOvertimeFormHistory_LastModifiedByUser]
GO


CREATE CLUSTERED INDEX [IDX_FormOvertimeFormHistory]
ON [dbo].[FormOvertimeFormHistory]
([Id])
WITH
(
PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ONLINE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE
)
ON [PRIMARY];
GO




GO

