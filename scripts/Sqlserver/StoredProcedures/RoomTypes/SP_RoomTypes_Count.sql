CREATE PROCEDURE SP_RoomTypes_Count
AS
BEGIN
    SELECT 
       COUNT(*) AS TotalCount
    FROM 
        [RoomTypes]
END;
