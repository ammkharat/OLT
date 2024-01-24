CREATE TABLE [dbo].[ActionItemFunctionalLocation](
	[ActionItemId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,

	CONSTRAINT [PK_ActionItemFunctionalLocation] PRIMARY KEY CLUSTERED 
	(
		[ActionItemId] ASC,
		[FunctionalLocationId] ASC
	)
)

GO

ALTER TABLE [dbo].[ActionItemFunctionalLocation]  
ADD CONSTRAINT [FK_ActionItemFunctionalLocation_ActionItemId] FOREIGN KEY([ActionItemId])
REFERENCES [dbo].[ActionItem] ([Id])

GO

ALTER TABLE [dbo].[ActionItemFunctionalLocation] 
ADD CONSTRAINT [FK_ActionItemFunctionalLocation_FunctionalLocationId] FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO


-- ------------------------------------------------------

insert into ActionItemFunctionalLocation
select Id, FunctionalLocationId
from ActionItem

go

-- ------------------------------------------------------

drop index IDX_ACTIONITEM_FOR_DTO on ActionItem

go

alter table ActionItem
drop FK_ActionItem_FunctionalLocation

go

alter table ActionItem
drop column FunctionalLocationId

go
GO
