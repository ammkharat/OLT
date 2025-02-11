if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAllSiteCommunication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAllSiteCommunication]
GO

CREATE Procedure [dbo].[InsertAllSiteCommunication]
    (
    @Id bigint Output,
	@SiteId bigint,
    @Message varchar(300),
	@StartDateTime datetime,
	@EndDateTime datetime,
	@CreatedByUserId bigint,
	@CreatedDateTime datetime,
	@LastModifiedByUserId bigint,
	@LastModifiedDateTime datetime
    )
AS

declare @tempid int
declare @sitename varchar(50)
declare @tempsites table
(
    PK            int IDENTITY(1,1), 
    processed     int ,
    tempsiteID    int ,
    tempsitename  varchar(50)
)

insert into @tempsites select 0,site.Id,site.Name from Site order by site.Id

While (Select Count(*) From @tempsites Where Processed = 0) > 0
Begin
    Select Top 1 @tempid = tempsiteID From @tempsites Where Processed = 0
	select top 1 @sitename = tempsitename From @tempsites Where Processed = 0
INSERT INTO SiteCommunication
(
	SiteId,
	SiteName,
    [Message],
	StartDateTime,
	EndDateTime,
	CreatedByUserId,
	CreatedDateTime,
	LastModifiedByUserId,
	LastModifiedDateTime,
	Deleted
)
VALUES
(
    @tempid,
	@sitename,
	@Message,
    @StartDateTime,    
    @EndDateTime,
	@CreatedByUserId,
	@CreatedDateTime,
	@LastModifiedByUserId,
	@LastModifiedDateTime,
	0
) 
  
    Update @tempsites Set Processed = 1 Where tempsiteID = @tempid 

End

select * from SiteCommunication where Deleted = 0 order by StartDateTime asc


GRANT EXEC ON [InsertSiteCommunication] TO PUBLIC