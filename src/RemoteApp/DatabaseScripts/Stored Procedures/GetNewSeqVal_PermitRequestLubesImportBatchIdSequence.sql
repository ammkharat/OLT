IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetNewSeqVal_PermitRequestLubesImportBatchIdSequence')
	BEGIN
		DROP PROCEDURE [dbo].GetNewSeqVal_PermitRequestLubesImportBatchIdSequence
	END
GO

CREATE Procedure [dbo].GetNewSeqVal_PermitRequestLubesImportBatchIdSequence
(
	@Id bigint Output
)
AS

begin

	set NOCOUNT ON
	
	insert into PermitRequestLubesImportBatchIdSequence (SeqVal) values ('a')
	
	set @Id = scope_identity()     
	
	delete from PermitRequestLubesImportBatchIdSequence WITH (READPAST)

end

GO

GRANT EXEC ON GetNewSeqVal_PermitRequestLubesImportBatchIdSequence TO PUBLIC
GO

