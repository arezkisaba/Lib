$basePath = $PsScriptRoot
$artifactFolderPath = "$basePath\Artifacts"
$wxsTemplatePath = "$basePath\ProductTemplate.wxs"
$wxsPath = "$basePath\Product.wxs"
$items = Get-ChildItem $artifactFolderPath
$xml = ""

foreach ($item in $items) {
	if (!$item.PSIsContainer) {
		$absolutePath = "$artifactFolderPath\$($item.Name)"
		$guid = (New-Guid).Guid;
		$pattern = '[^a-zA-Z\._0-9]'
		$fileId = $absolutePath.Replace($basePath, '').Replace('\', '_') -replace $pattern,''
		$componentId = -join ((65..90) + (97..122) | Get-Random -Count 15 | % {[char]$_})
		$row = "`t`t`t<Component Id=`"$componentId`" Guid=`"$guid`">`r`n`t`t`t`t<File Id=`"$fileId`" Name=`"$($item.Name)`" Source=`"$absolutePath`"/>`r`n`t`t`t</Component>`r`n"
		$xml += "$row`n"
	}
}

$content = (Get-Content $wxsTemplatePath)
$content = $content -replace "##TOREPLACE##", $xml
Set-Content $wxsPath $content
