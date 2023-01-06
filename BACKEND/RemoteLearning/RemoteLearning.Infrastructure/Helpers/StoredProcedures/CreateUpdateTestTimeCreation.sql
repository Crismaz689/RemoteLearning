CREATE TRIGGER UpdateTestTimeCreation
ON [dbo].[TextQuestions]
AFTER INSERT
AS
BEGIN
	declare @testId int  
    SET NOCOUNT ON;  
    SELECT @testId = [TestId] from [inserted] 

	UPDATE [dbo].[Tests]
	SET [TimeMinutes] = (SELECT SUM([tq].[TimeMinutes])
		FROM [dbo].[TextQuestions] AS tq
		WHERE [tq].[TestId] = @testId),
		[Points] = (SELECT SUM([tq].[Points])
		FROM [dbo].[TextQuestions] AS tq
		WHERE [tq].[TestId] = @testId)
	WHERE [Id] = @testId
END


