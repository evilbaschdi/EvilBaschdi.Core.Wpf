dotnet publish -c Release -o "C:\Apps\$((Get-Item .).Name)\x64" -r win-x64 -f net10.0-windows --no-self-contained
dotnet publish -c Release -o "C:\Apps\$((Get-Item .).Name)\arm64" -r win-arm64 -f net10.0-windows --no-self-contained

$appName = (Get-Item .).Name
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
