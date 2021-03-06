
GO

/****** Object:  Table [dbo].[fwk_Param]    Script Date: 12/14/2013 10:39:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[fwk_Param](
	[ParamId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[Enabled] [bit] NOT NULL,
	[Culture] [char](5) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Param] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[fwk_Param]  WITH CHECK ADD  CONSTRAINT [FK_fwk_Param_fwk_Param] FOREIGN KEY([Id])
REFERENCES [dbo].[fwk_Param] ([Id])
GO

ALTER TABLE [dbo].[fwk_Param] CHECK CONSTRAINT [FK_fwk_Param_fwk_Param]
GO

ALTER TABLE [dbo].[fwk_Param] ADD  CONSTRAINT [DF_Param_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO

ALTER TABLE [dbo].[fwk_Param] ADD  CONSTRAINT [DF_fwk_Param_Culture]  DEFAULT ('es-AR') FOR [Culture]
GO


