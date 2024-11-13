CREATE PROC SP_Users_Create
(
    @Id UNIQUEIDENTIFIER,
    @CreatedAt DATETIME2,
    @Name NVARCHAR(50),
    @Password NVARCHAR(600),
    @Salt TEXT,
    @Email NVARCHAR(256),
    @BirthDate DATETIME2,
    @Role INT
)
AS
BEGIN
    INSERT INTO 
        [Users] ([Id], [CreatedAt], [Name], [Password], [Salt], [Email], [BirthDate], [Role])
    VALUES (@Id, @CreatedAt, @Name, @Password, @Salt, @Email, @BirthDate, @Role)
END;

