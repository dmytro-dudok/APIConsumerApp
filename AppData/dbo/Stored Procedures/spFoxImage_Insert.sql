CREATE PROCEDURE [dbo].[spFoxImage_Insert]
	@Title nvarchar(120),
	@ImageLink nvarchar(100)
AS
begin
	set nocount on;

	insert into dbo.FoxImage (Title, ImageLink)
	values (@Title, @ImageLink)
end
