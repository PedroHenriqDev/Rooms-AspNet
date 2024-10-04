CREATE PROCEDURE SP_RoomTypes_Exists_Name
(
    @Name NVARCHAR(50)
)
AS
BEGIN
    SELECT 
        CAST(CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS BIT) AS NameExists
    FROM 
        RoomTypes
    WHERE 
        [Name] = @Name;
END;
