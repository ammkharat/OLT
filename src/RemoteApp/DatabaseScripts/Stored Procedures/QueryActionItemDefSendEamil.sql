IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryActionItemDefSendEmail')
    BEGIN
        DROP PROCEDURE [dbo].QueryActionItemDefSendEmail
    END
GO

CREATE Procedure [dbo].[QueryActionItemDefSendEmail]
	(
		@ActionItemDefinitionId bigint
	)
AS

SELECT aidse.SendEmail from ActionItemDefinitionSendEmail Aidse where Aidse.ActionItemDefinitionId = @ActionItemDefinitionId


