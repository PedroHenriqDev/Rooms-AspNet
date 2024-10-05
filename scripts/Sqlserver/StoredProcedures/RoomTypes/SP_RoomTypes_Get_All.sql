CREATE PROCEDURE SP_RoomTypes_Get_All
(
    @OffSet INT,
    @Size INT
)
AS
BEGIN
    SELECT 
        [Id],
        [CreatedAt],
        [Name]
    FROM 
        [RoomTypes]
    ORDER BY [Name] 
    OFFSET @OffSet ROWS
    FETCH NEXT @Size ROWS ONLY;
END;

DROP PROC SP_RoomTypes_Get_All
