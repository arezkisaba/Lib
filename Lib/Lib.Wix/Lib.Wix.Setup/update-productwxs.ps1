$basePath = $PsScriptRoot
$artifactFolderName = "Artifacts"
$wxsTemplatePath = "$basePath\ProductTemplate.wxs"
$wxsPath = "$basePath\Product.wxs"
$items = Get-ChildItem "$basePath\$artifactFolderName"
$xml = ""

foreach ($item in $items) {
	if (!$item.PSIsContainer) {
		$absolutePath = "$artifactFolderName\$($item.Name)"
		$pattern = '[^a-zA-Z\._0-9]'
		$fileId = $absolutePath.Replace($basePath, '').Replace('\', '_') -replace $pattern,''
		$componentId = -join ((65..90) + (97..122) | Get-Random -Count 15 | % {[char]$_})
		$row = "`t`t`t<Component Id=`"$fileId`" Guid=`"*`">`r`n`t`t`t`t<File Id=`"$fileId`" Name=`"$($item.Name)`" Source=`"`$(var.ProjectDir)$absolutePath`"/>`r`n`t`t`t</Component>`r`n"
		$xml += "$row`n"
	}
}

$content = (Get-Content $wxsTemplatePath)
$content = $content -replace "##TOREPLACE##", $xml
Set-Content $wxsPath $content
