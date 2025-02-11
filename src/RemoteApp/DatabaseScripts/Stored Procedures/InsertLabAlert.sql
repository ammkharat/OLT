if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLabAlert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLabAlert]
GO

CREATE Procedure [dbo].[InsertLabAlert]
    (
    @Id bigint Output,
    @Name varchar (50),
	@Description varchar(4000),
    @FunctionalLocationId bigint,    
    @TagID bigint,
	@MinimumNumberOfSamples int,
	@ActualNumberOfSamples int,
	@LabAlertTagQueryRangeFromDateTime datetime,
	@LabAlertTagQueryRangeToDateTime datetime,
	@ScheduleDescription varchar(512),
	@LabAlertDefinitionID bigint,
	@LabAlertStatusId bigint,
	@LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime,   
    @CreatedDateTime datetime
    )
AS

INSERT INTO LabAlert
(
    Name,
	Description,
    FunctionalLocationId,    
    TagId,
	MinimumNumberOfSamples,
	ActualNumberOfSamples,
	LabAlertTagQueryRangeFromDateTime,
	LabAlertTagQueryRangeToDateTime,
	ScheduleDescription,
	LabAlertDefinitionId,
	LabAlertStatusId,
	LastModifiedByUserId, 
    LastModifiedDateTime,   
    CreatedDateTime
)
VALUES
(	
    @Name,
	@Description,
    @FunctionalLocationId,    
    @TagId,
	@MinimumNumberOfSamples,
	@ActualNumberOfSamples,
	@LabAlertTagQueryRangeFromDateTime,
	@LabAlertTagQueryRangeToDateTime,
	@ScheduleDescription,
	@LabAlertDefinitionID,
	@LabAlertStatusId,
	@LastModifiedByUserId, 
    @LastModifiedDateTime,   
    @CreatedDateTime
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertLabAlert] TO PUBLIC
GO
