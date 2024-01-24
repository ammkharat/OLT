IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemDefinitionSendEmail')
    BEGIN
        DROP PROCEDURE [dbo].InsertActionItemDefinitionSendEmail
    END
GO


CREATE Procedure [dbo].[InsertActionItemDefinitionSendEmail]
    (
    @ActionItemDefinitionId bigint,
	@SendEmail bit
    )
AS

INSERT INTO ActionItemDefinitionSendEmail (ActionItemDefinitionId, SendEmail)
values (@ActionItemDefinitionId, @SendEmail)

