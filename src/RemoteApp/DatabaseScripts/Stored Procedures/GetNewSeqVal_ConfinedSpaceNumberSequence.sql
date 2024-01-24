IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_ConfinedSpaceNumberSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_ConfinedSpaceNumberSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_ConfinedSpaceNumberSequence
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into ConfinedSpaceNumberSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     

	delete from ConfinedSpaceNumberSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewSeqVal_ConfinedSpaceNumberSequence TO PUBLIC
GO

 