CREATE PROCEDURE SP_Rooms_Count
AS
BEGIN
    SELECT 
       COUNT(*) AS TotalCount
    FROM 
        [Rooms]
END;
