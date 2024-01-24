

IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[LOGImages]') AND type in (N'U'))

BEGIN
Create table LOGImages
(
   ID bigint identity(1,1)
  ,LOGID bigint NOT NULL
  ,Name Varchar(50)
  ,[Description] Varchar(150)
  ,ImagePath Varchar(150)
  ,CreatedDate datetime
  ,Createdby Int
  ,Updateddate datetime
  ,UpdatedBy datetime
  ,RecordType int
  ,RecordFor int default(0)
  
)
END
