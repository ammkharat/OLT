CREATE TABLE [dbo].[OvertimeForm] (
[Id] bigint NOT NULL,
[FormStatusId] tinyint NOT NULL,
[CreatedByUserId] bigint NOT NULL,
[CreatedDateTime] datetime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[LastModifiedDateTime] datetime NOT NULL,
[Deleted] bit NOT NULL,
[ValidFromDateTime] datetime NOT NULL,
[ValidToDateTime] datetime NOT NULL,
[ApprovedDateTime] datetime NULL,
[CancelledDateTime] datetime NULL,
[Trade] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FunctionalLocationId] bigint NOT NULL,
CONSTRAINT [PK_OvertimeForm]
PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_OvertimeForm_FunctionalLocation]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] ),
CONSTRAINT [FK_OvertimeForm_CreatedUser]
FOREIGN KEY ([CreatedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_OvertimeForm_LastModifiedUser]
FOREIGN KEY ([LastModifiedByUserId])
REFERENCES [dbo].[User] ( [Id] )
)
ON [PRIMARY];
GO

-- index for grids
CREATE NONCLUSTERED INDEX [IDX_OvertimeForm_DTO]
ON [dbo].[OvertimeForm]
([ValidFromDateTime] , [ValidToDateTime] , [FormStatusId])
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

CREATE TABLE [dbo].[OvertimeFormContractor] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[OvertimeFormId] bigint NOT NULL,
[Person] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PrimaryLocation] varchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[StartDateTime] datetime NOT NULL,
[EndDateTime] datetime NOT NULL,
[IsDayShift] bit NOT NULL,
[IsNightShift] bit NOT NULL,
[PhoneNumber] varchar(25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Radio] varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Company] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[WorkOrderNumber] varchar(15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ExpectedHours] decimal(8, 2) NOT NULL,
[Deleted] bit NOT NULL,
PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_OvertimeContractor_Overtime]
FOREIGN KEY ([OvertimeFormId])
REFERENCES [dbo].[OvertimeForm] ( [Id] )
)
ON [PRIMARY];
GO

CREATE TABLE [dbo].[OvertimeFormApproval] (
[Id] bigint IDENTITY(1, 1) NOT FOR REPLICATION NOT NULL,
[OvertimeFormId] bigint NOT NULL,
	[Approver] [varchar](100) NOT NULL,
	[ApprovedByUserId] [bigint] NULL,
	[ApprovalDateTime] [datetime] NULL,
	[ShouldBeEnabledBehaviourId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
CONSTRAINT [FK_OvertimeApproval_ApprovedUser]
FOREIGN KEY ([ApprovedByUserId])
REFERENCES [dbo].[User] ( [Id] ),
CONSTRAINT [FK_OvertimeApproval_OvertimeForm]
FOREIGN KEY ([OvertimeFormId])
REFERENCES [dbo].[OvertimeForm] ( [Id] ),
CONSTRAINT [PK_OvertimeFormApproval]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[DocumentLink] ADD [OvertimeFormId] bigint SPARSE NULL
GO
ALTER TABLE [dbo].[DocumentLink] 
ADD  CONSTRAINT [FK_DocumentLink_OvertimeForm]
FOREIGN KEY ([OvertimeFormId])
REFERENCES [dbo].[OvertimeForm] ( [Id] )
GO

CREATE NONCLUSTERED INDEX [FK_Overtime_FormId]
ON [dbo].[OvertimeFormApproval]
([OvertimeFormId])
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

CREATE NONCLUSTERED INDEX [IDX_OvertimeFormContractor_OvertimeForm]
ON [dbo].[OvertimeFormContractor]
([OvertimeFormId])
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