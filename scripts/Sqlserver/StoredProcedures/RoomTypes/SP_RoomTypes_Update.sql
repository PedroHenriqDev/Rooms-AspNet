CREATE PROCEDURE SP_RoomTypes_Update
(
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(50)
)
AS
BEGIN
    UPDATE
        [RoomTypes]
    SET
        [Name] = @Name
    WHERE
        [Id] = @Id
END;