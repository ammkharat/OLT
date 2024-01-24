IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertGasTestElementMUDS')
    BEGIN
        DROP PROCEDURE [dbo].InsertGasTestElementMUDS
    END
GO  
CREATE Procedure [dbo].[InsertGasTestElementMUDS]  
(  
    @Id bigint Output,  
    @WorkPermitId bigint,  
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
  
DELETE   
FROM  
    WorkPermitGasTestElementInfoMUDS  
WHERE  
    WorkPermitGasTestElementInfoMUDS.WorkPermitId = @WorkPermitId AND  
    WorkPermitGasTestElementInfoMUDS.GasTestElementInfoId = @GasTestElementInfoId  
  
INSERT INTO [WorkPermitGasTestElementInfoMUDS]  
(  
     WorkPermitId ,  
    GasTestElementInfoId ,  
    FirstRequiredTest ,  
    FirstTestResult  ,  
    SecondRequiredTest,  
    SecondTestResult,
    ThirdRequiredTest ,  
    ThirdTestResult ,
    FourthRequiredTest ,  
    FourthTestResult   
)  
VALUES  
(  
    @WorkPermitId ,  
    @GasTestElementInfoId ,  
    @FirstRequiredTest ,  
    @FirstTestResult  ,  
    @SecondRequiredTest,  
    @SecondTestResult,
    @ThirdRequiredTest ,  
    @ThirdTestResult ,
    @FourthRequiredTest ,  
    @FourthTestResult  
)  
  
SET @Id= SCOPE_IDENTITY()   

GRANT EXEC ON InsertGasTestElementMUDS TO PUBLIC