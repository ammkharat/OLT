if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateImageData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateImageData]

GO

CREATE  Procedure UpdateImageData
(	
   @ID bigint
  ,@Name Varchar(50)
  ,@Description Varchar(150)
 
)
AS

UPdate ImageData
SET
   Name =@Name
  ,[Description]=@Description  

WHERE ID=@ID

GO

GRANT EXEC ON UpdateImageData TO PUBLIC
GO


