if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertImageData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertImageData]

GO
CREATE  Procedure [dbo].[InsertImageData]
(
	
   @ItemID bigint
  ,@Name Varchar(50)
  ,@Description Varchar(150)
  ,@ImagePath Varchar(150)
  ,@Createdby Int
  ,@CreatedDate datetime
  ,@RecordType bigint
  ,@RecordFor bigint
)
AS

INSERT INTO ImageData
(
   ItemID 
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
   @ItemID 
  ,@Name 
  ,@Description
  ,@ImagePath
  ,@Createdby 
  ,@CreatedDate
  ,@RecordType
  ,@RecordFor
);

GO

GRANT EXEC ON InsertImageData TO PUBLIC
GO
 

