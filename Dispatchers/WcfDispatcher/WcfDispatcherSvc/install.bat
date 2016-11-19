@ECHO Installing Service...
@set DOTNETFX2=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\
@set PATH=%PATH%;%DOTNETFX2%

echo Installing MyService...

%DOTNETFX2%InstallUtil /i c:\projects\repos_allus\meucci\arquitectura\Dispatchers\deploy\WcfDispatcher\MeucciWCFservice.exe


pause

