  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateLogDefinition')
	BEGIN
		DROP  Procedure  UpdateLogDefinition
	END

GO

CREATE Procedure [dbo].[UpdateLogDefinition]
	(
	@Id bigint,
	@ScheduleId bigint,
	@LastModifiedUserId bigint, 
	@LastModifiedDateTime datetime, 
	@CreatedDateTime datetime,
	@InspectionFollowUp bit,
	@ProcessControlFollowUp bit, 
	@OperationsFollowUp bit, 
	@SupervisionFollowUp bit, 
	@EHSFollowUp bit,
	@OtherFollowUp bit,
	@CreatedByRoleId [BIGINT],
	@LogType tinyint,
	@RtfComments varchar(max),
	@PlainTextComments varchar(max),
	@Active bit
	)
AS

UPDATE    [LogDefinition]
SET       LastModifiedUserId = @LastModifiedUserId, 
          LastModifiedDateTime = @LastModifiedDateTime, 
          CreatedDateTime = @CreatedDateTime, 
          EHSFollowup = @EHSFollowUp, 
          ProcessControlFollowUp = @ProcessControlFollowUp, 
          OperationsFollowUp = @OperationsFollowUp, 
          SupervisionFollowUp = @SupervisionFollowUp, 
          InspectionFollowUp = @InspectionFollowUp, 
          OtherFollowUp = @OtherFollowUp,
          ScheduleId = @ScheduleId,
		  CreatedByRoleId = @CreatedByRoleId,
          LogType = @LogType,
		  RtfComments = @RtfComments,
		  PlainTextComments = @PlainTextComments,
		  Active = @Active
          
WHERE     (Id = @Id)
GO


GRANT EXEC ON UpdateLogDefinition TO PUBLIC

GO


 