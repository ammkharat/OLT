IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetWorkPermitDocumentType')
	BEGIN
		DROP PROCEDURE [dbo].GetWorkPermitDocumentType
	END
	
GO
CREATE  Procedure [dbo].[GetWorkPermitDocumentType]
(
 
 @SiteId Int
 
)
AS

SELECT * FROM WorkPermitDocumentType WHERE siteid=@SiteId and deleted=0



GRANT EXEC ON GetWorkPermitDocumentType TO PUBLIC   


