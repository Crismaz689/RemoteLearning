CREATE TRIGGER UpdateTestTimeDeletion
ON [dbo].[TextQuestions]
AFTER DELETE
AS
BEGIN
	declare @testId int  
    SET NOCOUNT ON;  
    SELECT @testId = [TestId] from [deleted] 

	IF (SELECT COUNT ([tq].[TimeMinutes])
		FROM [dbo].[TextQuestions] AS tq
		WHERE [tq].[TestId] = @testId) = 0
		BEGIN
			UPDATE [dbo].[Tests]
			SET [TimeMinutes] = 0,
			[Points] = 0
			WHERE [Id] = @testId
		END
	ELSE
		BEGIN
			UPDATE [dbo].[Tests]
			SET [TimeMinutes] = (SELECT SUM([tq].[TimeMinutes])
				FROM [dbo].[TextQuestions] AS tq
				WHERE [tq].[TestId] = @testId),
				[Points] = (SELECT SUM([tq].[Points])
				FROM [dbo].[TextQuestions] AS tq
				WHERE [tq].[TestId] = @testId)
			WHERE [Id] = @testId
		END
END

