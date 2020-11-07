﻿$basePath = $PsScriptRoot
$artifactFolderName = "Artifacts"

#PRODUCT.WXS

$wxsTemplatePath = "$basePath\Templates\Components.wxs"
$wxsPath = "$basePath\Components.wxs"
$artifactFiles = Get-ChildItem "$basePath\$artifactFolderName"
$xml = ""

foreach ($artifactFile in $artifactFiles) {
	if (!$artifactFile.PSIsContainer) {
		$absolutePath = "$artifactFolderName\$($artifactFile.Name)"
		$pattern = '[^a-zA-Z\._0-9]'
		$fileId = $absolutePath.Replace($basePath, '').Replace('\', '_') -replace $pattern,''
		$componentId = -join ((65..90) + (97..122) | Get-Random -Count 15 | % {[char]$_})
		$row = "`t`t`t<Component Id=`"$fileId`" Guid=`"*`">`r`n`t`t`t`t<File Id=`"$fileId`" Name=`"$($artifactFile.Name)`" Source=`"`$(var.ProjectDir)$absolutePath`"/>`r`n`t`t`t</Component>`r`n"
		$xml += "$row`n"
	}
}

$content = (Get-Content $wxsTemplatePath)
$content = $content -replace "##TOREPLACE##", $xml
Set-Content $wxsPath $content

# LICENCE

$licenceTemplatePath = "$basePath\Templates\LICENCE.rtf"
$licencePath = "$basePath\$artifactFolderName\LICENCE.rtf"
$exe = Get-ChildItem -Path "$basePath\$artifactFolderName" -Filter *.exe 
$productName = [io.path]::GetFileNameWithoutExtension($exe[0].FullName)

$content = (Get-Content $licenceTemplatePath)
$content = $content -replace "##ProductName##", $productName
Set-Content $licencePath $content