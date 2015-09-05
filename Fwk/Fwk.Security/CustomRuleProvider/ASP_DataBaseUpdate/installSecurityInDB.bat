%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe -E -S localhost -d pubs -A all -sqlexportonly c:\membership.sql
pause



%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe -E -S localhost -d pepo -A all -sqlexportonly c:\membership.sql

Para configurar la dependencia de caché de SQL, se necesitan privilegios administrativos o se requieren la cuenta administrativa y la contraseña. El siguiente comando 
habilita la dependencia de caché de SQL para la tabla Empleados en la base de datos Northwind. 

aspnet_regsql.exe -S <Server> -U <Username> -P <Password> -ed -d Northwind -et -t Employees




Para ejecutar el asistente, ejecute Aspnet_regsql.exe sin argumentos de línea 
de comandos, tal como se muestra en el ejemplo siguiente: 

C:\Archivos de programa\Microsoft Visual Studio 9.0\VC>aspnet_regsql.exe
