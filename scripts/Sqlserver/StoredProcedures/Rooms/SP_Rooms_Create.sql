CREATE PROCEDURE SP_Rooms_Create
(
    @Id UNIQUEIDENTIFIER,
    @CreatedAt DATETIME2,
    @Name NVARCHAR(100),
    @Capacity INT,
    @RoomTypeId UNIQUEIDENTIFIER,
    @StartDate DATETIME2,
    @EndDate DATETIME2,
    @SoldOut BIT
)
AS
BEGIN
    INSERT INTO
        [Rooms] 
        (
            [Id],
            [CreatedAt], 
            [Name],
            [Capacity],
            [RoomTypeId],
            [StartDate],
            [EndDate],
            [SoldOut]
        )
    VALUES
    (
        @Id,
        @CreatedAt,
        @Name,
        @Capacity,
        @RoomTypeId,
        @StartDate,
        @EndDate,
        @SoldOut
    )
END;