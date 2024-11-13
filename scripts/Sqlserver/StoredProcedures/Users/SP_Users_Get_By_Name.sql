CREATE PROCEDURE SP_Users_Get_By_Name
(
    @Name INT
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
        [Name] = @Name
END;