
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewMudsSeqVal_MudsFormIdSequence')
	BEGIN
		DROP Procedure [dbo].GetNewMudsSeqVal_MudsFormIdSequence
	END
GO

Create Procedure [dbo].[GetNewMudsSeqVal_MudsFormIdSequence]
AS

begin

	declare @NewSeqValue int

	set NOCOUNT ON

	insert into MudsFormIdSequence (SeqVal) values ('a')

	set @NewSeqValue = scope_identity()     
	
	delete from MudsFormIdSequence WITH (READPAST)

	return @NewSeqValue

end



GRANT EXEC ON GetNewMudsSeqVal_MudsFormIdSequence TO PUBLIC
GO

