CREATE PROCEDURE SP_Seats_Delete
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    DELETE FROM
        [Seats]
    WHERE
        [Id] = @id
END