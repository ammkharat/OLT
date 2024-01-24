CREATE TABLE dbo.PriorityPageSectionConfiguration (
	Id bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,	
	SectionKey int NOT NULL,
	UserId bigint NOT NULL,
	SectionExpandedByDefault bit NOT NULL,		
	LastModifiedDateTime datetime NOT NULL
)
GO

ALTER TABLE dbo.PriorityPageSectionConfiguration 
ADD  CONSTRAINT FK_PriorityPageSectionConfiguration_User
FOREIGN KEY(UserId) REFERENCES dbo.[User](Id)
GO

ALTER TABLE PriorityPageSectionConfiguration
ADD CONSTRAINT UQ_PriorityPageSectionConfiguration_UQSectionKeyUserId UNIQUE(SectionKey, UserId);
GO

CREATE TABLE dbo.PriorityPageSectionConfigurationWorkAssignment (
	PriorityPageSectionConfigurationId bigint NOT NULL,
	WorkAssignmentId bigint NOT NULL
);
GO

ALTER TABLE dbo.PriorityPageSectionConfigurationWorkAssignment 
ADD  CONSTRAINT FK_PriorityPageSectionConfigurationWorkAssignment_PriorityPageSectionConfiguration
FOREIGN KEY(PriorityPageSectionConfigurationId) REFERENCES dbo.PriorityPageSectionConfiguration(Id)
GO

ALTER TABLE dbo.PriorityPageSectionConfigurationWorkAssignment 
ADD  CONSTRAINT FK_PriorityPageSectionConfigurationWorkAssignment_WorkAssignment
FOREIGN KEY(WorkAssignmentId) REFERENCES dbo.WorkAssignment(Id)
GO



GO

