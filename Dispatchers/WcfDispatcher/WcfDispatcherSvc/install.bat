@ECHO Installing Service...
@set DOTNETFX2=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\
@set PATH=%PATH%;%DOTNETFX2%

echo Installing MyService...

%DOTNETFX2%InstallUtil /i [root]\MeucciWCFservice.exe


pause

