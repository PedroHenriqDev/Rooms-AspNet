CREATE PROCEDURE SP_Seats_Get_All
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
        [RoomId]
    FROM 
        [Seats]
    ORDER BY [Name] 
    OFFSET @OffSet ROWS
    FETCH NEXT @Size ROWS ONLY;
END;

DROP PROC SP_RoomTypes_Get_All
