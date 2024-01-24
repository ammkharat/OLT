if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCokerCard]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCokerCard]
GO

CREATE Procedure [dbo].[UpdateCokerCard]
    (
    @Id bigint Output,
	@LastModifiedByUserId bigint, 
    @LastModifiedDateTime datetime
    )
AS

update CokerCard
set 
	LastModifiedByUserId = @LastModifiedByUserId,
    LastModifiedDateTime = @LastModifiedDateTime
where Id = @Id

go

GRANT EXEC ON [UpdateCokerCard] TO PUBLIC
GO
