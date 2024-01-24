if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTrainingBlock]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertTrainingBlock]
GO

CREATE Procedure [dbo].[InsertTrainingBlock]
(
	@Id bigint Output,
	
	@Name varchar(100),
	@Code varchar(100) = NULL,
	@Siteid bigint = NULL
)
AS

INSERT INTO TrainingBlock
(
	Name,
	Code,
	Siteid,
	Deleted
)
VALUES
(
	@Name,
	@Code,
	@Siteid,
	0
);

SET @Id = SCOPE_IDENTITY();

GO

GRANT EXEC ON InsertTrainingBlock TO PUBLIC
GO
