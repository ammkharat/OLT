 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertRestrictionDefinition')
	BEGIN
		DROP PROCEDURE [dbo].InsertRestrictionDefinition
	END
GO 
Create Procedure [dbo].[InsertRestrictionDefinition]  
    (  
    @Id bigint Output,  
    @Name varchar (50),  
    @FunctionalLocationID bigint,  
    @Description varchar(3000),  
    @MeasurementTagID bigint,  
    @ProductionTargetValue decimal(9,2)= NULL,   
    @ProductionTargetTagID bigint = NULL,  
    @RestrictionDefinitionStatusID bigint,  
    @IsActive bit,  
 @IsOnlyVisibleOnReports bit,  
    @LastInvokedDateTime datetime = NULL,  
    @UpdatedUserId bigint,   
    @UpdatedDate datetime,  
    @CreatedDate datetime ,
    --Added by Mukesh for RITM0219490  
    @ToleranceValue int=NULL  
    
    ,@HourFrequency bigint = Null --DMND0010124 mangesh
    )  
AS  
  
INSERT INTO RestrictionDefinition  
(  
    [Name],  
    FunctionalLocationID,  
    [Description],  
    MeasurementTagID,  
    ProductionTargetValue,  
    ProductionTargetTagID,  
    RestrictionDefinitionStatusID,  
    IsActive,  
	IsOnlyVisibleOnReports,  
    LastInvokedDateTime,  
    LastModifiedUserId,  
    LastModifiedDateTime,  
    CreatedDateTime ,
    ToleranceValue,
    HourFrequency 
)  
VALUES  
(  
    @Name,  
    @FunctionalLocationID,  
    @Description,  
    @MeasurementTagID,  
    @ProductionTargetValue,   
    @ProductionTargetTagID,  
    @RestrictionDefinitionStatusID,  
    @IsActive,  
	@IsOnlyVisibleOnReports,  
    @LastInvokedDateTime,  
    @UpdatedUserId,   
    @UpdatedDate,  
    @CreatedDate , 
    @ToleranceValue,
    @HourFrequency
)  
SET @Id= SCOPE_IDENTITY()   
  
  
GRANT EXEC ON [InsertRestrictionDefinition] TO PUBLIC  