USE [master]
GO
/****** Object:  Database [Blog_BTL]    Script Date: 5/8/2023 12:18:42 AM ******/
CREATE DATABASE [Blog_BTL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blog_BTL', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Blog_BTL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blog_BTL_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Blog_BTL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Blog_BTL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog_BTL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog_BTL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog_BTL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog_BTL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog_BTL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog_BTL] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog_BTL] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Blog_BTL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog_BTL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog_BTL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog_BTL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog_BTL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog_BTL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog_BTL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog_BTL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog_BTL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Blog_BTL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog_BTL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog_BTL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog_BTL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog_BTL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog_BTL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog_BTL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog_BTL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blog_BTL] SET  MULTI_USER 
GO
ALTER DATABASE [Blog_BTL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog_BTL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog_BTL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog_BTL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blog_BTL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blog_BTL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Blog_BTL] SET QUERY_STORE = OFF
GO
USE [Blog_BTL]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[idAccount] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](200) NOT NULL,
	[pass] [nvarchar](200) NOT NULL,
	[fullname] [nvarchar](200) NULL,
	[idAdmin] [int] NULL,
	[phoneNumber] [nvarchar](20) NULL,
	[Avatar] [ntext] NULL,
	[address] [nvarchar](200) NULL,
	[email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminBlog]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminBlog](
	[idAdmin] [int] IDENTITY(1,1) NOT NULL,
	[adminAccount] [nvarchar](200) NULL,
	[adminPass] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[idBlog] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[status] [int] NULL,
	[createAt] [date] NOT NULL,
	[content] [ntext] NOT NULL,
	[amountLike] [int] NULL,
	[isDelete] [int] NULL,
	[idAccount] [int] NULL,
	[ImageTitle] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBlog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[nameCategory] [nvarchar](100) NULL,
	[idAdmin] [int] NULL,
	[img] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentBlog]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentBlog](
	[idComment] [int] IDENTITY(1,1) NOT NULL,
	[content] [ntext] NOT NULL,
	[createAt] [date] NULL,
	[idAccount] [int] NULL,
	[idBlog] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailCategory]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailCategory](
	[idBlog] [int] NOT NULL,
	[idCategory] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBlog] ASC,
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LikeBlog]    Script Date: 5/8/2023 12:18:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikeBlog](
	[idAccount] [int] NOT NULL,
	[idBlog] [int] NOT NULL,
	[likeAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBlog] ASC,
	[idAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (1, N'tranminhduc', N'Duc@123456', N'Trần Minh Đứcc', 1, N'0367218700', N'https://localhost:7237/images/avatars/tranminhduc/sample-image.jpg', N'Cẩm Phả , Quảng Ninh', N'mintduc26@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (2, N'mylinh', N'Linh@123456', N'Trần Mỹ Linh', NULL, N'0862861396', N'https://localhost:7237/images/avatars/mylinh/MyLinh.jpg', N'Đông Anh, Hà Nội', N'linh@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (3, N'doducliem', N'Liem@123456', N'Đỗ Đức Liêm', NULL, N'0367218700', N'./../images/avatars/user-01.jpg', N'số nhà 9', N'liem@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (4, N'TakaSakai', N'Tu1den10@', N'Hieu_Sakai', NULL, NULL, N'./../images/icons/social/iconmonstr-user-circle-thin.svg', NULL, N'hieu0353333494@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (5, N'minhngoc', N'Ngoc@123456', N'Nguyễn Minh Ngọc', NULL, N'0399620226', N'https://localhost:7237/images/avatars/minhngoc/ngoc.png', N'Đông Anh, Hà Nội', N'ngoc@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (6, N'levansy', N'Sy@123456', N'Lê Văn Sỹ', NULL, N'0971497472', N'https://localhost:7237/images/avatars/levansy/338170629_1385412425645224_3835160975926136846_n.jpg', N'Nghệ An', N'sy@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (7, N'lexuanquynh', N'Quynh@123456', N'Lê Xuân Quỳnh', NULL, N'3242342423243', N'https://localhost:7237/images/avatars/lexuanquynh/338347182_1142696016396972_2523939214791352353_n.jpg', N'Ha-Nam, Hà Nam, Vietnam', N'quynh@gmail.com')
INSERT [dbo].[Account] ([idAccount], [userName], [pass], [fullname], [idAdmin], [phoneNumber], [Avatar], [address], [email]) VALUES (8, N'kimsao', N'Kimsao@1234', N'Nguyễn Kim Sao0', NULL, N'098765432', N'https://localhost:7237/images/avatars/kimsao/AvatarCoSao.jpg', N'Hà Nội', N'kimsao@gmail.com')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminBlog] ON 

INSERT [dbo].[AdminBlog] ([idAdmin], [adminAccount], [adminPass]) VALUES (1, N'Admin', N'Admin@123456')
SET IDENTITY_INSERT [dbo].[AdminBlog] OFF
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (5, N'sadasd', 2, CAST(N'2023-03-24' AS Date), N'<p>sdasdasda</p>', 0, NULL, 3, N'https://localhost:7237/ImageTitle/doducliem/wheel-1000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (15, N'Hello', 3, CAST(N'2023-04-02' AS Date), N'<p>zxcxzczxc</p>', 0, NULL, 2, N'https://localhost:7237/ImageTitle/mylinh/single-gallery-03-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (16, N'Helacdads', 3, CAST(N'2023-04-02' AS Date), N'<p>adasdasd</p>', 0, NULL, 2, N'https://localhost:7237/ImageTitle/mylinh/single-gallery-03-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (19, N'ádasdasd', 3, CAST(N'2023-04-02' AS Date), N'<figure class="image image_resized" style="width:66.81%;"><img src="https://localhost:7237/ImagePost/mylinh/1680440814288single-gallery-03-2000.jpg"></figure>', 0, NULL, 2, N'https://localhost:7237/ImageTitle/mylinh/single-gallery-03-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (30, N'acasdasd', 3, CAST(N'2023-04-03' AS Date), N'<p>adasdsad</p>', 0, NULL, 1, N'https://localhost:7237/ImageTitle/tranminhduc/single-gallery-03-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (31, N'xzczc', 3, CAST(N'2023-04-03' AS Date), N'<p>zczxcz</p>', 0, NULL, 1, N'https://localhost:7237/ImageTitle/tranminhduc/single-gallery-03-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (33, N'ccc', 3, CAST(N'2023-04-03' AS Date), N'<p>cacc</p>', 0, NULL, 1, N'https://localhost:7237/ImageTitle/tranminhduc/single-gallery-02-1000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (34, N'ccc', 3, CAST(N'2023-04-03' AS Date), N'<p>acaxczxc</p>', 0, NULL, 1, N'https://localhost:7237/ImageTitle/tranminhduc/single-gallery-03-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (35, N'Tôi muốn sống cuộc sống của tôi', 2, CAST(N'2023-04-03' AS Date), N'<p>Cuộc sống đôi khi không phải như ta nghĩ, &nbsp;có những thứ thật gần mà không thể với, có những thứ cũng thật xa mà như trước mặt.</p><p>Mùa đông năm đó, chạy vội trên con đường đến bến xe quen thuộc, hơi thở nặng nề vì cái lạnh giá của thời tiết, tôi bước lên xe rồi tìm một chỗ ngồi cho bản thân. Như mọi buổi sáng khác, chuyến xe buýt luôn đông nghẹt người, cảm tưởng như chỉ muộn thêm nửa phút nữa thôi thì đến chỗ đứng cũng không còn.</p><p>Cố gắng ổn định lại nhịp thở của mình,&nbsp;</p><p>&nbsp;<img class="image_resized" style="width:52.32%;" src="https://localhost:7237/ImagePost/TakaSakai/16805144967376382715.jpg"></p><blockquote><p>Ăn chay luôn là giải pháp tốt để tôi có thể lấy lại nhịp thở của mình</p><p>Mọi người hãy ăn chay nhé</p></blockquote>', 0, NULL, 4, N'https://localhost:7237/ImageTitle/TakaSakai/334915478_1135697117202135_5228134943451106029_n.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (39, N'Xin Chào các bạn đây là bài viết đầu tiên của Mình ', 2, CAST(N'2023-04-10' AS Date), N'<blockquote><p>Chào mọi người mình tên là Trần Minh Đức</p></blockquote><p><img src="https://localhost:7237/ImagePost/tranminhduc/1681128476369standard-500.jpg"></p><p>Đây là nhà của minh heheee</p><pre><code class="language-html">&lt;h1&gt;Hello&lt;/h1&gt;</code></pre>', 1, NULL, 1, N'https://localhost:7237/ImageTitle/tranminhduc/standard-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (40, N'Ông chủ Tân Hiệp Phát Trần Quí Thanh bị bắt', 2, CAST(N'2023-04-10' AS Date), N'<h2><strong>Ông chủ Tân Hiệp Phát Trần Quí Thanh bị bắt</strong></h2><p><span style="color:rgb(117,117,117)!important;">TP HCM</span>Ông Trần Quí Thanh, Tổng giám đốc Tập đoàn nước giải khát Tân Hiệp Phát, và hai con gái Trần Uyên Phương, Trần Ngọc Bích bị bắt tạm giam, hoặc khởi tố.</p><p>Quyết định bắt tạm giam ông Thanh (70 tuổi), bà Uyên Phương (42 tuổi) về tội <i>Lạm dụng tín nhiệm chiếm đoạt tài sản</i> được Cơ quan Cảnh sát điều tra (C01, Bộ Công an) ký các ngày 8-10/4.</p><p>Cùng tội danh, C01 cũng khởi tố con gái thứ hai của ông Thanh là Trần Ngọc Bích (39 tuổi, Phó tổng Giám đốc Tân Hiệp Phát kiêm Giám đốc Công ty Number One Hà Nam). Bị can được tại ngoại.</p><p><img class="image_resized" style="width:680px;" src="https://i1-vnexpress.vnecdn.net/2023/04/10/Tran-Qui-Thanh-Tan-Hiep-Phat-3636-1681124038.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=gy9NjSZKWRKN5VQW0l6K6A" alt="Ông Trần Quí Thanh và con gái Trần Phương Uyên. Ảnh: Thành Nguyễn"></p><p>Ông Trần Quí Thanh và con gái Trần Uyên Phương, tháng 10/2019. Ảnh: <i>Thành Nguyễn</i></p><p>Chiều 10/3, C01 đã khám xét chỗ ở, nơi làm việc của 3 bị can tại 9 địa điểm. Hàng trăm cảnh sát vũ trang đã phong toả trụ sở Công ty Tân Hiệp Phát trên quốc lộ 13, phường Lái Thiêu, TP Thuận An (Bình Dương) để khám xét.</p><p>Theo C01, việc khởi tố và bắt tạm giam 3 cha con ông Thanh nằm trong diễn tiến giải quyết đơn của một số người ở TP HCM, Đồng Nai. Họ tố giác ông Thanh, bà Uyên Phương, bà Bích và một số cá nhân có hành vi <i>Lừa đảo chiếm đoạt tài sản, Lạm dụng tín nhiệm chiếm đoạt tài sản, Trốn thuế</i> và <i>Cưỡng đoạt tài sản</i>. Những hành vi này liên quan các dự án, bất động sản có giá trị đặc biệt lớn tại Đồng Nai và TP HCM.</p><p><img class="image_resized" style="width:680px;" src="https://i1-vnexpress.vnecdn.net/2023/04/10/tan-hiep-phat-tru-so-3057-1681125880.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=zmYEApbtRTjV1KYaU5Vllw" alt="Cảnh sát bảo vệ bên ngoài trụ sở Tân Hiệp Phát khi một số phòng làm việc bị khám xét, chiều 10/4. Ảnh: Phước Tuấn"></p><p>Cảnh sát bảo vệ bên ngoài trụ sở Tân Hiệp Phát khi một số phòng làm việc bị khám xét, chiều 10/4. Ảnh: <i>Yên Khánh</i></p><p>Hai năm trước, tháng 3/2021, C01 đã khởi tố vụ án <i>Lừa đảo chiếm đoạt tài sản</i> khi nhận được đơn tố cáo của ông Lê Văn Lâm, Tổng giám đốc Công ty Cổ phần đầu tư phát triển Kim Oanh Đồng Nai (Công ty Kim Oanh); ông Nguyễn Văn Chung (Giám đốc Công ty DCB) và Lâm Hoàng Sơn (cùng ngụ TP HCM).</p><p>Trong đơn, ông Lâm cho rằng ông Thanh và con gái Uyên Phương cùng một số người liên quan đã có hành vi chiếm đoạt tài sản thông qua chuyển nhượng dự án, cổ phần doanh nghiệp. Các ký kết giữa hai bên là hợp đồng giả cách (các bên thực hiện nhằm che giấu đi một hợp đồng khác), bản chất là việc vay mượn tiền.</p>', 0, NULL, 1, N'https://localhost:7237/ImageTitle/tranminhduc/wheel-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (41, N'Cuộc chiến xe điện của Tesla ở Trung Quốc', 2, CAST(N'2023-04-10' AS Date), N'<p>Zhang Hua dành ba tháng để xem xét khoảng 6 mẫu xe điện trước khi quyết định chọn Xpeng P7 thay cho chiếc Honda Civic cũ, chứ không phải Tesla.</p><p>Trước khi xuống tiền mua chiếc sedan P7 đầu tháng 3, Zhang Hua, một nhà nghiên cứu tại Đại học Giao thông Thượng Hải, đã đọc đánh giá trên các diễn đàn xe, đến các showroom để lái thử và đặt các câu hỏi về dịch vụ bổ sung, khả năng mất giá khi bán lại xe.</p><p>Cuối cùng, hệ thống hỗ trợ người lái trên chiếc P7 và các chức năng ra lệnh bằng giọng nói đã chinh phục anh chi 250.000 nhân dân tệ (36.340 USD) để mua.</p><p>"Tôi ưu tiên mức độ thông minh vì đây là kỷ nguyên số, nơi người lái xe và hành khách yêu cầu nhiều hoạt động giải trí trong xe và kết nối kỹ thuật số hơn", Zhang, 40 tuổi, cho biết. Theo anh, xe điện trong nước là lựa chọn hợp lý cho giới trung lưu vì công nghệ và dịch vụ đáp ứng đúng nhu cầu.</p><p>Không chỉ Zhang, hàng chục nghìn người Trung Quốc gần đây đã đổ xô đến đại lý các hãng nội địa như BYD, Nio, Xpeng, Li Auto để sắm ôtô mới. Trong top 10 mẫu xe điện được ưu thích nhất do JD Power và Đại học Tongji (Thượng Hải) khảo sát, 9 hạng đầu thuộc về các hãng nội địa. Tesla chỉ có Model Y ở hạng 10.</p><p>Mẫu sedan ET7 của Nio đứng đầu, theo sau là chiếc SUV G9 của Xpeng. JD Power không tiết lộ số lượng người tham gia khảo sát nhưng cho hay khả năng giải trí và công nghệ trên xe là yếu tố quan trọng được xét đến.</p><p><img class="image_resized" style="width:680px;" src="https://i1-kinhdoanh.vnecdn.net/2023/04/10/screenshot-2023-04-10-at-12-15-9689-1663-1681061088.png?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=4RzZ9X9CaMcUaKjhDlNc5w" alt="10 mẫu xe điện được yêu thích nhất Trung Quốc. Đồ họa: SCMP"></p><p>&nbsp;</p><p>10 mẫu xe điện được yêu thích nhất Trung Quốc. Đồ họa: <i>SCMP</i></p><p>David Zhang, nhà phân tích của Trung tâm nghiên cứu đổi mới ngành ôtô tại Đại học Công nghệ Bắc Trung Quốc, cho biết Tesla đã rất thành công ở thị trường này xét trên doanh số bán hàng và sự công nhận thương hiệu. "Nhưng giờ đây, họ đang phải đối mặt với câu hỏi khó là làm thế nào để tiếp tục dẫn đầu", ông nói.</p><p>Người mua xe điện Trung Quốc bị thu hút bởi buồng lái kỹ thuật số, hệ thống giải trí trên xe và khả năng hệ thống nhận dạng các ngôn ngữ địa phương khác nhau ở nước này. Ít nhất 87% trong top 10 hiểu được khẩu lệnh.</p><p>"Một số nhà lắp ráp ôtô thông minh Trung Quốc đã vượt trội so với các đối thủ toàn cầu về phát triển buồng lái kỹ thuật số", Jeff Cai, Cố vấn trưởng của bộ phận thực hành sản phẩm ôtô JD Power China, cho biết.</p><p>Tesla cũng cung cấp công nghệ nhận dạng giọng nói cho người dùng Trung Quốc nhưng không hoạt động tốt trong môi trường ồn ào, theo khảo sát của JD Power và Đại học Tongji. Hơn nữa, Model 3 của Tesla không lọt vào top 10.</p><p>Dù có thứ hạng thấp, Tesla vẫn tiếp tục dẫn đầu trong phân khúc xe điện cao cấp. Shanghai Gigafactory, cơ sở sản xuất lớn nhất của Tesla trên toàn thế giới, đang hoạt động với tốc độ cao. Những chiếc Model 3 và Model Y tiếp tục là những chiếc EV cao cấp bán chạy nhất Trung Quốc nhờ được giảm giá mạnh gần đây.</p><p>Sau khi Model 3 do nhà máy Thượng Hải sản xuất tung ra thị trường đại lục vào tháng 1/2020, nó đã thu hút được nhiều lời khen ngợi. Đây cũng là mẫu xe điện bán chạy nhất cho đến khi bị truất ngôi vào tháng 9/2020 bởi một mẫu xe điện mini do SAIC-GM-Wuling lắp ráp.</p><p><img class="image_resized" style="width:680px;" src="https://i1-kinhdoanh.vnecdn.net/2023/04/10/screenshot-2023-04-10-at-12-10-4593-5267-1681061088.png?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=6ck5orpV9v81JBvyTEXk3w" alt="Sản lượng xe giao hàng hàng tháng của các thương hiệu tại Trung Quốc. Đồ họa: SCMP"></p><p>Sản lượng xe giao hàng hàng tháng của các thương hiệu tại Trung Quốc. Đồ họa: <i>SCMP</i></p><p>Xe Tesla vẫn rất phổ biến trên đường phố Trung Quốc. Năm ngoái, hãng đã giao hơn 710.000 chiếc Model 3 và Model Y cho khách hàng nước này, tăng 50% so với cùng kỳ 2021. Để so sánh, Li Auto có trụ sở tại Bắc Kinh, đối thủ gần nhất của Tesla, chỉ bàn giao 133.246 chiếc cho khách hàng vào năm ngoái. Doanh số của Li cũng tăng trưởng đến 47% so với cùng kỳ 2021.</p><p>Khảo sát khách hàng của hãng tư vấn toàn cầu AlixPartners chỉ ra rằng người mua xe Trung Quốc đánh giá cao các công nghệ mới tiên tiến, bao gồm lái xe tự động và chức năng buồng lái thông minh.</p><p>"Các nhà sản xuất ôtô nước ngoài đã có một khởi đầu thuận lợi với một số công nghệ này. Tuy nhiên, các đối thủ Trung Quốc đang nhanh chóng bắt kịp và trong nhiều trường hợp, vượt qua các đồng nghiệp nước ngoài", Stephen Dyer, Trưởng bộ phận thực hành ôtô châu Á tại AlixPartners, nhận định.</p><p>Tại Trung Quốc, xe Tesla được gọi là "mẫu quốc tế" vì chúng không được thiết kế dành riêng cho người lái xe và hành khách nước này. Eric Han, Quản lý cấp cao công ty tư vấn Suolei ở Thượng Hải cho biết Tesla không phải là phương tiện thông minh hiện đại mà nhiều người tiêu dùng Trung Quốc giàu có mong muốn. "Nhưng nó vẫn được coi là sản phẩm chất lượng cao và đáng đồng tiền bát gạo vì nhận diện thương hiệu mạnh mẽ", ông nói.</p><p>Ngoài ra, trong khi Model 3 và Model Y của Tesla có thể đi được quãng đường tương ứng là 556 km và 545 km trong một lần sạc, thì các phiên bản cấp thấp như ET7 của Nio, P7 của Xpeng và L8 của Li Auto có phạm vi di chuyển lần lượt là 530 km, 480 km và 1.315 km cho một lần sạc.</p><p><img class="image_resized" style="width:680px;" src="https://i1-kinhdoanh.vnecdn.net/2023/04/10/Screenshot-2023-04-10-at-12-14-1676-3606-1681061088.png?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=EQ3T3puPbMsaM1pvqpMISQ" alt="Tầm hoạt động (km) mỗi lần sạc của các mẫu xe điện. Đồ họa: SCMP"></p><p>Tầm hoạt động (km) mỗi lần sạc của các mẫu xe điện. Đồ họa: <i>SCMP</i></p><p>Xe điện thông minh của Trung Quốc còn được trang bị hệ thống AR và VR để mang đến cho hành khách cái gọi là trải nghiệm nhập vai, điều mà xe Tesla thiếu. Hơn nữa, hệ thống hỗ trợ người lái tiên tiến của Tesla là phần mềm tự lái hoàn toàn (FSD), chưa được chấp thuận sử dụng ở Trung Quốc.</p><p>Xpeng đã tiết lộ phần mềm điều khiển hướng dẫn NGP – tương tự như FSD của Tesla – cuối tháng trước. NGP cho phép xe Xpeng tự động điều hướng trên đường phố ở Trung Quốc đại lục. "Tesla đóng vai trò hàng đầu trong việc làm cho xe điện trở nên thông minh, nhưng NGP được đầu tư tỉ mỉ từ chúng tôi, không thua kém FSD", Wu Xinzhou, Phó chủ tịch kiêm người đứng đầu trung tâm lái xe tự hành tại Xpeng cho biết. Ông nói dù FSD được sử dụng ở Trung Quốc thì nó có thể không hiệu quả bằng NGP do độ phức tạp của hạ tầng giao thông nước này.</p><p>Cuối năm ngoái, Tesla tuyên bố sẽ tiếp tục đổi mới để tăng doanh số cho xe sản xuất từ nhà máy Thượng Hải. Họ nhập bán những mẫu hạng sang Model S và Model X sản xuất ở Mỹ nhưng chỉ chiếm một phần rất nhỏ trong tổng doanh số.</p><p>Ngày 9/1, Grace Tao, Phó chủ tịch phụ trách đối ngoại của Tesla Trung Quốc, nói công ty chưa bao giờ coi các nhà sản xuất xe điện khác là đối thủ cạnh tranh và kêu gọi tất cả cùng nhau tinh chỉnh sản phẩm để đáp ứng nhu cầu khách hàng.</p><p>Nhận xét của bà được đưa ra sau khi Tesla giảm giá tất cả dòng xe sản xuất tại Thượng Hải để thúc đẩy doanh số vào ngày 24/10/2022 và 6/1/2023 khiến giá xe của hãng chạm mức thấp nhất kể từ khi nhà máy hoạt động cuối 2019.</p><p>Jane Kong, một cư dân Thượng Hải, mong đợi Tesla sẽ ra mắt các mẫu xe mới được sản xuất tại Trung Quốc. "Tôi sẽ thay thế chiếc Model 3 bằng một trong số chúng. Model 3 trông không còn lạ mắt và hiện đại nữa, khi các nhà sản xuất ôtô Trung Quốc đang tung ra các mẫu xe mới", người này nói.</p><p><br>&nbsp;</p>', 2, NULL, 5, N'https://localhost:7237/ImageTitle/minhngoc/contact-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (42, N'Đức Chiến bị treo giò hai trận vì đá cầu thủ HAGL', 2, CAST(N'2023-04-10' AS Date), N'<p>Tiền vệ CLB Viettel Nguyễn Đức Chiến nhận án phạt nguội vì hành vi đá vào người Lê Văn Sơn trong trận thua HAGL 1-4 ở vòng 5 V-League 2023 ngày 6/4.</p><p>Phút 69 khi tỷ số đang là 3-1 cho đội khách, Đức Chiến và Văn Sơn tranh bóng, khiến hậu vệ HAGL ngã xuống sân. Cầu thủ Viettel dùng chân trái đá vào người Văn Sơn, và lập tức bị trọng tài Hoàng Thanh Bình phạt thẻ vàng cảnh cáo. Khi tiền đạo HAGL Paollo phản ứng, bênh vực đồng đội, Đức Chiến đặt ngón trỏ lên môi ra dấu cho ngoại binh bên phía đối phương im lặng.</p><p><img class="image_resized" style="width:680px;" src="https://i1-thethao.vnecdn.net/2023/04/10/Screen-Shot-2023-04-10-at-3-05-4872-6449-1681117197.jpg?w=680&amp;h=0&amp;q=100&amp;dpr=1&amp;fit=crop&amp;s=bzr8X5hDxAqeiXpbzLPI5A" alt="Đức Chiến (số 21) trong pha đá vào người Văn Sơn ở trận Viettel thua HAGL 1-4 trên sân Hàng Đẫy ngày 6/4. Ảnh: chụp màn hình"></p><p>Đức Chiến (số 21) trong pha đá vào người Văn Sơn ở trận Viettel thua HAGL 1-4 trên sân Hàng Đẫy ngày 6/4. Ảnh: <i>chụp màn hình</i></p><p>Bốn ngày sau sự việc, Ban kỷ luật LĐBĐ Việt Nam (VFF) ra án phạt nguội. Đức Chiến được xác định có hành vi cố tình xâm phạm thân thể Văn Sơn. Vì thế, tiền vệ Viettel bị cấm thi đấu hai trận và phải nộp phạt 15 triệu đồng.</p><p>Ở trận này, Đức Chiến vào sân từ ghế dự bị ở phút 56 thay Nguyễn Hữu Thắng nhưng không giúp đội nhà thoát trận thua 1-4.</p><p>Đức Chiến sinh năm 1998, trưởng thành từ lò đào tạo trẻ Viettel cùng Hoàng Đức. Anh có sở trường trung vệ, nhưng được kéo lên đá tiền vệ phòng ngự. Đến nay, Đức Chiến đã chơi 63 trận tại V-League cho <a href="https://vnexpress.net/the-thao/du-lieu-bong-da/doi-bong/viettel-3681">Viettel</a> và là thành viên đội bóng này vô địch năm 2020.</p><p>Phong độ ấn tượng ở Viettel giúp Đức Chiến được gọi vào các đội tuyển quốc gia. Cầu thủ người Hải Dương từng cùng U22 Việt Nam giành HC vàng SEA Games 2019, dự vòng chung kết U23 châu Á 2020. Anh cũng từng được triệu tập lên đội tuyển Việt Nam dưới thời HLV Park Hang-seo.</p><p>Bên cạnh án phạt nguội cho Đức Chiến, Ban kỷ luật VFF còn phạt <a href="https://vnexpress.net/the-thao/du-lieu-bong-da/doi-bong/nam-dinh-3674">CLB Nam Định</a> 15 triệu đồng do để xảy ra tình trạng CĐV có lời lẽ thô tục lăng mạ, xúc phạm trọng tài trong trận <a href="https://vnexpress.net/the-thao/nam-dinh-thoat-thua-phut-bu-thu-bay-o-v-league-4590906.html">hoà Khánh Hoà 1-1</a> ngày 7/4 tại sân Thiên Trường.</p><p>Sự việc bắt nguồn khi trọng tài Trương Hồng Vũ xác định cho Khánh Hoà ném biên ở cánh phải, trong khi trọng tài biên xác định quyền ném thuộc về Nam Định. Sau đó, Yago Ramos tận dụng dẫn bóng ghi bàn mở tỷ số cho đội khách. Cuối trận, trọng tài Hồng Vũ tiếp tục gây tranh cãi khi cho Nam Định hưởng phạt đền sau pha tranh chấp giữa Mai Xuân Quyết và thủ môn Ngọc Cường.</p><p>HLV Vũ Tiến Thành của CLB TP HCM cũng bị cảnh cáo, <a href="https://vnexpress.net/the-thao/hlv-vu-tien-thanh-bi-phat-vi-phat-ngon-4591582.html">phạt 10 triệu đồng</a> do phát ngôn gây ảnh hưởng nghiêm trọng đến uy tín quan chức VFF, hình ảnh V-League ở họp báo, sau trận thua Hà Nội FC 1-3 ngày 8/4. Ông Thành chỉ trích công tác trọng tài sau khi Lucao ghi bàn mở tỷ số cho Hà Nội dù đã việt vị, tuyên bố "cứ gặp Hà Nội là thua vì trọng tài. Ngoài ra, HLV CLB TP HCM khẳng định lãnh đạo Hà Nội FC ngồi trên khán đài khiến trọng tài không dám bắt đúng.</p>', 0, NULL, 5, N'https://localhost:7237/ImageTitle/minhngoc/single-gallery-01-2000.jpg')
INSERT [dbo].[Blog] ([idBlog], [title], [status], [createAt], [content], [amountLike], [isDelete], [idAccount], [ImageTitle]) VALUES (43, N'Giới thiệu các tính năng chính của Viblo Interview', 2, CAST(N'2023-04-13' AS Date), N'<p>🌻 Vào ngày 3/4 vừa qua, <strong>Viblo Interview</strong> đã chính thức ra mắt cộng đồng với nhiều tính năng như một <strong>Trang Mạng Xã Hội</strong> dành riêng cho những bạn đang có nhu cầu phỏng vấn trong ngành CNTT. Hôm nay, hãy cùng Viblo Team tìm hiểu về các tính năng chính trên <strong>Viblo Interview</strong> nhé!</p><p>📌 Trải nghiệm Viblo Interview ngay tại đây: <a href="https://interview.viblo.asia/">https://interview.viblo.asia/</a></p><h3><strong>🔍 Tham khảo các câu hỏi trên trang Newest/Mới nhất</strong></h3><p>Trang <strong>Newest/Mới nhất</strong> là nơi cập nhật những câu hỏi và chủ đề câu hỏi được đóng góp mới nhất của người dùng trên <strong>Viblo Interview</strong>. Ngoài ra, người dùng cũng có thể chọn nội dung đọc theo câu hỏi/chủ đề câu hỏi hoặc theo các level của câu hỏi (từ Fresher đến Senior).</p><figure class="image"><img src="https://images.viblo.asia/12d448b8-bf14-4b97-bba9-0a818e2e104b.png" alt=""></figure><h3><strong>🔍 Tham khảo các câu hỏi trên trang Following/Đang theo dõi</strong></h3><p>Tại lần đầu đăng nhập trên <strong>Viblo Interview</strong>, người dùng sẽ được chọn 5 tag trong danh sách tag của hệ thống mà người dùng đang quan tâm để theo dõi.</p><p>Trang <strong>Following/Đang theo dõi</strong> là nơi cập nhật những câu hỏi và chủ đề câu hỏi mới nhất thuộc các tag mà người dùng đang theo dõi, hoặc của người dùng được theo dõi. Vì vậy, đừng quên nhấn <strong>Theo dõi</strong> tag và các người dùng nổi bật khác để có thể cập nhật những câu hỏi chất lượng một cách sớm nhất nhé!</p><figure class="image"><img src="https://images.viblo.asia/a1f34482-07f7-41c6-82a4-a13d06867ec7.png" alt=""></figure><h3><strong>🔍 Tham khảo các câu hỏi trên trang Detail tag/Chi tiết tag</strong></h3><p>Truy cập vào trang <strong>Chi tiết của một Tag</strong> bất kỳ trên <strong>Viblo Interview</strong>, người dùng có thể tìm đọc tất cả các câu hỏi thuộc Tag đó. Các câu hỏi sẽ được sắp xếp theo thứ tự thời gian publish, ngoài ra, người dùng cũng có thể sắp xếp các câu hỏi theo số lượt view, bookmark hoặc vote giảm dần để hiển thị những câu hỏi nổi bật nhất.</p><figure class="image"><img src="https://images.viblo.asia/5712a8df-e2b9-4eb7-9157-5989ccc93594.png" alt=""></figure><h3><strong>🔍 Tìm kiếm theo câu hỏi, chủ đề câu hỏi, tag</strong></h3><p><strong>Ô tìm kiếm</strong> ở đầu trang chủ sẽ giúp bạn tìm kiếm các câu hỏi, chủ đề câu hỏi hoặc tag đang hiện có trên hệ thống. Bạn có thể nhập từ khóa bạn mong muốn tìm, và tất cả các kết quả sẽ hiện ra giúp bạn có thể dễ dàng tìm kiếm các câu hỏi mà bạn đang muốn tham khảo.</p><figure class="image"><img src="https://images.viblo.asia/f4c4330e-00ad-4ff7-a03a-d7d815ac7549.png" alt=""></figure><h3><strong>📌 Đóng góp câu hỏi:</strong></h3><p>Sử dụng tính năng đóng góp câu hỏi bằng cách:</p><ul><li>Click vào ô <strong>Tạo câu hỏi</strong> ở trang chủ</li><li>Điền các thông tin của câu hỏi, sau đó Gửi và chờ admin duyệt</li></ul><figure class="image"><img src="https://images.viblo.asia/6b274959-4072-4486-b202-89f69cabe17a.png" alt=""></figure><p>Các câu hỏi sẽ được admin duyệt trong vòng dưới 2 ngày làm việc. Sau khi duyệt, trong trường hợp bị từ chối, bạn sẽ nhận được comment từ admin để chỉnh sửa các câu hỏi đó.</p><h3><strong>📌 Đóng góp chủ đề câu hỏi:</strong></h3><p>Đóng góp chủ đề câu hỏi bằng cách:</p><ul><li>Click vào ô <strong>Tạo chủ đề câu hỏi</strong> ở trang chủ</li><li>Điền thông tin về chủ đề câu hỏi</li><li>Thêm các câu hỏi mà bạn muốn đưa vào chủ đề. Lưu ý: Bạn cần tạo các câu hỏi này trước khi thêm vào chủ đề</li></ul><figure class="image"><img src="https://images.viblo.asia/07f267a0-d684-4b8d-a52a-056b8baf4d7b.png" alt=""></figure><p>Các chủ đề câu hỏi sẽ không cần admin duyệt mà tự động publish, tuy nhiên những chủ đề không có câu hỏi nào sẽ không được xuất hiện trên trang chủ mà chỉ xuất hiện trong trang cá nhân.</p><h3><strong>📌 Tổng hợp chủ đề câu hỏi:</strong></h3><p>Bạn có thể tổng hợp các câu hỏi vào chủ đề của bạn bằng cách:</p><ul><li>Ở câu hỏi bạn muốn thêm, click vào dấu 3 chấm và chọn <strong>Thêm vào chủ đề</strong></li><li>Chọn chủ đề mà bạn muốn thêm câu hỏi vào. Lưu ý: Bạn cần tạo chủ đề trước khi thêm câu hỏi vào.</li></ul><figure class="image"><img src="https://images.viblo.asia/36e39baa-4f2c-427b-86a4-8711c8ae1b38.png" alt=""></figure><p>Các câu hỏi được thêm có thể là của bạn, hoặc có thể là của các tác giả khác trên <strong>Viblo Interview</strong>. Hãy tận dụng các nguồn tham khảo này để tạo các chủ đề câu hỏi để ôn tập cho riêng mình nhé!</p><p><img class="image_resized" style="width:55.73%;" src="https://localhost:7237/ImagePost/kimsao/1681346962942Hong.jpg"></p><blockquote><p>Hồng sao bằng quần áo em</p></blockquote>', 0, NULL, 8, N'https://localhost:7237/ImageTitle/kimsao/single-gallery-01-1000.jpg')
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (3, N'Lifec', 1, N'../ImageTopic/ngoc.png')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (5, N'Love', NULL, N'
../ImageTopic/guitarist-1200.jpg')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (11, N'Game', 1, N'../ImageTopic/walk-1200.jpg')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (12, N'Environment', 1, N'../ImageTopic/dew-600.jpg')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (13, N'Music', 1, N'../ImageTopic/guitarist-1200.jpg')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (14, N'Food', 1, N'../ImageTopic/cookies-600.jpg')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (15, N'Soccer', 1, N'../ImageTopic/about-2000.jpg')
INSERT [dbo].[Category] ([idCategory], [nameCategory], [idAdmin], [img]) VALUES (16, N'Politic', 1, N'../ImageTopic/about-2000.jpg')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[CommentBlog] ON 

INSERT [dbo].[CommentBlog] ([idComment], [content], [createAt], [idAccount], [idBlog]) VALUES (45, N'hay', CAST(N'2023-03-26' AS Date), 3, 5)
INSERT [dbo].[CommentBlog] ([idComment], [content], [createAt], [idAccount], [idBlog]) VALUES (51, N'Mọi người ủng hộ mình nhé', CAST(N'2023-04-10' AS Date), 1, 39)
INSERT [dbo].[CommentBlog] ([idComment], [content], [createAt], [idAccount], [idBlog]) VALUES (52, N'Oke Ngọc , bài viết hay quá !', CAST(N'2023-04-10' AS Date), 1, 41)
INSERT [dbo].[CommentBlog] ([idComment], [content], [createAt], [idAccount], [idBlog]) VALUES (53, N'Hello
', CAST(N'2023-04-10' AS Date), 1, 41)
INSERT [dbo].[CommentBlog] ([idComment], [content], [createAt], [idAccount], [idBlog]) VALUES (55, N'oke', CAST(N'2023-04-13' AS Date), 5, 5)
INSERT [dbo].[CommentBlog] ([idComment], [content], [createAt], [idAccount], [idBlog]) VALUES (57, N'hay quá', CAST(N'2023-04-13' AS Date), 8, 41)
SET IDENTITY_INSERT [dbo].[CommentBlog] OFF
GO
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (5, 5)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (19, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (35, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (35, 5)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (39, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (39, 11)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (39, 14)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (40, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (41, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (41, 12)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (41, 14)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (42, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (43, 3)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (43, 5)
INSERT [dbo].[DetailCategory] ([idBlog], [idCategory]) VALUES (43, 12)
GO
INSERT [dbo].[LikeBlog] ([idAccount], [idBlog], [likeAt]) VALUES (1, 39, CAST(N'2023-04-10' AS Date))
INSERT [dbo].[LikeBlog] ([idAccount], [idBlog], [likeAt]) VALUES (1, 41, CAST(N'2023-04-10' AS Date))
INSERT [dbo].[LikeBlog] ([idAccount], [idBlog], [likeAt]) VALUES (8, 41, CAST(N'2023-04-13' AS Date))
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [fk_Admin_Account] FOREIGN KEY([idAdmin])
REFERENCES [dbo].[AdminBlog] ([idAdmin])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [fk_Admin_Account]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [fk_Blog_Account] FOREIGN KEY([idAccount])
REFERENCES [dbo].[Account] ([idAccount])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [fk_Blog_Account]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [fk_Admin_Category] FOREIGN KEY([idAdmin])
REFERENCES [dbo].[AdminBlog] ([idAdmin])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [fk_Admin_Category]
GO
ALTER TABLE [dbo].[CommentBlog]  WITH CHECK ADD  CONSTRAINT [fk_CommentBlog_Account] FOREIGN KEY([idAccount])
REFERENCES [dbo].[Account] ([idAccount])
GO
ALTER TABLE [dbo].[CommentBlog] CHECK CONSTRAINT [fk_CommentBlog_Account]
GO
ALTER TABLE [dbo].[CommentBlog]  WITH CHECK ADD  CONSTRAINT [fk_CommentBlog_Blog] FOREIGN KEY([idBlog])
REFERENCES [dbo].[Blog] ([idBlog])
GO
ALTER TABLE [dbo].[CommentBlog] CHECK CONSTRAINT [fk_CommentBlog_Blog]
GO
ALTER TABLE [dbo].[DetailCategory]  WITH CHECK ADD  CONSTRAINT [fk_Blog_DetailCategory] FOREIGN KEY([idBlog])
REFERENCES [dbo].[Blog] ([idBlog])
GO
ALTER TABLE [dbo].[DetailCategory] CHECK CONSTRAINT [fk_Blog_DetailCategory]
GO
ALTER TABLE [dbo].[DetailCategory]  WITH CHECK ADD  CONSTRAINT [fk_Category_DetailCategory] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Category] ([idCategory])
GO
ALTER TABLE [dbo].[DetailCategory] CHECK CONSTRAINT [fk_Category_DetailCategory]
GO
ALTER TABLE [dbo].[LikeBlog]  WITH CHECK ADD  CONSTRAINT [fk_LikeBlog_Account] FOREIGN KEY([idAccount])
REFERENCES [dbo].[Account] ([idAccount])
GO
ALTER TABLE [dbo].[LikeBlog] CHECK CONSTRAINT [fk_LikeBlog_Account]
GO
ALTER TABLE [dbo].[LikeBlog]  WITH CHECK ADD  CONSTRAINT [fk_LikeBlog_Blog] FOREIGN KEY([idBlog])
REFERENCES [dbo].[Blog] ([idBlog])
GO
ALTER TABLE [dbo].[LikeBlog] CHECK CONSTRAINT [fk_LikeBlog_Blog]
GO
USE [master]
GO
ALTER DATABASE [Blog_BTL] SET  READ_WRITE 
GO
