CREATE PROCEDURE SP_Rooms_Update
(
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(100),
    @Capacity INT,
    @RoomTypeId UNIQUEIDENTIFIER,
    @StartDate DATETIME2,
    @EndDate DATETIME2,
    @SoldOut BIT
)
AS
BEGIN
    UPDATE 
        [Rooms]
    SET 
        [Name] = @Name,
        [Capacity] = @Capacity,
        [RoomTypeId] = @RoomTypeId,
        [StartDate] = @StartDate,
        [EndDate] = @EndDate,
        [SoldOut] = @SoldOut
END;