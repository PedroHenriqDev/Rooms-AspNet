CREATE PROCEDURE SP_Rooms_Delete
(
    @Id UNIQUEIDENTIFIER 
)
AS
BEGIN
    DELETE FROM    
        [Rooms]
    WHERE
        [Id] = @Id 
END;