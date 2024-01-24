
 
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'QueryFormOP14MarkedAsReadReport')
    BEGIN
        DROP PROCEDURE [dbo].[QueryFormOP14MarkedAsReadReport]
    END
GO

      
CREATE Procedure [dbo].[QueryFormOP14MarkedAsReadReport]
(        
 @StartDate DATE,
 @EndDate   DATE,
 @SiteId INT
)        
AS 

WITH theDates AS
     (SELECT @StartDate as theDate
      UNION ALL
      SELECT DATEADD(day, 1, theDate)
        FROM theDates
       WHERE DATEADD(day, 1, theDate) <= @EndDate
     )
     
               
SELECT theDates.theDate, op14rd.FormOP14Id,op14.CriticalSystemDefeated , op14rd.UserId,  Usr.Username, Usr.Firstname,Usr.Lastname,
op14rd.[DateTime],op14rd.ShiftId, shft.Name, op14rd.Deleted FROM FormOP14Read op14rd
INNER JOIN FormOP14 op14 ON op14rd.FormOP14Id = op14.Id 
INNER JOIN  Shift shft ON op14rd.ShiftId = shft.Id
INNER JOIN  [User] Usr ON op14rd.UserId = Usr.Id
INNER JOIN  theDates ON  CONVERT(date, op14rd.[DateTime]) = theDates.theDate
Where op14.siteid= @SiteId
OPTION (MAXRECURSION 0)
;

 
 GRANT EXEC ON QueryFormOP14MarkedAsReadReport TO PUBLIC
GO 