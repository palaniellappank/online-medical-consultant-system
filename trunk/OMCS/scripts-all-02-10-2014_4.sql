USE [master]
GO
/****** Object:  Database [OMCS]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[AllergyType]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[HospitalInformation]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[FilmType]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[MedicalProfileTemplate]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[SpecialtyField]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Patient]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Rating]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Doctor]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[CustomSnippet]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[CustomSnippetField]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Conversation]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Comment]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[PersonalHealthRecord]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[MedicalProfile]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Immunization]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[ConversationDetail]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[Allergy]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[CustomSnippetValue]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[TreatmentHistory]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  Table [dbo].[FilmDocument]    Script Date: 10/02/2014 17:11:45 ******/
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
/****** Object:  ForeignKey [FK_dbo.SpecialtyField_dbo.SpecialtyField_ParentId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[SpecialtyField]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SpecialtyField_dbo.SpecialtyField_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[SpecialtyField] ([SpecialtyFieldId])
GO
ALTER TABLE [dbo].[SpecialtyField] CHECK CONSTRAINT [FK_dbo.SpecialtyField_dbo.SpecialtyField_ParentId]
GO
/****** Object:  ForeignKey [FK_dbo.Patient_dbo.User_UserId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Patient]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Patient_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Patient] CHECK CONSTRAINT [FK_dbo.Patient_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.Rating_dbo.User_UserId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Rating_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_dbo.Rating_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.Doctor_dbo.SpecialtyField_SpecialtyFieldId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctor_dbo.SpecialtyField_SpecialtyFieldId] FOREIGN KEY([SpecialtyFieldId])
REFERENCES [dbo].[SpecialtyField] ([SpecialtyFieldId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_dbo.Doctor_dbo.SpecialtyField_SpecialtyFieldId]
GO
/****** Object:  ForeignKey [FK_dbo.Doctor_dbo.User_UserId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctor_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_dbo.Doctor_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippet_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[CustomSnippet]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippet_dbo.MedicalProfileTemplate_MedicalProfileTemplateId] FOREIGN KEY([MedicalProfileTemplateId])
REFERENCES [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomSnippet] CHECK CONSTRAINT [FK_dbo.CustomSnippet_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]
GO
/****** Object:  ForeignKey [FK_dbo.UserRole_dbo.Role_RoleId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.UserRole_dbo.User_UserId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippetField_dbo.CustomSnippet_CustomSnippetId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[CustomSnippetField]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippetField_dbo.CustomSnippet_CustomSnippetId] FOREIGN KEY([CustomSnippetId])
REFERENCES [dbo].[CustomSnippet] ([CustomSnippetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomSnippetField] CHECK CONSTRAINT [FK_dbo.CustomSnippetField_dbo.CustomSnippet_CustomSnippetId]
GO
/****** Object:  ForeignKey [FK_dbo.Conversation_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Conversation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Conversation_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
GO
ALTER TABLE [dbo].[Conversation] CHECK CONSTRAINT [FK_dbo.Conversation_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.Conversation_dbo.Patient_PatientId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Conversation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Conversation_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Conversation] CHECK CONSTRAINT [FK_dbo.Conversation_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.Comment_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comment_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_dbo.Comment_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.Comment_dbo.Patient_PatientId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comment_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_dbo.Comment_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.PersonalHealthRecord_dbo.Patient_PatientId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[PersonalHealthRecord]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PersonalHealthRecord_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
GO
ALTER TABLE [dbo].[PersonalHealthRecord] CHECK CONSTRAINT [FK_dbo.PersonalHealthRecord_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.MedicalProfile_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[MedicalProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicalProfile_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalProfile] CHECK CONSTRAINT [FK_dbo.MedicalProfile_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.MedicalProfile_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[MedicalProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicalProfile_dbo.MedicalProfileTemplate_MedicalProfileTemplateId] FOREIGN KEY([MedicalProfileTemplateId])
REFERENCES [dbo].[MedicalProfileTemplate] ([MedicalProfileTemplateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalProfile] CHECK CONSTRAINT [FK_dbo.MedicalProfile_dbo.MedicalProfileTemplate_MedicalProfileTemplateId]
GO
/****** Object:  ForeignKey [FK_dbo.MedicalProfile_dbo.Patient_PatientId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[MedicalProfile]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MedicalProfile_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalProfile] CHECK CONSTRAINT [FK_dbo.MedicalProfile_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.Immunization_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Immunization]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Immunization_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Immunization] CHECK CONSTRAINT [FK_dbo.Immunization_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.ConversationDetail_dbo.Conversation_ConversationId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[ConversationDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConversationDetail_dbo.Conversation_ConversationId] FOREIGN KEY([ConversationId])
REFERENCES [dbo].[Conversation] ([ConversationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConversationDetail] CHECK CONSTRAINT [FK_dbo.ConversationDetail_dbo.Conversation_ConversationId]
GO
/****** Object:  ForeignKey [FK_dbo.ConversationDetail_dbo.User_UserId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[ConversationDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConversationDetail_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ConversationDetail] CHECK CONSTRAINT [FK_dbo.ConversationDetail_dbo.User_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.Allergy_dbo.AllergyType_AllergyTypeId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Allergy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allergy_dbo.AllergyType_AllergyTypeId] FOREIGN KEY([AllergyTypeId])
REFERENCES [dbo].[AllergyType] ([AllergyTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergy] CHECK CONSTRAINT [FK_dbo.Allergy_dbo.AllergyType_AllergyTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.Allergy_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[Allergy]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Allergy_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Allergy] CHECK CONSTRAINT [FK_dbo.Allergy_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippetValue_dbo.CustomSnippet_CustomSnippetId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[CustomSnippetValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.CustomSnippet_CustomSnippetId] FOREIGN KEY([CustomSnippetId])
REFERENCES [dbo].[CustomSnippet] ([CustomSnippetId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CustomSnippetValue] CHECK CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.CustomSnippet_CustomSnippetId]
GO
/****** Object:  ForeignKey [FK_dbo.CustomSnippetValue_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[CustomSnippetValue]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
GO
ALTER TABLE [dbo].[CustomSnippetValue] CHECK CONSTRAINT [FK_dbo.CustomSnippetValue_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationFromId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationFromId] FOREIGN KEY([ConversationFromId])
REFERENCES [dbo].[ConversationDetail] ([ConversationDetailId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationFromId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationToId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationToId] FOREIGN KEY([ConversationToId])
REFERENCES [dbo].[ConversationDetail] ([ConversationDetailId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.ConversationDetail_ConversationToId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.TreatmentHistory_dbo.Patient_PatientId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[TreatmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([UserId])
GO
ALTER TABLE [dbo].[TreatmentHistory] CHECK CONSTRAINT [FK_dbo.TreatmentHistory_dbo.Patient_PatientId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.Doctor_DoctorId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.Doctor_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctor] ([UserId])
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.Doctor_DoctorId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.FilmType_FilmTypeId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.FilmType_FilmTypeId] FOREIGN KEY([FilmTypeId])
REFERENCES [dbo].[FilmType] ([FilmTypeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.FilmType_FilmTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.MedicalProfile_MedicalProfileId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.MedicalProfile_MedicalProfileId] FOREIGN KEY([MedicalProfileId])
REFERENCES [dbo].[MedicalProfile] ([MedicalProfileId])
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.MedicalProfile_MedicalProfileId]
GO
/****** Object:  ForeignKey [FK_dbo.FilmDocument_dbo.TreatmentHistory_TreatmentHistoryId]    Script Date: 10/02/2014 17:11:45 ******/
ALTER TABLE [dbo].[FilmDocument]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FilmDocument_dbo.TreatmentHistory_TreatmentHistoryId] FOREIGN KEY([TreatmentHistoryId])
REFERENCES [dbo].[TreatmentHistory] ([TreatmentHistoryId])
GO
ALTER TABLE [dbo].[FilmDocument] CHECK CONSTRAINT [FK_dbo.FilmDocument_dbo.TreatmentHistory_TreatmentHistoryId]
GO
