IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveLOGImage')
	BEGIN
		DROP PROCEDURE [dbo].RemoveLOGImage
	END
	
GO
CREATE  Procedure [dbo].[RemoveLOGImage]
(
	
   @Id bigint
  
)
AS

Delete  LOGImages where Id=@Id



GRANT EXEC ON RemoveLOGImage TO PUBLIC   

