USE [DBSALES]
GO

/****** Object:  Table [dbo].[Brand]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[City]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Company]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[ContactName] [nvarchar](50) NULL,
	[ContactLastName] [nvarchar](50) NULL,
	[CreationDate] [datetime] NOT NULL,
	[Enabled] [bit] NULL,
	[InitialDate] [datetime] NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Website] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[Postal] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Schedule] [nvarchar](150) NULL,
	[Logo] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CompanySector]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompanySector](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[SectorId] [int] NOT NULL,
 CONSTRAINT [PK_CompanySector] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ConfigScreen]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConfigScreen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[SystemScreenId] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Orden] [int] NULL,
	[Icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_Screen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ConfigScreenField]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConfigScreenField](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConfigScreenId] [int] NOT NULL,
	[SystemScreenFieldId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Required] [bit] NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[DefaultValue] [nvarchar](50) NULL,
	[Orden] [int] NULL,
 CONSTRAINT [PK_ConfigScreenField] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ContactType]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Country]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[DocumentType]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ExchangeCurrency]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExchangeCurrency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Quote] [money] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[DateEnd] [datetime] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Location]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[LogError]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogError](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[SecurityUserId] [int] NULL,
	[Path] [nvarchar](200) NULL,
	[Error] [varchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LogErrorFront] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentMethod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[PriceList]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PriceList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SalesState]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_SalesState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SalesUnit]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_SalesUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Sector]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sector](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SecurityAction]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SecurityAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConfigScreenId] [int] NOT NULL,
	[SystemActionId] [int] NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Enabled] [bit] NULL,
 CONSTRAINT [PK_ConfigAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SecurityRole]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SecurityRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](100) NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[SystemRoleId] [int] NULL,
 CONSTRAINT [PK__Security__3214EC071301632D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SecurityRoleAction]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SecurityRoleAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SecurityRoleId] [int] NOT NULL,
	[SecurityActionId] [int] NOT NULL,
 CONSTRAINT [PK_SecurityRoleAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SecurityRoleScreen]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SecurityRoleScreen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SecurityRoleId] [int] NOT NULL,
	[ConfigScreenId] [int] NOT NULL,
 CONSTRAINT [PK_SecurityRoleScreen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SecurityUser]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SecurityUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SecurityRoleId] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[tipo_documento] [varchar](20) NULL,
	[num_documento] [varchar](20) NULL,
	[direccion] [varchar](70) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NOT NULL,
	[password_hash] [varbinary](max) NOT NULL,
	[password_salt] [varbinary](max) NOT NULL,
	[condicion] [bit] NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK__Security__3214EC074EE7C13F] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Service]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[State]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SubCategory]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SystemAction]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemScreenId] [int] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_SystemAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SystemRole]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SystemRoleAction]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemRoleAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemRoleId] [int] NOT NULL,
	[SystemActionId] [int] NOT NULL,
 CONSTRAINT [PK_SystemRoleAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SystemRoleScreen]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemRoleScreen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemScreenId] [int] NOT NULL,
	[SystemRoleId] [int] NOT NULL,
 CONSTRAINT [PK_SystemRoleScreen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SystemScreen]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemScreen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[ParentId] [int] NULL,
	[Orden] [int] NOT NULL,
	[Entity] [nvarchar](50) NULL,
	[Path] [nvarchar](100) NULL,
	[Icon] [nvarchar](50) NULL,
 CONSTRAINT [PK_SystemScreen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SystemScreenField]    Script Date: 11/7/2020 17:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemScreenField](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemScreenId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Required] [bit] NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[DefaultValue] [nvarchar](50) NULL,
	[Orden] [int] NULL,
 CONSTRAINT [PK_SystemScreenField] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[SecurityRole] ADD  CONSTRAINT [DF__SecurityR__condi__46E78A0C]  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[SecurityUser] ADD  CONSTRAINT [DF__SecurityU__condi__5070F446]  DEFAULT ((1)) FOR [condicion]
GO

ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [FK_Brand_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [FK_Brand_Company]
GO

ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Company]
GO

ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO

ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO

ALTER TABLE [dbo].[CompanySector]  WITH CHECK ADD  CONSTRAINT [FK_CompanySector_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[CompanySector] CHECK CONSTRAINT [FK_CompanySector_Company]
GO

ALTER TABLE [dbo].[CompanySector]  WITH CHECK ADD  CONSTRAINT [FK_CompanySector_Sector] FOREIGN KEY([SectorId])
REFERENCES [dbo].[Sector] ([Id])
GO

ALTER TABLE [dbo].[CompanySector] CHECK CONSTRAINT [FK_CompanySector_Sector]
GO

ALTER TABLE [dbo].[ConfigScreen]  WITH CHECK ADD  CONSTRAINT [FK_ConfigScreen_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[ConfigScreen] CHECK CONSTRAINT [FK_ConfigScreen_Company]
GO

ALTER TABLE [dbo].[ConfigScreen]  WITH CHECK ADD  CONSTRAINT [FK_ConfigScreen_SystemScreen] FOREIGN KEY([SystemScreenId])
REFERENCES [dbo].[SystemScreen] ([Id])
GO

ALTER TABLE [dbo].[ConfigScreen] CHECK CONSTRAINT [FK_ConfigScreen_SystemScreen]
GO

ALTER TABLE [dbo].[ConfigScreenField]  WITH CHECK ADD  CONSTRAINT [FK_ConfigScreenField_ConfigScreen] FOREIGN KEY([ConfigScreenId])
REFERENCES [dbo].[ConfigScreen] ([Id])
GO

ALTER TABLE [dbo].[ConfigScreenField] CHECK CONSTRAINT [FK_ConfigScreenField_ConfigScreen]
GO

ALTER TABLE [dbo].[ConfigScreenField]  WITH CHECK ADD  CONSTRAINT [FK_ConfigScreenField_SystemScreenField] FOREIGN KEY([SystemScreenFieldId])
REFERENCES [dbo].[SystemScreenField] ([Id])
GO

ALTER TABLE [dbo].[ConfigScreenField] CHECK CONSTRAINT [FK_ConfigScreenField_SystemScreenField]
GO

ALTER TABLE [dbo].[ContactType]  WITH CHECK ADD  CONSTRAINT [FK_ContactType_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[ContactType] CHECK CONSTRAINT [FK_ContactType_Company]
GO

ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Company]
GO

ALTER TABLE [dbo].[DocumentType]  WITH CHECK ADD  CONSTRAINT [FK_DocumentType_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[DocumentType] CHECK CONSTRAINT [FK_DocumentType_Company]
GO

ALTER TABLE [dbo].[ExchangeCurrency]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeCurrency_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[ExchangeCurrency] CHECK CONSTRAINT [FK_ExchangeCurrency_Company]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Company]
GO

ALTER TABLE [dbo].[PaymentMethod]  WITH CHECK ADD  CONSTRAINT [FK_PaymentMethod_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[PaymentMethod] CHECK CONSTRAINT [FK_PaymentMethod_Company]
GO

ALTER TABLE [dbo].[PriceList]  WITH CHECK ADD  CONSTRAINT [FK_PriceList_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[PriceList] CHECK CONSTRAINT [FK_PriceList_Company]
GO

ALTER TABLE [dbo].[SalesState]  WITH CHECK ADD  CONSTRAINT [FK_SalesState_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[SalesState] CHECK CONSTRAINT [FK_SalesState_Company]
GO

ALTER TABLE [dbo].[SalesUnit]  WITH CHECK ADD  CONSTRAINT [FK_SalesUnit_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[SalesUnit] CHECK CONSTRAINT [FK_SalesUnit_Company]
GO

ALTER TABLE [dbo].[SecurityAction]  WITH CHECK ADD  CONSTRAINT [FK_ConfigAction_ConfigScreen] FOREIGN KEY([SystemActionId])
REFERENCES [dbo].[SystemAction] ([Id])
GO

ALTER TABLE [dbo].[SecurityAction] CHECK CONSTRAINT [FK_ConfigAction_ConfigScreen]
GO

ALTER TABLE [dbo].[SecurityAction]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAction_ConfigScreen] FOREIGN KEY([ConfigScreenId])
REFERENCES [dbo].[ConfigScreen] ([Id])
GO

ALTER TABLE [dbo].[SecurityAction] CHECK CONSTRAINT [FK_SecurityAction_ConfigScreen]
GO

ALTER TABLE [dbo].[SecurityRole]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRole_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[SecurityRole] CHECK CONSTRAINT [FK_SecurityRole_Company]
GO

ALTER TABLE [dbo].[SecurityRole]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRole_SystemRole] FOREIGN KEY([SystemRoleId])
REFERENCES [dbo].[SystemRole] ([Id])
GO

ALTER TABLE [dbo].[SecurityRole] CHECK CONSTRAINT [FK_SecurityRole_SystemRole]
GO

ALTER TABLE [dbo].[SecurityRoleAction]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRoleAction_SecurityAction] FOREIGN KEY([SecurityActionId])
REFERENCES [dbo].[SecurityAction] ([Id])
GO

ALTER TABLE [dbo].[SecurityRoleAction] CHECK CONSTRAINT [FK_SecurityRoleAction_SecurityAction]
GO

ALTER TABLE [dbo].[SecurityRoleAction]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRoleAction_SecurityRole] FOREIGN KEY([SecurityRoleId])
REFERENCES [dbo].[SecurityRole] ([Id])
GO

ALTER TABLE [dbo].[SecurityRoleAction] CHECK CONSTRAINT [FK_SecurityRoleAction_SecurityRole]
GO

ALTER TABLE [dbo].[SecurityRoleScreen]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRoleScreen_ConfigScreen] FOREIGN KEY([ConfigScreenId])
REFERENCES [dbo].[ConfigScreen] ([Id])
GO

ALTER TABLE [dbo].[SecurityRoleScreen] CHECK CONSTRAINT [FK_SecurityRoleScreen_ConfigScreen]
GO

ALTER TABLE [dbo].[SecurityRoleScreen]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRoleScreen_SecurityRole] FOREIGN KEY([SecurityRoleId])
REFERENCES [dbo].[SecurityRole] ([Id])
GO

ALTER TABLE [dbo].[SecurityRoleScreen] CHECK CONSTRAINT [FK_SecurityRoleScreen_SecurityRole]
GO

ALTER TABLE [dbo].[SecurityUser]  WITH CHECK ADD  CONSTRAINT [FK__SecurityU__Secur__5165187F] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[SecurityUser] CHECK CONSTRAINT [FK__SecurityU__Secur__5165187F]
GO

ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Company]
GO

ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country]
GO

ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO

ALTER TABLE [dbo].[SystemRoleAction]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleAction_SystemAction] FOREIGN KEY([SystemActionId])
REFERENCES [dbo].[SystemAction] ([Id])
GO

ALTER TABLE [dbo].[SystemRoleAction] CHECK CONSTRAINT [FK_SystemRoleAction_SystemAction]
GO

ALTER TABLE [dbo].[SystemRoleAction]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleAction_SystemRole] FOREIGN KEY([SystemRoleId])
REFERENCES [dbo].[SystemRole] ([Id])
GO

ALTER TABLE [dbo].[SystemRoleAction] CHECK CONSTRAINT [FK_SystemRoleAction_SystemRole]
GO

ALTER TABLE [dbo].[SystemRoleScreen]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleScreen_SystemRole] FOREIGN KEY([SystemRoleId])
REFERENCES [dbo].[SystemRole] ([Id])
GO

ALTER TABLE [dbo].[SystemRoleScreen] CHECK CONSTRAINT [FK_SystemRoleScreen_SystemRole]
GO

ALTER TABLE [dbo].[SystemRoleScreen]  WITH CHECK ADD  CONSTRAINT [FK_SystemRoleScreen_SystemScreen] FOREIGN KEY([SystemScreenId])
REFERENCES [dbo].[SystemScreen] ([Id])
GO

ALTER TABLE [dbo].[SystemRoleScreen] CHECK CONSTRAINT [FK_SystemRoleScreen_SystemScreen]
GO

ALTER TABLE [dbo].[SystemScreenField]  WITH CHECK ADD  CONSTRAINT [FK_SystemScreenField_SystemScreen] FOREIGN KEY([SystemScreenId])
REFERENCES [dbo].[SystemScreen] ([Id])
GO

ALTER TABLE [dbo].[SystemScreenField] CHECK CONSTRAINT [FK_SystemScreenField_SystemScreen]
GO

