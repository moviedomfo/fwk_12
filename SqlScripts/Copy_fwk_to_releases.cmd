@echo off
:: deploying fwk 


@SET SOURCEDIR= %CD%"\fwk_10.4\Libraries\Framework\"
@SET RELEASEDIR=%CD%"\"fwk_releases\FWK-10.4\libs\"

Echo origen %SOURCEDIR%
Echo destino %RELEASEDIR%

ECHO:
Echo  ********************************************************************
ECHO  ******* Copiando archivos fwk_10.4******************************************
Echo  ********************************************************************
ECHO:
copy %SOURCEDIR%Fwk.* %RELEASEDIR%
del %RELEASEDIR%*.pdb 

ECHO:
Echo  ********************************************************************
ECHO  ******* Copiando archivos fwk_12******************************************
Echo  ********************************************************************

@SET SOURCEDIR= %CD%"\fwk_12\Libraries\Framework\"
@SET RELEASEDIR=%CD%"\"fwk_releases\FWK-12.0\libs\"
copy %SOURCEDIR%Fwk.* %RELEASEDIR%
del %RELEASEDIR%*.pdb 



pause
