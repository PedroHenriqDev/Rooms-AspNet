CREATE PROCEDURE SP_Rooms_Get_By_Id
(
    @Id UNIQUEIDENTIFIER
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
    WHERE
        [Id] = @Id
END;