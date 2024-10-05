CREATE PROCEDURE SP_Rooms_Get_All
(
    @OffSet INT,
    @Size INT
)
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
    ORDER BY [Name] 
    OFFSET @OffSet ROWS
    FETCH NEXT @Size ROWS ONLY;
END;