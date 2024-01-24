if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCokerCardConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCokerCardConfiguration]
GO

CREATE Procedure [dbo].[UpdateCokerCardConfiguration]
    (
    @Id bigint,
	@Name Varchar(40), 
    @FunctionalLocationId bigint
    )
AS

update CokerCardConfiguration
set 
	Name = @Name,
	FunctionalLocationId = @FunctionalLocationId	
where Id = @Id

go

GRANT EXEC ON [UpdateCokerCardConfiguration] TO PUBLIC
GO
