
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_ConfinedSpaceMudsNumberSequence')
	BEGIN
		DROP Procedure [dbo].GetNewSeqVal_ConfinedSpaceMudsNumberSequence
	END
GO

Create Procedure [dbo].[GetNewSeqVal_ConfinedSpaceMudsNumberSequence]
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into ConfinedSpaceMudsNumberSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     

	delete from ConfinedSpaceMudsNumberSequence WITH (READPAST)

	return @NewSeqValue

end
GO


GRANT EXEC ON GetNewSeqVal_ConfinedSpaceMudsNumberSequence TO PUBLIC
GO

