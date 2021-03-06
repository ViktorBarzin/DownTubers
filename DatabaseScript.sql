USE [master]
GO
/****** Object:  Database [DownTubers]    Script Date: 17.3.2016 г. 17:19:51 ******/
CREATE DATABASE [DownTubers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DownTubers', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DownTubers.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DownTubers_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DownTubers_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DownTubers] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DownTubers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DownTubers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DownTubers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DownTubers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DownTubers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DownTubers] SET ARITHABORT OFF 
GO
ALTER DATABASE [DownTubers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DownTubers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DownTubers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DownTubers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DownTubers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DownTubers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DownTubers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DownTubers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DownTubers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DownTubers] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DownTubers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DownTubers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DownTubers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DownTubers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DownTubers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DownTubers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DownTubers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DownTubers] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DownTubers] SET  MULTI_USER 
GO
ALTER DATABASE [DownTubers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DownTubers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DownTubers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DownTubers] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DownTubers] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DownTubers]
GO
/****** Object:  Table [dbo].[HistorySet]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorySet](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
	[WatchDate] [datetime] NOT NULL,
 CONSTRAINT [PK_HistorySet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HistoryVideoJoin]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryVideoJoin](
	[HistoryId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
 CONSTRAINT [PK_HistoryVideoJoin] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC,
	[VideoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlaylistSet]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_PlaylistSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subscribers]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribers](
	[UserId] [int] NOT NULL,
	[SubscriberId] [int] NOT NULL,
 CONSTRAINT [PK_Subscribers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[SubscriberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserPlaylistJoin]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPlaylistJoin](
	[UserId] [int] NOT NULL,
	[PlaylistId] [int] NOT NULL,
 CONSTRAINT [PK_UserPlaylistJoin] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSet]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nchar](44) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Registered] [date] NULL,
	[LastLogin] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Priveleges] [int] NOT NULL,
	[PictureLocation] [nvarchar](250) NULL,
 CONSTRAINT [PK_UserSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VideoPlaylistsJoin]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoPlaylistsJoin](
	[PlaylistId] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
 CONSTRAINT [PK_VideoPlaylistsJoin] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC,
	[VideoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VideoSet]    Script Date: 17.3.2016 г. 17:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[UploadTime] [datetime] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Length] [real] NOT NULL,
	[Views] [int] NOT NULL,
	[Likes] [int] NULL,
	[VideoPath] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_VideoSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[HistorySet]  WITH CHECK ADD  CONSTRAINT [FK_HistorySet_UserSet] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserSet] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HistorySet] CHECK CONSTRAINT [FK_HistorySet_UserSet]
GO
ALTER TABLE [dbo].[HistoryVideoJoin]  WITH CHECK ADD  CONSTRAINT [FK_HistoryVideoJoin_HistorySet] FOREIGN KEY([HistoryId])
REFERENCES [dbo].[HistorySet] ([Id])
GO
ALTER TABLE [dbo].[HistoryVideoJoin] CHECK CONSTRAINT [FK_HistoryVideoJoin_HistorySet]
GO
ALTER TABLE [dbo].[HistoryVideoJoin]  WITH CHECK ADD  CONSTRAINT [FK_HistoryVideoJoin_VideoSet] FOREIGN KEY([VideoId])
REFERENCES [dbo].[VideoSet] ([Id])
GO
ALTER TABLE [dbo].[HistoryVideoJoin] CHECK CONSTRAINT [FK_HistoryVideoJoin_VideoSet]
GO
ALTER TABLE [dbo].[Subscribers]  WITH CHECK ADD  CONSTRAINT [FK_Subscribers_UserSet] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserSet] ([Id])
GO
ALTER TABLE [dbo].[Subscribers] CHECK CONSTRAINT [FK_Subscribers_UserSet]
GO
ALTER TABLE [dbo].[Subscribers]  WITH CHECK ADD  CONSTRAINT [FK_Subscribers_UserSet1] FOREIGN KEY([SubscriberId])
REFERENCES [dbo].[UserSet] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subscribers] CHECK CONSTRAINT [FK_Subscribers_UserSet1]
GO
ALTER TABLE [dbo].[UserPlaylistJoin]  WITH CHECK ADD  CONSTRAINT [FK_UserPlaylistJoin_PlaylistSet] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[PlaylistSet] ([Id])
GO
ALTER TABLE [dbo].[UserPlaylistJoin] CHECK CONSTRAINT [FK_UserPlaylistJoin_PlaylistSet]
GO
ALTER TABLE [dbo].[UserPlaylistJoin]  WITH CHECK ADD  CONSTRAINT [FK_UserPlaylistJoin_UserSet] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserSet] ([Id])
GO
ALTER TABLE [dbo].[UserPlaylistJoin] CHECK CONSTRAINT [FK_UserPlaylistJoin_UserSet]
GO
ALTER TABLE [dbo].[VideoPlaylistsJoin]  WITH CHECK ADD  CONSTRAINT [FK_VideoPlaylistsJoin_PlaylistSet] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[PlaylistSet] ([Id])
GO
ALTER TABLE [dbo].[VideoPlaylistsJoin] CHECK CONSTRAINT [FK_VideoPlaylistsJoin_PlaylistSet]
GO
ALTER TABLE [dbo].[VideoPlaylistsJoin]  WITH CHECK ADD  CONSTRAINT [FK_VideoPlaylistsJoin_VideoSet] FOREIGN KEY([VideoId])
REFERENCES [dbo].[VideoSet] ([Id])
GO
ALTER TABLE [dbo].[VideoPlaylistsJoin] CHECK CONSTRAINT [FK_VideoPlaylistsJoin_VideoSet]
GO
ALTER TABLE [dbo].[VideoSet]  WITH CHECK ADD  CONSTRAINT [FK_VideoSet_UserSet] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[UserSet] ([Id])
GO
ALTER TABLE [dbo].[VideoSet] CHECK CONSTRAINT [FK_VideoSet_UserSet]
GO
USE [master]
GO
ALTER DATABASE [DownTubers] SET  READ_WRITE 
GO
