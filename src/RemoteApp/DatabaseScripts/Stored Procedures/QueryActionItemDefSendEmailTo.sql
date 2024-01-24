IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefSendEmailTo')
	BEGIN
		DROP  Procedure  QueryActionItemDefSendEmailTo
	END

GO

CREATE Procedure [dbo].[QueryActionItemDefSendEmailTo]
	(
		@ActionItemDefinitionId bigint
	)
AS

SELECT aidse.EmailTo from ActionItemDefinitionEmailToRecipient Aidse where Aidse.ActionItemDefinitionId = @ActionItemDefinitionId


