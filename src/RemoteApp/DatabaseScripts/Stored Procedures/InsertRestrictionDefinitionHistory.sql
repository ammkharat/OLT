 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRestrictionDefinitionHistory')
	BEGIN
		DROP PROCEDURE [dbo].InsertRestrictionDefinitionHistory
	END
GO

CREATE Procedure dbo.InsertRestrictionDefinitionHistory    
    (    
    @Id bigint,    
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
    @UpdatedDate datetime ,  
     --Added by Mukesh for RITM0219490  
    @ToleranceValue int  
    
    ,@HourFrequency bigint = Null --DMND0010124 mangesh 
    )    
AS    
    
INSERT INTO RestrictionDefinitionHistory    
(    
    Id,    
    [Name],    
    FunctionalLocationID,    
    [Description],    
    MeasurementTagID,    
    ProductionTargetValue,    
    ProductionTargetTagID,    
    RestrictionDefinitionStatusID,    
    IsActive,    
	IsOnlyVisibleOnReports,    
    LastModifiedUserId,    
    LastModifiedDateTime ,  
    ToleranceValue  ,
    HourFrequency
)    
VALUES    
(    
    @Id,    
    @Name,    
    @FunctionalLocationID,    
    @Description,    
    @MeasurementTagID,    
    @ProductionTargetValue,     
    @ProductionTargetTagID,    
    @RestrictionDefinitionStatusID,    
    @IsActive,    
 @IsOnlyVisibleOnReports,    
    @UpdatedUserId,     
    @UpdatedDate ,  
    @ToleranceValue,
    @HourFrequency   
)

 GRANT EXEC ON InsertRestrictionDefinitionHistory TO PUBLIC