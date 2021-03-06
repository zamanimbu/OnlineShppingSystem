USE [master]
GO
/****** Object:  Database [onlineShoppingCartDB]    Script Date: 3/19/2018 10:56:33 PM ******/
CREATE DATABASE [onlineShoppingCartDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'onlineShoppingCartDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\onlineShoppingCartDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'onlineShoppingCartDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\onlineShoppingCartDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [onlineShoppingCartDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [onlineShoppingCartDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [onlineShoppingCartDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [onlineShoppingCartDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [onlineShoppingCartDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [onlineShoppingCartDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [onlineShoppingCartDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET RECOVERY FULL 
GO
ALTER DATABASE [onlineShoppingCartDB] SET  MULTI_USER 
GO
ALTER DATABASE [onlineShoppingCartDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [onlineShoppingCartDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [onlineShoppingCartDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [onlineShoppingCartDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [onlineShoppingCartDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'onlineShoppingCartDB', N'ON'
GO
ALTER DATABASE [onlineShoppingCartDB] SET QUERY_STORE = OFF
GO
USE [onlineShoppingCartDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [onlineShoppingCartDB]
GO
/****** Object:  UserDefinedFunction [dbo].[getSizeName]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[Brand]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [varchar](50) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gender]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [varchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[SizeId] [int] NULL,
	[UserName] [varchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[SellingPrice] [decimal](18, 2) NULL,
	[BrandId] [int] NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[GenderId] [int] NULL,
	[Description] [varchar](5000) NULL,
	[Details] [varchar](5000) NULL,
	[MaterialCare] [varchar](5000) NULL,
	[FreeDelivery] [int] NULL,
	[DaysReturn] [int] NULL,
	[Cod] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Extention] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSizeQuantity]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSizeQuantity](
	[ProductSizeQuantityId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[SizeId] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ProductSizeQuantity] PRIMARY KEY CLUSTERED 
(
	[ProductSizeQuantityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Size]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[SizeId] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [varchar](50) NULL,
	[BrandId] [int] NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[GenderId] [int] NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryName] [varchar](50) NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[UserType] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([SizeId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Size]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([BrandId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Gender]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([SubCategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product]
GO
ALTER TABLE [dbo].[ProductSizeQuantity]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizeQuantity_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductSizeQuantity] CHECK CONSTRAINT [FK_ProductSizeQuantity_Product]
GO
ALTER TABLE [dbo].[ProductSizeQuantity]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizeQuantity_Size] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([SizeId])
GO
ALTER TABLE [dbo].[ProductSizeQuantity] CHECK CONSTRAINT [FK_ProductSizeQuantity_Size]
GO
ALTER TABLE [dbo].[Size]  WITH CHECK ADD  CONSTRAINT [FK_Size_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([BrandId])
GO
ALTER TABLE [dbo].[Size] CHECK CONSTRAINT [FK_Size_Brand]
GO
ALTER TABLE [dbo].[Size]  WITH CHECK ADD  CONSTRAINT [FK_Size_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Size] CHECK CONSTRAINT [FK_Size_Category]
GO
ALTER TABLE [dbo].[Size]  WITH CHECK ADD  CONSTRAINT [FK_Size_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Size] CHECK CONSTRAINT [FK_Size_Gender]
GO
ALTER TABLE [dbo].[Size]  WITH CHECK ADD  CONSTRAINT [FK_Size_SubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([SubCategoryId])
GO
ALTER TABLE [dbo].[Size] CHECK CONSTRAINT [FK_Size_SubCategory]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertUser]
@UserName varchar(50),
@Password varchar(50),
@Name varchar(50),
@Email varchar(50),
@UserType varchar(50)
as
begin 
insert into Users(UserName,[Password],[Name],Email,UserType)
values(@UserName,@Password,@Name,@Email,@UserType)
end 
GO
/****** Object:  StoredProcedure [dbo].[spBindAllProduct]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spBindAllProduct]
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

GO
/****** Object:  StoredProcedure [dbo].[spGetSelectedSize]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetSelectedSize]
@BrandId int,
@CategoryId int,
@SubCategoryId int,
@GenderId int
as
begin 
select * from Size where BrandId = @BrandId and CategoryId = @CategoryId and SubCategoryId = @SubCategoryId and GenderId = @GenderId
end 

GO
/****** Object:  StoredProcedure [dbo].[spInsertProduct]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertProduct]
@ProductName varchar(50),
@Price decimal,
@SellingPrice decimal,
@BrandId int,
@CategoryId int,
@SubCategoryId int,
@GenderId int,
@Description varchar(5000),
@Details varchar(5000),
@MaterialCare varchar(5000),
@FreeDelivery int,
@DaysReturn int,
@Cod int
as
begin 
insert into Product(ProductName,Price,SellingPrice,BrandId,CategoryId,SubCategoryId,GenderId,[Description],Details,MaterialCare,FreeDelivery,DaysReturn,Cod)
values(@ProductName,@Price,@SellingPrice,@BrandId,@CategoryId,@SubCategoryId,@GenderId,@Description,@Details,@MaterialCare,@FreeDelivery,@DaysReturn,@Cod)
select SCOPE_IDENTITY()
return 0
end 
GO
/****** Object:  StoredProcedure [dbo].[spInsertSize]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsertSize]
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

GO
/****** Object:  StoredProcedure [dbo].[spRepeaterSize]    Script Date: 3/19/2018 10:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spRepeaterSize]
as
begin
select A.*,B.*,C.*,D.*,E.* from Size A inner join Category B on B.CategoryId=A.CategoryId inner join Brand C on C.BrandId=A.BrandId inner join SubCategory D on D.SubCategoryId=A.SubCategoryId inner join Gender E on E.GenderId=A.GenderId
end

GO
USE [master]
GO
ALTER DATABASE [onlineShoppingCartDB] SET  READ_WRITE 
GO
