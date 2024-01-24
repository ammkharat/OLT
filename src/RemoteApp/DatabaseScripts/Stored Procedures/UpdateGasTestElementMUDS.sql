
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateGasTestElementMUDS')
    BEGIN
        DROP PROCEDURE [dbo].UpdateGasTestElementMUDS
    END
GO  
CREATE Procedure [dbo].[UpdateGasTestElementMUDS]  
(  
   @Id bigint ,   
    @GasTestElementInfoId bigint,  
    @FirstRequiredTest bit,  
    @FirstTestResult FLOAT ,  
  
     @SecondRequiredTest bit=NULL,  
    @SecondTestResult FLOAT = NULL,
    
     @ThirdRequiredTest bit,  
    @ThirdTestResult FLOAT = NULL,
    
     @FourthRequiredTest bit,  
    @FourthTestResult FLOAT = NULL
)  
AS  
  
UPDATE  
    [WorkPermitGasTestElementInfoMUDS]  
SET  
     
     
    FirstRequiredTest=FirstRequiredTest ,  
    FirstTestResult =FirstTestResult ,  
    SecondRequiredTest=SecondRequiredTest,  
    SecondTestResult=SecondTestResult,
    ThirdRequiredTest=ThirdRequiredTest ,  
    ThirdTestResult=ThirdTestResult ,
    FourthRequiredTest=FourthRequiredTest ,  
    FourthTestResult =FourthTestResult   
WHERE  
    (Id = @Id)  
    
    SELECT * from WorkPermitGasTestElementInfoMUDS
    
    
 GRANT EXEC ON UpdateGasTestElementMUDS TO PUBLIC