
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryEmailToRecipientDTOByActionItemDefinitionId')
	BEGIN
		DROP  Procedure  QueryEmailToRecipientDTOByActionItemDefinitionId
	END

GO

CREATE PROCEDURE QueryEmailToRecipientDTOByActionItemDefinitionId

@ActionItemDefinitionId bigint

AS

BEGIN

SET NOCOUNT ON;

select * from actionitemdefinitionemailtorecipient

END
