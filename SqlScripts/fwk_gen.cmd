ECHO ** generador**
@set OLDDIR=%CD%
@set "vs=\Microsoft Visual Studio 10.0\VC\Bin"
@SET "SPDIR= %PROGRAMFILES%%vs%"
@if not "%PROGRAMFILES(X86)%" == "" (
 @SET "SPDIR= %PROGRAMFILES(X86)%%vs%"
)



@CHDIR %SPDIR%


%SPDIR%\gacutil -i "%OLDDIR%\JavascriptCruncher.dll"

@ECHO OFF
ECHO:
ECHO  ** installing gac sussefully**
ECHO:
pause
