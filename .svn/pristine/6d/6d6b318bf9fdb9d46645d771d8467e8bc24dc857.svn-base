IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateActionItemDefSendEmail')
    BEGIN
        DROP PROCEDURE [dbo].UpdateActionItemDefSendEmail
    END
GO

CREATE Procedure UpdateActionItemDefSendEmail

@ActionItemDefinitionId bigint,
@SendEmail bit

as

update actionitemdefinitionsendemail set SendEmail = @SendEmail where ActionItemDefinitionId = @ActionItemDefinitionId
