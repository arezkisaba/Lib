Param(
	[string]$InstallFolder,
	[string]$ProductName,
	[string]$HandleStartup
)

if ($HandleStartup -eq "True") {
	$filePath = "$InstallFolder\$ProductName.exe"
	$Sta = New-ScheduledTaskAction -Execute "$filePath" -WorkingDirectory "$InstallFolder"
	$Stt = New-ScheduledTaskTrigger -AtLogon
	Register-ScheduledTask "$ProductName" -Action $Sta -Trigger $Stt -User "$env:UserDomain\$env:UserName" -RunLevel Highest
}
