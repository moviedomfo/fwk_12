
GO
/****** Objeto:  StoredProcedure [dbo].[fwk_ConfigManager_PIVOT]    Fecha de la secuencia de comandos: 07/26/2012 14:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 CREATE PROCEDURE [dbo].[fwk_ConfigManager_PIVOT]
      @columns VARCHAR(2000)
 AS
 --DECLARE @columns2 VARCHAR(2000)
--SET @columns2 = 'bb_config.en-US,bb_config.es-AR,bb_config.es-AR_local'
                             
 
DECLARE @query VARCHAR(4000)
 
SET @query = '
Select [group],[key] , ' + @columns + ' FROM (
SELECT *
FROM fwk_ConfigManager) p
PIVOT
(
MAX([value])
FOR ConfigurationFileName IN (' + @columns + ')
)
AS p'
--select @query
EXECUTE(@query)
----SELECT * FROM fwk_ConfigManager
--SELECT [key] ,[bb_config.en-ES] ,[bb_config.es-AR] FROM (
--
--SELECT * FROM fwk_ConfigManager) p
--PIVOT
--( 
--MAX([value])
--	FOR ConfigurationFileName IN ([bb_config.en-ES] ,[bb_config.es-AR])
--)
--AS p
--
