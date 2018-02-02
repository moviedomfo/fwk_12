
GO
/****** Object:  Table [dbo].[fwk_ServiceAudit]    Script Date: 11/17/2016 09:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fwk_ServiceAudit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [datetime] NOT NULL,
	[ServiceName] [varchar](200) NOT NULL,
	[Send_Time] [datetime] NOT NULL,
	[Resived_Time] [datetime] NOT NULL,
	[Send_UserId] [varchar](200) NOT NULL,
	[Send_Machine] [varchar](200) NOT NULL,
	[Dispatcher_Instance_Name] [varchar](200) NOT NULL,
	[ApplicationId] [varchar](200) NULL,
	[Requets] [varbinary](max) NULL,
	[Response] [varbinary](max) NULL,
	[ServiceError] [varbinary](max) NULL,
	[Message] [varchar](max) NULL,
	[Logtype] [varchar](10) NOT NULL,
	[RequetsText] [varchar](max) NULL,
	[ResponseText] [varchar](max) NULL,
 CONSTRAINT [PK_fwk_ServiceAudit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
