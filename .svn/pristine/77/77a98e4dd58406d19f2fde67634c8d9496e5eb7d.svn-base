if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTargetDefinitionChildAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertTargetDefinitionChildAssociation]
GO

CREATE Procedure [dbo].[InsertTargetDefinitionChildAssociation]
	(
		@ParentTargetDefinitionId bigint,
		@ChildTargetDefinitionId bigint
	)
AS

INSERT INTO TargetDefinitionAssociation	(ParentTargetDefinitionId, ChildTargetDefinitionId) 
VALUES (@ParentTargetDefinitionId, @ChildTargetDefinitionId)
GO

GRANT EXEC ON [InsertTargetDefinitionChildAssociation] TO PUBLIC
GO
