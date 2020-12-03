--Managing Database User Accounts Queries
CREATE User Troydon;

CREATE LOGIN Troydon   
    WITH PASSWORD = 'Vegeta123';
GO



GRANT ALL PRIVILIGES TO TROYDON;
GO

EXEC sp_addrolemember N'db_datawriter', N'Troydon'
