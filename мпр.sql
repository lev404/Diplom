USE [master]
GO
/****** Object:  Database [!Диплом]    Script Date: 25.06.2024 2:08:07 ******/
CREATE DATABASE [!Диплом]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'!Диплом', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\!Диплом.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'!Диплом_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\!Диплом_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [!Диплом] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [!Диплом].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [!Диплом] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [!Диплом] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [!Диплом] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [!Диплом] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [!Диплом] SET ARITHABORT OFF 
GO
ALTER DATABASE [!Диплом] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [!Диплом] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [!Диплом] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [!Диплом] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [!Диплом] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [!Диплом] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [!Диплом] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [!Диплом] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [!Диплом] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [!Диплом] SET  DISABLE_BROKER 
GO
ALTER DATABASE [!Диплом] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [!Диплом] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [!Диплом] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [!Диплом] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [!Диплом] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [!Диплом] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [!Диплом] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [!Диплом] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [!Диплом] SET  MULTI_USER 
GO
ALTER DATABASE [!Диплом] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [!Диплом] SET DB_CHAINING OFF 
GO
ALTER DATABASE [!Диплом] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [!Диплом] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [!Диплом] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [!Диплом] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [!Диплом] SET QUERY_STORE = ON
GO
ALTER DATABASE [!Диплом] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [!Диплом]
GO
/****** Object:  Table [dbo].[Автомобиль]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Автомобиль](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[Марка] [varchar](30) NOT NULL,
	[РегистрационныйНомер] [varchar](9) NOT NULL,
	[ТипАвтомобиля] [int] NOT NULL,
	[ТипТоплива] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказчик]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказчик](
	[ZakazchikID] [int] NOT NULL,
	[НаименованиеОрганизации] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Заказчик] PRIMARY KEY CLUSTERED 
(
	[ZakazchikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователь]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователь](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия] [varchar](30) NOT NULL,
	[Имя] [varchar](30) NOT NULL,
	[Отчество] [varchar](30) NULL,
	[ДатаРождения] [date] NOT NULL,
	[Пол] [varchar](1) NOT NULL,
	[Роль] [int] NOT NULL,
	[НомерТелефона] [bigint] NOT NULL,
	[НомерПаспорта] [int] NOT NULL,
	[СерияПаспорта] [int] NOT NULL,
	[НомерЛицензии] [int] NULL,
	[Логин] [varchar](255) NOT NULL,
	[Пароль] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Пользова__1788CCAC1102B90E] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Прицеп]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Прицеп](
	[TrailerID] [int] IDENTITY(1,1) NOT NULL,
	[Марка] [varchar](30) NOT NULL,
	[РегистрационныйНомер] [varchar](9) NOT NULL,
	[ГаражныйНомер] [int] NOT NULL,
	[ТипПрицепа] [int] NOT NULL,
 CONSTRAINT [PK__Прицеп__1B041CC3595DC553] PRIMARY KEY CLUSTERED 
(
	[TrailerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Продукт]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Продукт](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Название] [varchar](255) NOT NULL,
	[Производитель] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ПутевойЛист]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ПутевойЛист](
	[ListID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CarID] [int] NOT NULL,
	[TrailerID] [int] NULL,
	[ZakazchikID] [int] NOT NULL,
	[ВыездИзГаражаПоГрафику] [datetime] NOT NULL,
	[ВыездИзГаражаФактический] [datetime] NOT NULL,
	[НулевойПробегДоВыезда] [int] NOT NULL,
	[ПоказаниеСпидометраДоВыезда] [int] NOT NULL,
	[ВыданоГорючего] [int] NOT NULL,
	[ОстатокГорючегоПриВыезде] [int] NOT NULL,
	[АдресПунктаПогрузки] [varchar](255) NOT NULL,
	[АдресПунктаРазгрузки] [varchar](255) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Расстояние] [int] NOT NULL,
	[ТипПутевогоЛиста] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Роль]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Роль](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[НазваниеРоли] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипАвтомобиля]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипАвтомобиля](
	[CarTypeID] [int] IDENTITY(1,1) NOT NULL,
	[НазваниеТипа] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипПрицепа]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипПрицепа](
	[TrailerTypeID] [int] IDENTITY(1,1) NOT NULL,
	[НазваниеТипа] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TrailerTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипПутевогоЛиста]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипПутевогоЛиста](
	[ListTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ListTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ТипТоплива]    Script Date: 25.06.2024 2:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ТипТоплива](
	[FuelTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Марка] [varchar](30) NOT NULL,
	[КодМарки] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FuelTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Автомобиль]  WITH CHECK ADD  CONSTRAINT [FK_Автомобиль_ТипАвтомобиля] FOREIGN KEY([ТипАвтомобиля])
REFERENCES [dbo].[ТипАвтомобиля] ([CarTypeID])
GO
ALTER TABLE [dbo].[Автомобиль] CHECK CONSTRAINT [FK_Автомобиль_ТипАвтомобиля]
GO
ALTER TABLE [dbo].[Автомобиль]  WITH CHECK ADD  CONSTRAINT [FK_Автомобиль_ТипТоплива] FOREIGN KEY([ТипТоплива])
REFERENCES [dbo].[ТипТоплива] ([FuelTypeID])
GO
ALTER TABLE [dbo].[Автомобиль] CHECK CONSTRAINT [FK_Автомобиль_ТипТоплива]
GO
ALTER TABLE [dbo].[Пользователь]  WITH CHECK ADD  CONSTRAINT [FK_Пользователь_Роль] FOREIGN KEY([Роль])
REFERENCES [dbo].[Роль] ([RoleID])
GO
ALTER TABLE [dbo].[Пользователь] CHECK CONSTRAINT [FK_Пользователь_Роль]
GO
ALTER TABLE [dbo].[Прицеп]  WITH CHECK ADD  CONSTRAINT [FK_Прицеп_ТипПрицепа] FOREIGN KEY([ТипПрицепа])
REFERENCES [dbo].[ТипПрицепа] ([TrailerTypeID])
GO
ALTER TABLE [dbo].[Прицеп] CHECK CONSTRAINT [FK_Прицеп_ТипПрицепа]
GO
ALTER TABLE [dbo].[ПутевойЛист]  WITH CHECK ADD  CONSTRAINT [FK_ПутевойЛист_Автомобиль] FOREIGN KEY([CarID])
REFERENCES [dbo].[Автомобиль] ([CarID])
GO
ALTER TABLE [dbo].[ПутевойЛист] CHECK CONSTRAINT [FK_ПутевойЛист_Автомобиль]
GO
ALTER TABLE [dbo].[ПутевойЛист]  WITH CHECK ADD  CONSTRAINT [FK_ПутевойЛист_Заказчик] FOREIGN KEY([ZakazchikID])
REFERENCES [dbo].[Заказчик] ([ZakazchikID])
GO
ALTER TABLE [dbo].[ПутевойЛист] CHECK CONSTRAINT [FK_ПутевойЛист_Заказчик]
GO
ALTER TABLE [dbo].[ПутевойЛист]  WITH CHECK ADD  CONSTRAINT [FK_ПутевойЛист_Пользователь] FOREIGN KEY([UserID])
REFERENCES [dbo].[Пользователь] ([UserID])
GO
ALTER TABLE [dbo].[ПутевойЛист] CHECK CONSTRAINT [FK_ПутевойЛист_Пользователь]
GO
ALTER TABLE [dbo].[ПутевойЛист]  WITH CHECK ADD  CONSTRAINT [FK_ПутевойЛист_Прицеп] FOREIGN KEY([TrailerID])
REFERENCES [dbo].[Прицеп] ([TrailerID])
GO
ALTER TABLE [dbo].[ПутевойЛист] CHECK CONSTRAINT [FK_ПутевойЛист_Прицеп]
GO
ALTER TABLE [dbo].[ПутевойЛист]  WITH CHECK ADD  CONSTRAINT [FK_ПутевойЛист_Продукт] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Продукт] ([ProductID])
GO
ALTER TABLE [dbo].[ПутевойЛист] CHECK CONSTRAINT [FK_ПутевойЛист_Продукт]
GO
ALTER TABLE [dbo].[ПутевойЛист]  WITH CHECK ADD  CONSTRAINT [FK_ПутевойЛист_ТипПутевогоЛиста] FOREIGN KEY([ТипПутевогоЛиста])
REFERENCES [dbo].[ТипПутевогоЛиста] ([ListTypeID])
GO
ALTER TABLE [dbo].[ПутевойЛист] CHECK CONSTRAINT [FK_ПутевойЛист_ТипПутевогоЛиста]
GO
USE [master]
GO
ALTER DATABASE [!Диплом] SET  READ_WRITE 
GO
