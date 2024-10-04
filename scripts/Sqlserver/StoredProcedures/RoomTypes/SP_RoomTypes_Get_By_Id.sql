CREATE PROCEDURE SP_RoomTypes_Get_By_Id
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT
        [Id],
        [CreatedAt],
        [Name]
    FROM 
        [RoomTypes]
    WHERE
        [Id] = @Id
END;


