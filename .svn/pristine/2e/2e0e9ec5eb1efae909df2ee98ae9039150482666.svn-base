    
 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertDeviationAlert')
	BEGIN
		DROP PROCEDURE [dbo].InsertDeviationAlert
	END
GO 
CREATE PROCEDURE [dbo].[InsertDeviationAlert]    
(    
    @Id bigint Output,    
    @RestrictionDefinitionID bigint,    
    @RestrictionDefinitionName VARCHAR(30),    
    @RestrictionDefinitionDescription VARCHAR(MAX) = NULL,    
 @DeviationAlertResponseId bigint = NULL,    
    @FunctionalLocationID bigint,    
 @IsOnlyVisibleOnReports bit,    
    @MeasurementValueTagId bigint,    
    @ProductionTargetValueTagId bigint = NULL,    
    @MeasurementValue DECIMAL(9,2)= NULL,    
    @ProductionTargetValue DECIMAL(9,2)= NULL,    
    @StartDateTime DATETIME,    
    @EndDateTime DATETIME,    
 @Comments varchar(2048) = NULL,    
    @LastModifiedUserId bigint,    
    @LastModifiedDateTime DATETIME,    
    @CreatedDateTime DATETIME    
)    
AS    
  
 --Added by Mukesh for RITM0219490  
 Declare @ToleranceValue int;  
 SELECT @ToleranceValue=CASE WHEN ToleranceValue IS NOT NULL  then ((ToleranceValue*@ProductionTargetValue)/100) else ToleranceValue end FROM RestrictionDefinition WHERE Id=@RestrictionDefinitionID 
-- SELECT @ToleranceValue=ToleranceValue FROM RestrictionDefinition WHERE Id=@RestrictionDefinitionID  
   
INSERT INTO [dbo].[DeviationAlert]    
(    
    [RestrictionDefinitionID],    
    [RestrictionDefinitionName],    
    [RestrictionDefinitionDescription],    
 [DeviationAlertResponseId],    
    [FunctionalLocationID],    
 [IsOnlyVisibleOnReports],    
    [MeasurementValueTagId],    
    [ProductionTargetValueTagId],    
    [MeasurementValue],    
    [ProductionTargetValue],    
    [StartDateTime],    
    [EndDateTime],    
 [Comments],    
    [LastModifiedUserId],    
    [LastModifiedDateTime],    
    [CreatedDateTime],  
    [ToleranceValue]    
)    
VALUES    
(    
    @RestrictionDefinitionID,    
    @RestrictionDefinitionName,    
    @RestrictionDefinitionDescription,    
 @DeviationAlertResponseId,    
    @FunctionalLocationID,    
 @IsOnlyVisibleOnReports,    
    @MeasurementValueTagId,    
    @ProductionTargetValueTagId,    
    @MeasurementValue,    
    @ProductionTargetValue,    
    @StartDateTime,    
    @EndDateTime,    
 @Comments,    
    @LastModifiedUserId,    
    @LastModifiedDateTime,    
    @CreatedDateTime ,  
    @ToleranceValue   
)    
    
SET @Id= SCOPE_IDENTITY()    
  
GRANT EXEC ON InsertDeviationAlert TO PUBLIC  