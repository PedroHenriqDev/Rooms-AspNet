CREATE PROCEDURE SP_Persons_Get_All
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
END;
