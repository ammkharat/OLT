IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetWorkPermitDocument')
	BEGIN
		DROP PROCEDURE [dbo].GetWorkPermitDocument
	END
	
GO
CREATE  Procedure [dbo].[GetWorkPermitDocument]
(
 
 @WorkPermitId Varchar(100),
 @SiteId Int
 
)
AS

SELECT W.*,U.Username 
FROM WorkPermitDocument W
JOIN [User] U ON W.CreatedBy=U.Id
WHERE WorkPermitId=@WorkPermitId AND SiteId=@SiteId AND W.DELETED=0
ORDER BY W.CreatedDate



GRANT EXEC ON GetWorkPermitDocument TO PUBLIC   


