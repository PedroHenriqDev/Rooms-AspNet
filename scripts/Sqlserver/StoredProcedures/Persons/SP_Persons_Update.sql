CREATE PROCEDURE SP_Persons_Update
(
    @Id UNIQUEIDENTIFIER,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @BirthDate DATETIME2,
    @SeatId UNIQUEIDENTIFIER
)
AS
BEGIN
    UPDATE
        [Persons]
    SET 
        [FirstName] = @FirstName,
        [LastName] = @LastName,
        [BirthDate] = @BirthDate,
        [SeatId] = @SeatId
    WHERE
        Id = @Id
END;