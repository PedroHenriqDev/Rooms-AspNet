CREATE PROCEDURE SP_Seats_Count
AS
BEGIN
    SELECT 
       COUNT(*) AS TotalCount
    FROM 
        [Seats]
END;
