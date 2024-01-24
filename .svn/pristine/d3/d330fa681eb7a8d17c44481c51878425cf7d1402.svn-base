if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[QueryDocumentLinkByFormGN75BSarniaId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[QueryDocumentLinkByFormGN75BSarniaId]
GO

GO

Create Procedure [dbo].[QueryDocumentLinkByFormGN75BSarniaId]
	(
		@FormGN75BSarniaId bigint
	)

AS
SELECT * FROM DocumentLink WHERE FormGN75BSarniaId = @FormGN75BSarniaId
	and Deleted = 0 
	and FormGN75BSarniaId IS NOT NULL -- this is here to force the use of a Filtered index on the table
