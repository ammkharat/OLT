if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateLabAlertStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateLabAlertStatus]
GO

CREATE Procedure [dbo].[UpdateLabAlertStatus]
    (
    @Id bigint Output,
	@LabAlertStatusId bigint,
	@LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime
    )
AS

update LabAlert
set LabAlertStatusId = @LabAlertStatusId,
	LastModifiedByUserId = @LastModifiedByUserId,
    LastModifiedDateTime = @LastModifiedDateTime  
where Id = @Id

GO

GRANT EXEC ON [UpdateLabAlertStatus] TO PUBLIC
GO
