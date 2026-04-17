$appName = "EvilBaschdi.Core.Wpf.DummyApp"
$projectPath = "../samples/$appName/$appName.csproj"

dotnet publish $projectPath -c Release -o "C:\Apps\$appName\x64" -r win-x64 -f net10.0-windows --no-self-contained
dotnet publish $projectPath -c Release -o "C:\Apps\$appName\arm64" -r win-arm64 -f net10.0-windows --no-self-contained

$appsDirectory = "C:\Apps"
$appLauncherSource = "$appsDirectory\AppLauncher\x64\AppLauncher.exe"
$appLauncherTarget = "$appsDirectory\$appName\$appName.exe"

if (Test-Path $appLauncherSource) {
    Write-Output "Copying AppLauncher to $appLauncherTarget..."
    Copy-Item -Path $appLauncherSource -Destination $appLauncherTarget -Force
    Write-Output "Launcher ready: $appLauncherTarget"
}
else {
    Write-Warning "AppLauncher not found at $appLauncherSource"
}
