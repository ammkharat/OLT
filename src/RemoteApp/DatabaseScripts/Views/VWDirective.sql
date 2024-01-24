IF EXISTS (SELECT * FROM sysobjects WHERE type = 'V' AND name = 'VWDirective')
BEGIN
	DROP VIEW VWDirective
END

GO

CREATE VIEW [dbo].[VWDirective]
AS
SELECT     D.Id, D.ActiveFromDateTime, D.ActiveToDateTime, FL.Id AS FunctionalLocationId, FL.FullHierarchy AS FunctionalLocation, D.CreatedByUserId, 
                      U1.Username AS CreatedByUserName, D.CreatedDateTime, U1.Firstname AS CreatedByFirstName, U1.Lastname AS CreatedByLastName, D.LastModifiedByUserId, 
                      D.LastModifiedDateTime, U.Username AS LastModifiedByUserName, U.Firstname AS LastModifiedByFirstName, U.Lastname AS LastModifiedByLastName, 
                      D.PlainTextContent AS PlainTextComments, CASE WHEN D .ActiveToDateTime < Getdate() THEN 'Expired' WHEN D .ActiveFromDateTime > Getdate() 
                      THEN 'Future' WHEN GETDATE() BETWEEN D .ActiveFromDateTime AND D .ActiveToDateTime THEN 'Active' END AS State, 
                      CASE D .deleted WHEN 0 THEN 'No' ELSE 'Yes' END AS IsDeleted, S.Id AS SiteID, S.Name AS Site, SH.Name AS ShiftName, D.MigrationSource, 
                      D.ExtraInformationFromMigrationSource, D.CreatedByRoleId, r.Name AS CreatedByRoleName, W.Id AS WorkAssignmentId, 
                      D.CreatedByWorkAssignmentName AS WorkAssignmentName, D.[Content]
FROM         dbo.Directive AS D INNER JOIN
                      dbo.Role AS r ON D.CreatedByRoleId = r.Id LEFT OUTER JOIN
                      dbo.WorkAssignment AS W ON D.CreatedByWorkAssignmentName = W.Name INNER JOIN
                      dbo.DirectiveFunctionalLocation AS DF ON D.Id = DF.DirectiveId INNER JOIN
                      dbo.FunctionalLocation AS FL ON DF.FunctionalLocationId = FL.Id INNER JOIN
                      dbo.[User] AS U ON D.LastModifiedByUserId = U.Id INNER JOIN
                      dbo.[User] AS U1 ON D.CreatedByUserId = U1.Id INNER JOIN
                      dbo.Site AS S ON S.Id = FL.SiteId RIGHT OUTER JOIN
                      dbo.Shift AS SH ON SH.Id = FL.SiteId

GO



