IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertLOGImage')
	BEGIN
		DROP PROCEDURE [dbo].InsertLOGImage
	END
	
GO
CREATE  Procedure [dbo].[InsertLOGImage]
(
	
   @LOGID bigint
  ,@Name Varchar(50)
  ,@Description Varchar(150)
  ,@ImagePath Varchar(150)
  ,@Createdby Int
  ,@CreatedDate datetime
  ,@RecordType bigint
  ,@RecordFor bigint
)
AS

INSERT INTO LOGImages
(
   LOGID 
  ,Name 
  ,[Description]
  ,ImagePath
  ,Createdby 
  ,CreatedDate
  ,RecordType
  ,RecordFor
)
VALUES
(
   @LOGID 
  ,@Name 
  ,@Description
  ,@ImagePath
  ,@Createdby 
  ,@CreatedDate
  ,@RecordType
  ,@RecordFor
);


GRANT EXEC ON InsertLOGImage TO PUBLIC   

