IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetLOGImage')
	BEGIN
		DROP PROCEDURE [dbo].GetLOGImage
	END
	
GO
CREATE  Procedure [dbo].[GetLOGImage]
(
	@LOGIDs varchar(150)
   ,@RecordFor int
)
AS


Select * from LOGImages WHERE LOGID IN
(Select ID from dbo.IDSplitter(@LOGIDs))
AND RecordFor=@RecordFor
order by LOGID,ID

GRANT EXEC ON GetLOGImage TO PUBLIC   




