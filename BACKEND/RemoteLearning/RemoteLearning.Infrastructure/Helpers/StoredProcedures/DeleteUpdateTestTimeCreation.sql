IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'UpdateTestTimeCreation')
		DROP TRIGGER UpdateTestTimeCreation