CREATE PROCEDURE SP_Seats_Update
(
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(3),
    @RoomId UNIQUEIDENTIFIER
)
AS
BEGIN
    UPDATE 
        [Seats]
    SET
        [Name] = @Name,
        [RoomId] = @RoomId
END