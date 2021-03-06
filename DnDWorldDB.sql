USE [DnDWorldDB]
GO
/****** Object:  Table [dbo].[AuthTypes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthTypes](
	[AuthTypeID] [int] IDENTITY(1,1) NOT NULL,
	[AuthTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuthTypes] PRIMARY KEY CLUSTERED 
(
	[AuthTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterClasses]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterClasses](
	[CharacterClassID] [int] IDENTITY(1,1) NOT NULL,
	[CharacterID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_CharacterClasses] PRIMARY KEY CLUSTERED 
(
	[CharacterClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterDescriptions]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterDescriptions](
	[CharacterDescriptionID] [int] IDENTITY(1,1) NOT NULL,
	[CharacterID] [int] NOT NULL,
	[DescriptionID] [int] NOT NULL,
 CONSTRAINT [PK_CharacterDescriptions] PRIMARY KEY CLUSTERED 
(
	[CharacterDescriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterItems]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterItems](
	[CharacterItemID] [int] IDENTITY(1,1) NOT NULL,
	[CharacterID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_CharacterItems] PRIMARY KEY CLUSTERED 
(
	[CharacterItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[CharacterID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[RaceID] [int] NOT NULL,
	[Experience] [int] NOT NULL,
	[PicturePath] [text] NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsDead] [bit] NOT NULL,
	[CreateDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[CharacterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[PicturePath] [text] NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentTypes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentTypes](
	[ContentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ContentType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContentTypes] PRIMARY KEY CLUSTERED 
(
	[ContentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descriptions]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descriptions](
	[DescriptionID] [int] IDENTITY(1,1) NOT NULL,
	[DescriptionTypeID] [int] NOT NULL,
	[DescriptionContent] [text] NOT NULL,
 CONSTRAINT [PK_Descriptions] PRIMARY KEY CLUSTERED 
(
	[DescriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DescriptionTypes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DescriptionTypes](
	[DescriptionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[DescriptionTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DescriptionTypes] PRIMARY KEY CLUSTERED 
(
	[DescriptionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[Weight] [decimal](18, 1) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lores]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lores](
	[LoreID] [int] IDENTITY(1,1) NOT NULL,
	[LoreTypeID] [int] NOT NULL,
	[LoreContent] [text] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[UniverseID] [int] NOT NULL,
	[PlanetID] [int] NULL,
 CONSTRAINT [PK_Lores] PRIMARY KEY CLUSTERED 
(
	[LoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoreTypes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoreTypes](
	[LoreTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LoreTypeName] [nvarchar](50) NOT NULL,
	[LoreTypeDescription] [text] NOT NULL,
 CONSTRAINT [PK_LoreTypes] PRIMARY KEY CLUSTERED 
(
	[LoreTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionTypeID] [int] NOT NULL,
	[GrantingUserID] [int] NOT NULL,
	[GrantedUserID] [int] NOT NULL,
	[ContentTypeID] [int] NOT NULL,
	[ContentID] [int] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionTypes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionTypes](
	[PermissionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PermissionTypes] PRIMARY KEY CLUSTERED 
(
	[PermissionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planets]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planets](
	[PlanetID] [int] IDENTITY(1,1) NOT NULL,
	[UniverseID] [int] NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[OwnerID] [int] NOT NULL,
 CONSTRAINT [PK_Planets] PRIMARY KEY CLUSTERED 
(
	[PlanetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Races]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Races](
	[RaceID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[PicturePath] [text] NULL,
 CONSTRAINT [PK_Races] PRIMARY KEY CLUSTERED 
(
	[RaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Universes]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universes](
	[UniverseID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[OwnerID] [int] NOT NULL,
	[IsPublic] [bit] NOT NULL,
 CONSTRAINT [PK_Universes] PRIMARY KEY CLUSTERED 
(
	[UniverseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[UserLoginID] [int] IDENTITY(1,1) NOT NULL,
	[AuthTypeID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[AuthLoginID] [text] NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[UserLoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 19.08.2019 02:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NULL,
	[Password] [nvarchar](50) NULL,
	[AuthLevel] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [date] NOT NULL,
	[UpdateDate] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContentTypes] ON 

INSERT [dbo].[ContentTypes] ([ContentTypeID], [ContentType]) VALUES (1, N'Universe')
INSERT [dbo].[ContentTypes] ([ContentTypeID], [ContentType]) VALUES (2, N'Planet')
SET IDENTITY_INSERT [dbo].[ContentTypes] OFF
SET IDENTITY_INSERT [dbo].[Universes] ON 

INSERT [dbo].[Universes] ([UniverseID], [Fullname], [OwnerID], [IsPublic]) VALUES (1, N'Samanyolu', 1, 1)
INSERT [dbo].[Universes] ([UniverseID], [Fullname], [OwnerID], [IsPublic]) VALUES (2, N'Nebule', 1, 0)
SET IDENTITY_INSERT [dbo].[Universes] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Fullname], [Email], [Password], [AuthLevel], [IsDeleted], [CreateDate], [UpdateDate]) VALUES (1, N'Tamer Berat Çelik', N'tamerberatcelik@gmail.com', N'tamerberat', 0, 0, CAST(N'2019-08-17' AS Date), CAST(N'2019-08-17' AS Date))
INSERT [dbo].[Users] ([UserID], [Fullname], [Email], [Password], [AuthLevel], [IsDeleted], [CreateDate], [UpdateDate]) VALUES (2, N'Samet Aybaba', N'samet.aybaba@gmail.com', N'samet', 0, 0, CAST(N'2019-08-17' AS Date), CAST(N'2019-08-17' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Universes] ADD  CONSTRAINT [DF_Universes_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
GO
ALTER TABLE [dbo].[CharacterClasses]  WITH CHECK ADD  CONSTRAINT [FK_CharacterClasses_Characters] FOREIGN KEY([CharacterID])
REFERENCES [dbo].[Characters] ([CharacterID])
GO
ALTER TABLE [dbo].[CharacterClasses] CHECK CONSTRAINT [FK_CharacterClasses_Characters]
GO
ALTER TABLE [dbo].[CharacterClasses]  WITH CHECK ADD  CONSTRAINT [FK_CharacterClasses_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Classes] ([ClassID])
GO
ALTER TABLE [dbo].[CharacterClasses] CHECK CONSTRAINT [FK_CharacterClasses_Classes]
GO
ALTER TABLE [dbo].[CharacterDescriptions]  WITH CHECK ADD  CONSTRAINT [FK_CharacterDescriptions_Characters] FOREIGN KEY([CharacterID])
REFERENCES [dbo].[Characters] ([CharacterID])
GO
ALTER TABLE [dbo].[CharacterDescriptions] CHECK CONSTRAINT [FK_CharacterDescriptions_Characters]
GO
ALTER TABLE [dbo].[CharacterDescriptions]  WITH CHECK ADD  CONSTRAINT [FK_CharacterDescriptions_Descriptions] FOREIGN KEY([DescriptionID])
REFERENCES [dbo].[Descriptions] ([DescriptionID])
GO
ALTER TABLE [dbo].[CharacterDescriptions] CHECK CONSTRAINT [FK_CharacterDescriptions_Descriptions]
GO
ALTER TABLE [dbo].[CharacterItems]  WITH CHECK ADD  CONSTRAINT [FK_CharacterItems_Characters] FOREIGN KEY([CharacterID])
REFERENCES [dbo].[Characters] ([CharacterID])
GO
ALTER TABLE [dbo].[CharacterItems] CHECK CONSTRAINT [FK_CharacterItems_Characters]
GO
ALTER TABLE [dbo].[CharacterItems]  WITH CHECK ADD  CONSTRAINT [FK_CharacterItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[CharacterItems] CHECK CONSTRAINT [FK_CharacterItems_Items]
GO
ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_Characters_Races] FOREIGN KEY([RaceID])
REFERENCES [dbo].[Races] ([RaceID])
GO
ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_Characters_Races]
GO
ALTER TABLE [dbo].[Characters]  WITH CHECK ADD  CONSTRAINT [FK_Characters_Users] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Characters] CHECK CONSTRAINT [FK_Characters_Users]
GO
ALTER TABLE [dbo].[Descriptions]  WITH CHECK ADD  CONSTRAINT [FK_Descriptions_DescriptionTypes] FOREIGN KEY([DescriptionTypeID])
REFERENCES [dbo].[DescriptionTypes] ([DescriptionTypeID])
GO
ALTER TABLE [dbo].[Descriptions] CHECK CONSTRAINT [FK_Descriptions_DescriptionTypes]
GO
ALTER TABLE [dbo].[Lores]  WITH CHECK ADD  CONSTRAINT [FK_Lores_LoreTypes] FOREIGN KEY([LoreTypeID])
REFERENCES [dbo].[LoreTypes] ([LoreTypeID])
GO
ALTER TABLE [dbo].[Lores] CHECK CONSTRAINT [FK_Lores_LoreTypes]
GO
ALTER TABLE [dbo].[Lores]  WITH CHECK ADD  CONSTRAINT [FK_Lores_Users] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Lores] CHECK CONSTRAINT [FK_Lores_Users]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_ContentTypes] FOREIGN KEY([ContentTypeID])
REFERENCES [dbo].[ContentTypes] ([ContentTypeID])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_ContentTypes]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_PermissionTypes] FOREIGN KEY([PermissionTypeID])
REFERENCES [dbo].[PermissionTypes] ([PermissionTypeID])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionTypes]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Users] FOREIGN KEY([GrantingUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Users]
GO
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Users1] FOREIGN KEY([GrantedUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Users1]
GO
ALTER TABLE [dbo].[Planets]  WITH CHECK ADD  CONSTRAINT [FK_Planets_Universes] FOREIGN KEY([UniverseID])
REFERENCES [dbo].[Universes] ([UniverseID])
GO
ALTER TABLE [dbo].[Planets] CHECK CONSTRAINT [FK_Planets_Universes]
GO
ALTER TABLE [dbo].[Planets]  WITH CHECK ADD  CONSTRAINT [FK_Planets_Users] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Planets] CHECK CONSTRAINT [FK_Planets_Users]
GO
ALTER TABLE [dbo].[Universes]  WITH CHECK ADD  CONSTRAINT [FK_Universes_Users] FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Universes] CHECK CONSTRAINT [FK_Universes_Users]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_AuthTypes] FOREIGN KEY([AuthTypeID])
REFERENCES [dbo].[AuthTypes] ([AuthTypeID])
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_AuthTypes]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users]
GO
