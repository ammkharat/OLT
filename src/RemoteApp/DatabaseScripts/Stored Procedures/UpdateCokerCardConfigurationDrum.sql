if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCokerCardConfigurationDrum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCokerCardConfigurationDrum]
GO

CREATE Procedure [dbo].[UpdateCokerCardConfigurationDrum]
    (
    @Id bigint,
	@Name Varchar(20), 
    @DisplayOrder int
    )
AS

update CokerCardConfigurationDrum
set 
	Name = @Name,
	DisplayOrder = @DisplayOrder	
where Id = @Id

go

GRANT EXEC ON [UpdateCokerCardConfigurationDrum] TO PUBLIC
GO
