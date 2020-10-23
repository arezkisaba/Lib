$basePath = $PsScriptRoot
$artifactFolderPath = "$basePath\Artifacts"
$wxsTemplatePath = "$basePath\ProductTemplate.wxs"
$wxsPath = "$basePath\Product.wxs"
$items = Get-ChildItem $artifactFolderPath
$xml = ""

foreach ($item in $items) {
	if (!$item.PSIsContainer) {
		$relativePath = "$artifactFolderPath\$($item.Name)"
		$guid = (New-Guid).Guid;
		$otherGuid = $guid.Replace("-", "")
		$itemNameValid = $item.Name.Replace("-", "")
		$row = "`t`t`t<Component Id=`"$($itemNameValid).$otherGuid`" Guid=`"$guid`">`r`n`t`t`t`t<File Id=`"$($itemNameValid).$otherGuid`" Name=`"$($item.Name)`" Source=`"$relativePath`"/>`r`n`t`t`t</Component>`r`n"
		$xml += "$row`n"
	}
}

$content = (Get-Content $wxsTemplatePath)
$content = $content -replace "##TOREPLACE##", $xml
Set-Content $wxsPath $content
