CREATE TABLE [dbo].[WorkPermitMontreal] (
[Id] bigint IDENTITY(1, 1) NOT NULL,
[WorkPermitStatusId] int NOT NULL,
[WorkPermitTypeId] int NOT NULL,
[TemplateId] int NULL,
[StartDateTime] DateTime NOT NULL,
[EndDateTime] DateTime NOT NULL,
[PermitNumber] bigint NULL,
[WorkOrderNumber] VARCHAR(20) NULL,
[FunctionalLocationId] bigint NOT NULL,
[Trade] varchar(100) NULL,
[Description] VARCHAR(400) NULL,
[LastModifiedDateTime] DateTime NOT NULL,
[LastModifiedByUserId] bigint NOT NULL,
CONSTRAINT [PK_WorkPermitMontreal]
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

ALTER TABLE [dbo].[WorkPermitMontreal]
ADD  CONSTRAINT [FK_WorkPermitMontreal_Floc]
FOREIGN KEY ([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ( [Id] )
GO
