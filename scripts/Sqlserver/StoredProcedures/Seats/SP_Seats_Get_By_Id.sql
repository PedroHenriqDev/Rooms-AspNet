CREATE PROCEDURE SP_Seats_Get_By_Id
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT 
        [Id],
        [CreatedAt],
        [Name],
        [RoomId]
    FROM 
        [Seats]
    WHERE
        [Id] = @Id
END