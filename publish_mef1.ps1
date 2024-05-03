$dirPath = ".\.artifacts\publish\Mef1App\release_win-x64"
Remove-Item -Path $dirPath -Recurse

dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true .\MEF1\Mef1App\Mef1App.csproj

# plugin
dotnet publish -c Release -r win-x64 .\MEF1\Mef1Plugin\Mef1Plugin.csproj
$pluginPath = $dirPath + "\plugins"
New-Item -Path $pluginPath -ItemType Directory
Copy-Item -Path ".\.artifacts\bin\Mef1Plugin\release_win-x64\Mef1Plugin.dll" -Destination $pluginPath -Force

explorer $dirPath
