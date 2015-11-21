USE [BB_Desarrollo_5_0]
GO
/****** Object:  StoredProcedure [dbo].[ParamCampings_PIVOT]    Script Date: 08/01/2012 09:28:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 ALTER PROCEDURE [dbo].[ParamCampings_PIVOT]
      @columns VARCHAR(2000)
 AS
 --DECLARE @columns2 VARCHAR(2000)
--SET @columns2 = 'bb_config.en-US,bb_config.es-AR,bb_config.es-AR_local'
                             
 
DECLARE @query VARCHAR(4000)
 
SET @query = '
Select Codigo  , ParamCampaingIdRelated,Tipo,  ' + @columns + ' FROM (
SELECT pc.ParamCapaingId as Codigo,pc.ParamCampaingIdRelated,pc.Name,PCRelated.Name AS Tipo,pc.Remarks,pc.[Language]   
FROM Campaings.ParamCampaings as pc

INNER JOIN  Campaings.ParamCampaings AS PCRelated ON PCRelated.ParamCapaingId = pc.ParamCampaingIdRelated
  ) as SourceTable
	PIVOT
(
MAX([Name])
FOR [Language] IN (' + @columns + ')
)
AS p '

EXECUTE(@query)
--Select ParamCapaingId  , ParamCampaingIdRelated,Tipo, [bb_config.en-US],[bb_config.es-AR] 

--FROM (
--SELECT pc.ParamCapaingId ,pc.Name,pc.ParamCampaingIdRelated,PCRelated.Name AS Tipo,pc.Remarks,pc.[Language]   
--FROM Campaings.ParamCampaings as pc

--INNER JOIN  Campaings.ParamCampaings AS PCRelated ON PCRelated.ParamCapaingId = pc.ParamCampaingIdRelated
--  ) as SourceTable
--	PIVOT
--	(
--	MAX([Name])
--	FOR Language IN ([bb_config.en-US],[bb_config.es-AR])
--	)
--AS p