

GO
/****** Object:  StoredProcedure [dbo].[fwk_Logs_s]    Script Date: 12/10/2010 09:48:52 ******/
DROP PROCEDURE [dbo].[fwk_Logs_s]
GO
/****** Object:  StoredProcedure [dbo].[fwk_Logs_i]    Script Date: 12/10/2010 09:48:51 ******/
DROP PROCEDURE [dbo].[fwk_Logs_i]
GO
/****** Object:  StoredProcedure [dbo].[fwk_Logs_d]    Script Date: 12/10/2010 09:48:51 ******/
DROP PROCEDURE [dbo].[fwk_Logs_d]
GO
/****** Object:  Table [dbo].[fwk_Logs]    Script Date: 12/10/2010 09:48:54 ******/
DROP TABLE [dbo].[fwk_Logs]
GO
/****** Object:  Table [dbo].[fwk_Logs]    Script Date: 12/10/2010 09:48:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fwk_Logs](
	[Id] [uniqueidentifier] NOT NULL,
	[Message] [varchar](MAX)NOT NULL,
	[Source] [varchar](200) NOT NULL,
	[LogType] [varchar](20) NOT NULL,
	[Machine] [varchar](50) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[UserLoginName] [varchar](100) NOT NULL,
	[AppId] [varchar](100) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[fwk_Logs_i]    Script Date: 12/10/2010 09:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fwk_Logs_i]
(
	@Id  uniqueidentifier ,
	@LogDate datetime ,
	@Message varchar(MAX) ,
	@Source varchar(200) ,
	@LogType varchar(20) ,
	@Machine varchar(100) ,
	@UserLoginName nvarchar(100) ,
	@AppId nvarchar(100)

)
AS
				
-- Description : Procedimiento de creación de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

INSERT INTO fwk_Logs
(
	Id,
	LogDate,
	[Message],
	Source,
	LogType,
	Machine,
	UserLoginName,
	AppId

)
VALUES
(
	@Id,
	@LogDate,
	@Message,
	@Source,
	@LogType,
	@Machine,
	@UserLoginName,
	@AppId

)
GO
/****** Object:  StoredProcedure [dbo].[fwk_Logs_d]    Script Date: 12/10/2010 09:48:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[fwk_Logs_d]
(
	@Id    uniqueidentifier

)
AS
				
-- Description : Procedimiento de eliminación de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

DELETE FROM fwk_Logs
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[fwk_Logs_s]    Script Date: 12/10/2010 09:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	-- Autor:		moviedo
	-- Creacion:		26/02/2010 10:05:27
	-- Descripcion: 	Realiza una busqueda por parametros de la tabla Logs

	CREATE PROCEDURE [dbo].[fwk_Logs_s]
	-- Lista de Parámetros
	
	
	@Source VarChar(200) = null,
	@LogType VarChar(20) = null,
	@Machine VarChar(50) = null,
	@LogDateDesde DateTime = null,
	@LogDateHasta DateTime = null,
	@UserLoginName VarChar(100) = NULL,
	@AppId NVarChar(100) = null	

	AS

	SELECT * FROM fwk_Logs  
	WHERE 
	 (@LogType IS NULL or	 LogType = @LogType)
	 AND
	 ( (@LogDateDesde IS NULL  AND  @LogDateHasta IS NULL) OR (fwk_Logs.LogDate >= @LogDateDesde AND fwk_Logs.LogDate <= @LogDateHasta))
	 AND
	 ( (@LogDateDesde IS  NULL  AND  @LogDateHasta IS NULL) OR (fwk_Logs.LogDate >= @LogDateDesde))
	 AND
	 ( 
	 	(@UserLoginName IS NULL OR fwk_Logs.UserLoginName  LIKE  @UserLoginName)
	 OR
	 	(@Source IS NULL OR fwk_Logs.Source   LIKE  @Source) ----- Retorna si al menos en algun campo se cumple el like
	 OR
	 	(@Machine IS NULL OR fwk_Logs.[Machine]	  LIKE  @Machine)
	 	 OR
	 	(@AppId IS NULL OR fwk_Logs.AppId  LIKE  @AppId)
	 )
GO
