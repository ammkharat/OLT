if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertShiftHandoverEmailConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.InsertShiftHandoverEmailConfiguration
GO

CREATE Procedure dbo.InsertShiftHandoverEmailConfiguration
(
    @Id bigint Output,    	
	@ShiftId bigint,
	@EmailAddresses varchar(max),
	@SiteId bigint,
	@ScheduleId bigint
)
AS

INSERT INTO ShiftHandoverEmailConfiguration
(   
	ShiftId,
	EmailAddresses,
	SiteId,
	ScheduleId	
)
VALUES
(    
	@ShiftId,
	@EmailAddresses,
	@SiteId,
	@ScheduleId
)
SET @Id= SCOPE_IDENTITY() 
GO 
GRANT EXEC ON InsertShiftHandoverEmailConfiguration TO PUBLIC
GO  