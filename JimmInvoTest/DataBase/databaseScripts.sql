CREATE TABLE [dbo].[UserLogin](
	UserID [int] IDENTITY(1,1) NOT NULL,
	Username [varchar](50) NOT NULL,
	PasswordHash [nvarchar](255) NULL,
	Email [nvarchar](250) NULL,	
)


INSERT INTO [dbo].[UserLogin] (Username, PasswordHash, Email)
VALUES    
    ('user2', '6cf615d5bcaac778352a8f1f3360d23f02f34ec182e259897fd6ce485d7870d4', 'user2@example.com');



    CREATE TABLE Tasks (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    DueDate DATETIME NOT NULL,
    Priority NVARCHAR(10) NOT NULL
);


INSERT INTO [dbo].[Taskss]
           ([Title]
           ,[Description]
           ,[DueDate]
           ,[Priority])
     VALUES
           ('abc'
           ,'abc'
           ,'2024-04-10T15:55:09.553Z'
           ,0)
GO

