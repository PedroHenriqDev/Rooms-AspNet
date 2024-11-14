CREATE PROCEDURE SP_Persons_Count
AS
BEGIN
    SELECT 
       COUNT(*) AS TotalCount
    FROM 
        [Persons]
END;
