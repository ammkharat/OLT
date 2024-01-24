CREATE TABLE [dbo].[LogGuideline](
	[Id] bigint IDENTITY(100,1) NOT NULL,
	[FunctionalLocationId] bigint NOT NULL,
	[Text] varchar(max) NOT NULL,
	
	CONSTRAINT [PK_LogGuideline] PRIMARY KEY ([Id] ASC)
)

ALTER TABLE [dbo].[LogGuideline]
ADD CONSTRAINT [FK_LogGuideline_FunctionalLocation]
FOREIGN KEY([FunctionalLocationId])
REFERENCES [dbo].[FunctionalLocation] ([Id])

GO

ALTER TABLE [dbo].[LogGuideline]
ADD CONSTRAINT LogGuideline_FunctionalLocation_Unique
UNIQUE(FunctionalLocationId)

GO

insert into LogGuideline (FunctionalLocationId, Text)
select Id, 
'- Change in equipment status
        - Example: LOTO, pump switches, failures (seal, instrumentation, etc.), PMs, etc

- Variations form targets, KMPs and rundown sheets
        - Include reason for variations

- Identify any operational difficulties (e.g., tower flooding)
        - Include a summary of troubleshooting efforts undertaken

- # of technician short on shift'
from FunctionalLocation where FullHierarchy = 'ED1';

GO

insert into LogGuideline (FunctionalLocationId, Text)
select Id, 
'ILP
-----------------------
Required Information:

1) ILP #
2) Risk rank
3) Brief description
4) Additional info for ILPs with risk rank 1 or 2

Containment
-----------------------
Details would include:

1) Substance leaked
2) Location
3) Current status
4) What was done to mitigate

Personal Safety
-----------------------
Details would include:

1) ILP # (if any)
2) Location
3) Description
4) Cause (if known)
5) Mitigation
6) Follow up required

Risk Escalation
-----------------------
Details would include:

1) Location
2) Process stream
3) Type of risk:
     - Ongoing loss of containment
	 
Critical Systems Defeated
-----------------------
Details would include:

1) Which point (tag#) was defeated/bypassed
2) Why
3) Status (returned or still defeated/bypassed)
     - if still defeated/bypassed what is mitigated	 
'
from FunctionalLocation where FullHierarchy = 'EU1';

GO

insert into LogGuideline (FunctionalLocationId, Text)
select Id, 
'ILP
-----------------------
Required Information:

1) ILP #
2) Risk rank
3) Brief description
4) Additional info for ILPs with risk rank 1 or 2

Containment
-----------------------
Details would include:

1) Substance leaked
2) Location
3) Current status
4) What was done to mitigate

Personal Safety
-----------------------
Details would include:

1) ILP # (if any)
2) Location
3) Description
4) Cause (if known)
5) Mitigation
6) Follow up required

Risk Escalation
-----------------------
Details would include:

1) Location
2) Process stream
3) Type of risk:
     - Ongoing loss of containment
	 
Critical Systems Defeated
-----------------------
Details would include:

1) Which point (tag#) was defeated/bypassed
2) Why
3) Status (returned or still defeated/bypassed)
     - if still defeated/bypassed what is mitigated	 
'
from FunctionalLocation where FullHierarchy = 'MN1';
GO
