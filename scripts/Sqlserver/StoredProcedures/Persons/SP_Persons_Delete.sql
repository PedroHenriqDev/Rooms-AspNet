CREATE PROCEDURE SP_Persons_Delete
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    DELETE FROM
        [Persons] 
    WHERE
        Id = @Id
END;