insert into RoleElement values (149, 'View Coker Card');
insert into RoleElement values (150, 'Create Coker Card');
insert into RoleElement values (151, 'Edit Coker Card');
insert into RoleElement values (152, 'Delete Coker Card');

insert into RoleElementTemplate
select 149, r.Id, 3
from Role r
where exists (select roleid from roleelementtemplate t where t.roleid = r.id and t.siteid = 3)
and r.deleted = 0
;

go

insert into RoleElementTemplate
select 150, r.Id, 3
from Role r
where r.id in (1, 2) -- operator and supervisor
;

insert into RoleElementTemplate
select 151, r.Id, 3
from Role r
where r.id in (1, 2) -- operator and supervisor
;

insert into RoleElementTemplate
select 152, r.Id, 3
from Role r
where r.id in (1, 2) -- operator and supervisor
;

go



-- -----------------------------------------------------------------------


CREATE TABLE [dbo].[CokerCardConfiguration](  [Id] [bigint] IDENTITY(100,1) NOT NULL,  [Name] VARCHAR(40) NOT NULL,  [FunctionalLocationId] [bigint] NOT NULL,	  [Deleted] bit NOT NULL CONSTRAINT [PK_CokerCardConfiguration] PRIMARY KEY CLUSTERED ([Id] ASC))GOALTER TABLE [dbo].[CokerCardConfiguration] 	ADD CONSTRAINT [FK_CokerCardConfiguration_FunctionalLocation] FOREIGN KEY([FunctionalLocationId])	REFERENCES [dbo].[FunctionalLocation] ([Id])GOCREATE TABLE [dbo].[CokerCardConfigurationDrum] (  [Id] [bigint] IDENTITY(100,1) NOT NULL,  [Name] VARCHAR(20) NOT NULL,  [DisplayOrder] int NOT NULL,	  [CokerCardConfigurationId] [bigint] NOT NULL,  [Deleted] bit NOT NULL  CONSTRAINT [PK_CokerCardConfigurationDrum] PRIMARY KEY CLUSTERED ([Id] ASC))ALTER TABLE [dbo].[CokerCardConfigurationDrum] 	ADD CONSTRAINT [FK_CokerCardConfigurationDrum_CokerCardConfiguration] FOREIGN KEY([CokerCardConfigurationId])	REFERENCES [dbo].[CokerCardConfiguration] ([Id])GOCREATE TABLE [dbo].[CokerCardConfigurationCycleStep] (  [Id] [bigint] IDENTITY(100,1) NOT NULL,  [Name] VARCHAR(20) NOT NULL,  [DisplayOrder] int NOT NULL,	  [CokerCardConfigurationId] [bigint] NOT NULL,  [Deleted] bit NOT NULL  CONSTRAINT [PK_CokerCardConfigurationCycleStep] PRIMARY KEY CLUSTERED ([Id] ASC))ALTER TABLE [dbo].[CokerCardConfigurationCycleStep] 	ADD CONSTRAINT [FK_CokerCardConfigurationCycleStep_CokerCardConfiguration] FOREIGN KEY([CokerCardConfigurationId])	REFERENCES [dbo].[CokerCardConfiguration] ([Id])GO
GO


-- -----------------------------------------------------------------------

DECLARE @up1flocId BIGINT
DECLARE @cokerCardConfigId BIGINT

SELECT @up1flocId = [Id] From FunctionalLocation where SiteId = 3 and FullHierarchy = 'UP1'

INSERT INTO dbo.CokerCardConfiguration (
  [Name],
  [FunctionalLocationId],
  [Deleted]
)
VALUES ('UP1 Coker Card', @up1flocId, 0);

SET @cokerCardConfigId = @@IDENTITY

INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C3', 0, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C4', 1, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C5', 2, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C6', 3, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C7', 4, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C8', 5, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C50', 6, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationDrum ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('5C51', 7, @cokerCardConfigId, 0);

INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('SQ Frac', 0, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('SQ StO', 1, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('SQ WQ', 2, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('Pull TH', 3, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('Drn', 4, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('Pull BotH', 5, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('Cut', 6, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('Rhd', 7, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('ST', 8, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('VH', 9, @cokerCardConfigId, 0);
INSERT INTO dbo.CokerCardConfigurationCycleStep  ([Name],[DisplayOrder], [CokerCardConfigurationId], [Deleted]) VALUES ('Feed In', 10, @cokerCardConfigId, 0);


-- -----------------------------------------------------------------------

CREATE TABLE [dbo].[CokerCard](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[CokerCardConfigurationId]  [bigint] NOT NULL,	
	[FunctionalLocationId] [bigint] NOT NULL,	
	[WorkAssignmentId] [bigint] NULL,	
	[ShiftId] [bigint] NOT NULL,
	[ShiftStartDate] [datetime] NOT NULL,
	[CreatedByUserId] [bigint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,	
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
	[Deleted] bit NOT NULL,
 CONSTRAINT [PK_CokerCard] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

ALTER TABLE [dbo].[CokerCard] 
ADD CONSTRAINT [FK_CokerCard_CokerCardConfiguration] 
FOREIGN KEY([CokerCardConfigurationId])
REFERENCES [dbo].[CokerCardConfiguration] ([Id])
GO

ALTER TABLE [dbo].[CokerCard] 
ADD CONSTRAINT [FK_CokerCard_FunctionalLocation] 
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])
GO

ALTER TABLE [dbo].[CokerCard] 
ADD CONSTRAINT [FK_CokerCard_WorkAssignment] 
FOREIGN KEY([WorkAssignmentId])
REFERENCES [dbo].[WorkAssignment] ([Id])
GO

ALTER TABLE [dbo].[CokerCard] 
ADD CONSTRAINT [FK_CokerCard_Shift] 
FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO

ALTER TABLE [dbo].[CokerCard] 
ADD CONSTRAINT [FK_CokerCard_CreatedByUser] 
FOREIGN KEY([CreatedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[CokerCard] 
ADD CONSTRAINT [FK_CokerCard_LastModifiedByUser] 
FOREIGN KEY([LastModifiedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

CREATE NONCLUSTERED INDEX [IDX_CokerCard_CreatedDateTime_FunctionalLocationId]
ON [dbo].[CokerCard]
(
	[CreatedDateTime] ASC,
	[FunctionalLocationId] ASC,
	[Deleted] ASC
)
GO

CREATE NONCLUSTERED INDEX [IDX_CokerCard_ConfigurationId_ShiftId]
ON [dbo].[CokerCard]
(
	[CokerCardConfigurationId] ASC,
	[ShiftId] ASC,
	[ShiftStartDate] ASC,
	[Deleted] ASC
)
GO

-- -----------------------------------------------------------------------

CREATE TABLE [dbo].[CokerCardDrumEntry](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[CokerCardId] [bigint] NOT NULL,	
	[CokerCardConfigurationDrumId] [bigint] NOT NULL,	
	[CokerCardConfigurationLastCycleStepId] [bigint] NULL,
	[HoursIntoLastCycle] decimal(4,2) NULL,
	[Comments] varchar(200) NULL
 CONSTRAINT [PK_CokerCardDrumEntry] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

ALTER TABLE [dbo].[CokerCardDrumEntry] 
ADD CONSTRAINT [FK_CokerCardDrumEntry_CokerCard] 
FOREIGN KEY([CokerCardId])
REFERENCES [dbo].[CokerCard] ([Id])
GO

ALTER TABLE [dbo].[CokerCardDrumEntry] 
ADD CONSTRAINT [FK_CokerCardDrumEntry_CokerCardConfigurationDrum] 
FOREIGN KEY([CokerCardConfigurationDrumId])
REFERENCES [dbo].[CokerCardConfigurationDrum] ([Id])
GO

ALTER TABLE [dbo].[CokerCardDrumEntry] 
ADD  CONSTRAINT [UQ_CokerCardDrumEntry] UNIQUE NONCLUSTERED 
(
	[CokerCardId] ASC,
	[CokerCardConfigurationDrumId] ASC
)
GO

ALTER TABLE [dbo].[CokerCardDrumEntry] 
ADD CONSTRAINT [FK_CokerCardDrumEntry_LastCycleStep] 
FOREIGN KEY([CokerCardConfigurationLastCycleStepId])
REFERENCES [dbo].[CokerCardConfigurationCycleStep] ([Id])
GO


-- -----------------------------------------------------------------------

CREATE TABLE [dbo].[CokerCardCycleStepEntry](
	[Id] [bigint] IDENTITY(100,1) NOT NULL,
	[CokerCardId] [bigint] NOT NULL,	
	[CokerCardConfigurationDrumId] [bigint] NOT NULL,	
	[CokerCardConfigurationCycleStepId] [bigint] NOT NULL,	
	[StartTime] datetime NOT NULL,
	[StartEntryShiftId] bigint NOT NULL,
	[StartEntryShiftStartDate] datetime NOT NULL,
	[EndTime] datetime NULL,
	[EndEntryShiftId] bigint NULL,
	[EndEntryShiftStartDate] datetime NULL,
	[Deleted] bit NOT NULL
 CONSTRAINT [PK_CokerCardCycleStepEntry] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

ALTER TABLE [dbo].[CokerCardCycleStepEntry] 
ADD CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCard] 
FOREIGN KEY([CokerCardId])
REFERENCES [dbo].[CokerCard] ([Id])
GO

ALTER TABLE [dbo].[CokerCardCycleStepEntry] 
ADD CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCardConfigurationDrum] 
FOREIGN KEY([CokerCardConfigurationDrumId])
REFERENCES [dbo].[CokerCardConfigurationDrum] ([Id])
GO

ALTER TABLE [dbo].[CokerCardCycleStepEntry] 
ADD CONSTRAINT [FK_CokerCardCycleStepEntry_CokerCardConfigurationCycleStep] 
FOREIGN KEY([CokerCardConfigurationCycleStepId])
REFERENCES [dbo].[CokerCardConfigurationCycleStep] ([Id])
GO

ALTER TABLE [dbo].[CokerCardCycleStepEntry] 
ADD CONSTRAINT [FK_CokerCardCycleStepEntry_StartEntryShift] 
FOREIGN KEY([StartEntryShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO

ALTER TABLE [dbo].[CokerCardCycleStepEntry] 
ADD CONSTRAINT [FK_CokerCardCycleStepEntry_EndEntryShift] 
FOREIGN KEY([EndEntryShiftId])
REFERENCES [dbo].[Shift] ([Id])
GO

CREATE NONCLUSTERED INDEX [IDX_CokerCardCycleStepEntry_CokerCardId]
ON [dbo].[CokerCardCycleStepEntry]
(
	[CokerCardId] ASC,
	[Deleted] ASC
)
GO


GO
