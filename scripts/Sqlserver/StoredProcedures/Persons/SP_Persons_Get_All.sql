CREATE PROCEDURE SP_Persons_Get_All
(
    @OffSet INT,
    @Size INT
)
AS
BEGIN
    SELECT 
       [Id],
       [CreatedAt],
       [FirstName],
       [LastName],
       [BirthDate],
       [SeatId]
    FROM 
        [Persons] 
    ORDER BY [FirstName] 
    OFFSET @OffSet ROWS
    FETCH NEXT @Size ROWS ONLY;
END;
