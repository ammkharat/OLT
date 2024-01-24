if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetItemImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetItemImage]

GO

CREATE  Procedure GetItemImage
(
	@ItemIDs varchar(150)
   	,@RecordFor int
)
AS

Select * from ImageData WHERE ItemID IN
(Select ID from dbo.IDSplitter(@ItemIDs))
AND RecordFor=@RecordFor
order by ItemID,ID

GO

GRANT EXEC ON GetItemImage TO PUBLIC
GO
