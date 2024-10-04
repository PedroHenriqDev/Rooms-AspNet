CREATE PROCEDURE SP_Seats_Create
(
    @Id UNIQUEIDENTIFIER,
    @CreatedAt DATETIME2,
    @Name NVARCHAR(3),
    @RoomId UNIQUEIDENTIFIER
)
AS
BEGIN
    INSERT INTO
        [Seats] ([Id], [CreatedAt], [Name], [RoomId])
    VALUES (@Id, @CreatedAt, @Name, @RoomId)
END