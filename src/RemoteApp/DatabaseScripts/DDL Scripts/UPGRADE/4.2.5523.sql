-- Firebag fixes
IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P101' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '101/102 - Operator' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '101/102 - Operator' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P101' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P102' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '101/102 - Operator' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '101/102 - Operator' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P102' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P103' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '103/104 - Operator' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '103/104 - Operator' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P103' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P104' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '103/104 - Operator' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '103/104 - Operator' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P104' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P107' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '107 - Operator' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '107 - Operator' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P107' and f.SiteId = 5
END


IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-108' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '108 - Operator' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '108 - Operator' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-108' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P107' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '93/94 - Oil - CRO' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '93/94 - Oil - CRO' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P107' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P108' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = '93/94 - Oil - CRO' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = '93/94 - Oil - CRO' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P108' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P107' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Chief Steam Engineer' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Chief Steam Engineer' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P107' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P108' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Chief Steam Engineer' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Chief Steam Engineer' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P108' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P101' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P101' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P102' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P102' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P103' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P103' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P104' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P104' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P105' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P105' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P106' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P106' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P107' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P107' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P108' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P108' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P116' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P116' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P101' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager (Super)' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager (Super)' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P101' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P102' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager (Super)' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager (Super)' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P102' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P103' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager (Super)' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager (Super)' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P103' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P104' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager (Super)' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager (Super)' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P104' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P105' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Area Support Manager (Super)' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Area Support Manager (Super)' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P105' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P101' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P101' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P102' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P102' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P103' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P103' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P104' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P104' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P105' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P105' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P106' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P106' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P107' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P107' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P108' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P108' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P116' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Pads - Shift Supervisor' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Pads - Shift Supervisor' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P116' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P101' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Plant 91 Control Room' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Plant 91 Control Room' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P101' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P102' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Plant 91 Control Room' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Plant 91 Control Room' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P102' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P103' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Plant 91 Control Room' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Plant 91 Control Room' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P103' and f.SiteId = 5
END

IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'FB1-P104' and FunctionalLocation.SiteId = 5 
      and WorkAssignment.[Name] = 'Plant 91 Control Room' and FunctionalLocation.SiteId = 5)
BEGIN
INSERT INTO dbo.WorkAssignmentFunctionalLocation (
   WorkAssignmentId
  ,FunctionalLocationId
) Select 
      a.Id, f.Id 
    from 
      WorkAssignment a, functionallocation f
    where 
      a.[Name] = 'Plant 91 Control Room' and a.SiteId = 5 and 
      f.FullHierarchy = 'FB1-P104' and f.SiteId = 5
END


-- Sarnia fix
IF NOT EXISTS(SELECT count(*) from WorkAssignmentFunctionalLocation 
    INNER JOIN FunctionalLocation 
      ON WorkAssignmentFunctionalLocation.FunctionalLocationId = FunctionalLocation.Id
    INNER JOIN WorkAssignment
      ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id 
    where FunctionalLocation.FullHierarchy = 'SR1-OFFS-WWTU' and FunctionalLocation.SiteId = 1 
      and WorkAssignment.[Name] = 'Waste Water Treatment' and FunctionalLocation.SiteId = 1)
BEGIN
 INSERT INTO dbo.WorkAssignmentFunctionalLocation (
       WorkAssignmentId
      ,FunctionalLocationId
    ) Select 
          a.Id, f.Id 
        from 
          WorkAssignment a, functionallocation f
        where 
          a.[Name] = 'Waste Water Treatment' and a.SiteId = 1 and 
          f.FullHierarchy = 'SR1-OFFS-WWTU' and f.SiteId = 1
END


-- Delete WorkAssignment to Functional Location mappings where the Functional Location is deleted
DELETE WorkAssignmentFunctionalLocation
FROM 
WorkAssignmentFunctionalLocation 
inner join WorkAssignment 
  ON WorkAssignmentFunctionalLocation.WorkAssignmentId = WorkAssignment.Id
inner join FunctionalLocation 
  on FunctionalLocation.Id = dbo.WorkAssignmentFunctionalLocation.FunctionalLocationId
inner join dbo.Site on WorkAssignment.SiteId = Site.Id
where FunctionalLocation.Deleted = 1

GO