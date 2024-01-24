CREATE TABLE [dbo].[UserLoginHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,	
    [LoginDateTime] DateTime NOT NULL,
	[ShiftId] bigint NOT NULL,
    [ShiftStartDateTime] DateTime NOT NULL,
    [ShiftEndDateTime] DateTime NOT NULL,
	[AssignmentId] [bigint] NULL,

	CONSTRAINT [PK_UserLoginHistory] PRIMARY KEY ([Id] ASC)
)

GO

ALTER TABLE [UserLoginHistory]
ADD CONSTRAINT [FK_UserLoginHistory_User] 
FOREIGN KEY([UserId])
REFERENCES [User] ([Id])

GO

ALTER TABLE [UserLoginHistory]
ADD CONSTRAINT [FK_UserLoginHistory_Shift] 
FOREIGN KEY([ShiftId])
REFERENCES [Shift] ([Id])

GO

ALTER TABLE [UserLoginHistory]
ADD CONSTRAINT [FK_UserLoginHistory_Assignment] 
FOREIGN KEY([AssignmentId])
REFERENCES [WorkAssignment] ([Id])

GO

CREATE INDEX [IDX_UserLoginHistory_UserId_LoginDateTime] 
ON [dbo].[UserLoginHistory] 
(
	[UserId] ASC,
	[LoginDateTime] ASC
)


GO

drop table UserFunctionalLocationPreference

go


CREATE TABLE [dbo].[UserLoginHistoryFunctionalLocation](
	[UserLoginHistoryId] [bigint] NOT NULL,
	[FunctionalLocationId] [bigint] NOT NULL,

	CONSTRAINT [PK_UserLoginHistoryFunctionalLocation] PRIMARY KEY CLUSTERED 
	(
		[UserLoginHistoryId] ASC,
		[FunctionalLocationId] ASC
	)
)

GO

ALTER TABLE [UserLoginHistoryFunctionalLocation]
ADD CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [FunctionalLocation] ([Id])
GO

ALTER TABLE [UserLoginHistoryFunctionalLocation]
ADD  CONSTRAINT [FK_UserLoginHistoryFunctionalLocation_UserLoginHistory]
FOREIGN KEY([UserLoginHistoryId])
REFERENCES [UserLoginHistory] ([Id])

GO
