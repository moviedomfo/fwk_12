USE [health_prod]
GO
/****** Object:  Table [dbo].[SecurityClients]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityClients](
	[Id] [nvarchar](128) NOT NULL,
	[Secret] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ApplicationType] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[RefreshTokenLifeTime] [int] NOT NULL,
	[AllowedOrigin] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.ApplicationClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRefreshTokens]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRefreshTokens](
	[Id] [nvarchar](128) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[ClientId] [nvarchar](50) NOT NULL,
	[IssuedUtc] [datetime] NOT NULL,
	[ExpiresUtc] [datetime] NOT NULL,
	[ProtectedTicket] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.ApplicationRefreshTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRoles]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRolesInRules]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRolesInRules](
	[RolId] [uniqueidentifier] NOT NULL,
	[RuleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SecurityRolesInRules] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC,
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRules]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRules](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SecurityRules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRulesCategory]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRulesCategory](
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ParentCategoryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_SecurityRulesCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityRulesInCategory]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityRulesInCategory](
	[CategoryId] [uniqueidentifier] NOT NULL,
	[RuleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SecurityRulesInCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[RuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecuritytUserLogins]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecuritytUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SecuritytUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityUserClaims]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_SecurityUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityUserRoles]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_SecurityUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecurityUsers]    Script Date: 6/13/2018 5:00:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecurityUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_SecurityUsers_CreatedDate]  DEFAULT (getdate()),
	[LastLogInDate] [datetime] NULL,
 CONSTRAINT [PK_SecurityUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[SecurityRolesInRules]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRolesInRules_SecurityRoles] FOREIGN KEY([RolId])
REFERENCES [dbo].[SecurityRoles] ([Id])
GO
ALTER TABLE [dbo].[SecurityRolesInRules] CHECK CONSTRAINT [FK_SecurityRolesInRules_SecurityRoles]
GO
ALTER TABLE [dbo].[SecurityRolesInRules]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRolesInRules_SecurityRules] FOREIGN KEY([RuleId])
REFERENCES [dbo].[SecurityRules] ([Id])
GO
ALTER TABLE [dbo].[SecurityRolesInRules] CHECK CONSTRAINT [FK_SecurityRolesInRules_SecurityRules]
GO
ALTER TABLE [dbo].[SecurityRulesInCategory]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRulesInCategory_SecurityRules] FOREIGN KEY([RuleId])
REFERENCES [dbo].[SecurityRules] ([Id])
GO
ALTER TABLE [dbo].[SecurityRulesInCategory] CHECK CONSTRAINT [FK_SecurityRulesInCategory_SecurityRules]
GO
ALTER TABLE [dbo].[SecurityRulesInCategory]  WITH CHECK ADD  CONSTRAINT [FK_SecurityRulesInCategory_SecurityRulesCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[SecurityRulesCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[SecurityRulesInCategory] CHECK CONSTRAINT [FK_SecurityRulesInCategory_SecurityRulesCategory]
GO
ALTER TABLE [dbo].[SecuritytUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_SecuritytUserLogins_SecurityUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[SecurityUsers] ([Id])
GO
ALTER TABLE [dbo].[SecuritytUserLogins] CHECK CONSTRAINT [FK_SecuritytUserLogins_SecurityUsers]
GO
ALTER TABLE [dbo].[SecurityUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_SecurityUserClaims_SecurityUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[SecurityUsers] ([Id])
GO
ALTER TABLE [dbo].[SecurityUserClaims] CHECK CONSTRAINT [FK_SecurityUserClaims_SecurityUsers]
GO
ALTER TABLE [dbo].[SecurityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_SecurityUserRoles_SecurityRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[SecurityRoles] ([Id])
GO
ALTER TABLE [dbo].[SecurityUserRoles] CHECK CONSTRAINT [FK_SecurityUserRoles_SecurityRoles]
GO
ALTER TABLE [dbo].[SecurityUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_SecurityUserRoles_SecurityUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[SecurityUsers] ([Id])
GO
ALTER TABLE [dbo].[SecurityUserRoles] CHECK CONSTRAINT [FK_SecurityUserRoles_SecurityUsers]
GO
