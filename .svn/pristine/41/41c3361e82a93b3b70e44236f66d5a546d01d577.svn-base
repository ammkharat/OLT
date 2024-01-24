IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateTargetAlert')
	BEGIN
		DROP Procedure UpdateTargetAlert
	END
GO

CREATE Procedure [dbo].UpdateTargetAlert
	(
		@Id bigint,
		@TargetAlertStatusID bigint,
		@ExceedingBoundaries bit,
		@ActualValue DECIMAL(10,3) = NULL,
		@MaxValue DECIMAL(10,3) = NULL,
		@NeverToExceedMax DECIMAL(10,3) = NULL,
		@MinValue DECIMAL(10,3) = NULL,
		@NeverToExceedMin DECIMAL(10,3) = NULL,
		@TargetValueTypeId BIGINT,
		@TargetAlertValue DECIMAL(10,3) = NULL,
		@GapUnitValue DECIMAL(10,3) = NULL,
		@Description varchar(MAX),
		@LastModifiedUserId bigint = NULL,
		@LastModifiedDateTime DATETIME,
		@AcknowledgedUserId bigint = NULL,
		@AcknowledgedDateTime datetime = NULL,
		@TypeOfViolationStatusId int,
		@LastViolatedDateTime datetime,
		@MaxAtEvaluation decimal(10,3) = null,
		@MinAtEvaluation decimal(10,3) = null,
		@NTEMaxAtEvaluation decimal(10,3) = null,
		@NTEMinAtEvaluation decimal(10,3) = null,
		@ActualValueAtEvaluation decimal(10,3) = null		
	)
AS

UPDATE TargetAlert
SET	[TargetAlertStatusID] = @TargetAlertStatusId,
	[ExceedingBoundaries] = @ExceedingBoundaries,
	[ActualValue] = @ActualValue,
	[LastModifiedUserId] = @LastModifiedUserId,
	[LastModifiedDateTime] = @LastModifiedDateTime,
	[MaxValue] = @MaxValue,
	[NeverToExceedMax] = @NeverToExceedMax,
	[MinValue] = @MinValue,
	[NeverToExceedMin] = @NeverToExceedMin,
	[TargetValueTypeId] = @TargetValueTypeId,
	[TargetAlertValue] = @TargetAlertValue,
	[GapUnitValue] = @GapUnitValue,
	[Description] = @Description,
	[AcknowledgedUserId] = @AcknowledgedUserId,
	[AcknowledgedDateTime] = @AcknowledgedDateTime,
	[TypeOfViolationStatusId] = @TypeOfViolationStatusId,
	[LastViolatedDateTime] = @LastViolatedDateTime,
	[MaxAtEvaluation] = @MaxAtEvaluation,
	[MinAtEvaluation] = @MinAtEvaluation,
	[NTEMaxAtEvaluation] = @NTEMaxAtEvaluation,
	[NTEMinAtEvaluation] = @NTEMinAtEvaluation,
	[ActualValueAtEvaluation] = @ActualValueAtEvaluation

WHERE ID = @Id

GO

GRANT EXEC ON UpdateTargetAlert TO PUBLIC

GO 