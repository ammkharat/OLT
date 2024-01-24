IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'RemoveTargetDefinitionChildAssociation')
	BEGIN
		DROP  Procedure  RemoveTargetDefinitionChildAssociation
	END

GO

CREATE Procedure [dbo].RemoveTargetDefinitionChildAssociation
	(
		@ParentTargetDefinitionID bigint
	)


AS

DELETE FROM 
	TargetDefinitionAssociation
WHERE
	ParentTargetDefinitionID = @ParentTargetDefinitionID 

GO


