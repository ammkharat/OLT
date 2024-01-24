IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveActionitemDefinitionSendEmailTo')
	BEGIN
		DROP  Procedure  RemoveActionitemDefinitionSendEmailTo
	END

GO
create Procedure [dbo].[RemoveActionitemDefinitionSendEmailTo]
    (
    @ActionItemDefinitionId bigint
    )
AS

delete ActionItemDefinitionEmailToRecipient where actionitemdefinitionid = @ActionItemDefinitionId


