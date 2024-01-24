if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertTradeChecklistHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InsertTradeChecklistHistory]
GO

CREATE Procedure [dbo].[InsertTradeChecklistHistory]
(
	@Id bigint,
	@Trade varchar(128) = NULL,
	@Content nvarchar(max) = NULL,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
)
AS

INSERT INTO TradeChecklistHistory
(
	Id,	
	Trade,	
	Content,
	LastModifiedByUserId,
	LastModifiedDateTime
)
VALUES
(
	@Id,	
	@Trade,	
	@Content,
	@LastModifiedByUserId,
	@LastModifiedDateTime
);

GO

GRANT EXEC ON InsertTradeChecklistHistory TO PUBLIC
GO
