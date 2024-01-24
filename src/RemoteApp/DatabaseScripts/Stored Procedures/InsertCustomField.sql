IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertCustomField')
	BEGIN
		DROP  Procedure  InsertCustomField
	END

GO

CREATE Procedure [dbo].[InsertCustomField]            
(            
 @Id bigint Output,            
 @Name varchar(100),            
 @TagId bigint = NULL,            
 @TypeId tinyint,            
 @PhdLinkTypeId tinyint,            
 @OriginCustomFieldId bigint,          
 @GreaterThan decimal(18,6) = NULL,          
 @LessThan decimal(18,6) = NULL,          
 @RangeMin decimal(18,6) = NULL,          
 @RangeMax decimal(18,6) = NULL,        
 @Date DateTime,    
 @IsActive Bit             
)            
AS            
            
INSERT INTO [CustomField]            
(            
    [Name],            
 [TagId],            
 [TypeId],            
 [PhdLinkTypeId],            
 [OriginCustomFieldId]            
)            
VALUES            
(            
    @Name,            
 @TagId,            
 @TypeId,            
 @PhdLinkTypeId,            
 @OriginCustomFieldId            
)            
            
SET @Id = SCOPE_IDENTITY()            
            
if (@OriginCustomFieldId is null)            
begin            
 update CustomField set OriginCustomFieldId = @Id where Id = @Id            
end            
    
    
If @GREATERTHAN is null And @LESSTHAN is null And @RANGEMAX is null And @RANGEMIN is null        
Return         
INSERT INTO [CustomFieldWithRange]            
(            
   [CustomFieldID],                 
[GreaterThanValue],          
[LessThanValue],          
[RangeGreaterThanValue],          
[RangeLessThanValue],    
[IsActive] ,  
[ActiveFrom],  
[ActiveTo]         
)            
VALUES            
(            
    @Id,                      
 @GreaterThan,            
 @LessThan,            
 @RangeMax,          
 @RangeMin ,    
 @IsActive ,  
 @Date,  
 NULL          
)              
            
GRANT EXEC ON InsertCustomField TO PUBLIC 
GO
 