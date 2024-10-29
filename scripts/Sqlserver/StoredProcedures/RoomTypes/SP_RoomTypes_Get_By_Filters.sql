CREATE PROCEDURE SP_RoomTypes_Get_By_Filters(
    @Name NVARCHAR(50),
    @MinDate DATETIME2,
    @MaxDate DATETIME2
)
AS
BEGIN
    SELECT 
        [Id],
        [Name],
        [CreatedAt] 
    FROM 
        [RoomTypes]
    WHERE 
        LOWER([Name]) LIKE '%' + @Name + '%' 
    AND 
        [CreatedAt] 
    BETWEEN
        @MinDate
    AND 
        @MaxDate;
END;

