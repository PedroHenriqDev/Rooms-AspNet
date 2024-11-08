CREATE PROCEDURE SP_Persons_Get_By_Id
(
    @Id UNIQUEIDENTIFIER
)
AS
BEGIN
    SELECT 
       p.[Id],
       P.[CreatedAt],
       p.[FirstName],
       p.[LastName],
       p.[BirthDate],
       p.[SeatId]
    FROM 
        [Persons] p
    WHERE 
        p.[Id] = @Id 
END;