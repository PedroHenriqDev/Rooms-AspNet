CREATE PROC SP_Get_User_By_Email
(
    @Email NVARCHAR(256)
)
AS
BEGIN
    SELECT 
        [Id],
        [CreatedAt],
        [Name],
        [Password],
        [Email],
        [BirthDate],
        [Role],
        [Salt]
    FROM
        [Users]
    WHERE
        [Email] = @Email
END;