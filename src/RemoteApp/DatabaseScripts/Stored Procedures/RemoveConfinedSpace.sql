if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveConfinedSpace]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[RemoveConfinedSpace]
GO

CREATE Procedure [dbo].[RemoveConfinedSpace]
(
	@Id bigint,
	@LastModifiedDateTime datetime,
	@LastModifiedByUserId bigint
)
AS

UPDATE ConfinedSpace
  SET
  	LastModifiedDateTime = @LastModifiedDateTime,
  	LastModifiedByUserId = @LastModifiedByUserId,
    Deleted = 1
WHERE 
	Id = @Id
GO