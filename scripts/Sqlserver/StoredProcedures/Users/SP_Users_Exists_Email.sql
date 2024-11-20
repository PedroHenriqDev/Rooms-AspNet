CREATE PROCEDURE SP_Users_Exists_Email
(
    @Email NVARCHAR(256)
)  
AS
BEGIN
    SELECT 
        CAST(CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS BIT) AS EmailExists
    FROM 
        [Users]
    WHERE 
        [Email] = @Email;
END;


