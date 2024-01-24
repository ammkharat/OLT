IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ShiftLogMessageStaging]') AND type in (N'U'))
BEGIN

CREATE TABLE ShiftLogMessageStaging (
      ShiftLogMessageStagingId int IDENTITY(1,1) PRIMARY KEY,
      UserName VARCHAR(30) NOT NULL,
      Floc VARCHAR(50) NOT NULL,
SITE VARCHAR(20) NOT NULL,
      Source VARCHAR(30) NOT NULL,
      MessageTimeStamp DateTime NOT NULL,
      Message VARCHAR(max) NOT NULL
);

CREATE INDEX ix_ShiftLogMessageStaging ON 
      ShiftLogMessageStaging (UserName, Floc, MessageTimeStamp);

END



GO

