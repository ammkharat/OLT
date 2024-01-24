IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertShiftHandoverQuestionnaire')
  BEGIN
       DROP PROCEDURE [dbo].InsertShiftHandoverQuestionnaire
  END
GO

CREATE Procedure [dbo].InsertShiftHandoverQuestionnaire  
    (  
 @Id bigint Output,      
 @ShiftHandoverConfigurationName varchar(50),  
 @ShiftId bigint,  
 @AssignmentId bigint = null,  
 @CreatedByUserId bigint,  
 @CreatedDateTime datetime,  
 @LastModifiedDateTime datetime,  
 @HasYesAnswer bit,  
 @LogId bigint = null,  
 @SummaryLogId bigint = null ,
 @IsFlexible  Bit =0,
 @FlexiShiftStartDate datetime = null,
 @FlexiShiftEndDate datetime = null
    )  
AS  
  
INSERT INTO ShiftHandoverQuestionnaire  
(  
 [ShiftHandoverConfigurationName],  
 [ShiftId],  
 [WorkAssignmentId],  
 [CreatedByUserId],  
 [CreatedDateTime],  
 [LastModifiedDateTime],  
 [HasYesAnswer],  
 [LogId],  
 [SummaryLogId],
 [IsFlexible],
[FlexiShiftStartDate],
[FlexiShiftEndDate]
)  
VALUES  
(  
 @ShiftHandoverConfigurationName,  
 @ShiftId,  
 @AssignmentId,  
 @CreatedByUserId,  
 @CreatedDateTime,  
 @LastModifiedDateTime,  
 @HasYesAnswer,  
 @LogId,  
 @SummaryLogId,
 @IsFlexible,
 @FlexiShiftStartDate ,
 @FlexiShiftEndDate 
)  
SET @Id= SCOPE_IDENTITY()   

GRANT EXEC ON InsertShiftHandoverQuestionnaire TO PUBLIC
GO