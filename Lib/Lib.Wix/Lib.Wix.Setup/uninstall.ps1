Param(
	[string]$ProductName,
	[string]$HandleStartup
)

if ($HandleStartup) {
	Unregister-ScheduledTask -TaskName "$ProductName" -Confirm:$false
}