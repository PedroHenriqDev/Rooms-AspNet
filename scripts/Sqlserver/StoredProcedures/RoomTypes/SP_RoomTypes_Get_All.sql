CREATE PROCEDURE SP_RoomTypes_Get_All
AS
BEGIN
    SELECT
        [Id],
        [CreatedAt],
        [Name]
    FROM 
        [RoomTypes]
END;


