IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_PermitRequestEdmontonBatchIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_PermitRequestEdmontonBatchIdSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_PermitRequestEdmontonBatchIdSequence
(
	@Id bigint Output
)
AS

begin

	set NOCOUNT ON
	
	insert into PermitRequestEdmontonBatchIdSequence (SeqVal) values ('a')
	
	set @Id = scope_identity()     
	
	delete from PermitRequestEdmontonBatchIdSequence WITH (READPAST)

end

GO

GRANT EXEC ON GetNewSeqVal_PermitRequestEdmontonBatchIdSequence TO PUBLIC
GO

