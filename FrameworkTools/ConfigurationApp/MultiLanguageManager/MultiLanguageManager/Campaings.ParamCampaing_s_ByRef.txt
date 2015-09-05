
GO
/****** Objeto:  StoredProcedure [Campaings].[ParamCampaing_s_ByRef]    Fecha de la secuencia de comandos: 08/13/2012 09:05:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--------------------------------------------------------------------------------------------
	-- Autor:		moviedo
	-- Creacion:		02/01/2009 11:36:22 a.m.
	-- Descripcion: 	Realiza una busqueda por parametros de la tabla ParamCampaings por ParamCampaingIdRelated 
	--------------------------------------------------------------------------------------------

ALTER PROCEDURE [Campaings].[ParamCampaing_s_ByRef]
@ParamCampaingIdRelated int  = NULL,
@Language VARCHAR(50) = null
AS
BEGIN
SELECT ParamCapaingId, [Name], ParamCampaingIdRelated, Remarks
FROM Campaings.ParamCampaings  
WHERE ParamCampaingIdRelated =  @ParamCampaingIdRelated
AND ([Language]  = @Language  OR @Language  IS NULL)
END