if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCokerCard]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCokerCard]
GO

CREATE Procedure [dbo].[InsertCokerCard]
    (
    @Id bigint Output,
	@CokerCardConfigurationId bigint,
    @FunctionalLocationId bigint,    
    @WorkAssignmentId bigint = NULL,
    @ShiftId bigint,
	@ShiftStartDate datetime,
	@CreatedByUserId bigint, 
    @CreatedDateTime datetime,
	@LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime
    )
AS

INSERT INTO CokerCard
(
	CokerCardConfigurationId,
    FunctionalLocationId,  
	WorkAssignmentId,
	ShiftId,
	ShiftStartDate,
	CreatedByUserId,
    CreatedDateTime,
	LastModifiedByUserId, 
    LastModifiedDateTime,
	Deleted
)
VALUES
(	
	@CokerCardConfigurationId,
    @FunctionalLocationId,  
	@WorkAssignmentId,
	@ShiftId,
	@ShiftStartDate,
	@CreatedByUserId,
    @CreatedDateTime,
	@LastModifiedByUserId, 
    @LastModifiedDateTime,
	0
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertCokerCard] TO PUBLIC
GO
