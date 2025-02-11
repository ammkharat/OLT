if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAreaLabel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAreaLabel]
GO

CREATE Procedure [dbo].[InsertAreaLabel]
    (
    @Id bigint Output,
    @Name varchar(40),
	@SiteId bigint,
	@DisplayOrder int,
	@AllowManualSelection bit,
	@SAPPlannerGroup varchar(6) = NULL
    )
AS

INSERT INTO AreaLabel
(
    Name,
	SiteId,
    DisplayOrder,
	Deleted,
	AllowManualSelection,
	SAPPlannerGroup
)
VALUES
(	
    @Name,
	@SiteId,
    @DisplayOrder,    
    0,
	@AllowManualSelection,
	@SAPPlannerGroup
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertAreaLabel] TO PUBLIC
GO
