USE [master]
GO
/****** Object:  Database [OMCS]    Script Date: 10/02/2014 00:41:47 ******/
CREATE DATABASE [OMCS] ON  PRIMARY 
( NAME = N'OMCS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\OMCS.mdf' , SIZE = 3328KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OMCS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\OMCS_log.LDF' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OMCS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OMCS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OMCS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [OMCS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [OMCS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [OMCS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [OMCS] SET ARITHABORT OFF
GO
ALTER DATABASE [OMCS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [OMCS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [OMCS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [OMCS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [OMCS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [OMCS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [OMCS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [OMCS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [OMCS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [OMCS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [OMCS] SET  ENABLE_BROKER
GO
ALTER DATABASE [OMCS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [OMCS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [OMCS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [OMCS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [OMCS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [OMCS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [OMCS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [OMCS] SET  READ_WRITE
GO
ALTER DATABASE [OMCS] SET RECOVERY FULL
GO
ALTER DATABASE [OMCS] SET  MULTI_USER
GO
ALTER DATABASE [OMCS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [OMCS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'OMCS', N'ON'
GO
USE [OMCS]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Birthday] [datetime] NULL,
	[Phone] [nvarchar](max) NULL,
	[PrimaryAddress] [nvarchar](max) NULL,
	[SecondaryAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (1, N'admin@mail.com', N'123456', N'Admin', NULL, 1, CAST(0x0000A3AA01153EA4 AS DateTime), N'photo.jpg', NULL, CAST(0x0000A3AA01153EA4 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (2, N'doctor@mail.com', N'123456', N'Doctor 1', NULL, 1, CAST(0x0000A3AA01153EEA AS DateTime), N'doctor1.png', NULL, CAST(0x0000A3AA01153EEA AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (3, N'vana@gmail.com', N'123456', N'A', N'Nguyễn Văn', 1, CAST(0x0000A3AA01153EEA AS DateTime), N'nguyenvana.png', NULL, CAST(0x0000A3AA01153EEA AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (4, N'tonthattung@gmail.com', N'123456', N'Tùng', N'Tôn Thất', 1, CAST(0x0000A3AA01153EEA AS DateTime), N'tonthattung.png', NULL, CAST(0x0000A3AA01153EEA AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (5, N'hodacdi@gmail.com', N'123456', N'Di', N'Hồ Đắc', 1, CAST(0x0000A3AA01153EEA AS DateTime), N'photo.jpg', NULL, CAST(0x0000A3AA01153EEA AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (6, N'dangvanngu@gmail.com', N'123456', N'Ngữ', N'Đặng Văn', 1, CAST(0x0000A3AA01153EEA AS DateTime), N'tonthattung.png', NULL, CAST(0x0000A3AA01153EEA AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (7, N'trannguyentiensu@gmail.com', N'123456', N'Su', N'Tran', 1, CAST(0x0000A3AA01153F1A AS DateTime), N'Su.JPG', N'M', CAST(0x0000837300000000 AS DateTime), N'0933056722', N'Thôn 1, xa CuEbur, Buôn Ma Thuột', N'201/9 Đường Số 9, Gò Vấp')
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (8, N'caodanh@gmail.com', N'123456', N'Danh', N'Trần Cao', 1, CAST(0x0000A3AA01153F1A AS DateTime), N'photo.jpg', N'M', CAST(0x0000837300000000 AS DateTime), N'0933056722', N'Tiền gian', N'Quận 12')
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (9, N'tuanmai@gmail.com', N'123456', N'Tuấn', N'Mai Anh', 1, CAST(0x0000A3AA01153F1A AS DateTime), N'photo.jpg', N'M', CAST(0x0000837300000000 AS DateTime), N'0933056722', N'Tiền gian', N'Quận 12')
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (10, N'nguonnguyen@gmail.com', N'123456', N'Nguồn', N'Nguyễn Hồng Ngọc', 1, CAST(0x0000A3AA01153F1A AS DateTime), N'photo.jpg', N'F', CAST(0x0000837300000000 AS DateTime), N'0933056722', N'Tiền gian', N'Quận 12')
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (11, N'nhannguyen@gmail.com', N'123456', N'Nhân', N'Nguyễn Toàn', 1, CAST(0x0000A3AA01153F1A AS DateTime), N'photo.jpg', N'F', CAST(0x0000837300000000 AS DateTime), N'0933056722', N'Tiền gian', N'Quận 12')
INSERT [dbo].[User] ([UserId], [Email], [Password], [FirstName], [LastName], [IsActive], [CreatedDate], [ProfilePicture], [Gender], [Birthday], [Phone], [PrimaryAddress], [SecondaryAddress]) VALUES (12, N'linhnguyen@gmail.com', N'123456', N'Lịnh', N'Nguyễn Nhật', 1, CAST(0x0000A3AA01153F1A AS DateTime), N'photo.jpg', N'M', CAST(0x0000837300000000 AS DateTime), N'0933056722', N'Quảng Ngãi', N'Quận 12')
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[AllergyType]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllergyType](
	[AllergyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AllergyType] PRIMARY KEY CLUSTERED 
(
	[AllergyTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AllergyType] ON
INSERT [dbo].[AllergyType] ([AllergyTypeId], [Name], [Description]) VALUES (1, N'Thuốc', N'Dị ứng với các loại thuốc')
INSERT [dbo].[AllergyType] ([AllergyTypeId], [Name], [Description]) VALUES (2, N'Thức Ăn', NULL)
INSERT [dbo].[AllergyType] ([AllergyTypeId], [Name], [Description]) VALUES (3, N'Môi Trường', NULL)
INSERT [dbo].[AllergyType] ([AllergyTypeId], [Name], [Description]) VALUES (4, N'Khác', NULL)
SET IDENTITY_INSERT [dbo].[AllergyType] OFF
/****** Object:  Table [dbo].[HospitalInformation]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitalInformation](
	[HospitalInformationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.HospitalInformation] PRIMARY KEY CLUSTERED 
(
	[HospitalInformationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HospitalInformation] ON
INSERT [dbo].[HospitalInformation] ([HospitalInformationId], [Name], [Address], [Email], [Fax], [Phone], [Logo]) VALUES (1, N'FPT Hospital', N'Công viên phần mềm Quang Trung', N'contact@fpt.edu.vn', N'08.53453465', N'08.423423434', N'')
SET IDENTITY_INSERT [dbo].[HospitalInformation] OFF
/****** Object:  Table [dbo].[FilmType]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmType](
	[FilmTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.FilmType] PRIMARY KEY CLUSTERED 
(
	[FilmTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FilmType] ON
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (1, N'Webcam', NULL)
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (2, N'X-quang', NULL)
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (3, N'CT-Scanner', NULL)
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (4, N'Siêu âm', NULL)
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (5, N'Nội soi', NULL)
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (6, N'Xét nghiệm', NULL)
INSERT [dbo].[FilmType] ([FilmTypeId], [Name], [Description]) VALUES (7, N'Khác', NULL)
SET IDENTITY_INSERT [dbo].[FilmType] OFF
/****** Object:  Table [dbo].[MedicalProfileTemplate]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalProfileTemplate](
	[MedicalProfileTemplateId] [int] IDENTITY(1,1) NOT NULL,
	[MedicalProfileTemplateName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MedicalProfileTemplate] PRIMARY KEY CLUSTERED 
(
	[MedicalProfileTemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MedicalProfileTemplate] ON
INSERT [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId], [MedicalProfileTemplateName]) VALUES (1, N'Bệnh Án Mẫu')
INSERT [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId], [MedicalProfileTemplateName]) VALUES (2, N'Bệnh Án Nội Khoa')
INSERT [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId], [MedicalProfileTemplateName]) VALUES (3, N'Bệnh Án Truyền Nhiễm')
INSERT [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId], [MedicalProfileTemplateName]) VALUES (4, N'Bệnh Án Ngoài Da - BV Da Liễu')
INSERT [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId], [MedicalProfileTemplateName]) VALUES (5, N'Bệnh Án Ngoại Khoa')
SET IDENTITY_INSERT [dbo].[MedicalProfileTemplate] OFF
/****** Object:  Table [dbo].[SpecialtyField]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpecialtyField](
	[SpecialtyFieldId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.SpecialtyField] PRIMARY KEY CLUSTERED 
(
	[SpecialtyFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ParentId] ON [dbo].[SpecialtyField] 
(
	[ParentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SpecialtyField] ON
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (1, NULL, N'Ngoại khoa')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (2, NULL, N'Nội khoa')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (3, NULL, N'Nhi Khoa')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (4, 1, N'Ngoại tim mạch')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (5, 1, N'Ngoại lồng ngực')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (6, 1, N'Ngoại tiêu hóa')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (7, 1, N'Phẫu thuật mắt')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (8, 1, N'Ngoại tổng quát')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (9, 1, N'Ngoại thần kinh')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (10, 1, N'Phẫu thuật miệng & hàm mặt')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (11, 1, N'Chấn thương chỉnh hình')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (12, 2, N'Dị ứng')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (13, 2, N'Miễn dịch học')
INSERT [dbo].[SpecialtyField] ([SpecialtyFieldId], [ParentId], [Name]) VALUES (14, 2, N'Nội tim mạch')
SET IDENTITY_INSERT [dbo].[SpecialtyField] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([RoleId], [RoleName], [Description]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[Role] ([RoleId], [RoleName], [Description]) VALUES (2, N'User', NULL)
INSERT [dbo].[Role] ([RoleId], [RoleName], [Description]) VALUES (3, N'Doctor', NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Patient]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[UserId] [int] NOT NULL,
	[Ethnicity] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[Job] [nvarchar](max) NULL,
	[WhereToWork] [nvarchar](max) NULL,
	[ContactPerson] [nvarchar](max) NULL,
	[ContactPersonAddress] [nvarchar](max) NULL,
	[ContactPersonPhone] [nvarchar](max) NULL,
	[HealthInsuranceId] [nvarchar](max) NULL,
	[HealthInsuranceIssued] [datetime] NULL,
	[HealthInsuranceDateExpired] [datetime] NULL,
 CONSTRAINT [PK_dbo.Patient] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Patient] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Patient] ([UserId], [Ethnicity], [Nationality], [Job], [WhereToWork], [ContactPerson], [ContactPersonAddress], [ContactPersonPhone], [HealthInsuranceId], [HealthInsuranceIssued], [HealthInsuranceDateExpired]) VALUES (7, N'Kinh', N'Việt Nam', N'Lập trình viên', N'39B Trường Sơn, Tân Bình', N'Mỹ Linh', N'1 Lý Thường Kiệt', NULL, N'234234VSD', CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime))
INSERT [dbo].[Patient] ([UserId], [Ethnicity], [Nationality], [Job], [WhereToWork], [ContactPerson], [ContactPersonAddress], [ContactPersonPhone], [HealthInsuranceId], [HealthInsuranceIssued], [HealthInsuranceDateExpired]) VALUES (8, N'Kinh', N'Việt Nam', N'Lập trình viên', N'FPT Software', N'Mỹ Linh', N'1 Lý Thường Kiệt', NULL, N'234234VSD', CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime))
INSERT [dbo].[Patient] ([UserId], [Ethnicity], [Nationality], [Job], [WhereToWork], [ContactPerson], [ContactPersonAddress], [ContactPersonPhone], [HealthInsuranceId], [HealthInsuranceIssued], [HealthInsuranceDateExpired]) VALUES (9, N'Kinh', N'Việt Nam', N'Lập trình viên', N'FPT Software', N'Mỹ Linh', N'1 Lý Thường Kiệt', NULL, N'234234VSD', CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime))
INSERT [dbo].[Patient] ([UserId], [Ethnicity], [Nationality], [Job], [WhereToWork], [ContactPerson], [ContactPersonAddress], [ContactPersonPhone], [HealthInsuranceId], [HealthInsuranceIssued], [HealthInsuranceDateExpired]) VALUES (10, N'Kinh', N'Việt Nam', N'Sinh Vien', N'Hoa Sen', N'Mỹ Linh', N'1 Lý Thường Kiệt', NULL, N'234234VSD', CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime))
INSERT [dbo].[Patient] ([UserId], [Ethnicity], [Nationality], [Job], [WhereToWork], [ContactPerson], [ContactPersonAddress], [ContactPersonPhone], [HealthInsuranceId], [HealthInsuranceIssued], [HealthInsuranceDateExpired]) VALUES (11, N'Kinh', N'Việt Nam', N'Sinh Vien', N'Hoa Sen', N'Mỹ Linh', N'1 Lý Thường Kiệt', NULL, N'234234VSD', CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime))
INSERT [dbo].[Patient] ([UserId], [Ethnicity], [Nationality], [Job], [WhereToWork], [ContactPerson], [ContactPersonAddress], [ContactPersonPhone], [HealthInsuranceId], [HealthInsuranceIssued], [HealthInsuranceDateExpired]) VALUES (12, N'Kinh', N'Việt Nam', N'Sinh Vien', N'F Soft', N'Mỹ Linh', N'1 Lý Thường Kiệt', NULL, N'234234VSD', CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A600000000 AS DateTime))
/****** Object:  Table [dbo].[Rating]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RatingPoint] [float] NOT NULL,
	[RatingFor] [int] NOT NULL,
	[ObjectId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Rating] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Rating] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[UserId] [int] NOT NULL,
	[SpecialtyFieldId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Doctor] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SpecialtyFieldId] ON [dbo].[Doctor] 
(
	[SpecialtyFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Doctor] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[Doctor] ([UserId], [SpecialtyFieldId]) VALUES (3, 3)
INSERT [dbo].[Doctor] ([UserId], [SpecialtyFieldId]) VALUES (5, 3)
INSERT [dbo].[Doctor] ([UserId], [SpecialtyFieldId]) VALUES (2, 8)
INSERT [dbo].[Doctor] ([UserId], [SpecialtyFieldId]) VALUES (6, 8)
INSERT [dbo].[Doctor] ([UserId], [SpecialtyFieldId]) VALUES (4, 11)
/****** Object:  Table [dbo].[CustomSnippet]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomSnippet](
	[CustomSnippetId] [int] IDENTITY(1,1) NOT NULL,
	[MedicalProfileTemplateId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Position] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[PositionInTable] [int] NOT NULL,
	[SnippetType] [int] NOT NULL,
	[SnippetFieldName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CustomSnippet] PRIMARY KEY CLUSTERED 
(
	[CustomSnippetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileTemplateId] ON [dbo].[CustomSnippet] 
(
	[MedicalProfileTemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomSnippet] ON
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (1, 1, N'Hành chính', N'Form Name', 1, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (2, 1, N'Họ và tên', N'Static Text', 2, 0, 0, 1, N'FullName')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (3, 1, N'Giới tính', N'Static Text', 3, 0, 0, 1, N'Gender')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (4, 1, N'Công việc', N'Static Text', 4, 0, 0, 2, N'Job')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (5, 1, N'Dân tộc', N'Static Text', 5, 0, 0, 2, N'Ethnicity')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (6, 1, N'Địa chỉ', N'Static Text', 6, 0, 0, 1, N'PrimaryAddress')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (7, 1, N'Vào viện', N'Datepicker', 7, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (8, 1, N'Chuyên môn', N'Form Name', 8, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (9, 1, N'Lí do vào viện', N'Text Input', 9, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (10, 1, N'Bệnh sử', N'Text Area', 10, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (11, 1, N'Tiền sử', N'Form Name', 11, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (12, 1, N'Bản thân', N'Text Area', 12, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (13, 1, N'Gia đình', N'Text Area', 13, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (14, 1, N'Thăm khám', N'Form Name', 14, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (15, 1, N'Toàn thân', N'Text Area', 15, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (16, 1, N'Tóm tắt bệnh án', N'Form Name', 16, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (17, 1, N'Triệu chứng, hội chứng', N'Text Area', 17, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (18, 1, N'Chẩn đoán', N'Text Area', 18, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (19, 1, N'Biện luận chẩn đoán', N'Text Area', 19, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (20, 1, N'Điều trị', N'Form Name', 20, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (21, 1, N'Nguyên tắc', N'Text Area', 21, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (22, 1, N'Cụ thể', N'Text Area', 22, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (23, 1, N'Tiên lượng', N'Form Name', 23, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (24, 1, N'Gần', N'Text Area', 24, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (25, 1, N'Xa', N'Text Area', 25, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (26, 1, N'Dự phòng', N'Text Area', 26, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (27, 2, NULL, N'Form Name', 1, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (28, 2, NULL, N'Static Text', 2, 0, 0, 1, N'FullName')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (29, 2, NULL, N'Static Text', 3, 0, 0, 1, N'Birthday')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (30, 2, NULL, N'Static Text', 4, 0, 0, 1, N'Gender')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (31, 2, NULL, N'Static Text', 5, 0, 0, 2, N'Job')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (32, 2, NULL, N'Static Text', 6, 0, 0, 2, N'Ethnicity')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (33, 2, NULL, N'Static Text', 7, 0, 0, 2, N'Nationality')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (34, 2, NULL, N'Static Text', 8, 0, 0, 1, N'PrimaryAddress')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (35, 2, NULL, N'Static Text', 9, 0, 0, 2, N'WhereToWork')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (36, 2, NULL, N'Multiple Radios Inline', 10, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (37, 2, NULL, N'Static Text', 11, 0, 0, 2, N'HealthInsuranceId')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (38, 2, NULL, N'Static Text', 12, 0, 0, 2, N'HealthInsuranceDateExpired')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (39, 2, NULL, N'Static Text', 13, 0, 0, 2, N'ContactPerson')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (40, 2, NULL, N'Static Text', 14, 0, 0, 2, N'ContactPersonAddress')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (41, 2, NULL, N'Form Name', 15, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (42, 2, NULL, N'Datepicker', 16, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (43, 2, NULL, N'Select Basic', 17, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (44, 2, NULL, N'Select Basic', 18, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (45, 2, NULL, N'Text Input', 19, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (46, 2, NULL, N'Text Input', 20, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (47, 2, NULL, N'Text Input', 21, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (48, 2, NULL, N'Select Basic', 22, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (49, 2, NULL, N'Text Input', 23, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (50, 2, NULL, N'Datepicker', 24, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (51, 2, NULL, N'Multiple Radios', 25, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (52, 2, NULL, N'Text Input', 26, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (53, 2, NULL, N'Form Name', 27, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (54, 2, NULL, N'Text Area', 28, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (55, 2, NULL, N'Text Area', 29, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (56, 2, NULL, N'Text Area', 30, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (57, 2, NULL, N'Multiple Checkboxes Inline', 31, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (58, 2, NULL, N'Form Name', 32, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (59, 2, NULL, N'Text Area', 33, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (60, 2, NULL, N'Text Area', 34, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (61, 2, NULL, N'Multiple Checkboxes Inline', 35, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (62, 2, NULL, N'Form Name', 36, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (63, 2, NULL, N'Multiple Radios', 37, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (64, 2, NULL, N'Multiple Radios Inline', 38, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (65, 2, NULL, N'Text Input', 39, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (66, 2, NULL, N'Multiple Checkboxes', 40, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (67, 2, NULL, N'Text Area', 41, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (68, 2, NULL, N'Text Area', 42, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (69, 2, NULL, N'Form Name', 43, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (70, 2, NULL, N'Text Input', 44, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (71, 2, NULL, N'Form Name', 45, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (72, 2, NULL, N'Text Area', 46, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (73, 2, NULL, N'Text Area', 47, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (74, 2, NULL, N'Text Area', 49, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (75, 2, NULL, N'Form Name', 50, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (76, 2, NULL, N'Text Area', 51, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (77, 2, NULL, N'Text Area', 52, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (78, 2, NULL, N'Text Area', 53, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (79, 2, NULL, N'Text Area', 54, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (80, 2, NULL, N'Form Name', 55, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (81, 2, NULL, N'Text Input', 56, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (82, 2, NULL, N'Text Input', 57, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (83, 2, NULL, N'Text Input', 58, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (84, 2, NULL, N'Form Name', 59, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (85, 2, NULL, N'Text Area', 60, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (86, 2, NULL, N'Form Name', 61, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (87, 2, NULL, N'Text Area', 62, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (88, 2, NULL, N'Form Name', 63, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (89, 2, NULL, N'Form Name', 64, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (90, 2, NULL, N'Text Area', 65, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (91, 2, NULL, N'Form Name', 66, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (92, 2, NULL, N'Text Area', 67, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (93, 2, NULL, N'Form Name', 68, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (94, 2, NULL, N'Text Area', 69, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (95, 2, NULL, N'Form Name', 70, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (96, 2, NULL, N'Text Area', 71, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (97, 2, NULL, N'Form Name', 72, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (98, 2, NULL, N'Text Area', 73, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (122, 2, N'Xây dựng bảng', N'Table', 48, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (123, 2, N'Ô nhập liệu', N'Text Input', 74, 47, 0, 0, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (124, 2, N'Ô nhập liệu', N'Text Input', 75, 47, 6, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (125, 2, N'Ô nhập liệu', N'Text Input', 76, 47, 12, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (126, 2, N'Tùy chọn kép hàng ngang', N'Multiple Checkboxes Inline', 77, 47, 1, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (127, 2, N'Tùy chọn kép hàng ngang', N'Multiple Checkboxes Inline', 78, 47, 7, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (128, 2, N'Tùy chọn kép hàng ngang', N'Multiple Checkboxes Inline', 79, 47, 13, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (129, 2, N'Ô nhập liệu', N'Text Input', 80, 47, 2, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (130, 2, N'Ô nhập liệu', N'Text Input', 81, 47, 8, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (131, 2, N'Ô nhập liệu', N'Text Input', 82, 47, 14, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (132, 2, N'Ô nhập liệu', N'Text Input', 83, 47, 3, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (133, 2, N'Ô nhập liệu', N'Text Input', 84, 47, 9, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (134, 2, N'Ô nhập liệu', N'Text Input', 85, 47, 15, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (135, 2, N'Tùy chọn kép hàng ngang', N'Multiple Checkboxes Inline', 86, 47, 4, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (136, 2, N'Tùy chọn kép hàng ngang', N'Multiple Checkboxes Inline', 87, 47, 10, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (137, 2, N'Tùy chọn kép hàng ngang', N'Multiple Checkboxes Inline', 88, 47, 16, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (138, 2, N'Ô nhập liệu', N'Text Input', 89, 47, 5, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (139, 2, N'Ô nhập liệu', N'Text Input', 90, 47, 11, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (140, 2, N'Ô nhập liệu', N'Text Input', 91, 47, 17, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (141, 5, N'Khu vực', N'Form Name', 1, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (142, 5, N'Họ và tên', N'Static Text', 2, 0, 0, 1, N'FullName')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (143, 5, N'Giới tính', N'Static Text', 3, 0, 0, 1, N'Gender')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (144, 5, N'Tuổi', N'Static Text', 4, 0, 0, 1, N'Age')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (145, 5, N'Công việc', N'Static Text', 5, 0, 0, 2, N'Job')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (146, 5, N'Địa chỉ thường trú', N'Static Text', 6, 0, 0, 1, N'PrimaryAddress')
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (147, 5, N'Kiểu ngày tháng', N'Datepicker', 7, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (148, 5, N'Khu vực', N'Form Name', 10, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (149, 5, N'Ô nhập liệu', N'Text Input', 11, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (150, 5, N'Đoạn nhập liệu', N'Text Area', 12, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (151, 5, N'Ô nhập liệu', N'Text Input', 13, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (152, 5, N'Đoạn nhập liệu', N'Text Area', 14, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (153, 5, N'Khu vực', N'Form Name', 15, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (154, 5, N'Đoạn nhập liệu', N'Text Area', 16, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (155, 5, N'Ô nhập liệu', N'Text Input', 17, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (156, 5, N'Dị ứng', N'Form Name', 8, 0, 0, 0, NULL)
INSERT [dbo].[CustomSnippet] ([CustomSnippetId], [MedicalProfileTemplateId], [Name], [Title], [Position], [ParentId], [PositionInTable], [SnippetType], [SnippetFieldName]) VALUES (157, 5, N'Lịch sử khám bệnh', N'Form Name', 9, 0, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[CustomSnippet] OFF
/****** Object:  Table [dbo].[UserRole]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[UserRole] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserRole] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (2, 3)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (3, 3)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (4, 3)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (5, 3)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (6, 3)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (7, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (8, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (9, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (10, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (11, 2)
INSERT [dbo].[UserRole] ([UserId], [RoleId]) VALUES (12, 2)
/****** Object:  Table [dbo].[CustomSnippetField]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomSnippetField](
	[CustomSnippetFieldId] [int] IDENTITY(1,1) NOT NULL,
	[CustomSnippetId] [int] NOT NULL,
	[FieldId] [nvarchar](max) NULL,
	[FieldName] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[Label] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CustomSnippetField] PRIMARY KEY CLUSTERED 
(
	[CustomSnippetFieldId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CustomSnippetId] ON [dbo].[CustomSnippetField] 
(
	[CustomSnippetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomSnippetField] ON
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (1, 1, NULL, N'id', N'input', N'ID / Name', N'1', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (2, 1, NULL, N'name', N'input', N'Tên hiển thị', N'Hành chính', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (3, 1, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (4, 2, NULL, N'id', N'input', N'ID / Name', N'2', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (5, 2, NULL, N'name', N'input', N'Tên hiển thị', N'Họ và tên', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (6, 3, NULL, N'id', N'input', N'ID / Name', N'3', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (7, 3, NULL, N'name', N'input', N'Tên hiển thị', N'Giới tính', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (8, 4, NULL, N'id', N'input', N'ID / Name', N'4', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (9, 4, NULL, N'name', N'input', N'Tên hiển thị', N'Công việc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (10, 5, NULL, N'id', N'input', N'ID / Name', N'5', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (11, 5, NULL, N'name', N'input', N'Tên hiển thị', N'Dân tộc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (12, 6, NULL, N'id', N'input', N'ID / Name', N'6', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (13, 6, NULL, N'name', N'input', N'Tên hiển thị', N'Địa chỉ', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (14, 7, NULL, N'id', N'input', N'ID / Name', N'7', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (15, 7, NULL, N'label', N'input', N'Tên đối tượng', N'Vào viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (16, 7, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (17, 7, NULL, N'required', N'checkbox', N'Bắt buộc', N'True', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (18, 8, NULL, N'id', N'input', N'ID / Name', N'8', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (19, 8, NULL, N'name', N'input', N'Tên hiển thị', N'Chuyên môn', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (20, 8, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (21, 9, NULL, N'id', N'input', N'ID / Name', N'9', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (22, 9, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (23, 9, NULL, N'label', N'input', N'Tên đối tượng', N'Lí do vào viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (24, 9, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (25, 9, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhập lí do...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (26, 9, NULL, N'required', N'checkbox', N'Bắt buộc', N'True', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (27, 10, NULL, N'id', N'input', N'ID / Name', N'10', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (28, 10, NULL, N'label', N'input', N'Tên đối tượng', N'Bệnh sử', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (29, 10, NULL, N'numofline', N'input', N'Số dòng', N'10', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (30, 10, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (31, 10, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Quá trình mắc bệnh...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (32, 10, NULL, N'required', N'checkbox', N'Bắt buộc', N'True', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (33, 11, NULL, N'id', N'input', N'ID / Name', N'11', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (34, 11, NULL, N'name', N'input', N'Tên hiển thị', N'Tiền sử', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (35, 11, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (36, 12, NULL, N'id', N'input', N'ID / Name', N'12', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (37, 12, NULL, N'label', N'input', N'Tên đối tượng', N'Bản thân', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (38, 12, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (39, 12, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (40, 12, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (41, 12, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (42, 13, NULL, N'id', N'input', N'ID / Name', N'13', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (43, 13, NULL, N'label', N'input', N'Tên đối tượng', N'Gia đình', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (44, 13, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (45, 13, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (46, 13, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (47, 13, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (48, 14, NULL, N'id', N'input', N'ID / Name', N'14', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (49, 14, NULL, N'name', N'input', N'Tên hiển thị', N'Thăm khám', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (50, 14, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (51, 15, NULL, N'id', N'input', N'ID / Name', N'15', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (52, 15, NULL, N'label', N'input', N'Tên đối tượng', N'Toàn thân', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (53, 15, NULL, N'numofline', N'input', N'Số dòng', N'10', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (54, 15, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (55, 15, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (56, 15, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (57, 16, NULL, N'id', N'input', N'ID / Name', N'16', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (58, 16, NULL, N'name', N'input', N'Tên hiển thị', N'Tóm tắt bệnh án', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (59, 16, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (60, 17, NULL, N'id', N'input', N'ID / Name', N'17', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (61, 17, NULL, N'label', N'input', N'Tên đối tượng', N'Triệu chứng, hội chứng', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (62, 17, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (63, 17, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (64, 17, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (65, 17, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (66, 18, NULL, N'id', N'input', N'ID / Name', N'18', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (67, 18, NULL, N'label', N'input', N'Tên đối tượng', N'Chẩn đoán', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (68, 18, NULL, N'numofline', N'input', N'Số dòng', N'4', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (69, 18, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (70, 18, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (71, 18, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (72, 19, NULL, N'id', N'input', N'ID / Name', N'19', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (73, 19, NULL, N'label', N'input', N'Tên đối tượng', N'Biện luận chẩn đoán', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (74, 19, NULL, N'numofline', N'input', N'Số dòng', N'4', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (75, 19, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (76, 19, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (77, 19, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (78, 20, NULL, N'id', N'input', N'ID / Name', N'20', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (79, 20, NULL, N'name', N'input', N'Tên hiển thị', N'Điều trị', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (80, 20, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (81, 21, NULL, N'id', N'input', N'ID / Name', N'21', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (82, 21, NULL, N'label', N'input', N'Tên đối tượng', N'Nguyên tắc', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (83, 21, NULL, N'numofline', N'input', N'Số dòng', N'4', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (84, 21, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (85, 21, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (86, 21, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (87, 22, NULL, N'id', N'input', N'ID / Name', N'22', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (88, 22, NULL, N'label', N'input', N'Tên đối tượng', N'Cụ thể', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (89, 22, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (90, 22, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (91, 22, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (92, 22, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (93, 23, NULL, N'id', N'input', N'ID / Name', N'23', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (94, 23, NULL, N'name', N'input', N'Tên hiển thị', N'Tiên lượng', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (95, 23, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (96, 24, NULL, N'id', N'input', N'ID / Name', N'24', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (97, 24, NULL, N'label', N'input', N'Tên đối tượng', N'Gần', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (98, 24, NULL, N'numofline', N'input', N'Số dòng', N'2', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (99, 24, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (100, 24, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
GO
print 'Processed 100 total records'
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (101, 24, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (102, 25, NULL, N'id', N'input', N'ID / Name', N'25', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (103, 25, NULL, N'label', N'input', N'Tên đối tượng', N'Xa', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (104, 25, NULL, N'numofline', N'input', N'Số dòng', N'2', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (105, 25, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (106, 25, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (107, 25, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (108, 26, NULL, N'id', N'input', N'ID / Name', N'26', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (109, 26, NULL, N'label', N'input', N'Tên đối tượng', N'Dự phòng', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (110, 26, NULL, N'numofline', N'input', N'Số dòng', N'3', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (111, 26, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (112, 26, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (113, 26, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (114, 27, NULL, N'id', N'input', N'ID / Name', N'27', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (115, 27, NULL, N'name', N'input', N'Tên hiển thị', N'Hành chính', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (116, 27, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (117, 28, NULL, N'id', N'input', N'ID / Name', N'28', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (118, 28, NULL, N'name', N'input', N'Tên hiển thị', N'Họ và tên', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (119, 29, NULL, N'id', N'input', N'ID / Name', N'29', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (120, 29, NULL, N'name', N'input', N'Tên hiển thị', N'Ngày sinh', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (121, 30, NULL, N'id', N'input', N'ID / Name', N'30', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (122, 30, NULL, N'name', N'input', N'Tên hiển thị', N'Giới', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (123, 31, NULL, N'id', N'input', N'ID / Name', N'31', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (124, 31, NULL, N'name', N'input', N'Tên hiển thị', N'Nghề nghiệp', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (125, 32, NULL, N'id', N'input', N'ID / Name', N'32', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (126, 32, NULL, N'name', N'input', N'Tên hiển thị', N'Dân tộc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (127, 33, NULL, N'id', N'input', N'ID / Name', N'33', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (128, 33, NULL, N'name', N'input', N'Tên hiển thị', N'Ngoại kiều', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (129, 34, NULL, N'id', N'input', N'ID / Name', N'34', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (130, 34, NULL, N'name', N'input', N'Tên hiển thị', N'Địa chỉ', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (131, 35, NULL, N'id', N'input', N'ID / Name', N'35', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (132, 35, NULL, N'name', N'input', N'Tên hiển thị', N'Nơi làm việc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (133, 36, NULL, N'id', N'input', N'ID / Name', N'36', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (134, 36, NULL, N'label', N'input', N'Tên đối tượng', N'Đối tượng', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (135, 36, NULL, N'radios', N'textarea-split', N'Các tùy chọn', N'[
  "Bảo hiểm Y Tế",
  "Thu phí",
  "Miễn"
]', N'radios')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (136, 37, NULL, N'id', N'input', N'ID / Name', N'37', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (137, 37, NULL, N'name', N'input', N'Tên hiển thị', N'Số thẻ bảo hiểm y tế', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (138, 38, NULL, N'id', N'input', N'ID / Name', N'38', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (139, 38, NULL, N'name', N'input', N'Tên hiển thị', N'Ngày hết hạn', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (140, 39, NULL, N'id', N'input', N'ID / Name', N'39', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (141, 39, NULL, N'name', N'input', N'Tên hiển thị', N'Người liên lạc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (142, 40, NULL, N'id', N'input', N'ID / Name', N'40', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (143, 40, NULL, N'name', N'input', N'Tên hiển thị', N'Địa chỉ người liên lạc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (144, 41, NULL, N'id', N'input', N'ID / Name', N'41', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (145, 41, NULL, N'name', N'input', N'Tên hiển thị', N'Quản lí người bệnh', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (146, 41, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (147, 42, NULL, N'id', N'input', N'ID / Name', N'42', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (148, 42, NULL, N'label', N'input', N'Tên đối tượng', N'Ngày vào viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (149, 42, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (150, 42, NULL, N'required', N'checkbox', N'Bắt buộc', N'True', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (151, 43, NULL, N'id', N'input', N'ID / Name', N'43', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (152, 43, NULL, N'label', N'input', N'Tên đối tượng', N'Trực tiếp vào', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (153, 43, NULL, N'options', N'textarea-split', N'Options', N'[
  "Cấp cứu",
  "Khám chữa bệnh",
  "Khoa điều trị"
]', N'options')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (154, 43, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (155, 44, NULL, N'id', N'input', N'ID / Name', N'44', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (156, 44, NULL, N'label', N'input', N'Tên đối tượng', N'Nơi giới thiệu', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (157, 44, NULL, N'options', N'textarea-split', N'Options', N'[
  "Cơ quan y tế",
  "Tự đến",
  "Khác"
]', N'options')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (158, 44, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (159, 45, NULL, N'id', N'input', N'ID / Name', N'45', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (160, 45, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (161, 45, NULL, N'label', N'input', N'Tên đối tượng', N'Vào khoa', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (162, 45, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'Tên Khoa  Ngày..Tháng...Năm...  Giờ...Phút...', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (163, 45, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (164, 45, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (165, 46, NULL, N'id', N'input', N'ID / Name', N'46', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (166, 46, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (167, 46, NULL, N'label', N'input', N'Tên đối tượng', N'Chuyển khoa', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (168, 46, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'Tên Khoa  Ngày..Tháng...Năm...  Giờ...Phút...', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (169, 46, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (170, 46, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (171, 47, NULL, N'id', N'input', N'ID / Name', N'47', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (172, 47, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (173, 47, NULL, N'label', N'input', N'Tên đối tượng', N'Chuyển khoa', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (174, 47, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'Tên Khoa  Ngày..Tháng...Năm...  Giờ...Phút...', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (175, 47, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (176, 47, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (177, 48, NULL, N'id', N'input', N'ID / Name', N'48', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (178, 48, NULL, N'label', N'input', N'Tên đối tượng', N'Chuyển viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (179, 48, NULL, N'options', N'textarea-split', N'Options', N'[
  "Tuyến trên",
  "Tuyến dưới",
  "Chuyên khoa"
]', N'options')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (180, 48, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (181, 49, NULL, N'id', N'input', N'ID / Name', N'49', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (182, 49, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (183, 49, NULL, N'label', N'input', N'Tên đối tượng', N'Chuyển đến', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (184, 49, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (185, 49, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhập nơi chuyển đến', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (186, 49, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (187, 50, NULL, N'id', N'input', N'ID / Name', N'50', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (188, 50, NULL, N'label', N'input', N'Tên đối tượng', N'Ngày ra viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (189, 50, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (190, 50, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (191, 51, NULL, N'id', N'input', N'ID / Name', N'51', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (192, 51, NULL, N'label', N'input', N'Tên đối tượng', N'Ra viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (193, 51, NULL, N'radios', N'textarea-split', N'Các tùy chọn', N'[
  "Ra viện",
  "Xin về",
  "Bỏ về",
  "Đưa về"
]', N'radios')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (194, 52, NULL, N'id', N'input', N'ID / Name', N'52', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (195, 52, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (196, 52, NULL, N'label', N'input', N'Tên đối tượng', N'Số ngày điều trị', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (197, 52, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (198, 52, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhập số...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (199, 52, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (200, 53, NULL, N'id', N'input', N'ID / Name', N'53', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (201, 53, NULL, N'name', N'input', N'Tên hiển thị', N'Chẩn đoán', N'name')
GO
print 'Processed 200 total records'
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (202, 53, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (203, 54, NULL, N'id', N'input', N'ID / Name', N'54', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (204, 54, NULL, N'label', N'input', N'Tên đối tượng', N'Nơi chuyển đến', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (205, 54, NULL, N'numofline', N'input', N'Số dòng', N'6', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (206, 54, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (207, 54, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (208, 54, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (209, 55, NULL, N'id', N'input', N'ID / Name', N'55', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (210, 55, NULL, N'label', N'input', N'Tên đối tượng', N'Khám chữa bệnh, cấp cứu', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (211, 55, NULL, N'numofline', N'input', N'Số dòng', N'6', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (212, 55, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (213, 55, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (214, 55, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (215, 56, NULL, N'id', N'input', N'ID / Name', N'56', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (216, 56, NULL, N'label', N'input', N'Tên đối tượng', N'Khi vào khoa điều trị', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (217, 56, NULL, N'numofline', N'input', N'Số dòng', N'6', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (218, 56, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (219, 56, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (220, 56, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (221, 57, NULL, N'id', N'input', N'ID / Name', N'57', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (222, 57, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (223, 57, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Thủ thuật",
  "Phẩu thuật"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (224, 58, NULL, N'id', N'input', N'ID / Name', N'58', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (225, 58, NULL, N'name', N'input', N'Tên hiển thị', N'Ra viện', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (226, 58, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (227, 59, NULL, N'id', N'input', N'ID / Name', N'59', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (228, 59, NULL, N'label', N'input', N'Tên đối tượng', N'Bệnh chính', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (229, 59, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (230, 59, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (231, 59, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (232, 59, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (233, 60, NULL, N'id', N'input', N'ID / Name', N'60', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (234, 60, NULL, N'label', N'input', N'Tên đối tượng', N'Bệnh kèm theo', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (235, 60, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (236, 60, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (237, 60, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (238, 60, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (239, 61, NULL, N'id', N'input', N'ID / Name', N'61', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (240, 61, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (241, 61, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Tai biến",
  "Biến chứng"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (242, 62, NULL, N'id', N'input', N'ID / Name', N'62', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (243, 62, NULL, N'name', N'input', N'Tên hiển thị', N'Tình trạng ra viện', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (244, 62, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (245, 63, NULL, N'id', N'input', N'ID / Name', N'63', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (246, 63, NULL, N'label', N'input', N'Tên đối tượng', N'Kết quả điều trị', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (247, 63, NULL, N'radios', N'textarea-split', N'Các tùy chọn', N'[
  "Khỏi",
  "Đỡ, giảm",
  "Không thay đổi",
  "Nặng hơn",
  "Tử vong"
]', N'radios')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (248, 64, NULL, N'id', N'input', N'ID / Name', N'64', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (249, 64, NULL, N'label', N'input', N'Tên đối tượng', N'Giải phẫu bệnh', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (250, 64, NULL, N'radios', N'textarea-split', N'Các tùy chọn', N'[
  "Lành tính",
  "Nghi ngờ",
  "Ác tính"
]', N'radios')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (251, 65, NULL, N'id', N'input', N'ID / Name', N'65', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (252, 65, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (253, 65, NULL, N'label', N'input', N'Tên đối tượng', N'Tình hình tử vong', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (254, 65, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'...giờ...phút          ngày...tháng...năm', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (255, 65, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (256, 65, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (257, 66, NULL, N'id', N'input', N'ID / Name', N'66', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (258, 66, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (259, 66, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Do bệnh",
  "Do tai biến điều trị",
  "Khác",
  "Trong 24h vào viện",
  "Sau 24h vào viện"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (260, 67, NULL, N'id', N'input', N'ID / Name', N'67', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (261, 67, NULL, N'label', N'input', N'Tên đối tượng', N'Nguyên nhân chính tử vong', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (262, 67, NULL, N'numofline', N'input', N'Số dòng', N'3', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (263, 67, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (264, 67, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nguyên nhân', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (265, 67, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (266, 68, NULL, N'id', N'input', N'ID / Name', N'68', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (267, 68, NULL, N'label', N'input', N'Tên đối tượng', N'Chẩn đoán giải phẫu tử thi', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (268, 68, NULL, N'numofline', N'input', N'Số dòng', N'3', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (269, 68, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (270, 68, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (271, 68, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (272, 69, NULL, N'id', N'input', N'ID / Name', N'69', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (273, 69, NULL, N'name', N'input', N'Tên hiển thị', N'A. Bệnh án', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (274, 69, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (275, 70, NULL, N'id', N'input', N'ID / Name', N'70', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (276, 70, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (277, 70, NULL, N'label', N'input', N'Tên đối tượng', N'Lí do vào viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (278, 70, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (279, 70, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (280, 70, NULL, N'required', N'checkbox', N'Bắt buộc', N'True', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (281, 71, NULL, N'id', N'input', N'ID / Name', N'71', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (282, 71, NULL, N'name', N'input', N'Tên hiển thị', N'1. Hỏi bệnh', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (283, 71, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (284, 72, NULL, N'id', N'input', N'ID / Name', N'72', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (285, 72, NULL, N'label', N'input', N'Tên đối tượng', N'Quá trình bệnh lý', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (286, 72, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (287, 72, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (288, 72, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Phát triển thể lực từ nhỏ đến lớn, những bệnh đã mắc, phương pháp ĐTr, tiêm phòng, ăn uống, sinh hoạt  vv...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (289, 72, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (290, 73, NULL, N'id', N'input', N'ID / Name', N'73', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (291, 73, NULL, N'label', N'input', N'Tên đối tượng', N'Tiền sử bệnh bản thân', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (292, 73, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (293, 73, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (294, 73, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (295, 73, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (296, 74, NULL, N'id', N'input', N'ID / Name', N'74', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (297, 74, NULL, N'label', N'input', N'Tên đối tượng', N'Tiền sử bệnh gia đình', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (298, 74, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (299, 74, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (300, 74, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Những người trong gia đình:  bệnh đã mắc, đời sống, tinh thần, vật chất v.v...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (301, 74, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (302, 75, NULL, N'id', N'input', N'ID / Name', N'75', NULL)
GO
print 'Processed 300 total records'
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (303, 75, NULL, N'name', N'input', N'Tên hiển thị', N'2. Khám bệnh', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (304, 75, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (305, 76, NULL, N'id', N'input', N'ID / Name', N'76', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (306, 76, NULL, N'label', N'input', N'Tên đối tượng', N'Toàn thân', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (307, 76, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (308, 76, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (309, 76, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Ý thức, da niêm mạc, hệ thống hạch, tuyến giáp, vị trí, kích thước, số lượng, di động v.v...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (310, 76, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (311, 77, NULL, N'id', N'input', N'ID / Name', N'77', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (312, 77, NULL, N'label', N'input', N'Tên đối tượng', N'Các cơ quan', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (313, 77, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (314, 77, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (315, 77, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (316, 77, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (317, 78, NULL, N'id', N'input', N'ID / Name', N'78', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (318, 78, NULL, N'label', N'input', N'Tên đối tượng', N'Các xét nghiệm cận lâm sàn cần làm', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (319, 78, NULL, N'numofline', N'input', N'Số dòng', N'3', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (320, 78, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (321, 78, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (322, 78, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (323, 79, NULL, N'id', N'input', N'ID / Name', N'79', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (324, 79, NULL, N'label', N'input', N'Tên đối tượng', N'Tóm tắt bệnh án', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (325, 79, NULL, N'numofline', N'input', N'Số dòng', N'6', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (326, 79, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (327, 79, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (328, 79, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (329, 80, NULL, N'id', N'input', N'ID / Name', N'80', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (330, 80, NULL, N'name', N'input', N'Tên hiển thị', N'3.Chẩn đoán khi vào khoa điều trị', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (331, 80, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (332, 81, NULL, N'id', N'input', N'ID / Name', N'81', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (333, 81, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (334, 81, NULL, N'label', N'input', N'Tên đối tượng', N'Bệnh chính', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (335, 81, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (336, 81, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Bệnh chính...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (337, 81, NULL, N'required', N'checkbox', N'Bắt buộc', N'True', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (338, 82, NULL, N'id', N'input', N'ID / Name', N'82', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (339, 82, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (340, 82, NULL, N'label', N'input', N'Tên đối tượng', N'Bệnh kèm theo', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (341, 82, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (342, 82, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Bệnh kèm theo (nếu có)...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (343, 82, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (344, 83, NULL, N'id', N'input', N'ID / Name', N'83', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (345, 83, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (346, 83, NULL, N'label', N'input', N'Tên đối tượng', N'Phân biệt', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (347, 83, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (348, 83, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Phân biệt...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (349, 83, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (350, 84, NULL, N'id', N'input', N'ID / Name', N'84', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (351, 84, NULL, N'name', N'input', N'Tên hiển thị', N'4. Tiên lượng', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (352, 84, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (353, 85, NULL, N'id', N'input', N'ID / Name', N'85', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (354, 85, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (355, 85, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (356, 85, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (357, 85, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tiên lượng...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (358, 85, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (359, 86, NULL, N'id', N'input', N'ID / Name', N'86', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (360, 86, NULL, N'name', N'input', N'Tên hiển thị', N'5. Hướng điều trị', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (361, 86, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (362, 87, NULL, N'id', N'input', N'ID / Name', N'87', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (363, 87, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (364, 87, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (365, 87, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (366, 87, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Hướng điều trị...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (367, 87, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (368, 88, NULL, N'id', N'input', N'ID / Name', N'88', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (369, 88, NULL, N'name', N'input', N'Tên hiển thị', N'B. Tổng kết bệnh án', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (370, 88, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (371, 89, NULL, N'id', N'input', N'ID / Name', N'89', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (372, 89, NULL, N'name', N'input', N'Tên hiển thị', N'1. Quá trình bệnh lí và diễn biến lâm sàn', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (373, 89, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (374, 90, NULL, N'id', N'input', N'ID / Name', N'90', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (375, 90, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (376, 90, NULL, N'numofline', N'input', N'Số dòng', N'7', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (377, 90, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (378, 90, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (379, 90, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (380, 91, NULL, N'id', N'input', N'ID / Name', N'91', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (381, 91, NULL, N'name', N'input', N'Tên hiển thị', N'2. Tóm tắt kết quả xét nghiệm cận lâm sàng có giá trị chẩn đoán', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (382, 91, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (383, 92, NULL, N'id', N'input', N'ID / Name', N'92', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (384, 92, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (385, 92, NULL, N'numofline', N'input', N'Số dòng', N'7', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (386, 92, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (387, 92, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (388, 92, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (389, 93, NULL, N'id', N'input', N'ID / Name', N'93', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (390, 93, NULL, N'name', N'input', N'Tên hiển thị', N'3. Phương pháp điều trị', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (391, 93, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (392, 94, NULL, N'id', N'input', N'ID / Name', N'94', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (393, 94, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (394, 94, NULL, N'numofline', N'input', N'Số dòng', N'7', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (395, 94, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (396, 94, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (397, 94, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (398, 95, NULL, N'id', N'input', N'ID / Name', N'95', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (399, 95, NULL, N'name', N'input', N'Tên hiển thị', N'4. Tình trạng người bệnh ra viện', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (400, 95, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (401, 96, NULL, N'id', N'input', N'ID / Name', N'96', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (402, 96, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (403, 96, NULL, N'numofline', N'input', N'Số dòng', N'7', N'numofline')
GO
print 'Processed 400 total records'
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (404, 96, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (405, 96, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (406, 96, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (407, 97, NULL, N'id', N'input', N'ID / Name', N'97', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (408, 97, NULL, N'name', N'input', N'Tên hiển thị', N'5. Hướng điều trị và các chế độ tiếp theo', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (409, 97, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (410, 98, NULL, N'id', N'input', N'ID / Name', N'98', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (411, 98, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (412, 98, NULL, N'numofline', N'input', N'Số dòng', N'7', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (413, 98, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (414, 98, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (415, 98, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (517, 122, NULL, N'id', N'input', N'ID / Name', N'122', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (518, 122, NULL, N'columns', N'textarea-split', N'Danh sách cột', N'[
  "Thứ tự",
  "Ký hiệu",
  "Thời gian",
  "Thứ tự",
  "Ký hiệu",
  "Thời gian"
]', N'columns')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (519, 122, NULL, N'numofrows', N'input', N'Số dòng', N'3', N'numofrows')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (520, 122, NULL, N'label', N'input', N'Tên đối tượng', N'Đặc điểm liên quan bệnh', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (521, 123, NULL, N'id', N'input', N'ID / Name', N'123', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (522, 123, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (523, 123, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (524, 123, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'01', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (525, 123, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (526, 123, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (527, 124, NULL, N'id', N'input', N'ID / Name', N'124', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (528, 124, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (529, 124, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (530, 124, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'02', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (531, 124, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (532, 124, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (533, 125, NULL, N'id', N'input', N'ID / Name', N'125', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (534, 125, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (535, 125, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (536, 125, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'03', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (537, 125, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (538, 125, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (539, 126, NULL, N'id', N'input', N'ID / Name', N'126', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (540, 126, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (541, 126, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Dị ứng"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (542, 127, NULL, N'id', N'input', N'ID / Name', N'127', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (543, 127, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (544, 127, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Ma túy"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (545, 128, NULL, N'id', N'input', N'ID / Name', N'128', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (546, 128, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (547, 128, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Rượu bia"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (548, 129, NULL, N'id', N'input', N'ID / Name', N'129', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (549, 129, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (550, 129, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (551, 129, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (552, 129, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tính theo tháng', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (553, 129, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (554, 130, NULL, N'id', N'input', N'ID / Name', N'130', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (555, 130, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (556, 130, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (557, 130, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (558, 130, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tính theo tháng', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (559, 130, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (560, 131, NULL, N'id', N'input', N'ID / Name', N'131', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (561, 131, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (562, 131, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (563, 131, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (564, 131, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tính theo tháng', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (565, 131, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (566, 132, NULL, N'id', N'input', N'ID / Name', N'132', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (567, 132, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (568, 132, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (569, 132, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'04', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (570, 132, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (571, 132, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (572, 133, NULL, N'id', N'input', N'ID / Name', N'133', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (573, 133, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (574, 133, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (575, 133, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'05', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (576, 133, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (577, 133, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (578, 134, NULL, N'id', N'input', N'ID / Name', N'134', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (579, 134, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": true,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (580, 134, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (581, 134, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'06', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (582, 134, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Nhắc nhở...', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (583, 134, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (584, 135, NULL, N'id', N'input', N'ID / Name', N'135', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (585, 135, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (586, 135, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Thuốc lá"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (587, 136, NULL, N'id', N'input', N'ID / Name', N'136', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (588, 136, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (589, 136, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Thuốc lào"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (590, 137, NULL, N'id', N'input', N'ID / Name', N'137', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (591, 137, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (592, 137, NULL, N'checkboxes', N'textarea-split', N'Các tùy chọn', N'[
  "Khác"
]', N'checkboxes')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (593, 138, NULL, N'id', N'input', N'ID / Name', N'138', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (594, 138, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (595, 138, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (596, 138, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (597, 138, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tính theo tháng', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (598, 138, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (599, 139, NULL, N'id', N'input', N'ID / Name', N'139', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (600, 139, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (601, 139, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (602, 139, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (603, 139, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tính theo tháng', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (604, 139, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (605, 140, NULL, N'id', N'input', N'ID / Name', N'140', NULL)
GO
print 'Processed 500 total records'
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (606, 140, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (607, 140, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (608, 140, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (609, 140, NULL, N'placeholder', N'input', N'Nhắc nhở', N'Tính theo tháng', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (610, 140, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (611, 141, NULL, N'id', N'input', N'ID / Name', N'141', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (612, 141, NULL, N'name', N'input', N'Tên hiển thị', N'I. Hành Chính', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (613, 141, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (614, 142, NULL, N'id', N'input', N'ID / Name', N'142', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (615, 142, NULL, N'name', N'input', N'Tên hiển thị', N'Họ và tên', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (616, 143, NULL, N'id', N'input', N'ID / Name', N'143', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (617, 143, NULL, N'name', N'input', N'Tên hiển thị', N'Giới tính', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (618, 144, NULL, N'id', N'input', N'ID / Name', N'144', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (619, 144, NULL, N'name', N'input', N'Tên hiển thị', N'Tuổi', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (620, 144, NULL, N'mappingtype', N'select', N'Cách liên kết', N'[
  {
    "label": "Lấy trực tiếp",
    "value": "Direct",
    "selected": false
  },
  {
    "label": "Sao chép",
    "value": "Copy",
    "selected": true
  }
]', N'mappingtype')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (621, 144, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "label": "Nhỏ",
    "value": "col-md-2",
    "selected": false
  },
  {
    "label": "Trung bình",
    "value": "col-md-4",
    "selected": false
  },
  {
    "label": "Lớn",
    "value": "col-md-8",
    "selected": true
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (622, 144, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (623, 145, NULL, N'id', N'input', N'ID / Name', N'145', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (624, 145, NULL, N'name', N'input', N'Tên hiển thị', N'Công việc', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (625, 146, NULL, N'id', N'input', N'ID / Name', N'146', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (626, 146, NULL, N'name', N'input', N'Tên hiển thị', N'Địa chỉ', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (627, 147, NULL, N'id', N'input', N'ID / Name', N'147', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (628, 147, NULL, N'label', N'input', N'Tên đối tượng', N'Vào viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (629, 147, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": true,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": false,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (630, 147, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (631, 148, NULL, N'id', N'input', N'ID / Name', N'148', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (632, 148, NULL, N'name', N'input', N'Tên hiển thị', N'IV. Chuyên môn', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (633, 148, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (634, 149, NULL, N'id', N'input', N'ID / Name', N'149', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (635, 149, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (636, 149, NULL, N'label', N'input', N'Tên đối tượng', N'Lí do vào viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (637, 149, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (638, 149, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (639, 149, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (640, 150, NULL, N'id', N'input', N'ID / Name', N'150', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (641, 150, NULL, N'label', N'input', N'Tên đối tượng', N'Bệnh sử', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (642, 150, NULL, N'numofline', N'input', N'Số dòng', N'5', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (643, 150, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (644, 150, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (645, 150, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (646, 151, NULL, N'id', N'input', N'ID / Name', N'151', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (647, 151, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (648, 151, NULL, N'label', N'input', N'Tên đối tượng', N'Tiền sử', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (649, 151, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (650, 151, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (651, 151, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (652, 152, NULL, N'id', N'input', N'ID / Name', N'152', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (653, 152, NULL, N'label', N'input', N'Tên đối tượng', N'Tình trạng lúc nhập viện', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (654, 152, NULL, N'numofline', N'input', N'Số dòng', N'3', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (655, 152, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (656, 152, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (657, 152, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (658, 153, NULL, N'id', N'input', N'ID / Name', N'153', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (659, 153, NULL, N'name', N'input', N'Tên hiển thị', N'V. Tóm tắt bệnh án', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (660, 153, NULL, N'mapping', N'input', N'Khu vực', N'', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (661, 154, NULL, N'id', N'input', N'ID / Name', N'154', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (662, 154, NULL, N'label', N'input', N'Tên đối tượng', N'', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (663, 154, NULL, N'numofline', N'input', N'Số dòng', N'4', N'numofline')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (664, 154, NULL, N'defaultvalue', N'textarea', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (665, 154, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (666, 154, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (667, 155, NULL, N'id', N'input', N'ID / Name', N'155', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (668, 155, NULL, N'inputsize', N'select', N'Kích thước', N'[
  {
    "value": "col-md-2",
    "selected": false,
    "label": "Nhỏ"
  },
  {
    "value": "col-md-4",
    "selected": false,
    "label": "Trung bình"
  },
  {
    "value": "col-md-8",
    "selected": true,
    "label": "Lớn"
  }
]', N'inputsize')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (669, 155, NULL, N'label', N'input', N'Tên đối tượng', N'Kết luận', N'label')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (670, 155, NULL, N'defaultvalue', N'input', N'Giá trị mặc định', N'', N'defaultvalue')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (671, 155, NULL, N'placeholder', N'input', N'Nhắc nhở', N'', N'placeholder')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (672, 155, NULL, N'required', N'checkbox', N'Bắt buộc', N'False', N'required')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (673, 156, NULL, N'id', N'input', N'ID / Name', N'156', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (674, 156, NULL, N'name', N'input', N'Tên hiển thị', N'II. Dị ứng', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (675, 156, NULL, N'mapping', N'input', N'Khu vực', N'AllergyRegion', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (676, 157, NULL, N'id', N'input', N'ID / Name', N'157', NULL)
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (677, 157, NULL, N'name', N'input', N'Tên hiển thị', N'III. Lịch sử khám bệnh', N'name')
INSERT [dbo].[CustomSnippetField] ([CustomSnippetFieldId], [CustomSnippetId], [FieldId], [FieldName], [Type], [Label], [Value], [Name]) VALUES (678, 157, NULL, N'mapping', N'input', N'Khu vực', N'TreatmentHistory', NULL)
SET IDENTITY_INSERT [dbo].[CustomSnippetField] OFF
/****** Object:  Table [dbo].[Conversation]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversation](
	[ConversationId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[LatestContentFromPatient] [nvarchar](max) NULL,
	[LatestContentFromDoctor] [nvarchar](max) NULL,
	[LatestTimeFromDoctor] [datetime] NOT NULL,
	[LatestTimeFromPatient] [datetime] NOT NULL,
	[IsDoctorRead] [bit] NOT NULL,
	[IsPatientRead] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Conversation] PRIMARY KEY CLUSTERED 
(
	[ConversationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DoctorId] ON [dbo].[Conversation] 
(
	[DoctorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[Conversation] 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Conversation] ON
INSERT [dbo].[Conversation] ([ConversationId], [PatientId], [DoctorId], [LatestContentFromPatient], [LatestContentFromDoctor], [LatestTimeFromDoctor], [LatestTimeFromPatient], [IsDoctorRead], [IsPatientRead]) VALUES (1, 7, 2, N'tôi có phải kiêng ăn gì không?', N'Tôi đã thêm chẩn đoán, đơn thuốc và chế độ ăn của chị, hẹn chị tái khám sau 7 ngày hoặc có triệu chứng nặng nề hơn.', CAST(0x0000A3AB000334FD AS DateTime), CAST(0x0000A3AB0002FD05 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[Conversation] OFF
/****** Object:  Table [dbo].[Comment]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[PostedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DoctorId] ON [dbo].[Comment] 
(
	[DoctorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[Comment] 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalHealthRecord]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalHealthRecord](
	[PatientId] [int] NOT NULL,
	[Height] [float] NOT NULL,
	[Weight] [float] NOT NULL,
	[EyeColor] [nvarchar](max) NULL,
	[HairColor] [nvarchar](max) NULL,
	[BloodType] [nvarchar](max) NULL,
	[AlcoholPerWeek] [float] NOT NULL,
	[AlcoholNumOfYear] [int] NOT NULL,
	[IsBeer] [bit] NOT NULL,
	[SmokePackPerWeek] [float] NOT NULL,
	[SmokeNumOfYear] [int] NOT NULL,
	[SportName] [nvarchar](max) NULL,
	[SportPerWeek] [int] NOT NULL,
	[ExerciseType] [nvarchar](max) NULL,
	[ExercisePerWeek] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PersonalHealthRecord] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[PersonalHealthRecord] 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[PersonalHealthRecord] ([PatientId], [Height], [Weight], [EyeColor], [HairColor], [BloodType], [AlcoholPerWeek], [AlcoholNumOfYear], [IsBeer], [SmokePackPerWeek], [SmokeNumOfYear], [SportName], [SportPerWeek], [ExerciseType], [ExercisePerWeek]) VALUES (7, 170, 70.5, N'Đen', N'Đen', N'B', 1.2, 4, 1, 1, 2, N'Đá banh', 4, N'Yoga', 2)
INSERT [dbo].[PersonalHealthRecord] ([PatientId], [Height], [Weight], [EyeColor], [HairColor], [BloodType], [AlcoholPerWeek], [AlcoholNumOfYear], [IsBeer], [SmokePackPerWeek], [SmokeNumOfYear], [SportName], [SportPerWeek], [ExerciseType], [ExercisePerWeek]) VALUES (8, 170, 70.5, N'Đen', N'Đen', N'B', 1.2, 4, 1, 1, 2, N'Đá banh', 4, N'Yoga', 2)
INSERT [dbo].[PersonalHealthRecord] ([PatientId], [Height], [Weight], [EyeColor], [HairColor], [BloodType], [AlcoholPerWeek], [AlcoholNumOfYear], [IsBeer], [SmokePackPerWeek], [SmokeNumOfYear], [SportName], [SportPerWeek], [ExerciseType], [ExercisePerWeek]) VALUES (9, 170, 70.5, N'Đen', N'Đen', N'B', 1.2, 4, 1, 1, 2, N'Đá banh', 4, N'Yoga', 2)
INSERT [dbo].[PersonalHealthRecord] ([PatientId], [Height], [Weight], [EyeColor], [HairColor], [BloodType], [AlcoholPerWeek], [AlcoholNumOfYear], [IsBeer], [SmokePackPerWeek], [SmokeNumOfYear], [SportName], [SportPerWeek], [ExerciseType], [ExercisePerWeek]) VALUES (10, 170, 70.5, N'Đen', N'Đen', N'B', 1.2, 4, 1, 1, 2, N'Cầu Lông', 4, N'Yoga', 2)
INSERT [dbo].[PersonalHealthRecord] ([PatientId], [Height], [Weight], [EyeColor], [HairColor], [BloodType], [AlcoholPerWeek], [AlcoholNumOfYear], [IsBeer], [SmokePackPerWeek], [SmokeNumOfYear], [SportName], [SportPerWeek], [ExerciseType], [ExercisePerWeek]) VALUES (11, 170, 70.5, N'Đen', N'Đen', N'B', 1.2, 4, 1, 1, 2, N'Cầu Lông', 4, N'Yoga', 2)
INSERT [dbo].[PersonalHealthRecord] ([PatientId], [Height], [Weight], [EyeColor], [HairColor], [BloodType], [AlcoholPerWeek], [AlcoholNumOfYear], [IsBeer], [SmokePackPerWeek], [SmokeNumOfYear], [SportName], [SportPerWeek], [ExerciseType], [ExercisePerWeek]) VALUES (12, 170, 70.5, N'Đen', N'Đen', N'B', 1.2, 4, 1, 1, 2, N'Cầu Lông', 4, N'Yoga', 2)
/****** Object:  Table [dbo].[MedicalProfile]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalProfile](
	[MedicalProfileId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[MedicalProfileKey] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[MedicalProfileTemplateId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.MedicalProfile] PRIMARY KEY CLUSTERED 
(
	[MedicalProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DoctorId] ON [dbo].[MedicalProfile] 
(
	[DoctorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileTemplateId] ON [dbo].[MedicalProfile] 
(
	[MedicalProfileTemplateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[MedicalProfile] 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MedicalProfile] ON
INSERT [dbo].[MedicalProfile] ([MedicalProfileId], [PatientId], [DoctorId], [MedicalProfileKey], [CreatedDate], [MedicalProfileTemplateId]) VALUES (1, 7, 2, N'OMCS.0000001.01', CAST(0x0000A3AA01153FA1 AS DateTime), 1)
INSERT [dbo].[MedicalProfile] ([MedicalProfileId], [PatientId], [DoctorId], [MedicalProfileKey], [CreatedDate], [MedicalProfileTemplateId]) VALUES (2, 8, 2, N'OMCS.0000002.02', CAST(0x0000A3A000000000 AS DateTime), 2)
INSERT [dbo].[MedicalProfile] ([MedicalProfileId], [PatientId], [DoctorId], [MedicalProfileKey], [CreatedDate], [MedicalProfileTemplateId]) VALUES (3, 8, 2, N'OMCS.0000001.03', CAST(0x0000A3A500000000 AS DateTime), 1)
INSERT [dbo].[MedicalProfile] ([MedicalProfileId], [PatientId], [DoctorId], [MedicalProfileKey], [CreatedDate], [MedicalProfileTemplateId]) VALUES (4, 7, 2, N'OMCS.0000001.03', CAST(0x0000A3A500000000 AS DateTime), 2)
INSERT [dbo].[MedicalProfile] ([MedicalProfileId], [PatientId], [DoctorId], [MedicalProfileKey], [CreatedDate], [MedicalProfileTemplateId]) VALUES (5, 7, 2, NULL, CAST(0x0000A3B701215E6A AS DateTime), 5)
SET IDENTITY_INSERT [dbo].[MedicalProfile] OFF
/****** Object:  Table [dbo].[Immunization]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Immunization](
	[ImmunizationId] [int] IDENTITY(1,1) NOT NULL,
	[MedicalProfileId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DateImmunized] [datetime] NOT NULL,
	[BoosterTime] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Immunization] PRIMARY KEY CLUSTERED 
(
	[ImmunizationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileId] ON [dbo].[Immunization] 
(
	[MedicalProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Immunization] ON
INSERT [dbo].[Immunization] ([ImmunizationId], [MedicalProfileId], [Name], [DateImmunized], [BoosterTime]) VALUES (1, 1, N'Sởi', CAST(0x0000838C00000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Immunization] OFF
/****** Object:  Table [dbo].[ConversationDetail]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConversationDetail](
	[ConversationDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ConversationId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[Attachment] [nvarchar](max) NULL,
	[IsRead] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.ConversationDetail] PRIMARY KEY CLUSTERED 
(
	[ConversationDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ConversationId] ON [dbo].[ConversationDetail] 
(
	[ConversationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[ConversationDetail] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ConversationDetail] ON
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (1, 1, 7, N'Chào bác sĩ. Tôi bị sốt 2,3 ngày nay.', NULL, 1, CAST(0x0000A3AB0002341D AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (2, 1, 2, N'sốt cao không, khoảng bao nhiêu độ?, thường sốt vào thời điểm cụ thể trong ngày hay bất kỳ lúc nào? Có kèm theo triệu chúng gì bất thường nữa không?', NULL, 1, CAST(0x0000A3AB00024DFE AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (3, 1, 7, N'sốt khoảng 39-40 độ, có lúc sốt buổi sáng, có lúc sốt buổi tối, trong người cảm thấy nhức mỏi mình mẩy, và ớn lạnh.', NULL, 1, CAST(0x0000A3AB00025A1A AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (4, 1, 2, N'có đau họng không?, nuốt nước bọt có đau không? Trên da có nổi nốt xuất huyết nào không?', NULL, 1, CAST(0x0000A3AB00026526 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (5, 1, 7, N'có đau họng, nuốt nước bọt có đau, nhưng mà không thấy nốt xuất huyết nào hết. mà có cả ho nữa', NULL, 1, CAST(0x0000A3AB00026FF0 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (6, 1, 2, N'ho khan thôi hay là ho có đờm?', NULL, 1, CAST(0x0000A3AB000277D6 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (7, 1, 7, N'ho khan thôi,', NULL, 1, CAST(0x0000A3AB00028007 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (8, 1, 2, N'có nhức đầu sổ mũi gì nữa không? Xung quanh có ai bị bệnh tương tự không? Mấy ngày gần đây có hay ngủ lạnh hay ướt mưa gì không?', NULL, 1, CAST(0x0000A3AB00028FD7 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (9, 1, 7, N'không nhức đầu, nhưng sổ mũi, tịt mũi. Trong nhà không có ai bị bệnh tương tự hết, 3 ngày trước có ngủ quạt nên mới bị đau họng.', NULL, 1, CAST(0x0000A3AB00029B6D AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (10, 1, 2, N'ở nhà đã uống thuốc gì chưa?', NULL, 1, CAST(0x0000A3AB0002A5C2 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (11, 1, 7, N'mới chỉ uống mấy viên paracetamol hạ sốt thôi?', NULL, 1, CAST(0x0000A3AB0002BA28 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (12, 1, 2, N'trước giờ uống thuốc có bị dị ứng với loại thuốc nào hay không? Hiện giờ có đang có thai, hay đang cho con bú hoặc mắc bệnh mãn tính gì không?', NULL, 1, CAST(0x0000A3AB0002C5C0 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (13, 1, 7, N'trước giờ tôi chưa từng dị ứng thuốc, nhưng hiện tại đang có thai được 6 tháng', NULL, 1, CAST(0x0000A3AB0002D581 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (14, 1, 2, N'được rồi tôi sẽ chuẩn đoán và cho thuốc', NULL, 1, CAST(0x0000A3AB0002EF78 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (15, 1, 7, N'tôi có phải kiêng ăn gì không?', NULL, 1, CAST(0x0000A3AB0002FD05 AS DateTime))
INSERT [dbo].[ConversationDetail] ([ConversationDetailId], [ConversationId], [UserId], [Content], [Attachment], [IsRead], [CreatedDate]) VALUES (16, 1, 2, N'Tôi đã thêm chẩn đoán, đơn thuốc và chế độ ăn của chị, hẹn chị tái khám sau 7 ngày hoặc có triệu chứng nặng nề hơn.', NULL, 1, CAST(0x0000A3AB000334FD AS DateTime))
SET IDENTITY_INSERT [dbo].[ConversationDetail] OFF
/****** Object:  Table [dbo].[Allergy]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergy](
	[AllergyId] [int] IDENTITY(1,1) NOT NULL,
	[MedicalProfileId] [int] NOT NULL,
	[AllergyTypeId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DateLastOccurred] [datetime] NOT NULL,
	[Reaction] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Allergy] PRIMARY KEY CLUSTERED 
(
	[AllergyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AllergyTypeId] ON [dbo].[Allergy] 
(
	[AllergyTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileId] ON [dbo].[Allergy] 
(
	[MedicalProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Allergy] ON
INSERT [dbo].[Allergy] ([AllergyId], [MedicalProfileId], [AllergyTypeId], [Name], [DateLastOccurred], [Reaction], [Note]) VALUES (1, 1, 1, N'Thuốc kháng sinh', CAST(0x0000A13900000000 AS DateTime), N'Đau bụng nhẹ', NULL)
INSERT [dbo].[Allergy] ([AllergyId], [MedicalProfileId], [AllergyTypeId], [Name], [DateLastOccurred], [Reaction], [Note]) VALUES (2, 5, 2, N'Hải sản', CAST(0x0000A3AF00000000 AS DateTime), N'Buồn nôn, chóng mặt', NULL)
SET IDENTITY_INSERT [dbo].[Allergy] OFF
/****** Object:  Table [dbo].[CustomSnippetValue]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomSnippetValue](
	[CustomSnippetValueId] [int] IDENTITY(1,1) NOT NULL,
	[CustomSnippetId] [int] NOT NULL,
	[MedicalProfileId] [int] NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.CustomSnippetValue] PRIMARY KEY CLUSTERED 
(
	[CustomSnippetValueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CustomSnippetId] ON [dbo].[CustomSnippetValue] 
(
	[CustomSnippetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileId] ON [dbo].[CustomSnippetValue] 
(
	[MedicalProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomSnippetValue] ON
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (209, 7, 1, N'09/06/2014')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (210, 9, 1, N'Khó thở ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (211, 10, 1, N'Bệnh khởi 3 ngày trước nhập viện với triệu chứng : hắt hơi, sổ mủi, ho khan từng cơn ( 8 – 10 cơn /ngày, # 30s/cơn). Khó thở, khò khè,khó khạc đờm , khạc được thì dễ thở. Sốt nhẹ ,môi khô, mệt mỏi nhiều, đau nhức vai gáy, sau đó khó thở hai thì , nhiều hơn ở thì thở ra. Khó thở liên tục, tăng khi vận động thể lực, có những cơn kịch phát, ngồi dậy dễ  thở hơn.Ở nhà có dùng thuốc ( medisolume 4mg, tocemuc 200mg, theophilin 100mg, midirel 20mg, thở khí dung), nhưng không đở khó thở nên xin nhập viện điều trị.
Vào khoa với tình trạng:  
Tỉnh tiếp xúc tốt.
Da niêm hồng 
Khó thở độ 3
Co kéo khoang gian sườn
Phổi ran rít, ran ngáy hai phế trường, rải rác ran ẩm 
Tim đều
Bụng mềm, gan lách không sờ đụng.
Dấu hiệu sinh tồn :
M: 80 lần/ phút
T: 370 C
HA: 160/90mmhg
NT: 24l/p
 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (212, 12, 1, N'-	Dị ứng thuốc không rõ loại.
-	Viêm phế quản mạn 9 năm điều trị liên tục, nhiều đợt ho khạc đàm trắng loãng kéo dài # 1 tuần / năm
-	Viêm dạ dày khoảng 5 năm điều trị không liên tục.
-	Hút thuốc lá thụ động trên 30 năm.
 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (213, 13, 1, N'Không ai mắc bệnh tương tự. 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (214, 15, 1, N'Tỉnh tiếp xúc tốt, tổng trạng mập BMI 23,94
Da niêm hồng
Không phù, nốt xuất huyết dưới da đầu gối phải
Hạch ngoại vi không to
Không ngón tay dùi trống, móng tay không khum, ít bóng, có khía
Lông tóc móng không gãy rụng nhiều hơn bình thường
DHST:
M: 80l/p
T: 38
HA: 130/80mmhg
NT: 20l/p
2.	Cơ quan:
a, Hô hấp:
-	Ho đờm khó khạc, thỉnh thoảng khạc đàm đặc màu vàng, ko hôi, # 10ml/ 24h
-	Khó thở khò khè nhẹ liên tục, chủ yếu thì thở ra, tăng khi gắng sức nhiều như lên xuống 1 tầng cầu thang
-	Co kéo hõm ức, khoang gian sườn
-	Lồng ngực hình thùng, KGS giãn rộng, di động đều theo nhịp thở
-	Gõ trong 2 phế trường
-	RRPN êm dịu 2 phế trường, rale ngáy + rít 2 phế trường, rale ẩm đáy phổi P
b. Tuần hoàn:
- Không đau tức ngực, không hồi hộp trống ngực
- TMC không nổi
- Harzer (–)
- Tim đều rõ trùng nhịp mạch
- T2 mạnh ở ổ vale ĐMP
- Chưa nghe tiếng tim bệnh lý khác
c. Tiêu hóa:
- Ăn uống được ,đại tiện bình thường
- Không buồn nôn, không nôn, không ợ hơi, ợ chua, không đau bụng
- Bụng mềm, không chướng, không u cục, không sẹo mổ cũ
- Ấn không đau
- Gan lách không sờ đụng
d. Tiết niệu – sinh dục:
- Không tiểu buốt rát, nước tiểu vàng trong # 1,5l/ 24h
- Không đau vùng hông lưng
- Cơ quan sinh dục ngoài không biến dạng , không sưng nóng rát
- Chạm thận , bập bềnh thận (-)
-Ấn điểm đau niệu quản (-)
e. Thần kinh
- Tỉnh táo, tiếp xúc tốt
- Mệt mỏi, không  có dấu hiệu thần kinh khu trú
f. Cơ quan khác: không phát hiện bệnh lý 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (215, 17, 1, N'1.	Hội chứng nhiễm trùng:
môi khô( đã hết), sốt 380C, BC: 12,9k/mm3, Neu: 84%, CRP(+)

2.	Hội chứng khí phế thủng:
khó thở 2 thì chủ yếu thì thở ra,co kéo kgs,co rút hõm ức, NT: 20l/p, lồng ngực hình thùng, khoang gian sườn giãn rộng, XQ: tăng sang 2 trường phổi, KGS giãn rộng, cơ hoành hạ thấp 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (216, 18, 1, N'Đợt cấp COPD mức độ trung bình  do VPQ mạn 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (217, 19, 1, N'- CĐ đợt cấp COPD Vì có các tiêu chuẩn: HC phế quản, HC khí phế thũng, T/S hút thuốc lá thụ động >30 năm,vpq mạn  9 năm, có thêm sốt nhẹ 38 độ, BC tăng, Neu tăng, đàm đặc thay đổi màu săc sang vàng #10ml/24h,Khó thở ngày càng tăng, điều trị khí dung không đỡ

- CĐ mức độ TB vì: tri giác , lời nói bình thường, nhịp thở bình thương 20l/p, có co kéo KGS và hõm ức , sốt, thay đổi màu sắc đàm trắng sang vàng, tăng số lượng đờm
BN chưa nghĩ đến suy tim phải trên lâm sang vì chưa có DH suy tim P. Tuy nhiên để chắc chắn xem có tâm phế mạn ko cần làm thêm các CLS sau: Siêu âm tim, ECG, Khí máu động mạch

- Khi nhập viện đo HA: 160/90mmHg đủ để chẩn đoán THA tuy nhiên ngày thứ 2 sau nhập viện không uống thuốc hạ áp đo được 130/80mmHg, BN ko có T/S THA trước đó, LS và CLS ko có dấu hiệu của THA nên nguyên nhân của triệu chứng này có thể là do thiếu O2 , tăng CO2 máu làm kích thích tăng tiết catecholamine  nên mạch nhanh, tăng cung lượng tim dẫn đến  tăng HA Gọi là THA trong bối cảnh suy hô hấp cấp

- CĐ phân biệt: 
Cơn hen PQ vì tiên lượng, điều trị và dự phòng khác nhau. Ko nghĩ đến HPQ ở BN này vì: BN lớn tuổi, khó thở liên tục, ko có T/S HPQ, T/S hút thuốc lá thụ động >30 năm, T/S VPQ mạn 9 năm, điều trị khí dung giãn phế quản ko đáp ứng. Tuy nhiên để phân biệt chắc chắn cần làm thêm CLS: ECG, FEV, FEV1, Test GPQ 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (218, 21, 1, N'- Giảm hút thuốc lá thụ động, tiếp xúc với môi trường kích thích
- Thuốc giãn PQ
- Kháng sinh
- Corticoid
 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (219, 22, 1, N'- Nghỉ ngơi tại giường, tránh hoạt động gắng sức
- Ăn uống hợp lý đủ chất
-Tập thở: hít sâu, thở bóng, hít thở bằng cơ hoành
- Cefixim 1,5g 2 lọ IV chia 2
- Berodual 
-Prednisolon 5mg 6 viên sang 4v, chiều 2v
-Salbutamol 2mg 1 viên
 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (220, 24, 1, N'BN đáp ứng với điều trị: hạ sốt, giảm ho, giảm đàm, đỡ khó thở tuy nhiên có thể tái phát  
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (221, 25, 1, N'Xấu, cần theo dõi để phát hiện biến chứng tâm phế mạn 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (222, 26, 1, N'- Hạn chế tiếp xúc khói thuốc lá, tránh môi trường ô nhiễm
- Tập thở
- Thể dục thường xuyên 
    ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (320, 1, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (321, 2, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (322, 3, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (323, 4, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (324, 5, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (325, 6, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (326, 8, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (327, 11, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (328, 14, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (329, 16, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (330, 20, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (331, 23, 1, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (332, 27, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (333, 28, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (334, 29, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (335, 30, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (336, 31, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (337, 32, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (338, 33, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (339, 34, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (340, 35, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (341, 36, 4, N'Bảo hiểm Y Tế')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (342, 37, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (343, 38, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (344, 39, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (345, 40, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (346, 41, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (347, 42, 4, N'07/07/2014')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (348, 43, 4, N'Khám chữa bệnh')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (349, 44, 4, N'Tự đến')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (350, 45, 4, N'Tâm thần  Ngày 07/07/2014  12h30ph ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (351, 46, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (352, 47, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (353, 48, 4, N'Tuyến trên')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (354, 49, 4, N'Bệnh viện Da Liễu ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (355, 50, 4, N'10/07/2014')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (356, 51, 4, N'Xin về')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (357, 52, 4, N'2 ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (358, 53, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (359, 54, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (360, 55, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (361, 56, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (362, 57, 4, N'Phẩu thuật')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (363, 58, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (364, 59, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (365, 60, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (366, 61, 4, N'Tai biến')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (367, 62, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (368, 63, 4, N'Nặng hơn')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (369, 64, 4, N'Nghi ngờ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (370, 65, 4, N'...giờ...phút          ngày...tháng...năm ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (371, 66, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (372, 67, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (373, 68, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (374, 69, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (375, 70, 4, N'Tai nạn giao thông ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (376, 71, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (377, 72, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (378, 73, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (379, 74, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (380, 75, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (381, 76, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (382, 77, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (383, 78, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (384, 79, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (385, 80, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (386, 81, 4, N'Chấn thương sọ não ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (387, 82, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (388, 83, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (389, 84, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (390, 85, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (391, 86, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (392, 87, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (393, 88, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (394, 89, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (395, 90, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (396, 91, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (397, 92, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (398, 93, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (399, 94, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (400, 95, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (401, 96, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (402, 97, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (403, 98, 4, N' ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (417, 122, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (418, 123, 4, N'01')
GO
print 'Processed 100 total records'
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (419, 124, 4, N'02')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (420, 125, 4, N'03')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (421, 126, 4, N'Dị ứng')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (422, 127, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (423, 128, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (424, 129, 4, N'2')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (425, 130, 4, N'')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (426, 131, 4, N'')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (427, 132, 4, N'04')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (428, 133, 4, N'05')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (429, 134, 4, N'06')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (430, 135, 4, N'Thuốc lá')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (431, 136, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (432, 137, 4, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (433, 138, 4, N'3 tuần')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (434, 139, 4, N'')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (435, 140, 4, N'')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (436, 141, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (437, 142, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (438, 143, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (439, 144, 5, N'22')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (440, 145, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (441, 146, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (442, 147, 5, N'02/09/2014')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (443, 148, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (444, 149, 5, N'Tai nạn giao thông')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (445, 150, 5, N'Cách nhập viện 1 giờ bệnh nhân đang chạy xe gắn máy có đội nón bảo hiểm với tốc độ khoảng 40km/h thì tự té. Trước đó bệnh nhân có uống rượu. Bệnh nhân té đập mặt, ngực và vùng thái dương phải đập xuống đường. Bệnh nhân bất tỉnh khoảng 30p. Sau đó tự tỉnh lại và thấy đau đầu nhiều ở vùng thái dương (P), không nôn ói, chảy máu nhiều ở vùng dưới cằm và được đưa đến bệnh viện đa khoa thành phố cần thơ.')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (446, 151, 5, N'Chưa ghi nhận bệnh lý nội, ngoại khoa')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (447, 152, 5, N'Đồng tử 2mm đều 2 bên, Glasgow = 13 (E3V4M6), đau tức ngực (T), bệnh nhân tỉnh, tiếp xúc được. Vết thương nham nhở 2x3 cm ở cằm dưới. Đau thái dương (P), máu chảy ra từ lỗ tai (P) khoảng 2 ml. Dấu hiệu sinh tồn: Mạch 90 l/ph
HA: 120/80 mmHg
Nhiệt độ: 37oC
Nhịp thở: 22 l/ph
 Revised trauma score: 7,841  Probability of Survival : 98%
5. Khám lâm sàng: lúc 22h ngày 6/3/2012 
a. Khám đầu mặt cổ:
Đánh giá lại Glasgow: 15 đ
- Bệnh tỉnh, da niêm hồng, bệnh nhân than cảm thấy ù tai bên (P)
- Đau vùng thái dương (P) liên tục nhưng mức độ có giảm so với khi vào viện, đau không lan
- Máu chảy ra từ tai phải lượng 2ml, màu đỏ sậm, theo bác sĩ trực thì nguyên nhân là do vỡ xương đá, bệnh nhân thấy hơi ù tai bên P, không có vết bầm ở vùng xương chũm
- Dưới cằm vết thương 2x3 cm nham nhở; đã được cắt lọc mô dập nát, rửa sạch vết thương và khâu kín.
b. Ngực:
- lồng ngực cân đối đều 2 bên, di động nhịp thở
- Xây xát nhẹ vùng xương đòn phải
- Rung thanh đều 2 bên
- Rì rào phế nang êm dịu
c. Tim:
Mỏm tim liên sườn V đường trung đòn trái
Nhịp 90l/ph, đều rõ, không âm thổi
d Bụng:
Di động theo nhịp thở
Vết bầm máu 2x3cm ở hố chậu (P), được sát trùng bằng betadine
Bụng mềm
e. khám tứ chi: xây xát nhiều nơi ở gối P và bàn tay (P), được sát trùng bằng betadine
f. các cơ quan khác: chưa ghi nhận bệnh lý
Kết quả cận lâm sàng: 
Công thức máu: HC: 4,9 Hb: 13,9 g/dl, Hct: 0,45 , MCV: 91, MCH: 29, MCHC: 313, TC: 195, BC: 11,9, PTS 11s aPTT: 30s 
Sinh hóa máu: ure: 4,8; glucose: 5,9mmol; creatinin: 90; Na+: 137; K+: 5,3; Cl-: 95; Ca++ :2,1; AST: 55; ALT: 43

Siêu âm bụng tổng quát chưa ghi nhận bất thường
Chụp X quang sọ thẳng, nghiêng và xquang khung chậu chưa ghi nhận bệnh lý
 chỉ số AIS lần lượt là: Head and Neck :1, Face :1, External :1  ISS score: 3 ')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (448, 153, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (449, 154, 5, N'Bệnh nhân nam 35 tuổi vào viện vì tai nạn giao thông qua hỏi bệnh và khám lâm sàng ghi nhận:
Glasgow: 15đ, đồng tử đều 2 bên kt 2mm
Đau vùng thái dương (P)
Chảy máu lỗ tai (P)
Vết thương dưới cằm 2x3 cm nham nhở
Vết bầm 2x3 cm ở hố chậu P
Xây xát ở bàn tay (P) và gối (P)')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (450, 155, 5, N'Đa thương do tai nạn giao thông')
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (451, 156, 5, NULL)
INSERT [dbo].[CustomSnippetValue] ([CustomSnippetValueId], [CustomSnippetId], [MedicalProfileId], [Value]) VALUES (452, 157, 5, NULL)
SET IDENTITY_INSERT [dbo].[CustomSnippetValue] OFF
/****** Object:  Table [dbo].[TreatmentHistory]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentHistory](
	[TreatmentHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[MedicalProfileId] [int] NULL,
	[PatientId] [int] NULL,
	[ConversationFromId] [int] NULL,
	[ConversationToId] [int] NULL,
	[TreatmentHistoryType] [int] NOT NULL,
	[DoctorId] [int] NULL,
	[Symptom] [nvarchar](max) NULL,
	[Diagnosis] [nvarchar](max) NULL,
	[Treatment] [nvarchar](max) NULL,
	[Condition] [nvarchar](max) NULL,
	[HeartRate] [nvarchar](max) NULL,
	[Temperature] [nvarchar](max) NULL,
	[BloodPressure] [nvarchar](max) NULL,
	[BreathingRate] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[OnSetDate] [datetime] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TreatmentHistory] PRIMARY KEY CLUSTERED 
(
	[TreatmentHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ConversationFromId] ON [dbo].[TreatmentHistory] 
(
	[ConversationFromId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ConversationToId] ON [dbo].[TreatmentHistory] 
(
	[ConversationToId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DoctorId] ON [dbo].[TreatmentHistory] 
(
	[DoctorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileId] ON [dbo].[TreatmentHistory] 
(
	[MedicalProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PatientId] ON [dbo].[TreatmentHistory] 
(
	[PatientId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TreatmentHistory] ON
INSERT [dbo].[TreatmentHistory] ([TreatmentHistoryId], [MedicalProfileId], [PatientId], [ConversationFromId], [ConversationToId], [TreatmentHistoryType], [DoctorId], [Symptom], [Diagnosis], [Treatment], [Condition], [HeartRate], [Temperature], [BloodPressure], [BreathingRate], [DateCreated], [OnSetDate], [Note]) VALUES (1, 1, NULL, NULL, NULL, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A3AA01889B3A AS DateTime), CAST(0x0000A31E00898320 AS DateTime), N'Bệnh năng')
INSERT [dbo].[TreatmentHistory] ([TreatmentHistoryId], [MedicalProfileId], [PatientId], [ConversationFromId], [ConversationToId], [TreatmentHistoryType], [DoctorId], [Symptom], [Diagnosis], [Treatment], [Condition], [HeartRate], [Temperature], [BloodPressure], [BreathingRate], [DateCreated], [OnSetDate], [Note]) VALUES (2, 1, NULL, NULL, NULL, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A3AA01889B3A AS DateTime), CAST(0x0000A33D00898320 AS DateTime), N'Bệnh tiến triển bình thường')
INSERT [dbo].[TreatmentHistory] ([TreatmentHistoryId], [MedicalProfileId], [PatientId], [ConversationFromId], [ConversationToId], [TreatmentHistoryType], [DoctorId], [Symptom], [Diagnosis], [Treatment], [Condition], [HeartRate], [Temperature], [BloodPressure], [BreathingRate], [DateCreated], [OnSetDate], [Note]) VALUES (4, NULL, 7, 1, 16, 0, 2, N'Sốt nhẹ', N'Sốt', NULL, N'Sốt 39-40 độ, nhức mình, ớn lạnh', NULL, NULL, NULL, NULL, CAST(0x0000A3AB002FC844 AS DateTime), CAST(0x0000A3AB00A32383 AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TreatmentHistory] OFF
/****** Object:  Table [dbo].[FilmDocument]    Script Date: 10/02/2014 00:41:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmDocument](
	[FilmDocumentId] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentHistoryId] [int] NULL,
	[MedicalProfileId] [int] NULL,
	[DoctorId] [int] NOT NULL,
	[FilmTypeId] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Conclusion] [nvarchar](max) NULL,
	[FilmTypePosition] [int] NOT NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.FilmDocument] PRIMARY KEY CLUSTERED 
(
	[FilmDocumentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DoctorId] ON [dbo].[FilmDocument] 
(
	[DoctorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FilmTypeId] ON [dbo].[FilmDocument] 
(
	[FilmTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MedicalProfileId] ON [dbo].[FilmDocument] 
(
	[MedicalProfileId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TreatmentHistoryId] ON [dbo].[FilmDocument] 
(
	[TreatmentHistoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FilmDocument] ON
INSERT [dbo].[FilmDocument] ([FilmDocumentId], [TreatmentHistoryId], [MedicalProfileId], [DoctorId], [FilmTypeId], [DateCreated], [Description], [Conclusion], [FilmTypePosition], [ImagePath]) VALUES (1, 1, NULL, 3, 1, CAST(0x0000A3AA01889B6F AS DateTime), N'Hình ảnh viêm phổi', N'Viêm phổi tụ cầu', 0, N'viemphoidotucau.gif')
INSERT [dbo].[FilmDocument] ([FilmDocumentId], [TreatmentHistoryId], [MedicalProfileId], [DoctorId], [FilmTypeId], [DateCreated], [Description], [Conclusion], [FilmTypePosition], [ImagePath]) VALUES (2, 1, NULL, 3, 1, CAST(0x0000A3AA01889B6F AS DateTime), N'Bệnh nhân bị amydal', N'Viêm amydal cấp', 0, N'viem_amydal_cap.jpg')
SET IDENTITY_INSERT [dbo].[FilmDocument] OFF
/****** Object:  ForeignKey [FK_dbo.SpecialtyField_dbo.SpecialtyField_ParentId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[SpecialtyField]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SpecialtyField_dbo.SpecialtyField_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[SpecialtyField] ([SpecialtyFieldId])
GO
ALTER TABLE [dbo].[SpecialtyField] CHECK CONSTRAINT [FK_dbo.SpecialtyField_dbo.SpecialtyField_ParentId]
GO
/****** Object:  ForeignKey [FK_dbo.Patient_dbo.User_UserId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Patient_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_dbo.Patient_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.Rating_dbo.User_UserId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Rating_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_dbo.Rating_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.Doctor_dbo.SpecialtyField_SpecialtyFieldId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctor_dbo.SpecialtyField_SpecialtyFieldId] FOREIGN KEY([SpecialtyFieldId])
REFERENCES [dbo].[SpecialtyField] ([SpecialtyFieldId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_dbo.Doctor_dbo.SpecialtyField_SpecialtyFieldId]
GO
/****** Object:  ForeignKey [FK_dbo.Doctor_dbo.User_UserId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctor_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_dbo.Doctor_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippet_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[CustomSnippet]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippet_dbo.MedicalProfileTemplate_MedicalProfileTemplateId] FOREIGN KEY([MedicalProfileTemplateId])
REFERENCES [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomSnippet] CHECK CONSTRAINT [FK_dbo.CustomSnippet_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]
GO
/****** Object:  ForeignKey [FK_dbo.UserRole_dbo.Role_RoleId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.UserRole_dbo.User_UserId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippetField_dbo.CustomSnippet_CustomSnippetId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[CustomSnippetField]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippetField_dbo.CustomSnippet_CustomSnippetId] FOREIGN KEY([CustomSnippetId])
REFERENCES [dbo].[CustomSnippet] ([CustomSnippetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomSnippetField] CHECK CONSTRAINT [FK_dbo.CustomSnippetField_dbo.CustomSnippet_CustomSnippetId]
GO
/****** Object:  ForeignKey [FK_dbo.Conversation_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Conversation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Conversation_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
GO
ALTER TABLE [dbo].[Conversation] CHECK CONSTRAINT [FK_dbo.Conversation_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.Conversation_dbo.Patient_PatientId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Conversation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Conversation_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Conversation] CHECK CONSTRAINT [FK_dbo.Conversation_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.Comment_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comment_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_dbo.Comment_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.Comment_dbo.Patient_PatientId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comment_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_dbo.Comment_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.PersonalHealthRecord_dbo.Patient_PatientId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[PersonalHealthRecord]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PersonalHealthRecord_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
GO
ALTER TABLE [dbo].[PersonalHealthRecord] CHECK CONSTRAINT [FK_dbo.PersonalHealthRecord_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.MedicalProfile_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[MedicalProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicalProfile_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalProfile] CHECK CONSTRAINT [FK_dbo.MedicalProfile_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.MedicalProfile_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[MedicalProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicalProfile_dbo.MedicalProfileTemplate_MedicalProfileTemplateId] FOREIGN KEY([MedicalProfileTemplateId])
REFERENCES [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalProfile] CHECK CONSTRAINT [FK_dbo.MedicalProfile_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]
GO
/****** Object:  ForeignKey [FK_dbo.MedicalProfile_dbo.Patient_PatientId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[MedicalProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicalProfile_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalProfile] CHECK CONSTRAINT [FK_dbo.MedicalProfile_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.Immunization_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Immunization]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Immunization_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Immunization] CHECK CONSTRAINT [FK_dbo.Immunization_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.ConversationDetail_dbo.Conversation_ConversationId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[ConversationDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConversationDetail_dbo.Conversation_ConversationId] FOREIGN KEY([ConversationId])
REFERENCES [dbo].[Conversation] ([ConversationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConversationDetail] CHECK CONSTRAINT [FK_dbo.ConversationDetail_dbo.Conversation_ConversationId]
GO
/****** Object:  ForeignKey [FK_dbo.ConversationDetail_dbo.User_UserId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[ConversationDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConversationDetail_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConversationDetail] CHECK CONSTRAINT [FK_dbo.ConversationDetail_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.Allergy_dbo.AllergyType_AllergyTypeId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Allergy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allergy_dbo.AllergyType_AllergyTypeId] FOREIGN KEY([AllergyTypeId])
REFERENCES [dbo].[AllergyType] ([AllergyTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergy] CHECK CONSTRAINT [FK_dbo.Allergy_dbo.AllergyType_AllergyTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.Allergy_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[Allergy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allergy_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergy] CHECK CONSTRAINT [FK_dbo.Allergy_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippetValue_dbo.CustomSnippet_CustomSnippetId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[CustomSnippetValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.CustomSnippet_CustomSnippetId] FOREIGN KEY([CustomSnippetId])
REFERENCES [dbo].[CustomSnippet] ([CustomSnippetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomSnippetValue] CHECK CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.CustomSnippet_CustomSnippetId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippetValue_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[CustomSnippetValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
GO
ALTER TABLE [dbo].[CustomSnippetValue] CHECK CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationFromId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationFromId] FOREIGN KEY([ConversationFromId])
REFERENCES [dbo].[ConversationDetail] ([ConversationDetailId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationFromId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationToId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationToId] FOREIGN KEY([ConversationToId])
REFERENCES [dbo].[ConversationDetail] ([ConversationDetailId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationToId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.Patient_PatientId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.FilmType_FilmTypeId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.FilmType_FilmTypeId] FOREIGN KEY([FilmTypeId])
REFERENCES [dbo].[FilmType] ([FilmTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.FilmType_FilmTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.TreatmentHistory_TreatmentHistoryId]    Script Date: 10/02/2014 00:41:49 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.TreatmentHistory_TreatmentHistoryId] FOREIGN KEY([TreatmentHistoryId])
REFERENCES [dbo].[TreatmentHistory] ([TreatmentHistoryId])
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.TreatmentHistory_TreatmentHistoryId]
GO
