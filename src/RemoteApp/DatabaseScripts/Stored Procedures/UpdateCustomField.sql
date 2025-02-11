﻿IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateCustomField')
	BEGIN
		DROP  Procedure  UpdateCustomField
	END

GO

  
  
Create  PROCEDURE DBO.UPDATECUSTOMFIELD  
(                
 @ID BIGINT OUTPUT,                
    @NAME VARCHAR(100),                
 @TAGID BIGINT = NULL,                
 @TYPEID TINYINT,                
 @PHDLINKTYPEID TINYINT,                
 @GREATERTHAN DECIMAL(18,6) = NULL,              
 @LESSTHAN DECIMAL(18,6) = NULL,              
 @RANGEMIN DECIMAL(18,6) = NULL,              
 @RANGEMAX DECIMAL(18,6) = NULL ,               
 @DATE DATETIME,        
 @IsActive Bit            
)                
AS                
                
UPDATE [CUSTOMFIELD]                
SET                
NAME = @NAME,                
TAGID = @TAGID,                
TYPEID = @TYPEID,                
PHDLINKTYPEID = @PHDLINKTYPEID                
WHERE ID = @ID                
                
Declare @OldDate DateTime          
                
If @GREATERTHAN is null And @LESSTHAN is null And @RANGEMAX is null And @RANGEMIN is null          
Return          
        
If @IsActive  = 0        
           
  Begin     
  UPDATE [customfieldwithrange]          
      SET    ActiveTo = DATEADD(ss,-1,@Date) ,IsActive = 0        
      WHERE  customfieldid = @ID          
             AND ActiveTo is  null        
          
      Return      
    End               
    
                    
IF NOT EXISTS(SELECT TOP 1 customfieldid          
              FROM   customfieldwithrange c          
              WHERE  customfieldid = @ID          
                     AND IsActive = 1           
                     And ([GreaterThanValue] = @GREATERTHAN          
     Or [LessThanValue] = @LESSTHAN          
      Or ([RangeGreaterThanValue] = @RANGEMAX          
      And [RangeLessThanValue] = @RANGEMIN ))                              
              )          
           
           
Begin            
                             
UPDATE [customfieldwithrange]          
      SET    ActiveTo = DATEADD(ss,-1,@Date), IsActive = 0           
      WHERE  customfieldid = @ID         
       AND ActiveTo is null        
                             
INSERT INTO [customfieldwithrange]          
                  ([customfieldid],            
                   [greaterthanvalue],          
                   [lessthanvalue],          
     [rangegreaterthanvalue],          
                   [rangelessthanvalue],        
                   [IsActive],        
                   [ActiveFrom],        
                   [ActiveTo])          
      VALUES      ( @Id,         
                    @GreaterThan,          
                    @LessThan,          
                    @RangeMax,          
                    @RangeMin,        
                    @IsActive,        
                    @DATE,        
                    Null )          
  Return        
End          
           
  
GRANT EXEC ON UPDATECUSTOMFIELD TO PUBLIC        
        
        GO
 