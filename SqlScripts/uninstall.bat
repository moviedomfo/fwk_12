@ECHO Installing Service...
@SET PATH=%PATH%;%WINDIR%\Microsoft.NET\Framework\v4.0.30319\
@InstallUtil "C:\Projects\sfdocsamples\SF\Deploy\MultipleInstanceService_Deploy\install3\MultipleInstanceService.exe -u"
pause