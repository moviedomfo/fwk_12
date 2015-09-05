USE [WindowsLogs]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_sp]    Fecha de la secuencia de comandos: 05/21/2010 10:18:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_sp]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EventLog_sp]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_i]    Fecha de la secuencia de comandos: 05/21/2010 10:18:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_i]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EventLog_i]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_d]    Fecha de la secuencia de comandos: 05/21/2010 10:18:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_d]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EventLog_d]
GO
/****** Objeto:  Table [dbo].[EventLog]    Fecha de la secuencia de comandos: 05/21/2010 10:18:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog]') AND type in (N'U'))
DROP TABLE [dbo].[EventLog]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_sp]    Fecha de la secuencia de comandos: 05/21/2010 10:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_sp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------------------------------------------------
	ALTER PROCEDURE [dbo].[EventLog_sp]
	@Category nvarchar(20)  = NULL,
	@MachineName nvarchar(20)  = NULL,
	@Source nvarchar(20)  = NULL,
	@TimeGenerated DateTime  = NULL,
	@UserName nvarchar(20) = NULL,
	@EventLogEntryType nvarchar(12)  = NULL,
	@Winlog nvarchar(12)  = NULL,
	@AuditMachineName nvarchar(20) = NULL,
	@EventId nvarchar(1000)  = null
	AS
	BEGIN
	SET NOCOUNT ON
	SET DATEFORMAT DMY

	----------------------------------------
	-- Definiciones
	----------------------------------------
	DECLARE @sql        nvarchar(4000)
	DECLARE @parametros nvarchar(4000)
	DECLARE @today DATETIME

SET @Today = CONVERT(DATETIME, CONVERT(VARCHAR(10), getdate(), 103), 103)
SET @TimeGenerated  = CONVERT(DATETIME, CONVERT(VARCHAR(10), @TimeGenerated , 103), 103)


	SET @sql = N' SELECT * FROM EventLog  WHERE 1 = 1 '
	
	-- Category = TYPE nvarchar
	IF (@Category IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Category  LIKE  @Category '
	END
		
	-- MachineName = TYPE nvarchar
	IF (@MachineName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND MachineName  LIKE  ''%'' + @MachineName + ''%'''
	END
	
	-- Source = TYPE nvarchar
	IF (@Source IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Source  LIKE  ''%'' + @Source + ''%'''
	END
	

	 IF (@TimeGenerated IS NOT NULL AND @TimeGenerated <> '' )
	BEGIN
	  SET @sql = @sql + ' AND (TimeGenerated >= @TimeGenerated AND TimeGenerated <= @Today)' 
	   -- SET @sql = @sql + ' AND (TimeGenerated >= @TimeGenerated )'
	END
	
	-- UserName = TYPE nvarchar
	IF (@UserName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND UserName  LIKE  ''%'' + @UserName + ''%'''
	END
	
	-- EventLogEntryType = TYPE nvarchar
	IF (@EventLogEntryType IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND EventLogEntryType  =   @EventLogEntryType '
	END
	
	-- Winlog = TYPE nvarchar
	IF (@Winlog IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Winlog  =  @Winlog '
	END
	


	
	-- AuditMachineName = TYPE NChar
	IF (@AuditMachineName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND AuditMachineName  LIKE  @AuditMachineName + ''%'''
	END
	
IF (@EventId IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND EventId   IN (' + @EventId + ')'     
	END



	SELECT @parametros = '	
@Category nvarchar(20) ,
@MachineName nvarchar(20) ,
@Source nvarchar(20) ,
@TimeGenerated DateTime ,
@UserName nvarchar(20)	,
@EventLogEntryType nvarchar(12) ,
@Winlog nvarchar(12) ,
@AuditMachineName nvarchar(20),
@EventId nvarchar(1000)  ,
@Today datetime'

	EXEC sp_executesql @sql, @parametros, 
@Category, 
@MachineName, 
@Source,
@TimeGenerated, 
@UserName, 
@EventLogEntryType, 
@Winlog, 
@AuditMachineName,
@EventId,
@Today
	END

' 
END
GO
/****** Objeto:  Table [dbo].[EventLog]    Fecha de la secuencia de comandos: 05/21/2010 10:18:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventLog](
	[Message] [nvarchar](2000) NULL,
	[EventID] [bigint] NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[MachineName] [nvarchar](20) NOT NULL,
	[Source] [nvarchar](20) NOT NULL,
	[TimeWritten] [datetime] NOT NULL,
	[TimeGenerated] [datetime] NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[EventLogEntryType] [nvarchar](12) NOT NULL,
	[Winlog] [nvarchar](12) NOT NULL,
	[AuditMachineName] [nvarchar](12) NOT NULL,
	[EventGuid] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
END
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_d]    Fecha de la secuencia de comandos: 05/21/2010 10:18:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_d]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'    
    CREATE PROCEDURE [dbo].[EventLog_d]
    
    @EventGuid UNIQUEIDENTIFIER
    AS
    
    DELETE FROM dbo.EventLog WHERE EventGuid = @EventGuid' 
END
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_i]    Fecha de la secuencia de comandos: 05/21/2010 10:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_i]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------------------------------------------------
	-- Author     :		 moviedo
	-- Date       :	   2010-04-19T19:26:41
	-- Description: 	 [Description]
	--------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[EventLog_i]
	
	(
	@EventGuid AS UNIQUEIDENTIFIER,
		@Message NVarChar(1000)= NULL,
	 @EventID bigint = NULL,
	 @Category NVarChar(20) = NULL,
	 @MachineName NVarChar(20) = NULL,
	 @Source NVarChar(20)= NULL,
	 @TimeWritten DateTime = NULL,
	 @TimeGenerated DATETIME = NULL,
	 @UserName NVarChar(20)= NULL,
	 @EventLogEntryType NVarChar(12)= NULL,
	 @Winlog NVarChar(12)= NULL,
	 @AuditMachineName NVarChar(12)= NULL
	)
	
	AS
	
	
	
	
	
	INSERT INTO EventLog
	(
		EventGuid
		,[Message]
		,EventID
		,Category
		,MachineName
		,Source
		,TimeWritten
		,TimeGenerated
		,UserName
		,EventLogEntryType
		,Winlog
		,AuditMachineName
	)
	VALUES
	(
		@EventGuid,
		@Message,
		@EventID,
		@Category,
		@MachineName,
		@Source,
		@TimeWritten,
		@TimeGenerated,
		@UserName,
		@EventLogEntryType,
		@Winlog,@AuditMachineName
	)
' 
END
GO
