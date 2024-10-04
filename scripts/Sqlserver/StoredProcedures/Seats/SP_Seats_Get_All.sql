CREATE PROCEDURE SP_Seats_Get_All
AS
BEGIN
    SELECT 
        [Id],
        [CreatedAt],
        [Name],
        [RoomId]
    FROM 
        [Seats]
END