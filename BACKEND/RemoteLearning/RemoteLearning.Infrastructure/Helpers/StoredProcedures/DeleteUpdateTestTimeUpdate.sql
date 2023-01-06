IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'UpdateTestTimeUpdate')
		DROP TRIGGER UpdateTestTimeUpdate