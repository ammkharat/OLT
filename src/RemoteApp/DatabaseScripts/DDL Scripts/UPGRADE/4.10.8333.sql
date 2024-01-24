

alter table WorkPermitLubes add IssuedByUserId bigint null;
alter table WorkPermitLubesHistory add IssuedByUserId bigint null;
alter table WorkPermitLubesHistory add IssuedDateTime datetime null;

go

ALTER TABLE [dbo].[WorkPermitLubes]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubes_IssuedByUser] FOREIGN KEY([IssuedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitLubes] CHECK CONSTRAINT [FK_WorkPermitLubes_IssuedByUser]
GO

ALTER TABLE [dbo].[WorkPermitLubesHistory]  WITH CHECK ADD  CONSTRAINT [FK_WorkPermitLubesHistory_IssuedByUser] FOREIGN KEY([IssuedByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[WorkPermitLubesHistory] CHECK CONSTRAINT [FK_WorkPermitLubesHistory_IssuedByUser]
GO



GO

