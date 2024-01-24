IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertGasTestElementForSELC')
    BEGIN
        DROP  Procedure  InsertGasTestElementForSELC
    END

GO

CREATE Procedure [dbo].[InsertGasTestElementForSELC]
(
    @Id bigint Output,
    @WorkPermitId bigint,
    @GasTestElementInfoId bigint,
    @RequiredTest bit,
    @FirstTestResult FLOAT = NULL,
    @ConfinedSpaceTestResult FLOAT = NULL,
    @ConfinedSpaceTestRequired bit,
    @SystemEntryTestResult FLOAT = NULL,
    @SystemEntryTestNotApplicable bit    
)
AS

DELETE 
FROM
    WorkPermitGasTestElementInfoForSELC
WHERE
    WorkPermitGasTestElementInfoForSELC.WorkPermitId = @WorkPermitId AND
    WorkPermitGasTestElementInfoForSELC.GasTestElementInfoId = @GasTestElementInfoId

INSERT INTO [WorkPermitGasTestElementInfoForSELC]
(
    [WorkPermitId],
    [GasTestElementInfoId],
    [RequiredTest],
    [FirstTestResult],
    [ConfinedSpaceTestResult],
    [ConfinedSpaceTestRequired],
    [SystemEntryTestResult],
    [SystemEntryTestNotApplicable]
)
VALUES
(
    @WorkPermitId,
    @GasTestElementInfoId,
    @RequiredTest,
    @FirstTestResult,
    @ConfinedSpaceTestResult,
    @ConfinedSpaceTestRequired,
    @SystemEntryTestResult,
    @SystemEntryTestNotApplicable
)

SET @Id= SCOPE_IDENTITY() 
GO

GRANT EXEC ON [InsertGasTestElementForSELC] TO PUBLIC
GO


GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryAllGasTestElementByWorkPermitIdForSELC')
	BEGIN
		DROP PROCEDURE [dbo].QueryAllGasTestElementByWorkPermitIdForSELC
	END
GO

CREATE Procedure [dbo].[QueryAllGasTestElementByWorkPermitIdForSELC]
    (
    @WorkPermitId bigint,
	@siteid bigint
    )
AS
    SELECT
        WorkPermitGasTestElementInfoForSELC.*
    FROM
        WorkPermitGasTestElementInfoForSELC, GasTestElementInfo
    WHERE
        WorkPermitGasTestElementInfoForSELC.GasTestElementInfoId = GasTestElementInfo.Id AND
        GasTestElementInfo.Deleted = 0 AND
		GasTestElementInfo.SiteId = @siteid AND
        WorkPermitGasTestElementInfoForSELC.WorkPermitId = @WorkPermitId
GO

GRANT EXEC ON QueryAllGasTestElementByWorkPermitIdForSELC TO PUBLIC
GO


GO

 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveGasTestElementForSELC')
	BEGIN
		DROP  Procedure  RemoveGasTestElementForSELC
	END

GO

CREATE Procedure [dbo].RemoveGasTestElementForSELC
	(
			@id bigint
	)
AS

DELETE FROM [WorkPermitGasTestElementInfoForSELC]
WHERE Id = @Id
GO

GRANT EXEC ON RemoveGasTestElementForSELC TO PUBLIC

GO 


GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateGasTestElementForSELC')
BEGIN
    DROP  Procedure  UpdateGasTestElementForSELC
END

GO

CREATE Procedure [dbo].[UpdateGasTestElementForSELC]
(
    @Id bigint,
    @RequiredTest bit,
    @FirstTestResult FLOAT = NULL,
    @ConfinedSpaceTestResult FLOAT = NULL,
    @ConfinedSpaceTestRequired bit,
    @SystemEntryTestResult FLOAT = NULL,
    @SystemEntryTestNotApplicable bit
)
AS

UPDATE
    [WorkPermitGasTestElementInfoForSELC]
SET
    RequiredTest = @RequiredTest,
    FirstTestResult = @FirstTestResult,
    ConfinedSpaceTestResult = @ConfinedSpaceTestResult,
    ConfinedSpaceTestRequired = @ConfinedSpaceTestRequired,
    SystemEntryTestResult = @SystemEntryTestResult,
    SystemEntryTestNotApplicable = @SystemEntryTestNotApplicable 
WHERE
    (Id = @Id)
GO


GRANT EXEC ON UpdateGasTestElementForSELC TO PUBLIC

GO


 


GO


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




GO

