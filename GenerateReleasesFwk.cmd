@ECHO Installing Service...
@set DOTNETFX2=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\
@set PATH=%PATH%;%DOTNETFX2%
%DOTNETFX2%MSBuild.exe  GenerateReleasesFwk.xml

pause