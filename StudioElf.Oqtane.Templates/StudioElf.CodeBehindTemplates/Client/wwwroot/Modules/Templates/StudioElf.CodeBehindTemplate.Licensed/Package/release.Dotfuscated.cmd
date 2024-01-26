"C:\Program Files (x86)\Eziriz\.NET Reactor\dotNET_Reactor.Console.exe" -project "..\..\[Owner].[Module]\Package\[Owner].[Module].Client.Oqtane.nrproj" -licensed
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack [Owner].[Module].Dotfuscated.nuspec 
rem XCOPY "*.nupkg" "C:\inetpub\Oqtane\Packages" /Y
rem XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y
ECHO ============ Last Release Build %TIME% ============
pause