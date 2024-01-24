  
     
IF OBJECT_ID('QueryWorkPermitFortHillsHistoryById', 'P') IS NOT NULL
DROP PROC QueryWorkPermitFortHillsHistoryById
GO   

CREATE Procedure [dbo].[QueryWorkPermitFortHillsHistoryById]  
(  
 @Id bigint  
)  
AS  
  
select * from WorkPermitFortHillsHistory h where h.Id = @Id  
ORDER BY h.LastModifiedDateTime  
  
  
GRANT EXEC ON QueryWorkPermitFortHillsHistoryById TO PUBLIC 