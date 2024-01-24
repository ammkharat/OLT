create table [dbo].WorkPermitOssaPermitNumberSequence 
(
      SeqID bigint identity(600000,1) primary key,
      SeqVal varchar(1)
)
GO

CREATE TABLE [dbo].[WorkPermitOssa] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[WorkPermitStatusId] int NOT NULL,
[WorkPermitTypeId] int NOT NULL,
[SourceId] int NOT NULL,
[StartDateTime] DateTime NOT NULL,
[EndDateTime] DateTime NOT NULL,
[PermitNumber] bigint NULL,
[WorkOrderNumber] VARCHAR(20) NULL,
[FunctionalLocationId] bigint NOT NULL,
[Trade] varchar(100) NULL,
[CrewSize] int NULL,
[Description] VARCHAR(400) NULL,

[Company] varchar(100) NULL,      
[JobCoordinator] varchar (100) NULL,
[CoordinatorContactInfo] varchar (100) NULL,    
[EquipmentNumber] varchar (50) NULL,

[EmergencyAssemblyArea] varchar (100) NULL,
[EmergencyMeetingPoint] varchar (100) NULL,
[RequestedStartDateTime] DateTime NULL,      

[EmergencyContactInfo] varchar (100) NULL,
[RevalidationDateTime] DateTime NULL,
[ExtensionTime] DateTime NULL,
[ExtensionAuthorizedBy] varchar(100) NULL,
[LockBoxNumber] varchar(50) NULL,
[IsolationNumber] varchar(100) NULL,

[CreatedDateTime] DateTime NOT NULL,
[CreatedByUserId] bigint NOT NULL,
[LastModifiedDateTime] DateTime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
[Deleted] bit NOT NULL,

CONSTRAINT [PK_WorkPermitOssa]
PRIMARY KEY CLUSTERED ([Id] )
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON )
 ON [PRIMARY]
)
ON [PRIMARY];
GO

ALTER TABLE [dbo].[WorkPermitOssa]
ADD  CONSTRAINT [FK_WorkPermitOssa_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] )
GO



GO

