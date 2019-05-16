USE [master]
GO
CREATE DATABASE ORDERMILKTEA
GO
USE ORDERMILKTEA
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
--Nhập liệu bảng Account
INSERT INTO [dbo].[Account] VALUES ('Admin','Admin','123','huynhhoa8697@gmail.com','1')
INSERT INTO [dbo].[Account] VALUES ('User1',N'Duyên','345','nguyenthimyduyen8697@gmail.com','0')
INSERT INTO [dbo].[Account] VALUES ('User2',N'Hậu','345','vovanhau8697@gmail.com','0')
INSERT INTO [dbo].[Account] VALUES ('User3',N'Lan','345','nguyenthilan8697@gmail.com','0')
INSERT INTO [dbo].[Account] VALUES ('User4',N'Nam','345','tranvannam8697@gmail.com','0')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON
--Nhập liệu bảng thức uống
INSERT INTO [dbo].[TableFood] VALUES (01,N'Bàn 1',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (02,N'Bàn 2',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (03,N'Bàn 3',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (04,N'Bàn 4',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (05,N'Bàn 5',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (06,N'Bàn 6',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (07,N'Bàn 7',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (08,N'Bàn 8',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (09,N'Bàn 9',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (10,N'Bàn 10',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (11,N'Bàn 11',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (12,N'Bàn 12',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (13,N'Bàn 13',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (14,N'Bàn 14',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (15,N'Bàn 15',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (16,N'Bàn 16',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (17,N'Bàn 17',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (18,N'Bàn 18',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (19,N'Bàn 19',N'Trống')
INSERT INTO [dbo].[TableFood] VALUES (20,N'Bàn 20',N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON
--Nhập liệu bảng danh mục
INSERT INTO [dbo].[FoodCategory] VALUES (01,N'Cà phê')
INSERT INTO [dbo].[FoodCategory] VALUES (02,N'Trà sữa')
INSERT INTO [dbo].[FoodCategory] VALUES (03,N'Các loại trà hoa')
INSERT INTO [dbo].[FoodCategory] VALUES (04,N'Trà bí đao')
INSERT INTO [dbo].[FoodCategory] VALUES (05,N'Trà đặc biệt')
INSERT INTO [dbo].[FoodCategory] VALUES (06,N'Món thêm')

SET IDENTITY_INSERT [dbo].[FoodCategory] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO
EXEC dbo.USP_GetAccountByUserName @userName =N'Admin'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Food] ON
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (01,N'Cà phê đen','01',12000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (02,N'Cà phê sữa', '01' ,12000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (03,N'Trà sữa hồng trà','02',18000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (04,N'Trà sữa ô long','02',19000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (05,N'Trà sữa trân châu Đài Loan','02',21000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (06,N'Trà sữa thạch thiên nhiên','02',24000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (07,N'Trà sữa QQ','02',24000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (08,N'Trà sữa Pudding','02',23000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (09,N'Trà sữa đậu đỏ','02',24000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (10,N'Trà sữa Matcha Nhật Bản','02',27000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (11,N'Trà sữa Yuan Yang','02',27000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (12,N'Trà sữa khoai môn','02',29000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (13,N'Sữa tươi trân châu đường đen','02',35000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (14,N'Hoa đậu biếc hương sữa','03',28000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (15,N'Hoa đậu biếc hương cam','03',31000)
INSERT INTO [dbo].[Food]  ([id], [name], [idCategory], [price])VALUES (16,N'Hoa đậu biếc hương chanh','03',31000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (17,N'Trà bí đao truyền thống','04',12000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (18,N'Trà bí đao trân châu','04',16000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (19,N'Bí đao chanh','04',18000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (20,N'Bí đao sữa','04',21000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (21,N'Hồng trà','05',15000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (22,N'Lục trà','05',16000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (23,N'Trà ô long','05',16000)
INSERT INTO [dbo].[Food]([id], [name], [idCategory], [price])  VALUES (24,N'Hồng trà chanh','05',20000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (25,N'Lục trà chanh','05',20000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (26,N'Hồng trà mật ong','05',21000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (27,N'Trà đào(hồng trà)','05',29000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (28,N'Trà đào(ô long)','05',30000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (29,N'Trà chanh mật ong','05',28000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (30,N'Trà chanh tắc','05',28000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (31,N'Trân châu','06',5000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (32,N'Thạch thiên nhiên','06',6000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (33,N'Đạu đỏ','06',6000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (34,N'Pudding','06',6000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (35,N'Thạch dừa vị táo xanh','06',5000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (36,N'Thạch dừa vị dâu','06',5000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (37,N'Thạch dừa vị đào','06',5000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (38,N'Hạt thủy tinh đào','06',4000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (39,N'Hạt thủy tinh nho','06',4000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (40,N'Hạt thủy tinh dâu','06',4000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (41,N'Hạt thủy tinh vị sữa chua','06',4000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (42,N'Bánh flan','06',9000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (43,N'Thạch dâu','06',3000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (44,N'Thạch đào','06',3000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price])VALUES (45,N'Thạch táo xanh','06',3000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (46,N'Thạch cà phê','06',3000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (47,N'Thạch trái cây','06',3000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (48,N'Trân châu vuông đường đen','06',9000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (49,N'Trân châu trắng','06',9000)
INSERT INTO [dbo].[Food] ([id], [name], [idCategory], [price])VALUES (50,N'Kem','06',12000)
SET IDENTITY_INSERT [dbo].[Food] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.TableFood
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetNumBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT COUNT(*)
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateForReport]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name, b.totalPrice, DateCheckIn, DateCheckOut, discount
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateAndPage]
@checkIn date, @checkOut date, @page int
AS 
BEGIN
	DECLARE @pageRows INT = 10
	DECLARE @selectRows INT = @pageRows
	DECLARE @exceptRows INT = (@page - 1) * @pageRows
	
	;WITH BillShow AS( SELECT b.ID, t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable)
	
	SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar] (100)NOT NULL,
	[sex] [nvarchar] (100) NOT NULL,
	[birthday] [date] NOT NULL,
	[numberphone] [int] NOT NULL,
	[address] [nvarchar] (100) NOT NULL DEFAULT 0
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Staff] ON
INSERT INTO Staff ([id], [name],  [sex], [birthday],[numberphone], [address] ) VALUES (01,N'Nguyễn Văn Linh',N'Nam','8/6/1997',N'01629337872',N'An Giang')
INSERT INTO Staff ([id], [name],  [sex], [birthday],[numberphone], [address] ) VALUES (02,N'Nguyễn Thị Mỹ Duyên',N'Nữ','2/3/1997',N'01629337787',N'Bình Định')
INSERT INTO Staff ([id], [name],  [sex], [birthday],[numberphone], [address] ) VALUES (03,N'Cù Huy Hiếu',N'Nam','7/12/1997',N'01629337873',N'Hà Tĩnh')
INSERT INTO Staff ([id], [name],  [sex], [birthday],[numberphone], [address] ) VALUES (04,N'Võ Huỳnh Hoa',N'Nữ','8/6/1997',N'01629337872',N'An Giang')
INSERT INTO Staff ([id], [name],  [sex], [birthday],[numberphone], [address] ) VALUES (05,N'Võ văn Hậu',N'Nam','2/16/2000',N'01629337872',N'An Giang')
SET IDENTITY_INSERT [dbo].[Staff] OFF
select * from Staff

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
	          discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
	          0
	        )
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTabel]
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO

ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Admin') FOR [DisplayName]
GO

ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO

ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO

ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Bàn chưa được đặt tên') FOR [name]
GO

ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO

ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO

ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [name]
GO

ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [price]
GO

ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO

ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [status]
GO

ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO

ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO

ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO

ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([id])
GO

ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO

SELECT MAX( id) FROM Bill
SELECT * FROM TableFood
select * from Food

CREATE TRIGGER UTG_UPDATEBILLINFO
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill  INT 
	SELECT  @idBill FROM Inserted
	DECLARE @idTable INT 
	SELECT @idTable = idTable From dbo.Bill where id=@idBill and status =0
	UPDATE dbo.TableFood SET status=N'Có người' where id=@idTable 
END 
GO


 delete dbo.Bill
 delete dbo.BillInfo
CREATE TRIGGER UTG_UPDATEBILL 
ON dbo.Bill FOR UPDATE 
AS
BEGIN
	DECLARE @idBill INT
	SELECT @idBill =id FROM Inserted 
	DECLARE @idTable INT 
	SELECT @idTable = idTable From dbo.Bill where id=@idBill 
	DECLARE @count int=0
	SELECT @count =COUNT (*) FROM dbo.Bill  where idTable =@idTable and status=0
	if(@count = 0)
		update dbo.TableFood set status =N'Trống'

END 
GO 

UPDATE dbo.Bill SET status=1 where id=1
