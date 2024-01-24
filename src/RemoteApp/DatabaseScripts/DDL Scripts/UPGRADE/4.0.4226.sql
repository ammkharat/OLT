-- Create RolePermission table with Foreign Keys
CREATE TABLE [dbo].[RolePermission](
	[RoleId] [bigint] NOT NULL,
	[RoleElementId] [bigint] NOT NULL,
	[CreatedByRoleId] [bigint] NOT NULL,
	CONSTRAINT [FK_RolePermission_RoleId] FOREIGN KEY([RoleId]) REFERENCES [dbo].[Role] ([Id]),
	CONSTRAINT [FK_RolePermission_RoleElementId] FOREIGN KEY([RoleElementId]) REFERENCES [dbo].[RoleElement] ([Id]),
	CONSTRAINT [FK_RolePermission_CreatedByRoleId] FOREIGN KEY([CreatedByRoleId]) REFERENCES [dbo].[Role] ([Id])
)
GO
-- *****************************************************************************************************
-- Populate Role permission table
-- *****************************************************************************************************

-- SARNIA : SiteId = 1 *********************************************************************************
-- INSERT INTO [RolePermission] VALUES (xx, yy, zz)
-- LOGS
-- Operating Engineer = 65, AuthorizedToEditLog 
INSERT INTO [RolePermission] VALUES (65, 34, 65)
INSERT INTO [RolePermission] VALUES (65, 34, 56)
-- Operating Engineer = 65, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (65, 35, 65)
INSERT INTO [RolePermission] VALUES (65, 35, 56)
-- Operating Engineer = 65, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (65, 65, 65)
INSERT INTO [RolePermission] VALUES (65, 65, 56)

-- Operator = 56, AuthorizedToEditLog
INSERT INTO [RolePermission] VALUES (56, 34, 56)
-- Operator = 56, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (56, 35, 56)
-- Operator = 56, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (56, 68, 56)

-- Supervisor = 49, AuthorizedToEditLog
INSERT INTO [RolePermission] VALUES (49, 34, 49)
INSERT INTO [RolePermission] VALUES (49, 34, 81)
-- Supervisor = 49, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (49, 35, 49)
INSERT INTO [RolePermission] VALUES (49, 35, 81)
-- Supervisor = 49, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (49, 71, 49)
INSERT INTO [RolePermission] VALUES (49, 71, 81)

-- Supervisor Plus = 81, AuthorizedToEditLog
INSERT INTO [RolePermission] VALUES (81, 34, 49)
INSERT INTO [RolePermission] VALUES (81, 34, 81)
-- Supervisor Plus = 81, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (81, 35, 49)
INSERT INTO [RolePermission] VALUES (81, 35, 81)
-- Supervisor Plus = 81, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (81, 71, 49)
INSERT INTO [RolePermission] VALUES (81, 71, 81)

-- DIRECTIVES

-- Supervisor = 49, AssertAuthorizedToEditDirectives
INSERT INTO [RolePermission] VALUES (49, 98, 49)
INSERT INTO [RolePermission] VALUES (49, 98, 81)
-- Supervisor = 49, AssertAuthorizedToDeleteDirectives
INSERT INTO [RolePermission] VALUES (49, 99, 49)
INSERT INTO [RolePermission] VALUES (49, 99, 81)

-- Supervisor Plus = 81, AssertAuthorizedToEditDirectives
INSERT INTO [RolePermission] VALUES (81, 98, 49)
INSERT INTO [RolePermission] VALUES (81, 98, 81)
-- Supervisor Plus = 81, AssertAuthorizedToDeleteDirectives
INSERT INTO [RolePermission] VALUES (81, 99, 49)
INSERT INTO [RolePermission] VALUES (81, 99, 81)

-- DENVER : SiteId = 2 *********************************************************************************
-- LOGS
-- Operator = 57, AuthorizedToEditLog
INSERT INTO [RolePermission] VALUES (57, 34, 57)
-- Operator = 57, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (57, 35, 57)
-- Operator = 57, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (57, 65, 57)

-- Supervisor = 50, AuthorizedToEditLog
INSERT INTO [RolePermission] VALUES (50, 34, 50)
INSERT INTO [RolePermission] VALUES (50, 34, 82)
-- Supervisor = 50, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (50, 35, 50)
INSERT INTO [RolePermission] VALUES (50, 35, 82)
-- Supervisor = 50, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (50, 71, 50)
INSERT INTO [RolePermission] VALUES (50, 71, 82)

-- Supervisor Plus = 82, AuthorizedToEditLog
INSERT INTO [RolePermission] VALUES (82, 34, 50)
INSERT INTO [RolePermission] VALUES (82, 34, 82)
-- Supervisor Plus = 82, AuthorizedToDeleteLog
INSERT INTO [RolePermission] VALUES (82, 35, 50)
INSERT INTO [RolePermission] VALUES (82, 35, 82)
-- Supervisor Plus = 82, AuthorizedToCancelReoccuringLog
INSERT INTO [RolePermission] VALUES (82, 71, 50)
INSERT INTO [RolePermission] VALUES (82, 71, 82)

-- DIRECTIVES
-- Supervisor = 50, AssertAuthorizedToEditDirectives
INSERT INTO [RolePermission] VALUES (50, 98, 50)
INSERT INTO [RolePermission] VALUES (50, 98, 82)
-- Supervisor = 50, AssertAuthorizedToDeleteDirectives
INSERT INTO [RolePermission] VALUES (50, 99, 50)
INSERT INTO [RolePermission] VALUES (50, 99, 82)

-- Supervisor Plus = 82, AssertAuthorizedToEditDirectives
INSERT INTO [RolePermission] VALUES (82, 98, 82)
INSERT INTO [RolePermission] VALUES (82, 98, 50)
-- Supervisor Plus = 82, AssertAuthorizedToDeleteDirectives
INSERT INTO [RolePermission] VALUES (82, 99, 82)
INSERT INTO [RolePermission] VALUES (82, 99, 50)

-- OILSANDS : SiteId = 3 *******************************************************************************

-- FIREBAG : SiteId = 5 ********************************************************************************
-- MACKAY RIVER : SiteId = 7 ***************************************************************************
-- EDMONTON : SiteId = 8 *******************************************************************************
-- MONTREAL : SiteId = 9 *******************************************************************************
























GO
