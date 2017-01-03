
UPDATE [dbo].[fwk_ConfigManager]   
SET [ConfigurationFileName] = 'bb_config.es-AR' WHERE ConfigurationFileName = 'ConfigurationManager_Test'
 
--DELETE FROM dbo.fwk_ConfigManager WHERE ConfigurationFileName = 'en-ES'
 
 
 --Generar nuevo lenguaje apartir de otro
INSERT  INTO [dbo].[fwk_ConfigManager]  ([ConfigurationFileName]  ,[group] ,[key],[encrypted],[value]  )
SELECT 'en-US' ,[group],  [key],[encrypted],[value]
FROM dbo.fwk_ConfigManager WHERE ConfigurationFileName = 'es-AR'


---Import fwk configs de una BD a otra

USE BB_Desarrollo_5_0
insert into fwk_ConfigManager (ConfigurationFileName,[group],[key],encrypted,[value])
SELECT ConfigurationFileName,[group],[key],encrypted,[value] FROM [SANTANA\SQLEXPRESS].fwkdata.dbo.fwk_ConfigManager;

----------------------params--------------------------------

--SELECT * FROM Campaings.ParamCampaings pc

UPDATE Campaings.ParamCampaings SET [Language] = 'es-AR' 

INSERT  INTO  Campaings.ParamCampaings    ([Language]  ,ParamCapaingId ,[Name],[ParamCampaingIdRelated],[Remarks]  )
SELECT 'en-US' ,ParamCapaingId,  [Name],[ParamCampaingIdRelated],[Remarks]
FROM  Campaings.ParamCampaings   WHERE [Language] = 'es-AR'


--EXEC sp_depends [Campaings.ParamCampaings]


