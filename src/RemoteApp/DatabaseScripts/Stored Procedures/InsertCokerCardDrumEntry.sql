if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCokerCardDrumEntry]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCokerCardDrumEntry]
GO

CREATE Procedure [dbo].[InsertCokerCardDrumEntry]
    (
    @Id bigint Output,
	@CokerCardId bigint,
    @CokerCardConfigurationDrumId bigint,
	@CokerCardConfigurationLastCycleStepId bigint = null,
	@HoursIntoLastCycle decimal(4,2) = null, 
    @Comments varchar(200) = null
    )
AS

INSERT INTO CokerCardDrumEntry
(
	CokerCardId,
	CokerCardConfigurationDrumId,
	CokerCardConfigurationLastCycleStepId,
	HoursIntoLastCycle,
	Comments
)
VALUES
(	
	@CokerCardId,
	@CokerCardConfigurationDrumId,
	@CokerCardConfigurationLastCycleStepId,
	@HoursIntoLastCycle,
	@Comments
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertCokerCardDrumEntry] TO PUBLIC
GO
