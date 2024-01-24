if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertProcedureDeviationComment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertProcedureDeviationComment]
GO


CREATE Procedure [dbo].[InsertProcedureDeviationComment]
(
	@Id bigint Output,
	@ProcedureDeviationId bigint,
	@CreatedUserId bigint,
	@CreatedDate datetime,
	@Text varchar(MAX)
)
AS

INSERT INTO Comment
(
	[CreatedUserId],
	[CreatedDate],
	[Text]
)
VALUES
(
	@CreatedUserId,
	@CreatedDate,
	@Text
)
SET @Id= SCOPE_IDENTITY() 

INSERT INTO FormProcedureDeviationComment
(
	FormProcedureDeviationId,
	CommentId
)
VALUES
(
	@ProcedureDeviationId,
	@Id
)
GO 

GRANT EXEC ON InsertProcedureDeviationComment TO PUBLIC
GO 