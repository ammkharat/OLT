IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLabAlertDefinitionHistory')
	BEGIN
		DROP  Procedure  InsertLabAlertDefinitionHistory
	END

GO

CREATE Procedure dbo.InsertLabAlertDefinitionHistory
    (
    @Id bigint,
    @Name varchar (50),
    @FunctionalLocationID bigint,
    @Description varchar(3000),
    @TagID bigint,
    @MinimumNumberOfSamples int,
    @LabAlertTagQueryRange varchar(300),
    @Schedule varchar(300),
    @LabAlertDefinitionStatusID bigint,
    @IsActive bit,
    @LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime
    )
AS

INSERT INTO LabAlertDefinitionHistory
(
    Id,
    [Name],
    FunctionalLocationID,
    [Description],
    TagID,
    MinimumNumberOfSamples,
    LabAlertTagQueryRange,
    Schedule,
    LabAlertDefinitionStatusID,
    IsActive,
    LastModifiedByUserId,
    LastModifiedDateTime
)
VALUES
(
    @Id,
    @Name,
    @FunctionalLocationID,
    @Description,
    @TagID,
    @MinimumNumberOfSamples,
    @LabAlertTagQueryRange,
    @Schedule,
    @LabAlertDefinitionStatusID,
    @IsActive,
    @LastModifiedByUserId, 
    @LastModifiedDateTime
)
GO


GRANT EXEC ON [InsertLabAlertDefinitionHistory] TO PUBLIC
GO
