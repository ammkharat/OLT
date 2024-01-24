IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_WorkPermitLubesPermitNumberSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_WorkPermitLubesPermitNumberSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_WorkPermitLubesPermitNumberSequence
AS

begin

	declare @NewSeqValue bigint

	set NOCOUNT ON

	insert into WorkPermitLubesPermitNumberSequence (SeqVal) values ('z')

	set @NewSeqValue = scope_identity()     

	delete from WorkPermitLubesPermitNumberSequence WITH (READPAST)

	return @NewSeqValue

end

GO

GRANT EXEC ON GetNewSeqVal_WorkPermitLubesPermitNumberSequence TO PUBLIC
GO

