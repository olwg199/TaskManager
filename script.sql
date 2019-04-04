USE [TaskManager]
GO

/****** Object:  Table [dbo].[Tasks]    Script Date: 01.04.2019 19:46:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tasks](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Category] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO 
	[dbo].[Tasks]([Id], [Name], [Date], [IsActive], [Category], [Description])
VALUES
	('6a1c4190-4bd1-42c0-90d4-296e167ad623',
	'Убрать в комнате',
	'2019-04-04',
	'0',
	'1',
	'Замести и помыть полы.')

GO

INSERT INTO 
	[dbo].[Tasks]([Id], [Name], [Date], [IsActive], [Category], [Description])
VALUES
	('72200fdc-c37b-4cf1-afd6-413ae2cc20d4',
	'Выкинуть мусор',
	'2019-04-04',
	'1',
	'1',
	'Не забыть мусор с балкона.')

GO

INSERT INTO 
	[dbo].[Tasks]([Id], [Name], [Date], [IsActive], [Category], [Description])
VALUES
	('f1cc19d5-bf6a-44c4-86db-4ac895ac39ca',
	'Установить антивирус на компьютер',
	'2019-04-06',
	'1',
	'0',
	'')

GO

INSERT INTO 
	[dbo].[Tasks]([Id], [Name], [Date], [IsActive], [Category], [Description])
VALUES
	('5d34222b-d294-47f4-9730-4d7aefce6073',
	'Составить бюджет на месяц',
	'2019-04-05',
	'1',
	'0',
	'Посчитать остаток и распределить по категориям деньги.')

GO
