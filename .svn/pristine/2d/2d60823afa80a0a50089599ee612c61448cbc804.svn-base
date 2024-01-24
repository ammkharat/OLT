IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_FormOilsandsIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_FormOilsandsIdSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_FormOilsandsIdSequence
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into FormOilsandsIdSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     
	
	delete from FormOilsandsIdSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewSeqVal_FormOilsandsIdSequence TO PUBLIC
GO

