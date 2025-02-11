if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCokerCardConfigurationDrum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCokerCardConfigurationDrum]
GO

CREATE Procedure [dbo].[InsertCokerCardConfigurationDrum]
    (
    @Id bigint Output,
	@Name Varchar(40),
	@DisplayOrder int,
    @CokerCardConfigurationId bigint	
    )
AS

INSERT INTO CokerCardConfigurationDrum
(
	Name,
    DisplayOrder,
	CokerCardConfigurationId
)
VALUES
(	
	@Name,
	@DisplayOrder,
	@CokerCardConfigurationId
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertCokerCardConfigurationDrum] TO PUBLIC
GO
