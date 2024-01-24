SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'FN' AND name = 'GetCustomFieldColourForSummaryLog')
	BEGIN
		DROP  Function  [dbo].[GetCustomFieldColourForSummaryLog]
	END
GO


     
Create
 FUNCTION [dbo].[GetcustomfieldcolourForSummaryLog] (@SummaryLogId         BIGINT,        
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
      
 SET @RangeID = (SELECT  cfwr.ID AS RangeId        
                        FROM   SummaryLogCustomFieldEntry lcfe        
                               LEFT JOIN customfieldwithrange cfwr        
                                      ON lcfe.customfieldid = cfwr.customfieldid        
                               LEFT JOIN SummaryLog lg        
                                      ON lcfe.SummaryLogId = lg.id        
                        WHERE  lcfe.SummaryLogId = @SummaryLogId        
                               AND lcfe.CustomFieldId = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))       
  if @RangeID is Null      
  Return 'B|'      
       
      SET @LogDate = (SELECT top 1 lg.LogDateTime AS LogDate        
                      FROM   SummaryLogCustomFieldEntry lcfe        
                             LEFT JOIN customfieldwithrange cfwr        
                                    ON lcfe.customfieldid = cfwr.customfieldid        
                             LEFT JOIN SummaryLog lg        
                                    ON lcfe.SummaryLogId = lg.id        
                      WHERE  lg.id = @SummaryLogId  )      
                             --AND lcfe.customfieldid = @CustomFieldID)        
      
      
      SET @RangeDate = (SELECT cfwr.ActiveFrom AS RangeDate        
                        FROM   SummaryLogCustomFieldEntry lcfe        
                               LEFT JOIN customfieldwithrange cfwr        
                                      ON lcfe.customfieldid = cfwr.customfieldid        
                               LEFT JOIN SummaryLog lg        
                                      ON lcfe.SummaryLogId = lg.id        
                        WHERE  lcfe.SummaryLogId = @SummaryLogId        
                               AND lcfe.CustomFieldId = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))        
      
      
      SET @NumericValue = (SELECT top 1 lcfe.NumericFieldEntry        
                           FROM   SummaryLogCustomFieldEntry lcfe        
                                  LEFT JOIN customfieldwithrange cfwr        
                                         ON lcfe.customfieldid = cfwr.customfieldid        
                                  LEFT JOIN SummaryLog lg        
                                         ON lcfe.SummaryLogId = lg.id        
                           WHERE  lcfe.SummaryLogId = @SummaryLogId       
                                  AND lcfe.customfieldid = @CustomFieldID)        
      
      SET @GreaterThanValue = (SELECT cfwr.GreaterThanValue        
                               FROM   SummaryLogCustomFieldEntry lcfe        
                                      LEFT JOIN customfieldwithrange cfwr        
                                             ON lcfe.customfieldid = cfwr.customfieldid        
                                      LEFT JOIN SummaryLog lg        
                                             ON lcfe.SummaryLogId = lg.id        
                               WHERE  lcfe.SummaryLogId = @SummaryLogId       
                                      AND lcfe.customfieldid = @CustomFieldID  And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))        
      
      SET @LessThanValue = (SELECT  cfwr.LessThanValue        
          FROM   SummaryLogCustomFieldEntry lcfe        
                                      LEFT JOIN customfieldwithrange cfwr        
                                          ON lcfe.customfieldid = cfwr.customfieldid        
                                      LEFT JOIN SummaryLog lg        
                                             ON lcfe.SummaryLogId = lg.id        
                               WHERE  lcfe.SummaryLogId = @SummaryLogId       
                                      AND lcfe.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))       
      
    SET @RangeGreaterThanValue = (SELECT  cfwr.RangeGreaterThanValue        
                            FROM   SummaryLogCustomFieldEntry lcfe        
                                      LEFT JOIN customfieldwithrange cfwr        
                                             ON lcfe.customfieldid = cfwr.customfieldid        
                                      LEFT JOIN SummaryLog lg        
                                             ON lcfe.SummaryLogId = lg.id        
                               WHERE  lcfe.SummaryLogId = @SummaryLogId       
                                      AND lcfe.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))       
      
    SET @RangeLessThanValue = (SELECT  cfwr.RangeLessThanValue        
                            FROM   SummaryLogCustomFieldEntry lcfe        
                                      LEFT JOIN customfieldwithrange cfwr        
                                             ON lcfe.customfieldid = cfwr.customfieldid        
                                      LEFT JOIN SummaryLog lg        
                                             ON lcfe.SummaryLogId = lg.id        
                               WHERE  lcfe.SummaryLogId = @SummaryLogId       
                                      AND lcfe.customfieldid = @CustomFieldID And lg.LogDateTime between cfwr.ActiveFrom and isnull(cfwr.ActiveTo, '9999-12-31'))                                            
      
      
End                                           
      
      --print @NumericValue         
      --print   @GreaterThanValue        
      
 If @RangeDate is NULL         
       Return 'B|'+ @RangeID        
      
    IF @RangeDate < @LogDate        
      
  IF @NumericValue <= @GreaterThanValue        
          Return 'R|'+ @RangeID        
  Else IF @NumericValue >= @LessThanValue        
          Return 'R|'+ @RangeID        
  Else IF @NumericValue Not BETWEEN @RangeLessThanValue And @RangeGreaterThanValue
    Return 'R|'+ @RangeID        
 Else              
  Return 'B|'+ @RangeID        
      
      
      
    Return 'B|'+ @RangeID        
      
  END 