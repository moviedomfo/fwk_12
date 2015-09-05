@ECHO Installing Service...
@SET PATH=%PATH%;%WINDIR%\Microsoft.NET\Framework\v4.0.30319\ 
@InstallUtil "Fwk.Remoting.Listener.exe"
pause