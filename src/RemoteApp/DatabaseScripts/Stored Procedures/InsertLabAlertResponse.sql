if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLabAlertResponse]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLabAlertResponse]
GO

CREATE Procedure [dbo].[InsertLabAlertResponse]
    (
    @Id bigint Output,
	@LabAlertId bigint,
	@LabAlertStatusId bigint,
    @Comments varchar(max),
    @CreatedByUserId bigint, 
    @CreatedDateTime datetime
    )
AS

INSERT INTO LabAlertResponse
(
	LabAlertId,
	LabAlertStatusId,
    Comments,
    CreatedByUserId,
    CreatedDateTime
)
VALUES
(
	@LabAlertId,
	@LabAlertStatusId,
    @Comments,
	@CreatedByUserId,
    @CreatedDateTime
)
SET @Id= SCOPE_IDENTITY() 


GRANT EXEC ON [InsertLabAlertResponse] TO PUBLIC
GO
