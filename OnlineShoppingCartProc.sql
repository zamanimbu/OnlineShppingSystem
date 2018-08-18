create procedure InsertUser
@UserName varchar(50),
@Password varchar(50),
@Name varchar(50),
@Email varchar(50)
as
begin 
insert into Users(UserName,[Password],[Name],Email)
values(@UserName,@Password,@Name,@Email)
end 
go

create procedure spInsertSize
@SizeName varchar(50),
@BrandId int,
@CategoryId int,
@SubCategoryId int,
@GenderId int
as
begin 
insert into Size(SizeName,BrandId,CategoryId,SubCategoryId,GenderId)
values(@SizeName,@BrandId,@CategoryId,@SubCategoryId,@GenderId)
end 
go

create procedure spRepeaterSize
as
begin
select A.*,B.*,C.*,D.*,E.* from Size A inner join Category B on B.CategoryId=A.CategoryId inner join Brand C on C.BrandId=A.BrandId inner join SubCategory D on D.SubCategoryId=A.SubCategoryId inner join Gender E on E.GenderId=A.GenderId
end
go


exec spRepeaterSize



create procedure spGetSelectedSize
@BrandId int,
@CategoryId int,
@SubCategoryId int,
@GenderId int
as
begin 
select * from Size where BrandId = @BrandId and CategoryId = @CategoryId and SubCategoryId = @SubCategoryId and GenderId = @GenderId
end 
go



create procedure spBindAllProduct
as
begin
select A.*,B.*, C.BrandName, A.Price - A.SellingPrice as DiscountAmount, B.Name as ImageName, C.BrandName as BrandName
from Product A  
inner join Brand C on C.BrandId = A.BrandId
cross apply(
select top 1 * from ProductImage B where B.ProductId = A.ProductId order by B.ProductId desc 
) B
order by A.ProductId desc 
end
go


create function [dbo].[getSizeName]
(
@SizeId int
)
returns nvarchar(10)
as
begin
declare @SizeName nvarchar(10)
select @SizeName = SizeName from Size where SizeId = @SizeId
return @SizeName 
end
GO