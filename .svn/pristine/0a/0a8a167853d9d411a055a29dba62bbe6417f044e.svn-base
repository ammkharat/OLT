IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_FormIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_FormIdSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_FormIdSequence
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into FormIdSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     
	
	delete from FormIdSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewSeqVal_FormIdSequence TO PUBLIC
GO

