if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveImageData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RemoveImageData]

GO

CREATE  Procedure RemoveImageData
(	
   @Id bigint  
)
AS

Delete  ImageData where Id=@Id


GO

GRANT EXEC ON RemoveImageData TO PUBLIC
GO