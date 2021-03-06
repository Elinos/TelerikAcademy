USE [master]
GO
/****** Object:  Database [Dictionary]    Script Date: 22.8.2014 г. 15:44:55 ******/
CREATE DATABASE [Dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dictionary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dictionary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dictionary] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Dictionary]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[Discription] [text] NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[PartOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeech] PRIMARY KEY CLUSTERED 
(
	[PartOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Translations]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ExplanationID] [int] NOT NULL,
	[PartOfSpeechID] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Antonyms]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Antonyms](
	[WordID] [int] NOT NULL,
	[AntonymID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Antonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[AntonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Hyponyms]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Hyponyms](
	[WordID] [int] NOT NULL,
	[HyponymID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Hyponyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[HyponymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Synonyms]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Synonyms](
	[WordID] [int] NOT NULL,
	[SynonymID] [int] NOT NULL,
 CONSTRAINT [PK_Words_Synonyms] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC,
	[SynonymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words_Translations]    Script Date: 22.8.2014 г. 15:44:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words_Translations](
	[TranslationWordID] [int] NOT NULL,
	[WordID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Words_Translations] PRIMARY KEY CLUSTERED 
(
	[TranslationWordID] ASC,
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Languages1] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Languages1]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Explanations] FOREIGN KEY([ExplanationID])
REFERENCES [dbo].[Explanations] ([ExplanationID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Explanations]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeech] FOREIGN KEY([PartOfSpeechID])
REFERENCES [dbo].[PartsOfSpeech] ([PartOfSpeechID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeech]
GO
ALTER TABLE [dbo].[Words_Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Antonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Antonyms] CHECK CONSTRAINT [FK_Words_Antonyms_Words]
GO
ALTER TABLE [dbo].[Words_Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Antonyms_Words1] FOREIGN KEY([AntonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Antonyms] CHECK CONSTRAINT [FK_Words_Antonyms_Words1]
GO
ALTER TABLE [dbo].[Words_Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Hyponyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Hyponyms] CHECK CONSTRAINT [FK_Words_Hyponyms_Words]
GO
ALTER TABLE [dbo].[Words_Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Hyponyms_Words1] FOREIGN KEY([HyponymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Hyponyms] CHECK CONSTRAINT [FK_Words_Hyponyms_Words1]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words]
GO
ALTER TABLE [dbo].[Words_Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Words_Synonyms_Words1] FOREIGN KEY([SynonymID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Synonyms] CHECK CONSTRAINT [FK_Words_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words]
GO
ALTER TABLE [dbo].[Words_Translations]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations_Words1] FOREIGN KEY([TranslationWordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Words_Translations] CHECK CONSTRAINT [FK_Words_Translations_Words1]
GO
USE [master]
GO
ALTER DATABASE [Dictionary] SET  READ_WRITE 
GO
