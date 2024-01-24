IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewLubesSeqVal_LubesFormIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewLubesSeqVal_LubesFormIdSequence
	END
GO

CREATE Procedure [dbo].GetNewLubesSeqVal_LubesFormIdSequence
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into LubesFormIdSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     
	
	delete from LubesFormIdSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewLubesSeqVal_LubesFormIdSequence TO PUBLIC
GO

