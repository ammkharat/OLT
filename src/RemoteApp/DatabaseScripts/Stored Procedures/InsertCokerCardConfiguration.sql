if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCokerCardConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCokerCardConfiguration]
GO

CREATE Procedure [dbo].[InsertCokerCardConfiguration]
    (
    @Id bigint Output,
	@Name Varchar(40),
    @FunctionalLocationId bigint	
    )
AS

INSERT INTO CokerCardConfiguration
(
	Name,
    FunctionalLocationId,
	Deleted
)
VALUES
(	
	@Name,
	@FunctionalLocationId,
	0
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertCokerCardConfiguration] TO PUBLIC
GO
