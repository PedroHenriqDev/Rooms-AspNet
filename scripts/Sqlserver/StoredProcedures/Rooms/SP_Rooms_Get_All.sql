CREATE PROCEDURE SP_Rooms_Get_All
AS
BEGIN
    SELECT
        [Id],
        [CreatedAt], 
        [Name],
        [Capacity],
        [RoomTypeId] AS TypeId,
        [StartDate],
        [EndDate],
        [SoldOut]
    FROM    
        [Rooms] 
END;