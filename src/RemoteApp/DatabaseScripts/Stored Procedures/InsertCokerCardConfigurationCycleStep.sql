if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCokerCardConfigurationCycleStep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCokerCardConfigurationCycleStep]
GO

CREATE Procedure [dbo].[InsertCokerCardConfigurationCycleStep]
    (
    @Id bigint Output,
	@Name Varchar(40),
	@DisplayOrder int,
    @CokerCardConfigurationId bigint	
    )
AS

INSERT INTO CokerCardConfigurationCycleStep
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


GRANT EXEC ON [InsertCokerCardConfigurationCycleStep] TO PUBLIC
GO
