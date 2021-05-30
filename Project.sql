CREATE DATABASE Project
GO
USE Project
GO

CREATE TABLE [dbo].[Category](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Slug] [nvarchar](50) NULL,
	[Sub_category] [nvarchar](50) NULL,
	[CreateAt] [datetime] NULL,
	[ModifiAt] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Favorite](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [int] NULL,
	[CreateAt] [nvarchar](50) NULL,
	[ModifiAt] [nvarchar](50) NULL,
 CONSTRAINT [PK_Favorite] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[History_Buy](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [int] NULL,
	[CreateAt] [datetime] NULL,
	[ModifiAt] [datetime] NULL,
 CONSTRAINT [PK_History_Buy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Product](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Slug] [nvarchar](50) NULL,
	[Parent_category] [nvarchar](50) NULL,
	[Sub_category] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Quantily] [int] NULL,
	[Price] [int] NULL,
	[ModifyAt] [datetime] NULL,
	[CreateAt] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SubCategory](
	[id] [int] NOT NULL,
	[Parent_category] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Slug] [nvarchar](50) NULL,
	[CreateAt] [datetime] NULL,
	[ModifyAt] [datetime] NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[Fullnname] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Adress] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


select * from [dbo].[User]
