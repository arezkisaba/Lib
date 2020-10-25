Param(
	[string]$InstallFolder,
	[string]$ProductName,
	[string]$HandleStartup
)

if ($HandleStartup -eq "True") {
	$filePath = "$InstallFolder\$ProductName.exe"
	$Sta = New-ScheduledTaskAction -Execute "$filePath"
	$Stt = New-ScheduledTaskTrigger -AtLogon
	Register-ScheduledTask "$ProductName" -Action $Sta -Trigger $Stt -User "System"
}
