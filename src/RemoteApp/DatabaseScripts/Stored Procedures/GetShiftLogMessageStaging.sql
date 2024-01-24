IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetShiftLogMessageStaging')
	BEGIN
		DROP PROCEDURE [dbo].GetShiftLogMessageStaging
	END
	
GO


CREATE Procedure [dbo].[GetShiftLogMessageStaging]    
(    
     
 @SiteId Int=null ,  
 @CsvFlocIds VARCHAR(MAX)=NULL   
     
)    
AS    
  

DECLARE @HoursDiff INT
SELECT  @HoursDiff=DATEDIFF(hh, getutcdate(), getdate())
  
  
    
SELECT 
--STG.* 
STG.ShiftLogMessageStagingId
,UserName
,Floc
,SITE
,STG.Source
--,CONVERT(VARCHAR(10), DATEADD(hour, @HoursDiff, MessageTimeStamp), 101) + ' ' + RIGHT(CONVERT(VARCHAR, DATEADD(hour, @HoursDiff, MessageTimeStamp), 100), 7) as MessageTimeStamp
,DATEADD(hour, @HoursDiff, MessageTimeStamp)as MessageTimeStamp
,Message
from ShiftLogMessageStaging STG  
JOIN FunctionalLocation FL on STG.Floc=FL.FullHierarchy  
WHERE DATEADD(HOUR, 12, DATEADD(hour, @HoursDiff, MessageTimeStamp))>=GETDATE()   
AND    
  (    
    EXISTS (    
      -- Floc of Log matches one of the passed in flocs    
      select * From IDSplitter(@CsvFLOCIds) ids    
      WHERE FL.Id = ids.Id    
    )    
    OR EXISTS    
    (    
      -- Floc of Log is parent of one of the passed in flocs (look up the floc tree from my selected flocs)    
      select * from FunctionalLocationAncestor a    
      INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.Id    
      WHERE a.AncestorId = FL.Id   
    )    
    OR EXISTS    
    (    
      -- Floc of Log is child of one of the passed in flocs (look down the floc tree from my selected flocs)    
      select * from FunctionalLocationAncestor a    
      INNER JOIN IDSplitter(@CsvFLOCIds) ids ON ids.Id = a.ancestorid    
      WHERE a.Id = FL.Id   
    )    
  )    
    
GRANT EXEC ON [GetShiftLogMessageStaging] TO PUBLIC       