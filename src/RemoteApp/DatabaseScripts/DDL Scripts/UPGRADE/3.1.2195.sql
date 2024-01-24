IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UndoFunctionalLocation')
	BEGIN
		DROP  Procedure UndoFunctionalLocation
	END

GO
GO
