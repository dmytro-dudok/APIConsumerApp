CREATE PROCEDURE [dbo].[spFoxImage_GetAll]

AS
begin
	set nocount on;

	SELECT [Title], [ImageLink] 
	from dbo.FoxImage
end