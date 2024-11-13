CREATE PROCEDURE SP_Users_Get_All
(
    @OffSet INT,
    @Size INT
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
END;