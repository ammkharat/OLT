CREATE TABLE dbo.ShiftHandoverEmailConfigurationWorkAssignment(	
	ShiftHandoverEmailConfigurationId bigint NOT NULL,
	WorkAssignmentId bigint NOT NULL,
 CONSTRAINT PK_ShiftHandoverEmailConfigurationWorkAssignment PRIMARY KEY CLUSTERED 
(
	ShiftHandoverEmailConfigurationId ASC,
	WorkAssignmentId ASC	
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE dbo.ShiftHandoverEmailConfigurationWorkAssignment 
WITH CHECK ADD CONSTRAINT FK_ShiftHandoverEmailConfigurationWorkAssignment_ShiftHandoverEmailConfiguration FOREIGN KEY(ShiftHandoverEmailConfigurationId)
REFERENCES dbo.ShiftHandoverEmailConfiguration (Id);

ALTER TABLE dbo.ShiftHandoverEmailConfigurationWorkAssignment 
WITH CHECK ADD CONSTRAINT FK_ShiftHandoverEmailConfigurationWorkAssignment_WorkAssignment FOREIGN KEY(WorkAssignmentId)
REFERENCES dbo.WorkAssignment (Id)



GO

