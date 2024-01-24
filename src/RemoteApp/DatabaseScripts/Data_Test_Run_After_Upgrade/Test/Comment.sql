SET IDENTITY_INSERT Comment ON

INSERT INTO [dbo].[Comment]
(
    [Id],
    [CreatedUserId],
    [CreatedDate],
    [Text]
)
VALUES
(
    1,                      -- [Id]
    1,                      -- [CreatedUserId]
    '2006-01-25 17:00:00',  -- [CreatedDate]
    'Id = 1, Some comment'  -- [Text]
);

INSERT INTO [dbo].[Comment]
(
    [Id],
    [CreatedUserId],
    [CreatedDate],
    [Text]
)
VALUES
(
    2,                      -- [Id]
    1,                      -- [CreatedUserId]
    '2006-01-26 17:00:00',  -- [CreatedDate]
    'Id = 2, Some comment'  -- [Text]
);

INSERT INTO [dbo].[Comment]
(
    [Id],
    [CreatedUserId],
    [CreatedDate],
    [Text]
)
VALUES
(
    3,                      -- [Id]
    1,                      -- [CreatedUserId]
    '2006-01-27 17:00:00',  -- [CreatedDate]
    'Id = 3, Some comment'  -- [Text]
);

INSERT INTO [dbo].[Comment]
(
    [Id],
    [CreatedUserId],
    [CreatedDate],
    [Text]
)
VALUES
(
    4,                      -- [Id]
    1,                      -- [CreatedUserId]
    '2006-01-28 17:00:00',  -- [CreatedDate]
    'Id = 4, Some comment'  -- [Text]
);

INSERT INTO [dbo].[Comment]
(
    [Id],
    [CreatedUserId],
    [CreatedDate],
    [Text]
)
VALUES
(
    5,                      -- [Id]
    1,                      -- [CreatedUserId]
    '2006-01-29 17:00:00',  -- [CreatedDate]
    'Id = 5, comment for target alert response'  -- [Text]
);

SET IDENTITY_INSERT Comment OFF
 