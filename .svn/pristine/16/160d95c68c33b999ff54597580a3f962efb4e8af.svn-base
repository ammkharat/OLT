
CREATE TABLE [dbo].[LabAlertDefinitionHistory](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[FunctionalLocationID] [bigint] NOT NULL,
	[Description] [varchar](max) NULL,
	[TagID] [bigint] NOT NULL,
	[MinimumNumberOfSamples] int not null,
    [LabAlertTagQueryRange] varchar(300) not NULL,
	[Schedule] varchar(300) NOT NULL,
	[LabAlertDefinitionStatusID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((0)),
	[LastModifiedByUserId] [bigint] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL
) ON [PRIMARY]

go

GO
