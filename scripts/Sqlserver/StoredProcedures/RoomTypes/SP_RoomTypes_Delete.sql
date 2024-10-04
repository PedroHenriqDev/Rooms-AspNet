CREATE PROCEDURE SP_RoomTypes_Delete
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    DELETE FROM
        [RoomTypes]
    WHERE
        [Id] = @Id
END;
