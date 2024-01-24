SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'GetCustomFieldColour')
	BEGIN
		DROP  Function  [dbo].[GetCustomFieldColour]
	END
GO


   
     
Create FUNCTION GetCustomFieldColour (@LogId         BIGINT,          
                                     @CustomFieldID BIGINT)          
returns VARCHAR(8)          
AS          
  BEGIN          
      DECLARE @RangeDate DATETIME          
      DECLARE @LogDate DATETIME          
      DECLARE @NumericValue DECIMAL(18, 6)          
      DECLARE @GreaterThanValue DECIMAL(18, 6)          
      DECLARE @LessThanValue DECIMAL(18, 6)         
      DECLARE @RangeGreaterThanValue DECIMAL(18, 6)        
      DECLARE @RangeLessThanValue DECIMAL(18, 6)         
      Declare @RangeID varchar(7)       
        
        
BEGIN           
        
  SET @RangeID = (SELECT cfwr.ID AS RangeId         
                        FROM   logcustomfieldentry lcfe          
                               LEFT JOIN customfieldwithrange cfwr          
                                      ON lcfe.customfieldid = cfwr.customfieldid          
                               LEFT JOIN [log] lg          
         ON lcfe.logid = lg.id          
                        WHERE  lcfe.LogId = @LogId         
                               AND cfwr.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))       
  if @RangeID is Null      
  Return 'B|'      
      SET @LogDate = (SELECT top 1 lg.LogDateTime AS LogDate          
                      FROM   logcustomfieldentry lcfe          
                             LEFT JOIN customfieldwithrange cfwr          
                                    ON lcfe.customfieldid = cfwr.customfieldid          
                             LEFT JOIN [log] lg          
                                    ON lcfe.logid = lg.id          
                      WHERE  lcfe.LogId = @LogId          
                             AND lcfe.customfieldid = @CustomFieldID)         
        
SET @RangeDate = (SELECT cfwr.ActiveFrom AS RangeDate          
                        FROM   logcustomfieldentry lcfe          
                               LEFT JOIN customfieldwithrange cfwr          
                                      ON lcfe.customfieldid = cfwr.customfieldid          
                               LEFT JOIN [log] lg          
                                      ON lcfe.logid = lg.id          
                        WHERE  lcfe.LogId = @LogId          
                               AND cfwr.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))          
        
        
      SET @NumericValue = (SELECT top 1 lcfe.numericfieldentry          
                           FROM   logcustomfieldentry lcfe          
                                  LEFT JOIN customfieldwithrange cfwr          
                                         ON lcfe.customfieldid =          
                                            cfwr.customfieldid          
                                  LEFT JOIN [log] lg          
                                         ON lcfe.logid = lg.id          
                           WHERE  lcfe.LogId = @LogId          
                                  AND lcfe.customfieldid = @CustomFieldID)          
        
      SET @GreaterThanValue = (SELECT cfwr.greaterthanvalue          
                               FROM   logcustomfieldentry lcfe          
                                      LEFT JOIN customfieldwithrange cfwr          
                                             ON lcfe.customfieldid =          
                                                cfwr.customfieldid          
                                      LEFT JOIN [log] lg          
                                             ON lcfe.logid = lg.id          
                               WHERE  lcfe.LogId = @LogId          
                                      AND lcfe.customfieldid = @CustomFieldID  And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))          
        
      SET @LessThanValue = (SELECT cfwr.lessthanvalue        
                            FROM   logcustomfieldentry lcfe          
                                   LEFT JOIN customfieldwithrange cfwr          
                                          ON lcfe.customfieldid =          
                                             cfwr.customfieldid          
                                   LEFT JOIN [log] lg          
                                          ON lcfe.logid = lg.id          
                            WHERE  lcfe.LogId = @LogId          
                                   AND lcfe.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))         
        
  SET @RangeGreaterThanValue = (SELECT cfwr.RangeGreaterThanValue          
                            FROM   logcustomfieldentry lcfe          
                                   LEFT JOIN customfieldwithrange cfwr          
                                          ON lcfe.customfieldid =          
                                             cfwr.customfieldid          
                                   LEFT JOIN [log] lg          
                                          ON lcfe.logid = lg.id          
                            WHERE  lcfe.LogId = @LogId          
                                   AND lcfe.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))            
        
  SET @RangeLessThanValue = (SELECT  cfwr.RangeLessThanValue          
                            FROM   logcustomfieldentry lcfe          
                                   LEFT JOIN customfieldwithrange cfwr          
                                          ON lcfe.customfieldid =          
                                             cfwr.customfieldid          
                                   LEFT JOIN [log] lg          
                                          ON lcfe.logid = lg.id          
                            WHERE  lcfe.LogId = @LogId          
                                   AND lcfe.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))                                                                                    
End                                             
        
  --    print @LogDate         
    --  print @RangeDate        
     -- print @GreaterThanValue          
        
 If @RangeDate is NULL           
       Return 'B|'+ @RangeID          
        
    IF @RangeDate < @LogDate          
        
  IF @NumericValue <= @GreaterThanValue          
          Return 'R|'+ @RangeID          
  Else IF @NumericValue >= @LessThanValue          
          Return 'R|'+ @RangeID          
  Else IF @NumericValue Not BETWEEN  @RangeLessThanValue   And @RangeGreaterThanValue       
    Return 'R|'+ @RangeID         
 Else                
  Return 'B|'+ @RangeID          
        
        
        
    Return 'B|'+ @RangeID         
        
  END 