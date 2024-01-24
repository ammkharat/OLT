if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertDeviationAlertResponse]') and OBJECTPROPERTY(id,N'IsProcedure') = 1)
drop procedure [dbo].[InsertDeviationAlertResponse]
GO

CREATE PROCEDURE [dbo].[InsertDeviationAlertResponse]
(
    @Id bigint Output,    
    @LastModifiedUserId bigint,
    @LastModifiedDateTime DATETIME,
    @CreatedDateTime DATETIME,
	@Comments varchar(2048)
)
AS

INSERT INTO [dbo].[DeviationAlertResponse]
(    
    [LastModifiedUserId],
    [LastModifiedDateTime],
    [CreatedDateTime],
	[Comments]
)
VALUES
(   
    @LastModifiedUserId,
    @LastModifiedDateTime,
    @CreatedDateTime,
	@Comments
)

SET @Id= SCOPE_IDENTITY()
GO 

GRANT EXEC ON [InsertDeviationAlertResponse] TO PUBLIC
GO