IF EXISTS (SELECT 1 FROM sys.triggers 
           WHERE Name = 'UpdateTestTimeDeletion')
		DROP TRIGGER UpdateTestTimeDeletion