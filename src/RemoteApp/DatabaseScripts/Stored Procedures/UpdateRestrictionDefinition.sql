 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateRestrictionDefinition')
	BEGIN
		DROP PROCEDURE [dbo].UpdateRestrictionDefinition
	END
GO
  
Create Procedure [dbo].UpdateRestrictionDefinition  
(  
    @id bigint,  
 @Name varchar (50),  
    @FunctionalLocationID bigint,  
    @Description varchar(3000),  
    @MeasurementTagID bigint,  
    @ProductionTargetValue decimal(9,2)= NULL,   
    @ProductionTargetTagID bigint = NULL,  
    @RestrictionDefinitionStatusID bigint,  
    @IsActive bit,  
 @IsOnlyVisibleOnReports bit,  
    @UpdatedUserId bigint,   
    @UpdatedDate datetime,
--Added by Mukesh for RITM0219490  
    @ToleranceValue int=NULL  
    
    ,@HourFrequency bigint = Null --DMND0010124 mangesh
)  
AS  
  
UPDATE RestrictionDefinition  
SET   
 [Name] = @Name,  
 [FunctionalLocationID] = @FunctionalLocationID,  
 [Description] = @Description,  
 [MeasurementTagID] = @MeasurementTagID,  
 [ProductionTargetValue] = @ProductionTargetValue,  
 [ProductionTargetTagID] = @ProductionTargetTagID,  
 [RestrictionDefinitionStatusID] = @RestrictionDefinitionStatusID,  
 [IsActive] = @IsActive,  
 [IsOnlyVisibleOnReports] = @IsOnlyVisibleOnReports,  
 [LastModifiedUserId] = @UpdatedUserId,  
 [LastModifiedDateTime] = @UpdatedDate,
 --Added by Mukesh for RITM0219490  
  [ToleranceValue]= @ToleranceValue 
  
  ,[HourFrequency] = @HourFrequency  --DMND0010124 mangesh
WHERE ID = @id  

GRANT EXEC ON UpdateRestrictionDefinition TO PUBLIC
