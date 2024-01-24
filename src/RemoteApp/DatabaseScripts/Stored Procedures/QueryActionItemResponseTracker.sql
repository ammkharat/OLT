IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemResponseTracker')
    BEGIN
        DROP PROCEDURE [dbo].QueryActionItemResponseTracker
    END
GO

Create Procedure [dbo].[QueryActionItemResponseTracker]  
 (  
 @ActionItemDefinitionId bigint,  
 @ActionItemId bigint  
 )  
AS  
  
 declare @batchnumber bigint  
 set @batchnumber = (select max(BatchNumber) from ActionItemResponseTracker where ActionItemDefinitionId = @ActionItemDefinitionId)  
 if exists(Select 1 from actionitemresponsetracker WHERE ActionItemId=@ActionItemId)
 BEGIN
   SELECT * from actionitemresponsetracker t  WHERE ActionItemId=@ActionItemId and BatchNumber = (Select max(BatchNumber) from actionitemresponsetracker WHERE ActionItemId=@ActionItemId) order by DisplayOrder 
 END
 ELSE
 BEGIN
    SELECT * from actionitemresponsetracker t  WHERE ActionItemDefinitionId=@ActionItemDefinitionId and BatchNumber = @batchnumber order by DisplayOrder
 END 