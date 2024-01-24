IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'InsertActionItemDefinitionSendEmailTo')
	BEGIN
		DROP  Procedure  InsertActionItemDefinitionSendEmailTo
	END

GO
CREATE Procedure [dbo].[InsertActionItemDefinitionSendEmailTo]
    (
    @ActionItemDefinitionId bigint,
	@SendEmailTo varchar(100)
    )
AS

INSERT INTO ActionItemDefinitionEmailToRecipient (ActionItemDefinitionId, EmailTo)
values (@ActionItemDefinitionId, @SendEmailTo)

