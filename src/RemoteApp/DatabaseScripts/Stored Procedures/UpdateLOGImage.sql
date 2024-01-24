IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateLOGImage')
	BEGIN
		DROP PROCEDURE [dbo].UpdateLOGImage
	END
	
GO
CREATE  Procedure [dbo].[UpdateLOGImage]
(
	
   @ID bigint
  ,@Name Varchar(50)
  ,@Description Varchar(150)
 
)
AS

UPdate LOGImages
SET
   Name =@Name
  ,[Description]=@Description
  

WHERE ID=@ID


GRANT EXEC ON UpdateLOGImage TO PUBLIC   

