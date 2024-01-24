

ALTER TABLE [dbo].[Plant]
ADD CONSTRAINT PlantId_Unique
UNIQUE([Id])

GO

alter table [dbo].[User] add PlantId bigint null

GO

ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Plant]
FOREIGN KEY([PlantId])
REFERENCES [dbo].[Plant] ([Id])

GO


GO
