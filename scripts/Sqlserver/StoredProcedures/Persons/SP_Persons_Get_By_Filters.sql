CREATE PROCEDURE SP_Persons_Get_By_Filters 
(
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50), 
    @CreatedAtMin DATETIME2,
    @CreatedAtMax DATETIME2,
    @BirthDateMin DATETIME2,
    @BirthDateMax DATETIME2,
    @SeatName NVARCHAR(3)
)
AS
BEGIN
    SELECT 
       p.[Id],
       p.[CreatedAt],
       p.[FirstName],
       p.[LastName],
       p.[BirthDate],
       p.[SeatId]
    FROM 
        [Persons] p
    INNER JOIN 
        [Seats] s ON p.[SeatId] = s.[Id]
    WHERE 
        LOWER(p.[FirstName]) LIKE '%' + @FirstName + '%' 
    AND 
        LOWER(p.[LastName]) LIKE '%' + @LastName + '%'
    AND
        LOWER(s.[Name])  LIKE '%' + @SeatName + '%'
    AND
        p.[CreatedAt] BETWEEN @CreatedAtMin AND @CreatedAtMax
    AND
        p.[BirthDate] BETWEEN @BirthDateMin AND @BirthDateMax;
END;