if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCokerCardConfigurationCycleStep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCokerCardConfigurationCycleStep]
GO

CREATE Procedure [dbo].[UpdateCokerCardConfigurationCycleStep]
    (
    @Id bigint,
	@Name Varchar(20), 
    @DisplayOrder int
    )
AS

update CokerCardConfigurationCycleStep
set 
	Name = @Name,
	DisplayOrder = @DisplayOrder	
where Id = @Id

go

GRANT EXEC ON [UpdateCokerCardConfigurationCycleStep] TO PUBLIC
GO
