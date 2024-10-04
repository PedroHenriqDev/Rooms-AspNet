CREATE PROCEDURE SP_RoomTypes_Create
(
    @Id UNIQUEIDENTIFIER,
    @CreatedAt DATETIME2,
    @Name NVARCHAR(50)
)
AS
BEGIN
    INSERT INTO
        [RoomTypes] ([Id], [CreatedAt], [Name])
    VALUES(@Id, @CreatedAt, @Name)
END;


