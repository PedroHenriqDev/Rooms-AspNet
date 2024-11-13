CREATE PROCEDURE SP_Persons_Create
(
    @Id UNIQUEIDENTIFIER,
    @CreatedAt DATETIME2,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @BirthDate DATETIME2,
    @SeatId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER
)
AS
BEGIN
    INSERT INTO
         [Persons] ([Id], [CreatedAt], [FirstName], [LastName], [BirthDate], [SeatId], [UserId])
    VALUES(@Id, @CreatedAt, @FirstName, @LastName, @BirthDate, @SeatId, @UserId)
END;
